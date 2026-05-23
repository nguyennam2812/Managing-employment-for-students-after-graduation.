using System;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Services;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    public partial class TrangThaiXacThucForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;

        public TrangThaiXacThucForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
        }

        private void TrangThaiXacThucForm_Load(object sender, EventArgs e)
        {
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Không có quyền truy cập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            ApplyVisualStyle();
            LoadDuLieuDaXacThuc();
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(dgvKetQua);
            UITheme.StyleGhostButton(btnThoat);
            
            // Đặt text tiếng Việt ở runtime
            lblInfo.Text = "Tình trạng dữ liệu xác thực (Chỉ xem)";
            this.Text = "Đánh dấu tình trạng dữ liệu";
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        private void LoadDuLieuDaXacThuc()
        {
            try
            {
                var data = _displayService.GetLichSuDaXacThuc();
                dgvKetQua.DataSource = data;
                
                FormatGrid();
                UpdateStats(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvKetQua.Columns.Count == 0) return;

            // Ẩn cột không cần thiết
            if (dgvKetQua.Columns["MaLichSu"] != null) dgvKetQua.Columns["MaLichSu"].Visible = false;

            // Format tiêu đề
            if (dgvKetQua.Columns["MaSV"] != null) dgvKetQua.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvKetQua.Columns["HoTen"] != null) dgvKetQua.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvKetQua.Columns["TenDoanhNghiep"] != null) dgvKetQua.Columns["TenDoanhNghiep"].HeaderText = "Doanh nghiệp";
            if (dgvKetQua.Columns["ViTriCongViec"] != null) dgvKetQua.Columns["ViTriCongViec"].HeaderText = "Vị trí";
            if (dgvKetQua.Columns["KetQua"] != null) dgvKetQua.Columns["KetQua"].HeaderText = "Kết quả";
            if (dgvKetQua.Columns["TrangThaiXuLy"] != null) dgvKetQua.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
        }

        private void UpdateStats(System.Collections.Generic.List<LichSuDaXacThucDisplay> data)
        {
            int total = data.Count;
            int dung = data.Count(x => x.KetQua.Contains("Đúng"));
            int sai = data.Count(x => x.KetQua.Contains("Sai"));

            lblStatsTotal.Text = $"Tổng: {total}";
            lblStatsDung.Text = $"Đúng: {dung}";
            lblStatsSai.Text = $"Sai: {sai}";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var mainForm = this.Parent?.Parent as MainForm;
            if (mainForm != null)
            {
                mainForm.OpenChildInternal(new DashboardForm(mainForm));
            }
            else
            {
                this.Close();
            }
        }
    }
}
