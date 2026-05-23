using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;
using QuanLySinhVien.Services;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public partial class QuanLyPhieuKhaoSatForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly DataDisplayService _displayService;
        private GridFilterService<PhieuKhaoSat> _filterService;
        
        // Theo yêu cầu mới:
        // private System.Data.DataTable _dtPhieu;
        private string _mode = ""; // "", "ADD", "EDIT"

        public QuanLyPhieuKhaoSatForm()
        {
            InitializeComponent();
            _displayService = new DataDisplayService(_db);
        }

        private void QuanLyPhieuKhaoSatForm_Load(object sender, EventArgs e)
        {
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Sinh viên không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            // SetupPermissions();
            
            _filterService = new GridFilterService<PhieuKhaoSat>(dgvPhieu);

            LoadTrangThai();
            LoadDanhSachPhieu();
            SetEditingMode("");
            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(dgvPhieu);
            UITheme.StylePrimaryButton(btnSearch);
            UITheme.StylePrimaryButton(btnThem);
            UITheme.StyleSecondaryButton(btnSua);
            UITheme.StyleSecondaryButton(btnXoa);
            UITheme.StylePrimaryButton(btnLuu);
            UITheme.StyleGhostButton(btnHuy);
            UITheme.StyleGhostButton(btnDong);
            UITheme.StyleSecondaryButton(btnDesign);
            UITheme.StyleTextBox(txtSearch);
            UITheme.StyleTextBox(txtMaPhieu);
            UITheme.StyleTextBox(txtTenDot);
            UITheme.StyleComboBox(cboTrangThai);
            
            // Layout strategy:
            // 1. Buttons (Bottom) -> SendToBack (Last in Z-order, Processed First)
            // 2. Filter (Top) -> SendToBack (Next Last, Processed Second)
            // 3. Grid (Top) -> SendToBack (Next Last, Processed Third)
            // 4. Detail (Fill) -> BringToFront (First in Z-order, Processed Last)
            
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Height = 60;
            
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Height = 50;

            dgvPhieu.Dock = DockStyle.Top;
            dgvPhieu.Height = 200;

            grpChiTiet.Dock = DockStyle.Fill;
            
            // Execute Z-Order changes
            grpChiTiet.BringToFront();  // Index 0
            dgvPhieu.SendToBack();      // Index N-2
            pnlFilter.SendToBack();     // Index N-1
            pnlButtons.SendToBack();    // Index N (Max)
            
            // Resulting Process Order: Buttons(Btm) -> Filter(Top) -> Grid(Top) -> Detail(Fill)
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }
        
        private void LoadTrangThai()
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

                // Search logic
                string keyword = txtSearch.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    // EF LINQ to SQL: convert string to number might be tricky if field is int.
                    // Search by Name or ID
                    query = query.Where(x => x.TenDotKhaoSat.ToLower().Contains(keyword) || x.MaPhieu.ToString().Contains(keyword));
                }

                // Default Sort
                query = query.OrderByDescending(x => x.NgayTao);

                var list = query.ToList();

                // Set data via FilterService
                _filterService.SetData(list);
                
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            if (dgvPhieu.Columns.Count == 0) return;

            // Ẩn các cột không cần thiết (Navigation properties)
            if (dgvPhieu.Columns["KetQuaKhaoSats"] != null) dgvPhieu.Columns["KetQuaKhaoSats"].Visible = false;

            // Đặt tên cột tiếng Việt
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

        // Thêm biến lưu nội dung
        private string _currentJsonQuestions = "";

        // ... LoadDanhSachPhieu ...

        private void dgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieu.CurrentRow == null || _mode == "ADD") return;

            var row = dgvPhieu.CurrentRow;
            
            // Load Textboxes
            if (row.Cells["MaPhieu"].Value != null) txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
            if (row.Cells["TenDotKhaoSat"].Value != null) txtTenDot.Text = row.Cells["TenDotKhaoSat"].Value.ToString();
            
            if (row.Cells["NgayTao"].Value != null && row.Cells["NgayTao"].Value != DBNull.Value) 
                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            
            if (row.Cells["NgayHetHan"].Value != null && row.Cells["NgayHetHan"].Value != DBNull.Value) 
                dtpNgayHetHan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                
            if (row.Cells["TrangThaiPhieu"].Value != null) cboTrangThai.Text = row.Cells["TrangThaiPhieu"].Value.ToString();
           
            // Load Content
             var id = int.Parse(row.Cells["MaPhieu"].Value.ToString());
             var entity = _db.PhieuKhaoSats.Find(id);
             if (entity != null)
             {
                 _currentJsonQuestions = entity.NoiDungCauHoi;
             }
             else 
             {
                 _currentJsonQuestions = "";
             }

            SetEditingMode("", false);
        }
        
        // ... SetEditingMode ...

        private void btnDesign_Click(object sender, EventArgs e)
        {
            var form = new SurveyDesignerForm(_currentJsonQuestions);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _currentJsonQuestions = form.JsonResult;
                MessageBox.Show("Đã cập nhật bộ câu hỏi (Cần bấm LƯU để lưu vào CSDL).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetEditingMode(string mode, bool reloadData = true)
        {
            _mode = mode;
            bool isEditing = !string.IsNullOrEmpty(mode);

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing && dgvPhieu.CurrentRow != null;
            btnXoa.Enabled = !isEditing && dgvPhieu.CurrentRow != null;
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
            
            dgvPhieu.Enabled = !isEditing;

            txtTenDot.Enabled = isEditing;
            dtpNgayTao.Enabled = isEditing;
            dtpNgayHetHan.Enabled = isEditing;
            cboTrangThai.Enabled = isEditing;
            btnDesign.Enabled = isEditing;

            if (reloadData && !isEditing && dgvPhieu.CurrentRow != null)
            {
                // Re-bind current row data to controls to revert changes or show selection
                dgvPhieu_SelectionChanged(null, null);
            }
        }

        private bool ValidatePhieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenDot.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đợt khảo sát.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetEditingMode("ADD");
            
            // Clear inputs for new entry
            txtMaPhieu.Text = "";
            txtTenDot.Text = "";
            dtpNgayTao.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddDays(7);
            cboTrangThai.SelectedIndex = 0;
            _currentJsonQuestions = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.CurrentRow == null) return;
            
            // Refresh fields from current row before editing
            dgvPhieu_SelectionChanged(null, null);
            
            SetEditingMode("EDIT");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetEditingMode("");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidatePhieu()) return;

            try
            {
                if (_mode == "ADD")
                {
                    var p = new PhieuKhaoSat
                    {
                        TenDotKhaoSat = txtTenDot.Text.Trim(),
                        NgayTao = dtpNgayTao.Value,
                        NgayHetHan = dtpNgayHetHan.Value,
                        TrangThaiPhieu = cboTrangThai.Text,
                        NoiDungCauHoi = _currentJsonQuestions // Save JSON
                    };
                    _db.PhieuKhaoSats.Add(p);
                }
                else if (_mode == "EDIT")
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
                        p.NoiDungCauHoi = _currentJsonQuestions; // Update JSON
                    }
                }
                
                _db.SaveChanges();
                SetEditingMode("");
                LoadDanhSachPhieu();
                MessageBox.Show("Lưu phiếu khảo sát thành công.");
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.CurrentRow == null) return;

            // Lấy ID từ cell (vì textbox có thể chưa update nếu chưa click row)
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
                    // Manual cascade delete related records
                    var ketQuaList = _db.KetQuaKhaoSats.Where(x => x.MaPhieu == id).ToList();
                    if (ketQuaList.Any())
                    {
                        _db.KetQuaKhaoSats.RemoveRange(ketQuaList);
                    }

                    var phanCongList = _db.PhanCongKhaoSats.Where(x => x.MaPhieu == id).ToList();
                    if (phanCongList.Any())
                    {
                        _db.PhanCongKhaoSats.RemoveRange(phanCongList);
                    }

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

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Quay về Dashboard
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
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieu();
        }
    }
}
