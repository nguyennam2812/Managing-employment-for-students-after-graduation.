using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Dialogs;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Services;

namespace QuanLySinhVien
{
    public partial class QuanLyLichSuForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;
        private readonly StudentJobService _sjService;
        private global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.LichSuCongTacFullDisplay> _filterService;
        
        public QuanLyLichSuForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
            _sjService = new StudentJobService(_db);
        }

        public QuanLyLichSuForm(string maSV) : this()
        {
            if (!string.IsNullOrEmpty(maSV))
            {
                txtSearch.Text = maSV;
            }
        }


        private void QuanLyLichSuForm_Load(object sender, EventArgs e)
        {
            grid.ReadOnly = true;
            
            // Hiển thị search
            if (txtSearch != null) txtSearch.Visible = true;
            if (btnSearch != null) btnSearch.Visible = true;

            // Init Filter Service
            _filterService = new global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.LichSuCongTacFullDisplay>(grid);

            Reload();
            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(grid);
            UITheme.StylePrimaryButton(btnSearch);
            UITheme.StyleSecondaryButton(btnEdit);
            UITheme.StyleGhostButton(btnThoat); // Ghost style usually white/transparent
            UITheme.StyleTextBox(txtSearch);

            // --- LAYOUT ---
            int topMargin = 15;

            // Left Side: Buttons (Back, Edit)
            // Fix text for Back button
            btnThoat.Text = "← Quay về Dashboard";
            btnThoat.Width = 180;
            btnThoat.Top = topMargin;
            btnThoat.Left = 20;

            btnEdit.Top = topMargin;
            btnEdit.Left = btnThoat.Right + 10;
            
            // Right Side: Search
            // Image 2 shows [TextBox] [Button] (partially visible)
            
            // Ensure proper Anchors so they stick to the right on resize
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Recalculate Position
            // Use ClientSize.Width to position relative to right edge
            int rightMargin = 70; // Increased spacing from right edge
            
            btnSearch.Top = topMargin;
            btnSearch.Left = this.ClientSize.Width - btnSearch.Width - rightMargin;
            
            txtSearch.Top = topMargin + 1; // Align vertically
            int gap = 10;
            txtSearch.Width = 250;
            txtSearch.Left = btnSearch.Left - txtSearch.Width - gap;

            // Grid
            grid.Top = btnThoat.Bottom + 15;
            grid.Left = 20;
            grid.Width = this.ClientSize.Width - 40;
            grid.Height = this.ClientSize.Height - grid.Top - 20;
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        public string ViewMode { get; set; } = "ALL"; // "ALL" or "PENDING"

        public QuanLyLichSuForm(bool onlyPending) : this()
        {
            ViewMode = onlyPending ? "PENDING" : "ALL";
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            if (ViewMode == "PENDING")
                this.Text = "Cập nhật lịch sử làm việc (Chờ xác thực)";
            else
                this.Text = "Quản lý lịch sử công tác";
        }

        private async void Reload()
        {
            try
            {
                // Note: We don't nullify grid.DataSource immediately to avoid flicker if possible, 
                // but GridFilterService needs OriginalData set.

                var q = txtSearch.Text?.Trim() ?? string.Empty;
                
                // Lấy tất cả và filter client-side
                var all = await _displayService.GetLichSuCongTacsForDisplayAsync();

                if (!string.IsNullOrEmpty(q))
                {
                    all = await _displayService.SearchLichSuCongTacsAsync(q);
                }

                // Filter logic based on ViewMode
                if (ViewMode == "PENDING")
                {
                    all = all.Where(x => x.TrangThai == "Chưa xác thực").ToList();
                }
                // If "ALL", we show everything (or let user filter via grid later)

                // Pass data to filter service instead of setting DataSource directly
                // Filter service will set DataSource
                _filterService.SetData(all);
            }
            catch (Exception ex)
            {
                ShowError(ex, "Không thể tải dữ liệu lịch sử công tác");
            }
        }

        private void FocusRow(int maLichSu)
        {
            if (maLichSu <= 0 || grid.Rows.Count == 0)
                return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                var item = row.DataBoundItem as LichSuCongTacFullDisplay;
                if (item != null && item.MaLichSu == maLichSu)
                {
                    var cell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
                    if (cell == null)
                        continue;

                    grid.CurrentCell = cell;
                    row.Selected = true;
                    break;
                }
            }
        }

        private static void ShowError(Exception ex, string prefix)
        {
            var root = ex;
            while (root.InnerException != null) root = root.InnerException;
            MessageBox.Show(prefix + ":\n\n" + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var mainForm = this.Parent?.Parent as MainForm;
            if (mainForm != null)
            {
                mainForm.OpenChildInternal(new DashboardForm(mainForm));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = grid.CurrentRow.DataBoundItem as LichSuCongTacFullDisplay;
            if (item == null) return;

            // Mở form điền khảo sát (nhưng ở chế độ sửa lịch sử)
            // MaPhieu = 0 (Khai báo), MaSV, MaLichSu
            var frm = new FrmDienKhaoSat(0, item.MaSV, item.MaLichSu);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Reload();
                FocusRow(item.MaLichSu);
            }
        }
    }
}
