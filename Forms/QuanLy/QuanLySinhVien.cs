using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Services;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    public partial class QuanLySinhVien : Form
    {
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var q = txtSearch.Text?.Trim() ?? "";
                if (string.IsNullOrEmpty(q))
                {
                   LoadSinhVien();
                   return;
                }
                
                // Use LoadSinhVien method which is now async and handles search
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly StudentJobService _sjService;
        // Removed: ReportService _reportService (Reports tab removed)
        private readonly DataDisplayService _displayService;
        private readonly AuthService _authService;
        private global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.SinhVienDisplay> _filterService;


        // Filter Controls Removed as per user request



        public QuanLySinhVien()
        {
            InitializeComponent();
            _sjService = new StudentJobService(_db);
            // Removed: _reportService initialization
            _displayService = new DataDisplayService(_db);
            _authService = new AuthService(_db);
            ApplyVisualStyle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // D1: ADMIN (Xem, Thêm, Sửa, Xóa), GIÁO VIÊN (Chi Xem & Sửa - không được Xóa)
                var canEdit = AuthContext.CanViewAndEdit; 
                var canDelete = AuthContext.CanDelete;    
                
                if (gridSinhVien != null) gridSinhVien.ReadOnly = true;
                // btnSaveSV removed
                if (btnAddSV != null) btnAddSV.Enabled = canEdit;
 
                if (btnEditSV != null) btnEditSV.Enabled = canEdit;
                if (btnViewLog != null) btnViewLog.Visible = canDelete; 

                // Hiển thị search cũ
                if (txtSearch != null) txtSearch.Visible = true;
                if (btnSearch != null) btnSearch.Visible = true;

                // Init Filter Service
                _filterService = new global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.SinhVienDisplay>(gridSinhVien);

                LoadSinhVien();
                // Removed: LoadThongBao(), SetupReportTypes(), cboReportType.SelectedIndex (tabs removed)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void LoadSinhVien()
        {
            try 
            {
                // Hiển thị trạng thái đang tải (nếu cần)
                // gridSinhVien.DataSource = null; // Removed to avoid flicker
                
                List<SinhVienDisplay> data;
                
                if (AuthContext.IsStudent && !string.IsNullOrEmpty(AuthContext.MaSinhVien))
                {
                    // Case này ít dùng, tạm thời giữ sync hoặc chuyển async sau
                    // Để nhanh, ta cứ wrap Task.Run hoặc dùng EF async nếu query phức tạp
                    // Ở đây query đơn giản, ta dùng Task.Run cho gọn nếu lười sửa StudentJobService thêm
                    data = await Task.Run(() => 
                        _db.SinhViens
                        .Include(s => s.NganhHoc)
                        .Include(s => s.KhoaHoc)
                        // .Include(s => s.Lop) // Table Lop deleted
                        .Where(s => s.MaSV == AuthContext.MaSinhVien)
                        .ToList()
                        .Select(s => new SinhVienDisplay
                        {
                            MaSV = s.MaSV,
                            HoTen = s.HoTen,
                            NgaySinh = s.NgaySinh,
                            Email = s.EmailCaNhan,
                            SoDienThoai = s.SoDienThoai,

                            TenNganh = s.NganhHoc?.TenNganh ?? "",
                            NienKhoa = s.KhoaHoc?.NienKhoa ?? "",
                            TenLop = s.MaLop ?? "" // Display MaLop instead of TenLop
                        })
                        .ToList());
                }
                else
                {
                     // Tìm kiếm
                     var q = txtSearch.Text?.Trim() ?? "";
                     if (!string.IsNullOrEmpty(q))
                     {
                         data = await _displayService.SearchSinhViensAsync(q);
                     }
                     else
                     {
                         // Mặc định load hết
                         data = await _displayService.GetAllSinhViensAsync();
                     }
                }
                
                _filterService.SetData(data);
                SetGridSinhVienHeaders();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }


        private void SetGridSinhVienHeaders()
        {
            if (gridSinhVien.Columns.Count == 0) return;

            // Đặt tên tiếng Việt cho các cột
            if (gridSinhVien.Columns["MaSV"] != null) gridSinhVien.Columns["MaSV"].HeaderText = "Mã số SV";
            if (gridSinhVien.Columns["HoTen"] != null) gridSinhVien.Columns["HoTen"].HeaderText = "Họ và tên";
            if (gridSinhVien.Columns["NgaySinh"] != null) gridSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            if (gridSinhVien.Columns["Email"] != null) gridSinhVien.Columns["Email"].HeaderText = "Email";
            if (gridSinhVien.Columns["SoDienThoai"] != null) gridSinhVien.Columns["SoDienThoai"].HeaderText = "SĐT";

            if (gridSinhVien.Columns["TinhTrang"] != null) gridSinhVien.Columns["TinhTrang"].HeaderText = "Tình trạng VL";
            if (gridSinhVien.Columns["TenNganh"] != null) gridSinhVien.Columns["TenNganh"].HeaderText = "Ngành học";
            if (gridSinhVien.Columns["NienKhoa"] != null) gridSinhVien.Columns["NienKhoa"].HeaderText = "Khóa học";
            if (gridSinhVien.Columns["TenLop"] != null) gridSinhVien.Columns["TenLop"].HeaderText = "Lớp";

            // Ẩn các cột không cần thiết nếu có (ví dụ cột Id ẩn nếu binding entity)
            // Tự động điều chỉnh độ rộng
            gridSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        // Helper để lấy MaSV từ row (có thể là SinhVienDisplay hoặc SV entity)
        private string GetMaSVFromRow(DataGridViewRow row)
        {
            if (row == null) return null;
            var item = row.DataBoundItem;
            if (item == null) return null;
            
            if (item is SinhVienDisplay svd) return svd.MaSV;
            if (item is SV sv) return sv.MaSV;
            
            var prop = item.GetType().GetProperty("MaSV");
            return prop?.GetValue(item) as string;
        }

        // SetupReportTypes() and LoadThongBao() removed (tabs removed)

        // btnSaveSV_Click removed per user request

        private void btnReloadSV_Click(object sender, EventArgs e)
        {
            LoadSinhVien();
        }

        private void btnAddSV_Click(object sender, EventArgs e)
        {
            // D1: Admin + Giáo viên được thêm
            if (!AuthContext.CanViewAndEdit)
            {
                MessageBox.Show("Bạn không có quyền thêm.", "Truy cập bị hạn chế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use new DbContext to avoid concurrency issues with async operations
            using (var dialogDb = new SurveyDbContext())
            using (var dialog = new Dialogs.SinhVienEditForm(dialogDb))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK || dialog.Result == null)
                    return;

                try
                {
                    var sv = dialog.Result;
                    _sjService.SaveSinhVien(sv);
                    
                    // Tạo tài khoản nếu có
                    if (dialog.TaiKhoanMoi != null)
                    {
                        _authService.CreateAccount(dialog.TaiKhoanMoi);
                    }

                    LoadSinhVien();
                    FocusRow(sv.MaSV);
                    
                    // Thông báo thông tin tài khoản
                    if (dialog.TaiKhoanMoi != null)
                    {
                        MessageBox.Show(
                            $"Thêm sinh viên thành công!\n\n" +
                            $"Thông tin tài khoản:\n" +
                            $"- Tên đăng nhập: {dialog.TaiKhoanMoi.TenDangNhap}\n" +
                            $"- Mật khẩu: {dialog.TaiKhoanMoi.MatKhau}\n\n" +
                            $"Vui lòng cung cấp thông tin này cho sinh viên.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    var root = ex;
                    while (root.InnerException != null) root = root.InnerException;
                    MessageBox.Show("Không thể thêm sinh viên:\n\n" + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FocusRow(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV) || gridSinhVien.Rows.Count == 0)
                return;

            foreach (DataGridViewRow row in gridSinhVien.Rows)
            {
                var rowMaSV = GetMaSVFromRow(row);
                if (rowMaSV == maSV)
                {
                    var cell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
                    if (cell != null)
                    {
                        gridSinhVien.CurrentCell = cell;
                        row.Selected = true;
                    }
                    break;
                }
            }
        }



        private void btnEditSV_Click(object sender, EventArgs e)
        {
            // D1: Admin + Giáo viên được sửa
            if (!AuthContext.CanViewAndEdit)
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa.", "Truy cập bị hạn chế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maSV = GetMaSVFromRow(gridSinhVien.CurrentRow);
            if (!string.IsNullOrEmpty(maSV))
            {
                // Use new DbContext to avoid concurrency issues with async operations
                using (var dialogDb = new SurveyDbContext())
                {
                    // Tìm SV từ database mới
                    var sv = dialogDb.SinhViens.FirstOrDefault(s => s.MaSV == maSV);

                    if (sv == null)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên này trong CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var dialog = new Dialogs.SinhVienEditForm(dialogDb, sv))
                    {
                        if (dialog.ShowDialog(this) != DialogResult.OK || dialog.Result == null)
                            return;

                        try
                        {
                            dialogDb.SaveChanges(); // Save with dialog's context
                            
                            LoadSinhVien();
                            FocusRow(sv.MaSV);
                            MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            var root = ex;
                            while (root.InnerException != null) root = root.InnerException;
                            MessageBox.Show("Không thể cập nhật sinh viên:\n\n" + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            if (!AuthContext.IsAdmin) return;
            var form = new QuanLyLichSuThayDoiForm();
            form.ShowDialog(this);
        }



        // btnGenReport_Click() removed (Reports tab removed)

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

            // Style Tab Control
            if (tabMain != null)
            {
                UITheme.StyleTabControl(tabMain);
            }

            if (tabSinhVien != null)
            {
                tabSinhVien.BackColor = UITheme.BackgroundLight;
            }

            UITheme.StyleDataGridView(gridSinhVien);

            UITheme.StylePrimaryButton(btnAddSV);
            UITheme.StyleSecondaryButton(btnEditSV);
            UITheme.StyleSecondaryButton(btnViewLog);
            UITheme.StyleSecondaryButton(btnReloadSV);
            UITheme.StylePrimaryButton(btnSearch);
            UITheme.StyleGhostButton(btnThoat);
            UITheme.StyleTextBox(txtSearch);

            // Fix Layout: Flow Left-to-Right for action buttons
            int gap = 10;
            int startX = 5;

            // 1. Add Button
            btnAddSV.Left = startX;

            // 2. Edit Button
            if (btnEditSV != null) 
                btnEditSV.Left = btnAddSV.Right + gap;

            // 3. Thoat Button (usually "Back")
            // Note: In Designer it was at 209, but let's place it after Edit for logical flow
            // OR keep it consistent with "Back" button usage (usually far right or left). 
            // Current design has it mixed. Let's place it after Edit.
            if (btnThoat != null)
                btnThoat.Left = (btnEditSV != null ? btnEditSV.Right : btnAddSV.Right) + gap;

            // 4. View Log Button
            if (btnViewLog != null)
                btnViewLog.Left = (btnThoat != null ? btnThoat.Right : btnAddSV.Right) + gap;

            // Fix Right Side items
            // Container width might not be fully set if docked, but ClientSize works
            int rightEdge = tabSinhVien.Width; 
            
            if (btnReloadSV != null)
                btnReloadSV.Left = rightEdge - btnReloadSV.Width - 5;

            if (btnSearch != null && btnReloadSV != null)
                btnSearch.Left = btnReloadSV.Left - btnSearch.Width - gap;

            if (txtSearch != null && btnSearch != null)
                txtSearch.Left = btnSearch.Left - txtSearch.Width - gap;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw gradient background
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }
    }
}
