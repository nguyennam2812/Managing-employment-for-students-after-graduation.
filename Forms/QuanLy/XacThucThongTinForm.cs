using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Services;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    public partial class XacThucThongTinForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;

        public XacThucThongTinForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
        }

        private void XacThucThongTinForm_Load(object sender, EventArgs e)
        {
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Không có quyền truy cập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            ApplyVisualStyle();
            LoadPhanHoiChuaXuLy();
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(dgvPhanHoi);
            UITheme.StylePrimaryButton(btnCapNhatKetQua);
            UITheme.StyleGhostButton(btnThoat);
            
            // Đặt text tiếng Việt ở runtime để đảm bảo encoding đúng
            lblInfo.Text = "Ghi nhận phản hồi xác thực từ doanh nghiệp";
            this.Text = "Ghi nhận phản hồi xác thực";
            
            // Cho phép edit cột Kết quả
            dgvPhanHoi.ReadOnly = false;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        private void LoadPhanHoiChuaXuLy()
        {
            try
            {
                var data = _displayService.GetPhanHoiChuaXuLy();
                dgvPhanHoi.DataSource = data;
                
                // Thêm cột Kết quả với ComboBox nếu chưa có
                if (!dgvPhanHoi.Columns.Contains("colKetQua"))
                {
                    var cboCol = new DataGridViewComboBoxColumn
                    {
                        Name = "colKetQua",
                        HeaderText = "🔘 Kết quả",
                        Width = 120,
                        DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                    };
                    cboCol.Items.AddRange("", "✅ Đúng", "❌ Sai");
                    dgvPhanHoi.Columns.Add(cboCol);
                }

                // Đảm bảo có thể edit
                dgvPhanHoi.ReadOnly = false;
                dgvPhanHoi.Columns["colKetQua"].ReadOnly = false;
                foreach (DataGridViewColumn col in dgvPhanHoi.Columns)
                {
                    if (col.Name != "colKetQua")
                        col.ReadOnly = true;
                }
                
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvPhanHoi.Columns.Count == 0) return;

            // Ẩn các cột không cần thiết
            if (dgvPhanHoi.Columns["MaPhanHoi"] != null) dgvPhanHoi.Columns["MaPhanHoi"].Visible = false;
            if (dgvPhanHoi.Columns["MaLichSu"] != null) dgvPhanHoi.Columns["MaLichSu"].Visible = false;
            if (dgvPhanHoi.Columns["NoiDungChiTiet"] != null) dgvPhanHoi.Columns["NoiDungChiTiet"].Visible = false;
            if (dgvPhanHoi.Columns["KetQua"] != null) dgvPhanHoi.Columns["KetQua"].Visible = false;

            // Format tiêu đề
            if (dgvPhanHoi.Columns["MaSV"] != null) dgvPhanHoi.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvPhanHoi.Columns["HoTen"] != null) dgvPhanHoi.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvPhanHoi.Columns["TenDoanhNghiep"] != null) dgvPhanHoi.Columns["TenDoanhNghiep"].HeaderText = "Doanh nghiệp";
            if (dgvPhanHoi.Columns["ViTriCongViec"] != null) dgvPhanHoi.Columns["ViTriCongViec"].HeaderText = "Vị trí";
            if (dgvPhanHoi.Columns["NgayPhanHoi"] != null)
            {
                dgvPhanHoi.Columns["NgayPhanHoi"].HeaderText = "Ngày gửi";
                dgvPhanHoi.Columns["NgayPhanHoi"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvPhanHoi.Columns["TrangThaiPhanHoi"] != null) dgvPhanHoi.Columns["TrangThaiPhanHoi"].HeaderText = "Phản hồi DN";
            
            // Di chuyển cột Kết quả về cuối
            if (dgvPhanHoi.Columns["colKetQua"] != null)
            {
                dgvPhanHoi.Columns["colKetQua"].DisplayIndex = dgvPhanHoi.Columns.Count - 1;
            }
        }

        private void dgvPhanHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào ComboBox cell
            if (e.RowIndex >= 0 && dgvPhanHoi.Columns[e.ColumnIndex].Name == "colKetQua")
            {
                dgvPhanHoi.BeginEdit(true);
            }
        }

        private void btnCapNhatKetQua_Click(object sender, EventArgs e)
        {
            // Lấy các row có kết quả được chọn
            var updateList = new List<(int MaPhanHoi, int MaLichSu, string KetQua)>();
            
            foreach (DataGridViewRow row in dgvPhanHoi.Rows)
            {
                var ketQua = row.Cells["colKetQua"].Value?.ToString();
                if (!string.IsNullOrEmpty(ketQua) && (ketQua.Contains("Đúng") || ketQua.Contains("Sai")))
                {
                    var maPhanHoi = Convert.ToInt32(row.Cells["MaPhanHoi"].Value);
                    var maLichSu = Convert.ToInt32(row.Cells["MaLichSu"].Value);
                    updateList.Add((maPhanHoi, maLichSu, ketQua));
                }
            }

            if (updateList.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kết quả (Đúng/Sai) cho ít nhất một mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận cập nhật kết quả xác thực cho {updateList.Count} mục?\n\nHệ thống sẽ:\n- Cập nhật trạng thái xác thực\n- Đánh dấu phản hồi đã xử lý",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                int successCount = 0;
                foreach (var item in updateList)
                {
                    // 1. Cập nhật trạng thái xác thực trong LichSuCongTac
                    var lichSu = _db.LichSuCongTacs.Find(item.MaLichSu);
                    if (lichSu != null)
                    {
                        if (item.KetQua.Contains("Đúng"))
                            lichSu.TrangThaiXacThuc = "Xác thực đúng";
                        else
                            lichSu.TrangThaiXacThuc = "Xác thực sai";
                    }

                    // 2. Đánh dấu phản hồi đã xử lý
                    var phanHoi = _db.PhanHoiXacThucTams.Find(item.MaPhanHoi);
                    if (phanHoi != null)
                    {
                        phanHoi.DaXuLy = true;
                        phanHoi.TrangThaiPhanHoi = item.KetQua.Contains("Đúng") ? "Xác thực đúng" : "Xác thực sai";
                        successCount++;
                    }
                }

                _db.SaveChanges();

                MessageBox.Show(
                    $"Đã cập nhật kết quả xác thực thành công cho {successCount} mục.\n\nCác mục đã được chuyển sang trạng thái cuối.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reload data
                LoadPhanHoiChuaXuLy();
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi khi cập nhật: " + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
