using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Services;

namespace QuanLySinhVien
{
    public partial class XuLyXacThucForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;

        public XuLyXacThucForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
        }

        private void XuLyXacThucForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền
            if (Security.AuthContext.IsStudent)
            {
                MessageBox.Show("Sinh viên không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            ApplyVisualStyle();
            LoadAllTabs();
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(gridChuaXacThuc);
            UITheme.StyleDataGridView(gridDangCho);
            UITheme.StyleDataGridView(gridDaXuLy);
            UITheme.StylePrimaryButton(btnGuiXacThuc);
            UITheme.StyleGhostButton(btnThoat);
            UITheme.StylePrimaryButton(btnTimKiem);
            UITheme.StyleTextBox(txtSearch);
            UITheme.StyleTabControl(tabControl);
            
            // Đặt text tiếng Việt ở runtime
            tabChuaXacThuc.Text = "Chưa xác thực";
            tabDangCho.Text = "Đang chờ phản hồi";
            tabDaXuLy.Text = "Đã xử lý";
            chkSelectAll.Text = "Chọn tất cả";
            btnGuiXacThuc.Text = "Gửi xác thực";
            lblSelectedCount.Text = "Đã chọn: 0";
            this.Text = "Quản lý & Gửi Yêu Cầu Xác Thực";
            
            // Cho phép edit checkbox
            gridChuaXacThuc.ReadOnly = false;
            
            // Fix layout (override DPI scaling)
            FixLayout();
        }
        
        private void FixLayout()
        {
            // Panel Top
            panelTop.Height = 55;
            btnThoat.Location = new System.Drawing.Point(12, 12);
            btnThoat.Size = new System.Drawing.Size(160, 32);
            txtSearch.Location = new System.Drawing.Point(200, 14);
            txtSearch.Size = new System.Drawing.Size(300, 26);
            btnTimKiem.Location = new System.Drawing.Point(510, 12);
            btnTimKiem.Size = new System.Drawing.Size(100, 32);
            
            // Panel Bottom (trong tab Chưa xác thực)
            panelBottom.Height = 55;
            chkSelectAll.Location = new System.Drawing.Point(10, 15);
            lblSelectedCount.Location = new System.Drawing.Point(150, 17);
            btnGuiXacThuc.Location = new System.Drawing.Point(panelBottom.Width - 190, 10);
            btnGuiXacThuc.Size = new System.Drawing.Size(180, 36);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        private void LoadAllTabs()
        {
            LoadTabChuaXacThuc();
            LoadTabDangCho();
            LoadTabDaXuLy();
        }

        private void LoadTabChuaXacThuc()
        {
            try
            {
                var data = _displayService.GetLichSuChuaXacThuc();
                
                // --- Filter Logic ---
                string keyword = txtSearch.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    data = data.Where(x => 
                        x.MaSV.ToLower().Contains(keyword) || 
                        x.HoTen.ToLower().Contains(keyword) ||
                        x.TenDoanhNghiep.ToLower().Contains(keyword)
                    ).ToList();
                }
                // --------------------

                gridChuaXacThuc.DataSource = data;
                
                // Thêm checkbox column nếu chưa có
                if (!gridChuaXacThuc.Columns.Contains("colSelect"))
                {
                    var chkCol = new DataGridViewCheckBoxColumn
                    {
                        Name = "colSelect",
                        HeaderText = "☑",
                        Width = 40,
                        FalseValue = false,
                        TrueValue = true
                    };
                    gridChuaXacThuc.Columns.Insert(0, chkCol);
                }
                
                // Đảm bảo có thể edit checkbox
                gridChuaXacThuc.ReadOnly = false;
                gridChuaXacThuc.Columns["colSelect"].ReadOnly = false;
                foreach (DataGridViewColumn col in gridChuaXacThuc.Columns)
                {
                    if (col.Name != "colSelect")
                        col.ReadOnly = true;
                }
                
                FormatGrid(gridChuaXacThuc);
                UpdateSelectedCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Chưa xác thực: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTabDangCho()
        {
            try
            {
                var data = _displayService.GetLichSuDangChoXacThuc();
                gridDangCho.DataSource = data;
                FormatGrid(gridDangCho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Đang chờ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTabDaXuLy()
        {
            try
            {
                var data = _displayService.GetLichSuDaXacThuc();
                gridDaXuLy.DataSource = data;
                FormatGrid(gridDaXuLy);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Đã xử lý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid(DataGridView grid)
        {
            if (grid.Columns.Count == 0) return;
            
            if (grid.Columns["MaLichSu"] != null) grid.Columns["MaLichSu"].Visible = false;
            if (grid.Columns["MaSV"] != null) grid.Columns["MaSV"].HeaderText = "Mã SV";
            if (grid.Columns["HoTen"] != null) grid.Columns["HoTen"].HeaderText = "Họ tên";
            if (grid.Columns["TenDoanhNghiep"] != null) grid.Columns["TenDoanhNghiep"].HeaderText = "Doanh nghiệp";
            if (grid.Columns["ViTriCongViec"] != null) grid.Columns["ViTriCongViec"].HeaderText = "Vị trí";
            if (grid.Columns["NgayBatDau"] != null) 
            {
                grid.Columns["NgayBatDau"].HeaderText = "Thời gian";
                grid.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (grid.Columns["TrangThai"] != null) grid.Columns["TrangThai"].HeaderText = "Trạng thái";
            
            // Columns for Tab 3 (Đã xử lý)
            if (grid.Columns["KetQua"] != null) grid.Columns["KetQua"].HeaderText = "Kết quả";
            if (grid.Columns["TrangThaiXuLy"] != null) grid.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
        }

        private void UpdateSelectedCount()
        {
            int count = 0;
            foreach (DataGridViewRow row in gridChuaXacThuc.Rows)
            {
                if (row.Cells["colSelect"].Value != null && (bool)row.Cells["colSelect"].Value)
                    count++;
            }
            lblSelectedCount.Text = $"Đã chọn: {count}";
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridChuaXacThuc.Rows)
            {
                row.Cells["colSelect"].Value = chkSelectAll.Checked;
            }
            UpdateSelectedCount();
        }

        private void gridChuaXacThuc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && gridChuaXacThuc.Columns[e.ColumnIndex].Name == "colSelect")
            {
                UpdateSelectedCount();
            }
        }

        private void gridChuaXacThuc_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridChuaXacThuc.IsCurrentCellDirty && gridChuaXacThuc.CurrentCell is DataGridViewCheckBoxCell)
            {
                gridChuaXacThuc.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnGuiXacThuc_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các row được chọn
            var selectedIds = new List<int>();
            foreach (DataGridViewRow row in gridChuaXacThuc.Rows)
            {
                if (row.Cells["colSelect"].Value != null && (bool)row.Cells["colSelect"].Value)
                {
                    if (row.Cells["MaLichSu"].Value != null)
                    {
                        selectedIds.Add(Convert.ToInt32(row.Cells["MaLichSu"].Value));
                    }
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một mục để gửi xác thực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận gửi yêu cầu xác thực cho {selectedIds.Count} mục đã chọn?\n\nHệ thống sẽ:\n- Tạo phản hồi xác thực tạm\n- Cập nhật trạng thái thành 'Đã gửi xác thực'",
                "Xác nhận gửi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                int successCount = 0;
                foreach (var maLichSu in selectedIds)
                {
                    // 1. Tạo bản ghi PhanHoiXacThucTam
                    var phanHoi = new PhanHoiXacThucTam
                    {
                        MaLichSu = maLichSu,
                        NgayPhanHoi = DateTime.Now,
                        TrangThaiPhanHoi = "Chờ doanh nghiệp phản hồi",
                        DaXuLy = false,
                        NoiDungChiTiet = "Yêu cầu xác thực tự động từ hệ thống"
                    };
                    _db.PhanHoiXacThucTams.Add(phanHoi);

                    // 2. Cập nhật trạng thái lịch sử công tác
                    var lichSu = _db.LichSuCongTacs.Find(maLichSu);
                    if (lichSu != null)
                    {
                        lichSu.TrangThaiXacThuc = "Đã gửi xác thực";
                        successCount++;
                    }
                }

                _db.SaveChanges();

                MessageBox.Show(
                    $"Đã gửi yêu cầu xác thực thành công cho {successCount} mục.\n\nCác mục đã được chuyển sang tab 'Đang chờ phản hồi'.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reset checkbox và reload
                chkSelectAll.Checked = false;
                LoadAllTabs();
                
                // Chuyển sang tab Đang chờ phản hồi
                tabControl.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi khi gửi xác thực: " + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reload data khi chuyển tab
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    LoadTabChuaXacThuc();
                    break;
                case 1:
                    LoadTabDangCho();
                    break;
                case 2:
                    LoadTabDaXuLy();
                    break;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Tìm kiếm chỉ áp dụng cho Tab Chưa xác thực (theo yêu cầu hiện tại)
            if (tabControl.SelectedIndex == 0)
                LoadTabChuaXacThuc();
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