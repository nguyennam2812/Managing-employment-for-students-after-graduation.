using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    public partial class TiepNhanTuKhaiBaoForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();

        public TiepNhanTuKhaiBaoForm()
        {
            InitializeComponent();
        }

        // private global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.KetQuaKhaoSatDisplay> _filterService;

        private void TiepNhanTuKhaiBaoForm_Load(object sender, EventArgs e)
        {
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Không có quyền truy cập.");
                Close();
                return;
            }

            // Init Filter Service - REMOVED due to NullReferenceException and Direct Binding requirement
            // _filterService = new global::QuanLySinhVien.Services.GridFilterService<global::QuanLySinhVien.Services.KetQuaKhaoSatDisplay>(dgvKetQua);

            LoadCombos();
            LoadKetQua(); // Load default results
            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(dgvKetQua);
            UITheme.StylePrimaryButton(btnLoc);
            UITheme.StyleSecondaryButton(btnSearch);
            UITheme.StylePrimaryButton(btnXemChiTiet);
            UITheme.StyleGhostButton(btnThoat);
            UITheme.StyleComboBox(cboPhieu);
            UITheme.StyleComboBox(cboKhoaHoc);
            UITheme.StyleComboBox(cboNganh);
            UITheme.StyleTextBox(txtSearch);
            // Note: txtNoiDung is a large textbox, basic styling applied by default or can be explicit
            
            // --- FIX LAYOUT ---
            // Ẩn pnlFilter và splitContainer1 vì ta tự đặt layout
            pnlFilter.Visible = false;
            splitContainer1.Visible = false;
            
            // Ẩn các label thừa
            lblPhieu.Visible = false;
            lblKhoa.Visible = false;
            lblNganh.Visible = false;
            
            // Đảm bảo các control nằm trực tiếp trên form
            if (!this.Controls.Contains(cboPhieu)) this.Controls.Add(cboPhieu);
            if (!this.Controls.Contains(cboKhoaHoc)) this.Controls.Add(cboKhoaHoc);
            if (!this.Controls.Contains(cboNganh)) this.Controls.Add(cboNganh);
            if (!this.Controls.Contains(btnLoc)) this.Controls.Add(btnLoc);
            if (!this.Controls.Contains(txtSearch)) this.Controls.Add(txtSearch);
            if (!this.Controls.Contains(btnSearch)) this.Controls.Add(btnSearch);
            if (!this.Controls.Contains(dgvKetQua)) this.Controls.Add(dgvKetQua);
            if (!this.Controls.Contains(txtNoiDung)) this.Controls.Add(txtNoiDung);
            if (!this.Controls.Contains(btnXemChiTiet)) this.Controls.Add(btnXemChiTiet);
            if (!this.Controls.Contains(btnThoat)) this.Controls.Add(btnThoat);
            
            int topMargin = 20;
            int rowHeight = 35;
            
            // Row 1: Filter Dropdowns - Đợt khảo sát, Khóa, Ngành
            // cboPhieu - Đợt khảo sát
            cboPhieu.Top = topMargin;
            cboPhieu.Left = 20;
            cboPhieu.Width = 280;

            // cboKhoaHoc - Khóa học (Năm TN)
            cboKhoaHoc.Top = topMargin;
            cboKhoaHoc.Left = cboPhieu.Right + 15;
            cboKhoaHoc.Width = 200; // Tăng width để hiển thị đủ text

            // cboNganh - Ngành
            cboNganh.Top = topMargin;
            cboNganh.Left = cboKhoaHoc.Right + 15;
            cboNganh.Width = 220;

            // Row 2: Action Buttons (Filter, Search) - ngang hàng
            int row2Top = topMargin + rowHeight + 10;

            // btnLoc - Nút lọc
            btnLoc.Top = row2Top;
            btnLoc.Left = 20;
            btnLoc.Width = 120;
            btnLoc.Height = 32;
            
            // txtSearch - Ô tìm kiếm
            txtSearch.Top = row2Top + 2; // Căn chỉnh với button
            txtSearch.Left = btnLoc.Right + 20;
            txtSearch.Width = 250;
            txtSearch.Height = 28;
            
            // btnSearch - Nút tìm kiếm, nằm cạnh txtSearch
            btnSearch.Top = row2Top;
            btnSearch.Left = txtSearch.Right + 10;
            btnSearch.Width = 120;
            btnSearch.Height = 32;

            // Grid starts after Row 2
            int gridTop = row2Top + btnLoc.Height + 20;
            int bottomHeight = 150; // Space for Detail panel
            
            dgvKetQua.Top = gridTop;
            dgvKetQua.Left = 20;
            dgvKetQua.Width = this.ClientSize.Width - 40;
            dgvKetQua.Height = this.ClientSize.Height - gridTop - bottomHeight - 20;
            dgvKetQua.Dock = DockStyle.None;

            // Bottom Panel: Details
            // txtNoiDung
            txtNoiDung.Top = dgvKetQua.Bottom + 10;
            txtNoiDung.Left = 20;
            txtNoiDung.Width = this.ClientSize.Width - 200; // Leave space for buttons on right
            txtNoiDung.Height = bottomHeight;
            txtNoiDung.ReadOnly = true;
            txtNoiDung.BackColor = System.Drawing.Color.White;

            // Buttons: XemChiTiet, Thoat
            int btnTop = txtNoiDung.Top + 20;
            
            btnXemChiTiet.Top = btnTop;
            btnXemChiTiet.Left = txtNoiDung.Right + 10;
            btnXemChiTiet.Width = 150;

            btnThoat.Left = txtNoiDung.Right + 10;
            btnThoat.Top = btnXemChiTiet.Bottom + 10;
            btnThoat.Width = 150;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }
        
        public class CboItem
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public override string ToString() { return Text; }
        }

        private void LoadCombos()
        {
            try
            {
                // 1. Load Phiếu (Tất cả)
                var phieus = new System.Collections.Generic.List<CboItem>();
                phieus.Add(new CboItem { Value = "0", Text = "-- Tất cả đợt --" });
                
                var dbPhieus = _db.PhieuKhaoSats
                                .OrderByDescending(p => p.NgayTao)
                                .Select(p => new { p.MaPhieu, p.TenDotKhaoSat })
                                .ToList();
                foreach(var p in dbPhieus)
                {
                    phieus.Add(new CboItem { Value = p.MaPhieu.ToString(), Text = p.TenDotKhaoSat });
                }

                cboPhieu.DataSource = phieus;
                cboPhieu.DisplayMember = "Text";
                cboPhieu.ValueMember = "Value";

                // 2. Load Khoa
                var khoas = new System.Collections.Generic.List<CboItem>();
                khoas.Add(new CboItem { Value = "", Text = "-- Tất cả khóa --" });
                
                var dbKhoas = _db.KhoaHocs
                               .OrderByDescending(k => k.NienKhoa)
                               .Select(k => new { MaKhoaHoc = k.MaKhoaHoc, NienKhoa = k.NienKhoa })
                               .ToList();
                foreach(var k in dbKhoas)
                {
                    khoas.Add(new CboItem { Value = k.MaKhoaHoc, Text = k.NienKhoa });
                }

                cboKhoaHoc.DataSource = khoas;
                cboKhoaHoc.DisplayMember = "Text";
                cboKhoaHoc.ValueMember = "Value";

                // 3. Load Ngành
                var nganhs = new System.Collections.Generic.List<CboItem>();
                nganhs.Add(new CboItem { Value = "", Text = "-- Tất cả ngành --" });
                
                var dbNganhs = _db.NganhHocs
                                .Select(n => new { MaNganh = n.MaNganh, TenNganh = n.TenNganh })
                                .ToList();
                foreach(var n in dbNganhs)
                {
                    nganhs.Add(new CboItem { Value = n.MaNganh, Text = n.TenNganh });
                }

                cboNganh.DataSource = nganhs;
                cboNganh.DisplayMember = "Text";
                cboNganh.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadKetQua();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadKetQua();
        }

        private void LoadKetQua()
        {
            try
            {
                var query = _db.KetQuaKhaoSats
                               .Include(k => k.SinhVien)
                               .Include(k => k.PhieuKhaoSat)
                               .Include(k => k.SinhVien.NganhHoc)
                               .Include(k => k.SinhVien.KhoaHoc)
                               .AsQueryable();

                // Filter Phieu
                if (cboPhieu.SelectedValue != null)
                {
                    int pid = 0;
                    if (int.TryParse(cboPhieu.SelectedValue.ToString(), out pid) && pid > 0)
                    {
                        query = query.Where(k => k.MaPhieu == pid);
                    }
                }

                // Filter Khoa (via SinhVien)
                if (cboKhoaHoc.SelectedValue != null)
                {
                    string khoaId = cboKhoaHoc.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(khoaId))
                    {
                        query = query.Where(k => k.SinhVien.MaKhoaHoc == khoaId);
                    }
                }

                // Filter Nganh (via SinhVien)
                if (cboNganh.SelectedValue != null)
                {
                    string n = cboNganh.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(n))
                    {
                        query = query.Where(k => k.SinhVien.MaNganh == n);
                    }
                }

                // Text Search (Client-side or Server-side? Prefer Server-side for basic text)
                string searchText = txtSearch.Text?.Trim().ToLower();
                
                // Execute query first (Snapshots data)
                var rawList = query.ToList();

                // Get List of MaSV to batch fetch history status
                var maSVs = rawList.Select(x => x.MaSV).Distinct().ToList();
                
                // Fetch latest Work History Status for these students
                var histories = _db.LichSuCongTacs
                                   .Where(h => maSVs.Contains(h.MaSV))
                                   .ToList() 
                                   .GroupBy(h => h.MaSV)
                                   .ToDictionary(g => g.Key, g => g.OrderByDescending(x => x.NgayBatDau).FirstOrDefault());

                var list = rawList.Select(k => 
                {
                     string status = "Chưa có DL";
                     if (histories.ContainsKey(k.MaSV))
                     {
                         var h = histories[k.MaSV];
                         status = h.TrangThaiXacThuc ?? "Chưa xác thực"; 
                     }
                     
                     // Helper anonymous type for Grid Binding
                     return new 
                     {
                        MaKetQua = k.MaKetQua,
                        MaSV = k.MaSV,
                        HoTen = k.SinhVien != null ? k.SinhVien.HoTen : "",
                        TenDotKhaoSat = k.PhieuKhaoSat != null ? k.PhieuKhaoSat.TenDotKhaoSat : "",
                        TenNganh = k.SinhVien != null && k.SinhVien.NganhHoc != null ? k.SinhVien.NganhHoc.TenNganh : "",
                        NienKhoa = k.SinhVien != null && k.SinhVien.KhoaHoc != null ? k.SinhVien.KhoaHoc.NienKhoa : "",
                        NgayTraLoi = k.NgayTraLoi,
                        TrangThaiXacThuc = status,
                        NoiDung = k.NoiDungChiTiet
                     };
                }).ToList();

                // Client-side text search
                if (!string.IsNullOrEmpty(searchText))
                {
                    list = list.Where(x => 
                        x.MaSV.ToLower().Contains(searchText) || 
                        x.HoTen.ToLower().Contains(searchText)
                    ).ToList();
                }

                // Bind Directly to Grid
                dgvKetQua.DataSource = list;
                
                FormatGrid();
                
                txtNoiDung.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải kết quả: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            if (dgvKetQua.Columns.Count == 0) return;

            if (dgvKetQua.Columns["MaKetQua"] != null) dgvKetQua.Columns["MaKetQua"].HeaderText = "Mã KQ";
            if (dgvKetQua.Columns["MaSV"] != null) dgvKetQua.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvKetQua.Columns["HoTen"] != null) dgvKetQua.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvKetQua.Columns["TenNganh"] != null) dgvKetQua.Columns["TenNganh"].HeaderText = "Ngành";
            if (dgvKetQua.Columns["NienKhoa"] != null) dgvKetQua.Columns["NienKhoa"].HeaderText = "Khóa";
            if (dgvKetQua.Columns["NgayTraLoi"] != null) dgvKetQua.Columns["NgayTraLoi"].HeaderText = "Ngày trả lời";
            if (dgvKetQua.Columns["TrangThaiXacThuc"] != null) dgvKetQua.Columns["TrangThaiXacThuc"].HeaderText = "Trạng thái việc làm";

            if (dgvKetQua.Columns["MaPhieu"] != null) dgvKetQua.Columns["MaPhieu"].Visible = false;
            if (dgvKetQua.Columns["NoiDung"] != null) dgvKetQua.Columns["NoiDung"].Visible = false;

            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvKetQua_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKetQua.CurrentRow == null) return;

            string noiDung = dgvKetQua.CurrentRow.Cells["NoiDung"].Value?.ToString();
            txtNoiDung.Text = noiDung ?? "";
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvKetQua.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng kết quả.");
                return;
            }
            
            // Get data from current row
            string maSV = dgvKetQua.CurrentRow.Cells["MaSV"].Value?.ToString() ?? "";
            string hoTen = dgvKetQua.CurrentRow.Cells["HoTen"].Value?.ToString() ?? "";
            string ngayTraLoi = dgvKetQua.CurrentRow.Cells["NgayTraLoi"].Value?.ToString() ?? "";
            string noiDung = dgvKetQua.CurrentRow.Cells["NoiDung"].Value?.ToString() ?? "(Không có nội dung)";
            
            // Also update the side panel
            txtNoiDung.Text = noiDung;
            
            // Show popup dialog with full details
            string message = $"=== CHI TIẾT KẾT QUẢ KHẢO SÁT ===\n\n" +
                             $"Mã SV: {maSV}\n" +
                             $"Họ tên: {hoTen}\n" +
                             $"Ngày trả lời: {ngayTraLoi}\n\n" +
                             $"--- NỘI DUNG TRẢ LỜI ---\n{noiDung}";
            
            // Use custom form for larger display
            using (var popup = new Form())
            {
                popup.Text = "Chi tiết kết quả khảo sát - " + hoTen;
                popup.Size = new System.Drawing.Size(600, 500);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.FormBorderStyle = FormBorderStyle.FixedDialog;
                popup.MaximizeBox = false;
                popup.MinimizeBox = false;
                
                var textBox = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Dock = DockStyle.Fill,
                    Font = new System.Drawing.Font("Consolas", 10),
                    Text = message
                };
                
                var btnClose = new Button
                {
                    Text = "Đóng",
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    DialogResult = DialogResult.OK
                };
                
                popup.Controls.Add(textBox);
                popup.Controls.Add(btnClose);
                popup.AcceptButton = btnClose;
                
                popup.ShowDialog(this);
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
