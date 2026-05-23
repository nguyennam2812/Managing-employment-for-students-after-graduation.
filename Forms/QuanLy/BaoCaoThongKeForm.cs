using System;
using System.Data;
using System.Windows.Forms;
using ClosedXML.Excel;
using QuanLySinhVien.Services;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    public partial class BaoCaoThongKeForm : Form
    {
        private readonly StatisticalService _service = new StatisticalService();

        public BaoCaoThongKeForm()
        {
            InitializeComponent();
        }

        private void BaoCaoThongKeForm_Load(object sender, EventArgs e)
        {
             if (AuthContext.IsStudent)
            {
                MessageBox.Show("Không có quyền truy cập.");
                Close();
                return;
            }

            // Init Filters
            dtpVL_From.Value = DateTime.Now.AddYears(-1);
            dtpVL_To.Value = DateTime.Now;

            LoadMajors();
            LoadKhoas();

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

            // Style all DataGridViews
            UITheme.StyleDataGridView(dgvVL);
            UITheme.StyleDataGridView(dgvVL_Detail);
            UITheme.StyleDataGridView(dgvDN);
            UITheme.StyleDataGridView(dgvDN_Detail);
            UITheme.StyleDataGridView(dgvLuong);
            UITheme.StyleDataGridView(dgvLuong_Detail);

            // Style buttons
            UITheme.StylePrimaryButton(btnVL_ThongKe);
            UITheme.StyleSecondaryButton(btnVL_Luu);
            UITheme.StylePrimaryButton(btnDN_ThongKe);
            UITheme.StyleSecondaryButton(btnDN_Luu);
            UITheme.StylePrimaryButton(btnLuong_ThongKe);
            UITheme.StyleSecondaryButton(btnLuong_Luu);
            UITheme.StyleGhostButton(btnThoat);

            // Style ComboBoxes
            UITheme.StyleComboBox(cboNganh_DN);
            UITheme.StyleComboBox(cboKhoa_DN);

            // Style DateTimePickers
            UITheme.StyleDateTimePicker(dtpVL_From);
            UITheme.StyleDateTimePicker(dtpVL_To);

            // Style TabControl
            if (tabControl1 != null)
            {
                UITheme.StyleTabControl(tabControl1);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw gradient background
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        private void LoadMajors()
        {
            try
            {
                var dt = _service.GetAllMajors();
                
                // Add "All" option
                DataRow dr = dt.NewRow();
                dr["MaNganh"] = "";
                dr["TenNganh"] = "-- Tất cả chuyên ngành --";
                dt.Rows.InsertAt(dr, 0);

                cboNganh_DN.DataSource = dt;
                cboNganh_DN.DisplayMember = "TenNganh";
                cboNganh_DN.ValueMember = "MaNganh";
                cboNganh_DN.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ngành: " + ex.Message);
            }
        }

        // Tab 1: Việc làm
        private void btnVL_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = dtpVL_From.Value.Date;
                DateTime to = dtpVL_To.Value.Date;
                bool onlyPostGrad = false; // Removed UI option, defaulting to false

                var dt = _service.GetEmploymentStatsByMonth(from, to, onlyPostGrad);
                dgvVL.DataSource = dt;
                dgvVL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê việc làm: " + ex.Message);
            }
        }

        private void btnVL_Luu_Click(object sender, EventArgs e)
        {
            SaveReportToCache("BC_VIEC_LAM_SAU_TN", (DataTable)dgvVL.DataSource);
        }

        // Tab 2: Đúng ngành
        private void btnDN_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                string maNganh = cboNganh_DN.SelectedValue?.ToString() ?? "";
                string maKhoa = cboKhoa_DN.SelectedValue?.ToString() ?? "";
                
                var dt = _service.GetMajorAlignmentStats(maNganh, maKhoa);
                dgvDN.DataSource = dt;
                dgvDN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê ngành: " + ex.Message);
            }
        }

        private void btnDN_Luu_Click(object sender, EventArgs e)
        {
            SaveReportToCache("BC_DUNG_CHUYEN_NGANH", (DataTable)dgvDN.DataSource);
        }

        private void dgvDN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDN.CurrentRow == null) return;

            try
            {
                var row = dgvDN.CurrentRow;

                // Calculate ratio for display
                if (dgvDN.Columns.Contains("SoDungNganh") && dgvDN.Columns.Contains("Tong"))
                {
                    int soDung = row.Cells["SoDungNganh"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["SoDungNganh"].Value) : 0;
                    int tong = row.Cells["Tong"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Tong"].Value) : 0;
                    double tiLe = tong > 0 ? (soDung * 100.0 / tong) : 0;
                    lblTiLeDungNganh.Text = $"Tỷ lệ đúng chuyên ngành: {tiLe:F2}%";
                }

                // Load student details for "Đúng ngành"
                string tenNganh = row.Cells["TenNganh"].Value?.ToString();
                string nienKhoa = row.Cells["NienKhoa"].Value?.ToString();

                var dt = _service.GetStudentsByMajorAlignment(tenNganh, nienKhoa, true);
                dgvDN_Detail.DataSource = dt;

                // Format columns
                if (dgvDN_Detail.Columns["MaSV"] != null) dgvDN_Detail.Columns["MaSV"].HeaderText = "Mã SV";
                if (dgvDN_Detail.Columns["HoTen"] != null) dgvDN_Detail.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvDN_Detail.Columns["TenNganh"] != null) dgvDN_Detail.Columns["TenNganh"].HeaderText = "Ngành";
                if (dgvDN_Detail.Columns["NienKhoa"] != null) dgvDN_Detail.Columns["NienKhoa"].HeaderText = "Khóa";
                if (dgvDN_Detail.Columns["DoanhNghiep"] != null) dgvDN_Detail.Columns["DoanhNghiep"].HeaderText = "Doanh nghiệp";
                if (dgvDN_Detail.Columns["ViTriCongViec"] != null) dgvDN_Detail.Columns["ViTriCongViec"].HeaderText = "Vị trí";
                if (dgvDN_Detail.Columns["MucLuong"] != null) { dgvDN_Detail.Columns["MucLuong"].HeaderText = "Lương"; dgvDN_Detail.Columns["MucLuong"].DefaultCellStyle.Format = "N0"; }
                if (dgvDN_Detail.Columns["PhuHopNganh"] != null) dgvDN_Detail.Columns["PhuHopNganh"].HeaderText = "Phù hợp";
            }
            catch { /* Ignore errors during drill-down */ }
        }

        private void LoadKhoas()
        {
             try
            {
                var dt = _service.GetAllKhoas();
                
                DataRow dr = dt.NewRow();
                dr["MaKhoaHoc"] = "";
                dr["NienKhoa"] = "-- Tất cả khóa --";
                dt.Rows.InsertAt(dr, 0);

                cboKhoa_DN.DataSource = dt;
                cboKhoa_DN.DisplayMember = "NienKhoa";
                cboKhoa_DN.ValueMember = "MaKhoaHoc";
                cboKhoa_DN.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khóa: " + ex.Message);
            }
        }

        // Tab 3: Lương
        private void btnLuong_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                int? namTN = null;
                // Graduation year filter removed

                var dt = _service.GetSalaryDistributionStats(namTN);
                dgvLuong.DataSource = dt;
                dgvLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê lương: " + ex.Message);
            }
        }

        private void btnLuong_Luu_Click(object sender, EventArgs e)
        {
            SaveReportToCache("BC_MUC_LUONG", (DataTable)dgvLuong.DataSource);
        }

        // Back to Dashboard
        private void btnThoat_Click(object sender, EventArgs e)
        {
            var mainForm = this.Parent?.Parent as MainForm;
            if (mainForm != null)
            {
                mainForm.OpenChildInternal(new DashboardForm(mainForm));
            }
        }

        // Helper Method - Export to Excel
        private void SaveReportToCache(string tenThongKe, DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            string friendlyName = tenThongKe;
            switch (tenThongKe)
            {
                case "BC_VIEC_LAM_SAU_TN": friendlyName = "ThongKe_ViecLam_SauTotNghiep"; break;
                case "BC_DUNG_CHUYEN_NGANH": friendlyName = "ThongKe_DungChuyenNganh"; break;
                case "BC_MUC_LUONG": friendlyName = "ThongKe_MucLuong"; break;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"{friendlyName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                sfd.Title = "Lưu báo cáo Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("BaoCao");

                            // Header
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;
                                worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                                worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightBlue;
                            }

                            // Data
                            for (int row = 0; row < dt.Rows.Count; row++)
                            {
                                for (int col = 0; col < dt.Columns.Count; col++)
                                {
                                    var value = dt.Rows[row][col];
                                    if (value != DBNull.Value)
                                    {
                                        worksheet.Cell(row + 2, col + 1).Value = value.ToString();
                                    }
                                }
                            }

                            // Auto-fit columns
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show($"Đã xuất báo cáo Excel thành công!\n\nFile: {sfd.FileName}", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                    }
                }
            }
        }

        // Drill-down: Tab 1 - Show students for selected month/year
        private void dgvVL_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVL.CurrentRow == null) return;

            try
            {
                var row = dgvVL.CurrentRow;
                if (row.Cells["Nam"].Value == null || row.Cells["Thang"].Value == null) return;

                int year = Convert.ToInt32(row.Cells["Nam"].Value);
                int month = Convert.ToInt32(row.Cells["Thang"].Value);

                var dt = _service.GetStudentsByMonth(year, month);
                dgvVL_Detail.DataSource = dt;

                // Format columns
                if (dgvVL_Detail.Columns["MaSV"] != null) dgvVL_Detail.Columns["MaSV"].HeaderText = "Mã SV";
                if (dgvVL_Detail.Columns["HoTen"] != null) dgvVL_Detail.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvVL_Detail.Columns["TenNganh"] != null) dgvVL_Detail.Columns["TenNganh"].HeaderText = "Ngành";
                if (dgvVL_Detail.Columns["NienKhoa"] != null) dgvVL_Detail.Columns["NienKhoa"].HeaderText = "Khóa";
                if (dgvVL_Detail.Columns["DoanhNghiep"] != null) dgvVL_Detail.Columns["DoanhNghiep"].HeaderText = "Doanh nghiệp";
                if (dgvVL_Detail.Columns["ViTriCongViec"] != null) dgvVL_Detail.Columns["ViTriCongViec"].HeaderText = "Vị trí";
                if (dgvVL_Detail.Columns["MucLuong"] != null) { dgvVL_Detail.Columns["MucLuong"].HeaderText = "Lương"; dgvVL_Detail.Columns["MucLuong"].DefaultCellStyle.Format = "N0"; }
                if (dgvVL_Detail.Columns["NgayBatDau"] != null) { dgvVL_Detail.Columns["NgayBatDau"].HeaderText = "Ngày BĐ"; dgvVL_Detail.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy"; }
            }
            catch { /* Ignore errors during drill-down */ }
        }

        // Drill-down: Tab 3 - Show students for selected salary range
        private void dgvLuong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLuong.CurrentRow == null) return;

            try
            {
                var row = dgvLuong.CurrentRow;
                if (row.Cells["NhomLuong"].Value == null) return;

                string nhomLuong = row.Cells["NhomLuong"].Value.ToString();

                var dt = _service.GetStudentsBySalaryRange(nhomLuong);
                dgvLuong_Detail.DataSource = dt;

                // Format columns
                if (dgvLuong_Detail.Columns["MaSV"] != null) dgvLuong_Detail.Columns["MaSV"].HeaderText = "Mã SV";
                if (dgvLuong_Detail.Columns["HoTen"] != null) dgvLuong_Detail.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvLuong_Detail.Columns["TenNganh"] != null) dgvLuong_Detail.Columns["TenNganh"].HeaderText = "Ngành";
                if (dgvLuong_Detail.Columns["NienKhoa"] != null) dgvLuong_Detail.Columns["NienKhoa"].HeaderText = "Khóa";
                if (dgvLuong_Detail.Columns["DoanhNghiep"] != null) dgvLuong_Detail.Columns["DoanhNghiep"].HeaderText = "Doanh nghiệp";
                if (dgvLuong_Detail.Columns["ViTriCongViec"] != null) dgvLuong_Detail.Columns["ViTriCongViec"].HeaderText = "Vị trí";
                if (dgvLuong_Detail.Columns["MucLuong"] != null) { dgvLuong_Detail.Columns["MucLuong"].HeaderText = "Lương"; dgvLuong_Detail.Columns["MucLuong"].DefaultCellStyle.Format = "N0"; }
            }
            catch { /* Ignore errors during drill-down */ }
        }
    }
}
