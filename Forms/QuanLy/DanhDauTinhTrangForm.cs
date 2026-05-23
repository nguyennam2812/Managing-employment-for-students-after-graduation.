using System;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Services;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    public partial class DanhDauTinhTrangForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;

        public DanhDauTinhTrangForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
        }

        private void DanhDauTinhTrangForm_Load(object sender, EventArgs e)
        {
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Sinh viên không có quyền truy cập chức năng này.",
                    "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            // Load danh sách tình trạng
            cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.Add("Chưa xác thực");
            cboTinhTrang.Items.Add("Đang xác thực");
            cboTinhTrang.Items.Add("Đã xác thực");
            cboTinhTrang.Items.Add("Cần cập nhật");
            cboTinhTrang.Items.Add("Không hợp lệ");
            cboTinhTrang.SelectedIndex = 0;

            grid.ReadOnly = true;
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
            UITheme.StylePrimaryButton(btnDanhDau);
            UITheme.StyleGhostButton(btnThoat);
            UITheme.StyleComboBox(cboTinhTrang);
            UITheme.StyleTextBox(txtSearch);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        private async void Reload()
        {
            try
            {
                grid.DataSource = null;
                var q = txtSearch.Text?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(q))
                {
                    grid.DataSource = await _displayService.GetLichSuCongTacsForDisplayAsync();
                }
                else
                {
                    grid.DataSource = await _displayService.SearchLichSuCongTacsAsync(q);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex, "Không thể tải dữ liệu");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnDanhDau_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dòng để đánh dấu.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var tinhTrang = cboTinhTrang.SelectedItem?.ToString() ?? "Chưa xác thực";
                int count = 0;

                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    if (row.DataBoundItem is LichSuCongTacFullDisplay display)
                    {
                        var lichSu = _db.LichSuCongTacs.Find(display.MaLichSu);
                        if (lichSu != null)
                        {
                            lichSu.TrangThaiXacThuc = tinhTrang;
                            count++;
                        }
                    }
                }

                if (count > 0)
                {
                    _db.SaveChanges();
                    MessageBox.Show($"Đã đánh dấu {count} mục với tình trạng: {tinhTrang}", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reload();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex, "Không thể cập nhật tình trạng");
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
    }
}
