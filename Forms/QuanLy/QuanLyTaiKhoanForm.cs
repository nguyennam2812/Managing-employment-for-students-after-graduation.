using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;
using QuanLySinhVien.Services;

namespace QuanLySinhVien
{
    public partial class QuanLyTaiKhoanForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;
        private readonly AuthService _authService;
        
        // Tab 2: Quản lý đợt khảo sát
        private string _modePhieu = ""; // "", "ADD", "EDIT"
        private string _currentJsonQuestions = "";
        private GridFilterService<PhieuKhaoSat> _filterService;

        public QuanLyTaiKhoanForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
            _authService = new AuthService(_db);
        }


        private async void QuanLyTaiKhoanForm_Load(object sender, EventArgs e)
        {
            // D6: Chỉ ADMIN được phép tạo tài khoản cho Giáo viên
            if (!AuthContext.CanCreateAccount)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.\nChỉ ADMIN mới được phép quản lý tài khoản.", 
                    "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            
            ApplyVisualStyle();
            await Reload();
            
            // Tab 2: Init
            _filterService = new GridFilterService<PhieuKhaoSat>(dgvPhieu);
            LoadTrangThaiPhieu();
            LoadDanhSachPhieu();
            SetPhieuEditingMode("");
        }

        private void ApplyVisualStyle()
        {
            // Enable double buffering for smooth rendering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleTabControl(tabControl);
            
            // Tab 1: Tài khoản
            UITheme.StyleDataGridView(grid);
            UITheme.StylePrimaryButton(btnAdd);
            UITheme.StyleSecondaryButton(btnSave);
            UITheme.StyleSecondaryButton(btnDelete);
            UITheme.StyleGhostButton(btnThoat);
            
            // Tab 2: Đợt khảo sát
            UITheme.StyleDataGridView(dgvPhieu);
            UITheme.StylePrimaryButton(btnSearchPhieu);
            UITheme.StylePrimaryButton(btnThemPhieu);
            UITheme.StyleSecondaryButton(btnSuaPhieu);
            UITheme.StyleSecondaryButton(btnXoaPhieu);
            UITheme.StylePrimaryButton(btnLuuPhieu);
            UITheme.StyleGhostButton(btnHuyPhieu);
            UITheme.StyleSecondaryButton(btnDesignPhieu);
            UITheme.StyleTextBox(txtSearch);
            UITheme.StyleTextBox(txtMaPhieu);
            UITheme.StyleTextBox(txtTenDot);
            UITheme.StyleComboBox(cboTrangThai);

            // Fix Z-Order for Docking (Bottom -> Top -> Fill)
            // Elements processed in Reverse Z-Order (Back to Front) for Docking layout
            pnlButtonsPhieu.SendToBack(); // Dock Bottom
            pnlFilterPhieu.SendToBack();  // Dock Top
            dgvPhieu.SendToBack();        // Dock Top
            grpChiTiet.BringToFront();    // Dock Fill
            
            // Fix layout for Tab 2 controls (override any DPI scaling issues)
            FixTabPhieuLayout();
        }
        
        private void FixTabPhieuLayout()
        {
            // Row 1: Mã phiếu
            lblMaPhieu.Location = new System.Drawing.Point(15, 30);
            txtMaPhieu.Location = new System.Drawing.Point(140, 27);
            txtMaPhieu.Size = new System.Drawing.Size(100, 26);
            
            // Row 2: Tên đợt khảo sát
            lblTenDot.Location = new System.Drawing.Point(15, 65);
            txtTenDot.Location = new System.Drawing.Point(140, 62);
            txtTenDot.Size = new System.Drawing.Size(500, 26);
            
            // Row 3: Ngày tạo + Ngày hết hạn
            lblNgayTao.Location = new System.Drawing.Point(15, 100);
            dtpNgayTao.Location = new System.Drawing.Point(140, 97);
            dtpNgayTao.Size = new System.Drawing.Size(120, 26);
            
            lblNgayHetHan.Location = new System.Drawing.Point(290, 100);
            dtpNgayHetHan.Location = new System.Drawing.Point(400, 97);
            dtpNgayHetHan.Size = new System.Drawing.Size(120, 26);
            
            // Row 4: Trạng thái + Button
            lblTrangThai.Location = new System.Drawing.Point(15, 135);
            cboTrangThai.Location = new System.Drawing.Point(140, 132);
            cboTrangThai.Size = new System.Drawing.Size(120, 28);
            
            btnDesignPhieu.Location = new System.Drawing.Point(290, 130);
            btnDesignPhieu.Size = new System.Drawing.Size(150, 32);
            
            // Ensure labels are on top (Z-order)
            lblMaPhieu.BringToFront();
            lblTenDot.BringToFront();
            lblNgayTao.BringToFront();
            lblNgayHetHan.BringToFront();
            lblTrangThai.BringToFront();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw gradient background
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        #region Tab 1: Quản lý tài khoản

        private Task Reload()
        {
            return Task.Run(async () => 
            {
                try
                {
                    var data = await _displayService.GetTaiKhoansForDisplayAsync();
                    this.Invoke((MethodInvoker)delegate {
                         grid.DataSource = null;
                         grid.DataSource = data;
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate {
                        ShowError(ex, "Không thể tải tài khoản");
                    });
                }
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new Dialogs.TaoTaiKhoanForm())
                {
                    if (frm.ShowDialog() == DialogResult.OK && frm.NewAccount != null)
                    {
                        _authService.CreateAccount(frm.NewAccount);
                        Reload();
                        MessageBox.Show("Đã thêm tài khoản mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.Message ?? ex.Message;
                if (msg.Contains("PK_")) msg = "Tên đăng nhập đã tồn tại.";
                else if (msg.Contains("FK_")) msg = "Mã sinh viên không tồn tại.";
                MessageBox.Show("Không thể thêm tài khoản:\n" + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Để chỉnh sửa tài khoản, vui lòng chỉnh sửa trực tiếp trong database hoặc tạo form chỉnh sửa.", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow?.DataBoundItem is TaiKhoanDisplay display)
                {
                    var confirm = MessageBox.Show($"Xóa tài khoản '{display.TenDangNhap}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm != DialogResult.Yes) return;
                    _authService.DeleteAccount(display.MaTaiKhoan);
                    Reload();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex, "Không thể xóa");
            }
        }

        #endregion

        #region Tab 2: Quản lý đợt khảo sát

        private void LoadTrangThaiPhieu()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang mở");
            cboTrangThai.Items.Add("Đóng");
            cboTrangThai.Items.Add("Hết hạn");
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadDanhSachPhieu()
        {
            try
            {
                var query = _db.PhieuKhaoSats.AsQueryable();

                string keyword = txtSearch.Text?.Trim().ToLower() ?? "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(x => x.TenDotKhaoSat.ToLower().Contains(keyword) || x.MaPhieu.ToString().Contains(keyword));
                }

                query = query.OrderByDescending(x => x.NgayTao);
                var list = query.ToList();

                if (_filterService != null)
                   _filterService.SetData(list);
                else 
                   dgvPhieu.DataSource = list;

                FormatGridPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void FormatGridPhieu()
        {
            if (dgvPhieu.Columns.Count == 0) return;

            if (dgvPhieu.Columns["KetQuaKhaoSats"] != null) dgvPhieu.Columns["KetQuaKhaoSats"].Visible = false;
            if (dgvPhieu.Columns["NoiDungCauHoi"] != null) dgvPhieu.Columns["NoiDungCauHoi"].Visible = false;

            if (dgvPhieu.Columns["MaPhieu"] != null) dgvPhieu.Columns["MaPhieu"].HeaderText = "Mã phiếu";
            if (dgvPhieu.Columns["TenDotKhaoSat"] != null) dgvPhieu.Columns["TenDotKhaoSat"].HeaderText = "Tên đợt khảo sát";
            
            if (dgvPhieu.Columns["NgayTao"] != null) 
            {
                dgvPhieu.Columns["NgayTao"].HeaderText = "Ngày tạo";
                dgvPhieu.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            
            if (dgvPhieu.Columns["NgayHetHan"] != null) 
            {
                dgvPhieu.Columns["NgayHetHan"].HeaderText = "Ngày hết hạn";
                dgvPhieu.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            
            if (dgvPhieu.Columns["TrangThaiPhieu"] != null) dgvPhieu.Columns["TrangThaiPhieu"].HeaderText = "Trạng thái";

            dgvPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieu.CurrentRow == null || _modePhieu == "ADD") return;

            var row = dgvPhieu.CurrentRow;
            
            if (row.Cells["MaPhieu"].Value != null) txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
            if (row.Cells["TenDotKhaoSat"].Value != null) txtTenDot.Text = row.Cells["TenDotKhaoSat"].Value.ToString();
            
            if (row.Cells["NgayTao"].Value != null && row.Cells["NgayTao"].Value != DBNull.Value) 
                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            
            if (row.Cells["NgayHetHan"].Value != null && row.Cells["NgayHetHan"].Value != DBNull.Value) 
                dtpNgayHetHan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                
            if (row.Cells["TrangThaiPhieu"].Value != null) cboTrangThai.Text = row.Cells["TrangThaiPhieu"].Value.ToString();

            var id = int.Parse(row.Cells["MaPhieu"].Value.ToString());
            var entity = _db.PhieuKhaoSats.Find(id);
            _currentJsonQuestions = entity?.NoiDungCauHoi ?? "";

            SetPhieuEditingMode("", false);
        }

        private void SetPhieuEditingMode(string mode, bool reloadData = true)
        {
            _modePhieu = mode;
            bool isEditing = !string.IsNullOrEmpty(mode);

            btnThemPhieu.Enabled = !isEditing;
            btnSuaPhieu.Enabled = !isEditing && dgvPhieu.CurrentRow != null;
            btnXoaPhieu.Enabled = !isEditing && dgvPhieu.CurrentRow != null;
            btnLuuPhieu.Enabled = isEditing;
            btnHuyPhieu.Enabled = isEditing;
            
            dgvPhieu.Enabled = !isEditing;

            txtTenDot.Enabled = isEditing;
            dtpNgayTao.Enabled = isEditing;
            dtpNgayHetHan.Enabled = isEditing;
            cboTrangThai.Enabled = isEditing;
            btnDesignPhieu.Enabled = isEditing;

            if (reloadData && !isEditing && dgvPhieu.CurrentRow != null)
            {
                dgvPhieu_SelectionChanged(null, null);
            }
        }

        private void btnSearchPhieu_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieu();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            SetPhieuEditingMode("ADD");
            
            txtMaPhieu.Text = "";
            txtTenDot.Text = "";
            dtpNgayTao.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddDays(7);
            cboTrangThai.SelectedIndex = 0;
            _currentJsonQuestions = "";
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.CurrentRow == null) return;
            dgvPhieu_SelectionChanged(null, null);
            SetPhieuEditingMode("EDIT");
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            SetPhieuEditingMode("");
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDot.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đợt khảo sát.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_modePhieu == "ADD")
                {
                    var p = new PhieuKhaoSat
                    {
                        TenDotKhaoSat = txtTenDot.Text.Trim(),
                        NgayTao = dtpNgayTao.Value,
                        NgayHetHan = dtpNgayHetHan.Value,
                        TrangThaiPhieu = cboTrangThai.Text,
                        NoiDungCauHoi = _currentJsonQuestions
                    };
                    _db.PhieuKhaoSats.Add(p);
                }
                else if (_modePhieu == "EDIT")
                {
                    int id;
                    if (!int.TryParse(txtMaPhieu.Text, out id)) return;

                    var p = _db.PhieuKhaoSats.Find(id);
                    if (p != null)
                    {
                        p.TenDotKhaoSat = txtTenDot.Text.Trim();
                        p.NgayTao = dtpNgayTao.Value;
                        p.NgayHetHan = dtpNgayHetHan.Value;
                        p.TrangThaiPhieu = cboTrangThai.Text;
                        p.NoiDungCauHoi = _currentJsonQuestions;
                    }
                }
                
                _db.SaveChanges();
                SetPhieuEditingMode("");
                LoadDanhSachPhieu();
                MessageBox.Show("Lưu phiếu khảo sát thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.CurrentRow == null) return;

            var cellValue = dgvPhieu.CurrentRow.Cells["MaPhieu"].Value;
            if (cellValue == null) return;

            string maPhieuStr = cellValue.ToString();
            if (MessageBox.Show($"Xóa phiếu {maPhieuStr}? (Lưu ý: có thể đang có kết quả)",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                int id = int.Parse(maPhieuStr);
                var entity = _db.PhieuKhaoSats.Find(id);
                if (entity != null)
                {
                    var ketQuaList = _db.KetQuaKhaoSats.Where(x => x.MaPhieu == id).ToList();
                    if (ketQuaList.Any())
                        _db.KetQuaKhaoSats.RemoveRange(ketQuaList);

                    var phanCongList = _db.PhanCongKhaoSats.Where(x => x.MaPhieu == id).ToList();
                    if (phanCongList.Any())
                        _db.PhanCongKhaoSats.RemoveRange(phanCongList);

                    _db.PhieuKhaoSats.Remove(entity);
                    _db.SaveChanges();
                }
                LoadDanhSachPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnDesignPhieu_Click(object sender, EventArgs e)
        {
            var form = new SurveyDesignerForm(_currentJsonQuestions);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _currentJsonQuestions = form.JsonResult;
                MessageBox.Show("Đã cập nhật bộ câu hỏi (Cần bấm LƯU để lưu vào CSDL).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

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
