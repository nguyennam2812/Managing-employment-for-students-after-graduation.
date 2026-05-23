using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVien.Services;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    public partial class GuiThongBaoForm : Form
    {
        private readonly NotificationService _service = new NotificationService();

        public GuiThongBaoForm()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            var mainForm = this.Parent?.Parent as MainForm;
            if (mainForm != null)
            {
                mainForm.OpenChildInternal(new DashboardForm(mainForm));
            }
        }

        private void GuiThongBaoForm_Load(object sender, EventArgs e)
        {
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Không có quyền truy cập.");
                Close();
                return;
            }

            LoadLoaiDot();
            LoadKhoaHoc();
            LoadNganh();
            LoadNamTotNghiep();

            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            // Enable double buffering for smooth rendering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(dgvSinhVienThongBao);
            
            // Override ReadOnly để cho phép checkbox hoạt động
            dgvSinhVienThongBao.ReadOnly = false;
            colChon.ReadOnly = false;
            // Các cột khác vẫn ReadOnly
            colMaSV.ReadOnly = true;
            colHoTen.ReadOnly = true;
            colEmail.ReadOnly = true;
            colNienKhoa.ReadOnly = true;
            colNganh.ReadOnly = true;
            
            // Đăng ký event để commit edit ngay khi click checkbox
            dgvSinhVienThongBao.CurrentCellDirtyStateChanged += DgvSinhVienThongBao_CurrentCellDirtyStateChanged;
            
            UITheme.StylePrimaryButton(btnTimSV);
            UITheme.StylePrimaryButton(btnGuiEmail);
            UITheme.StyleGhostButton(btnDong);
            UITheme.StyleComboBox(cboLoaiDot);
            UITheme.StyleComboBox(cboKhoa);
            UITheme.StyleComboBox(cboNganh);
            UITheme.StyleComboBox(cboNamTotNghiep);
            UITheme.StyleTextBox(txtTieuDe);
        }

        private void DgvSinhVienThongBao_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit edit ngay khi checkbox được click để cập nhật giá trị
            if (dgvSinhVienThongBao.IsCurrentCellDirty && dgvSinhVienThongBao.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvSinhVienThongBao.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw gradient background
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        private void LoadLoaiDot()
        {
            cboLoaiDot.Items.Clear();
            cboLoaiDot.Items.Add("Tháng");
            cboLoaiDot.Items.Add("Quý");
            cboLoaiDot.Items.Add("Năm");
            cboLoaiDot.SelectedIndex = 0;
        }

        private void LoadKhoaHoc()
        {
            try
            {
                var dt = _service.GetAllKhoas();
                DataRow dr = dt.NewRow();
                dr["MaKhoaHoc"] = DBNull.Value; 
                dr["NienKhoa"] = "-- Tất cả khóa --";
                dt.Rows.InsertAt(dr, 0);

                cboKhoa.DataSource = dt;
                cboKhoa.DisplayMember = "NienKhoa";
                cboKhoa.ValueMember = "MaKhoaHoc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khóa: " + ex.Message);
            }
        }

        private void LoadNganh()
        {
            try
            {
                var dt = _service.GetAllMajors();
                DataRow dr = dt.NewRow();
                dr["MaNganh"] = DBNull.Value;
                dr["TenNganh"] = "-- Tất cả ngành --";
                dt.Rows.InsertAt(dr, 0);

                cboNganh.DataSource = dt;
                cboNganh.DisplayMember = "TenNganh";
                cboNganh.ValueMember = "MaNganh";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ngành: " + ex.Message);
            }
        }

        private void LoadNamTotNghiep()
        {
            try
            {
                var dt = _service.GetGraduationYears();
                
                // Thêm cột hiển thị nếu chưa có
                if (!dt.Columns.Contains("HienThi"))
                {
                    dt.Columns.Add("HienThi", typeof(string));
                }
                
                // Cập nhật giá trị hiển thị cho các dòng hiện có
                foreach (DataRow row in dt.Rows)
                {
                    if (row["NamTotNghiep"] != DBNull.Value)
                    {
                        row["HienThi"] = row["NamTotNghiep"].ToString();
                    }
                }
                
                // Thêm dòng "Tất cả năm TN" ở đầu
                DataRow dr = dt.NewRow();
                dr["NamTotNghiep"] = DBNull.Value;
                dr["HienThi"] = "-- Tất cả năm TN --";
                dt.Rows.InsertAt(dr, 0);

                cboNamTotNghiep.DataSource = dt;
                cboNamTotNghiep.DisplayMember = "HienThi";
                cboNamTotNghiep.ValueMember = "NamTotNghiep";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách năm TN: " + ex.Message);
            }
        }

        private void btnTimSV_Click(object sender, EventArgs e)
        {
            try
            {
                string maKhoa = cboKhoa.SelectedValue?.ToString() ?? "";
                string maNganh = cboNganh.SelectedValue?.ToString() ?? "";
                
                int? namTN = null;
                if (cboNamTotNghiep.SelectedValue != null && int.TryParse(cboNamTotNghiep.SelectedValue.ToString(), out int n))
                {
                    if (n > 0) namTN = n;
                }

                // Get days threshold
                int days = GetSoNgayTheoLoaiDot();

                var dt = _service.GetStudentsForNotification(maKhoa, maNganh, namTN, days);
                dgvSinhVienThongBao.DataSource = dt;
                dgvSinhVienThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                 MessageBox.Show($"Đã tìm thấy {dt.Rows.Count} sinh viên chưa cập nhật thông tin trong {days} ngày qua.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private int GetSoNgayTheoLoaiDot()
        {
            if (cboLoaiDot.SelectedItem == null) return 30; // default

            switch (cboLoaiDot.SelectedItem.ToString())
            {
                case "Tháng": return 30;
                case "Quý": return 90;
                case "Năm": return 365;
                default: return 30;
            }
        }

        private void btnGuiEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề email.");
                txtTieuDe.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung email.");
                txtNoiDung.Focus();
                return;
            }

            if (dgvSinhVienThongBao.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sinh viên nào trong danh sách để gửi.");
                return;
            }

            // Lấy danh sách email được tick
            var danhSachEmail = new List<string>();
            var danhSachMaSV = new List<string>();

            foreach (DataGridViewRow row in dgvSinhVienThongBao.Rows)
            {
                if (row.IsNewRow) continue;

                bool chon = false;
                if (row.Cells["colChon"].Value != null)
                    chon = Convert.ToBoolean(row.Cells["colChon"].Value);

                if (!chon) continue;

                string email = row.Cells["colEmail"].Value?.ToString();
                string maSV = row.Cells["colMaSV"].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(email))
                {
                    danhSachEmail.Add(email);
                    danhSachMaSV.Add(maSV);
                }
            }

            if (danhSachEmail.Count == 0)
            {
                MessageBox.Show("Chưa chọn sinh viên nào để gửi.");
                return;
            }

            // Gửi email (thật hoặc mô phỏng)
            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            // Thực hiện gửi
            int thanhCong = 0;
            int thatBai = 0;
            string loiChiTiet = "";

            foreach (var email in danhSachEmail)
            {
                try
                {
                    _service.SendEmail(email, tieuDe, noiDung);
                    thanhCong++;
                }
                catch (Exception ex)
                {
                    thatBai++;
                    loiChiTiet += $"- {email}: {ex.Message}\n";
                }
            }

            if (thatBai > 0)
            {
                MessageBox.Show($"Có {thatBai} email gửi thất bại:\n{loiChiTiet}", "Lỗi gửi mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Lưu log vào DuLieuPhanTichTam
            try 
            {
                string loaiDotStr = cboLoaiDot.SelectedItem?.ToString() ?? "Khác";
                _service.SaveThongBaoLog(loaiDotStr, danhSachMaSV.Count, danhSachMaSV);
            }
            catch(Exception ex)
            {
                 MessageBox.Show("Lỗi lưu log: " + ex.Message);
            }

            MessageBox.Show($"Đã gửi xong thông báo tới {danhSachEmail.Count} sinh viên.\n(Nếu cấu hình sai, sẽ báo lỗi ở từng email)");
        }
    }
}
