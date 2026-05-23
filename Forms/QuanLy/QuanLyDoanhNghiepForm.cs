using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Dialogs;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;
using QuanLySinhVien.Services;

namespace QuanLySinhVien
{
    public partial class QuanLyDoanhNghiepForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;
        private readonly StudentJobService _sjService;
        private global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.DoanhNghiepDisplay> _filterService;

        public QuanLyDoanhNghiepForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
            _sjService = new StudentJobService(_db);
            ApplyVisualStyle();
        }

        private void QuanLyDoanhNghiepForm_Load(object sender, EventArgs e)
        {
            // D2: ADMIN (Toàn quyền), GIÁO VIÊN (Chỉ Xem - không xóa nơi làm việc)
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Sinh viên không có quyền truy cập chức năng này.", 
                    "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            
            // Hiển thị search
            if (txtSearch != null) txtSearch.Visible = true;
            if (btnSearch != null) btnSearch.Visible = true;

            // Init Filter
            _filterService = new global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.DoanhNghiepDisplay>(grid);

            Reload();
        }

        private async void Reload()
        {
            try
            {
                // grid.DataSource = null; // Removed to avoid flicker
                var q = txtSearch.Text?.Trim() ?? string.Empty;
                
                System.Collections.Generic.List<global::QuanLySinhVien.Services.DoanhNghiepDisplay> data;

                if (string.IsNullOrEmpty(q))
                {
                    data = await _displayService.GetDoanhNghiepsForDisplayAsync();
                }
                else
                {
                    data = await _displayService.SearchDoanhNghiepsAsync(q);
                }

                _filterService.SetData(data);
            }
            catch (Exception ex)
            {
                ShowError(ex, "Không thể tải danh sách doanh nghiệp");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reload();
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

        private void ApplyVisualStyle()
        {
            // Enable double buffering for smooth rendering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(grid);
            UITheme.StyleTextBox(txtSearch);
            UITheme.StylePrimaryButton(btnSearch);
            UITheme.StyleGhostButton(btnThoat);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw gradient background
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }
    }
}
