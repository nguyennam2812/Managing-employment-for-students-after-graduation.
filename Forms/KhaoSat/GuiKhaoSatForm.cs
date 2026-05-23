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
    public partial class GuiKhaoSatForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();

        public GuiKhaoSatForm()
        {
            InitializeComponent();
        }

        private void GuiKhaoSatForm_Load(object sender, EventArgs e)
        {
            if (AuthContext.IsStudent)
            {
                MessageBox.Show("Không có quyền truy cập.");
                Close();
                return;
            }

            LoadCombos();
            lblPhieu.Text = "Đợt khảo sát:";
            ApplyVisualStyle();
            
            // Auto-load list logic
            btnTaiDS_Click(sender, e);
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StyleDataGridView(dgvSinhVien);
            // Override ReadOnly để cho phép checkbox hoạt động
            dgvSinhVien.ReadOnly = false;
            
            UITheme.StylePrimaryButton(btnTaiDS);
            UITheme.StylePrimaryButton(btnGui);
            UITheme.StyleSecondaryButton(btnSearch);
            UITheme.StyleGhostButton(btnDong);
            UITheme.StyleComboBox(cboPhieu);
            UITheme.StyleComboBox(cboKhoaHoc);
            UITheme.StyleComboBox(cboNganh);
            UITheme.StyleComboBox(cboNamTN);
            UITheme.StyleTextBox(txtSearch);

            // --- REFLOW LAYOUT ---

            // 1. Top Section (Survey Selection)
            int topMargin = 20;
            lblPhieu.Top = topMargin + 5;
            lblPhieu.Left = 20;
            
            cboPhieu.Top = topMargin;
            cboPhieu.Left = lblPhieu.Right + 10;
            cboPhieu.Width = 400;

            // 2. Filter Group Box
            grpFilter.Top = cboPhieu.Bottom + 15;
            grpFilter.Left = 20;
            grpFilter.Width = this.ClientSize.Width - 40;
            
            // Inside GroupBox - Layout các control lọc theo hàng ngang
            int filterTop = 30;
            int comboTop = 26;
            int gap = 15;
            
            // Khoa
            lblKhoa.Top = filterTop;
            lblKhoa.Left = 15;
            lblKhoa.AutoSize = true;
            
            cboKhoaHoc.Top = comboTop;
            cboKhoaHoc.Left = lblKhoa.Right + 5;
            cboKhoaHoc.Width = 130;
            
            // Ngành
            lblNganh.Top = filterTop;
            lblNganh.Left = cboKhoaHoc.Right + gap;
            lblNganh.AutoSize = true;
            
            cboNganh.Top = comboTop;
            cboNganh.Left = lblNganh.Right + 5;
            cboNganh.Width = 150;
            
            // Năm TN
            lblNamTN.Top = filterTop;
            lblNamTN.Left = cboNganh.Right + gap;
            lblNamTN.AutoSize = true;
            
            cboNamTN.Top = comboTop;
            cboNamTN.Left = lblNamTN.Right + 5;
            cboNamTN.Width = 100;

            // Đảm bảo GroupBox đủ rộng
            grpFilter.Height = 70;
            
            // 3. Search & Actions Row
            int searchRowTop = grpFilter.Bottom + 15;
            
            txtSearch.Top = searchRowTop;
            txtSearch.Left = 20;
            txtSearch.Width = 250;

            btnSearch.Top = searchRowTop - 1;
            btnSearch.Left = txtSearch.Right + 5;

            // Move Button "Lay DS" (Filter/Refresh) to this row
            btnTaiDS.Top = searchRowTop - 1;
            btnTaiDS.Left = btnSearch.Right + 10;
            btnTaiDS.Width = 120;
            btnTaiDS.Text = "Lọc / Tải lại";

            chkSelectAll.Top = searchRowTop + 3;
            chkSelectAll.Left = btnTaiDS.Right + 20;

            lblSelectedCount.Top = searchRowTop + 3;
            lblSelectedCount.Left = chkSelectAll.Right + 20;

            // 4. DataGridView
            dgvSinhVien.Top = txtSearch.Bottom + 15;
            dgvSinhVien.Left = 20;
            dgvSinhVien.Width = this.ClientSize.Width - 40;
            
            int bottomMargin = 70;
            dgvSinhVien.Height = this.ClientSize.Height - dgvSinhVien.Top - bottomMargin;

            // 5. Bottom Buttons
            int btnTop = this.ClientSize.Height - 50;
            
            btnGui.Top = btnTop;
            btnGui.Left = this.ClientSize.Width - btnGui.Width - 20;
            
            btnDong.Top = btnTop;
            btnDong.Left = btnGui.Left - btnDong.Width - 10;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }
        // Public helper class for binding
        public class CboItem
        {
            public string Value { get; set; }
            public string Text { get; set; }
            
            public override string ToString() 
            { 
                return Text; 
            }
        }

        private void LoadPhieu()
        {
            try
            {
                var list = _db.PhieuKhaoSats
                              .Where(p => p.TrangThaiPhieu == "Đang mở")
                              .OrderByDescending(p => p.NgayTao)
                              .Select(p => new { p.MaPhieu, p.TenDotKhaoSat })
                              .ToList();

                cboPhieu.DataSource = list;
                cboPhieu.DisplayMember = "TenDotKhaoSat";
                cboPhieu.ValueMember = "MaPhieu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đợt khảo sát: " + ex.Message);
            }
        }

        private void LoadKhoaHoc()
        {
            try
            {
                var fullList = new System.Collections.Generic.List<CboItem>();
                
                // 1. Add "All" option first
                fullList.Add(new CboItem { Value = "", Text = "-- Tất cả năm --" });

                // 2. Add DB items
                // Note: Using ToList() on DB query first to close reader
                var dbItems = _db.KhoaHocs
                              .OrderByDescending(k => k.NienKhoa)
                              .Select(k => new { k.MaKhoaHoc, k.NienKhoa })
                              .ToList();

                foreach (var item in dbItems)
                {
                    fullList.Add(new CboItem 
                    { 
                        Value = item.MaKhoaHoc, 
                        Text = item.NienKhoa 
                    });
                }

                // 3. Bind
                cboKhoaHoc.DataSource = null; // Reset
                cboKhoaHoc.DataSource = fullList;
                cboKhoaHoc.DisplayMember = "Text";
                cboKhoaHoc.ValueMember = "Value";

                if (fullList.Count > 0)
                    cboKhoaHoc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khóa học: " + ex.Message);
            }
        }

        private void LoadNganh()
        {
            try
            {
                var list = _db.NganhHocs
                              .Select(n => new { MaNganh = n.MaNganh, TenNganh = n.TenNganh })
                              .ToList();

                list.Insert(0, new { MaNganh = (string)null, TenNganh = "-- Tất cả ngành --" });

                cboNganh.DataSource = list;
                cboNganh.DisplayMember = "TenNganh";
                cboNganh.ValueMember = "MaNganh";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ngành học: " + ex.Message);
            }
        }



        private void LoadNamTN()
        {
            try
            {
                // Derive Graduation Years from NienKhoa (e.g. "2019-2023" -> "2023")
                var rawNienKhoa = _db.KhoaHocs.Select(k => k.NienKhoa).Distinct().ToList();
                var namTNs = new System.Collections.Generic.HashSet<string>();

                foreach (var nk in rawNienKhoa)
                {
                    if (string.IsNullOrWhiteSpace(nk)) continue;
                    var parts = nk.Split('-'); // Split "2019-2023"
                    if (parts.Length > 0)
                    {
                        var lastPart = parts[parts.Length - 1].Trim();
                        if (!string.IsNullOrEmpty(lastPart))
                        {
                            namTNs.Add(lastPart);
                        }
                    }
                }

                var list = new System.Collections.Generic.List<CboItem>();
                list.Add(new CboItem { Value = "", Text = "-- Tất cả năm --" });

                foreach (var year in namTNs.OrderByDescending(y => y))
                {
                    list.Add(new CboItem { Value = year, Text = year });
                }

                cboNamTN.DataSource = list;
                cboNamTN.DisplayMember = "Text";
                cboNamTN.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải năm tốt nghiệp: " + ex.Message);
            }
        }

        private void LoadCombos()
        {
            LoadPhieu();
            LoadKhoaHoc();
            LoadNganh();
            LoadNamTN();
        }

        private void btnTaiDS_Click(object sender, EventArgs e)
        {
            try
            {
                var query = _db.SinhViens
                               .Include(s => s.KhoaHoc)
                               .Include(s => s.NganhHoc)
                               .AsQueryable();

                // Build filter conditions
                if (cboKhoaHoc.SelectedValue != null)
                {
                    string k = cboKhoaHoc.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(k)) 
                        query = query.Where(s => s.MaKhoaHoc == k);
                }

                if (cboNganh.SelectedValue != null)
                {
                    string n = cboNganh.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(n))
                        query = query.Where(s => s.MaNganh == n);
                }

                if (cboNamTN.SelectedValue != null)
                {
                    string y = cboNamTN.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(y))
                        query = query.Where(s => s.KhoaHoc.NienKhoa.EndsWith(y));
                }




                // Projection
                var list = query.Select(s => new 
                {
                    s.MaSV,
                    s.HoTen,
                    s.EmailCaNhan,

                    NienKhoa = s.KhoaHoc != null ? s.KhoaHoc.NienKhoa : "",
                    TenNganh = s.NganhHoc != null ? s.NganhHoc.TenNganh : ""
                }).ToList();

                dgvSinhVien.DataSource = list;

                // Format Headers
                if (dgvSinhVien.Columns["MaSV"] != null) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                if (dgvSinhVien.Columns["HoTen"] != null) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvSinhVien.Columns["EmailCaNhan"] != null) dgvSinhVien.Columns["EmailCaNhan"].HeaderText = "Email";

                if (dgvSinhVien.Columns["NienKhoa"] != null) dgvSinhVien.Columns["NienKhoa"].HeaderText = "Niên khóa";
                if (dgvSinhVien.Columns["TenNganh"] != null) dgvSinhVien.Columns["TenNganh"].HeaderText = "Ngành";

                // Add checkbox column if not exists
                if (!dgvSinhVien.Columns.Contains("colSelect"))
                {
                    var chkCol = new DataGridViewCheckBoxColumn
                    {
                        Name = "colSelect",
                        HeaderText = "Chọn",
                        Width = 50
                    };
                    dgvSinhVien.Columns.Insert(0, chkCol);
                }

                // Make checkbox column editable - grid level ReadOnly must be false first
                dgvSinhVien.ReadOnly = false;
                dgvSinhVien.Columns["colSelect"].ReadOnly = false;
                foreach (DataGridViewColumn col in dgvSinhVien.Columns)
                {
                    if (col.Name != "colSelect")
                        col.ReadOnly = true;
                }

                UpdateSelectedCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        private void UpdateSelectedCount()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells["colSelect"].Value != null && (bool)row.Cells["colSelect"].Value)
                    count++;
            }
            lblSelectedCount.Text = $"Đã chọn: {count}";
        }

        private void dgvSinhVien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvSinhVien.Columns[e.ColumnIndex].Name == "colSelect")
            {
                UpdateSelectedCount();
            }
        }

        private void dgvSinhVien_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.IsCurrentCellDirty && dgvSinhVien.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvSinhVien.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                row.Cells["colSelect"].Value = chkSelectAll.Checked;
            }
            UpdateSelectedCount();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text?.Trim().ToLower() ?? "";
            if (string.IsNullOrEmpty(searchTerm))
            {
                btnTaiDS_Click(sender, e); // Reload all
                return;
            }

            var query = _db.SinhViens
                           .Include(s => s.KhoaHoc)
                           .Include(s => s.NganhHoc)
                           .Where(s => s.MaSV.ToLower().Contains(searchTerm) || s.HoTen.ToLower().Contains(searchTerm))
                           .Select(s => new
                           {
                               s.MaSV,
                               s.HoTen,
                               s.EmailCaNhan,
                               NienKhoa = s.KhoaHoc != null ? s.KhoaHoc.NienKhoa : "",
                               TenNganh = s.NganhHoc != null ? s.NganhHoc.TenNganh : ""
                           }).ToList();

            dgvSinhVien.DataSource = query;

            // Re-add checkbox column
            if (!dgvSinhVien.Columns.Contains("colSelect"))
            {
                var chkCol = new DataGridViewCheckBoxColumn
                {
                    Name = "colSelect",
                    HeaderText = "Chọn",
                    Width = 50
                };
                dgvSinhVien.Columns.Insert(0, chkCol);
            }
            dgvSinhVien.ReadOnly = false;
            dgvSinhVien.Columns["colSelect"].ReadOnly = false;
            foreach (DataGridViewColumn col in dgvSinhVien.Columns)
            {
                if (col.Name != "colSelect")
                    col.ReadOnly = true;
            }
            UpdateSelectedCount();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (cboPhieu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đợt khảo sát để gửi.");
                return;
            }

            // Đếm số sinh viên được chọn
            var selectedRows = new System.Collections.Generic.List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells["colSelect"].Value != null && (bool)row.Cells["colSelect"].Value)
                {
                    selectedRows.Add(row);
                }
            }

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sinh viên để gửi khảo sát.");
                return;
            }

            int phieuId = (int)cboPhieu.SelectedValue;
            int soSV = selectedRows.Count;

            var confirm = MessageBox.Show($"Xác nhận gửi email khảo sát cho {soSV} sinh viên đã chọn?", 
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                int countAssigned = 0;
                foreach (var row in selectedRows)
                {
                   var maSV = row.Cells["MaSV"].Value?.ToString();
                   if (!string.IsNullOrEmpty(maSV))
                   {
                        bool exists = _db.PhanCongKhaoSats.Any(pc => pc.MaPhieu == phieuId && pc.MaSV == maSV);
                        if (!exists)
                        {
                            var pc = new PhanCongKhaoSat
                            {
                                MaPhieu = phieuId,
                                MaSV = maSV,
                                NgayPhanCong = DateTime.Now
                            };
                            _db.PhanCongKhaoSats.Add(pc);
                            countAssigned++;
                        }
                   }
                }
                
                _db.SaveChanges();

                var log = new DuLieuPhanTichTam
                {
                    MaPhien = Guid.NewGuid().ToString(),
                    TenThongKe = "GUI_KHAOSAT_" + phieuId,
                    GiaTri = $"SoSV={soSV};MaPhieu={phieuId};ThoiGian={DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                    NgayTao = DateTime.Now
                };

                _db.DuLieuPhanTichTams.Add(log);
                _db.SaveChanges();

                MessageBox.Show($"Đã gửi khảo sát tới {soSV} sinh viên đã chọn.\n(Đã ghi log vào hệ thống)");
                
                // Bỏ chọn tất cả sau khi gửi
                foreach (DataGridViewRow row in dgvSinhVien.Rows)
                {
                    row.Cells["colSelect"].Value = false;
                }
                chkSelectAll.Checked = false;
                UpdateSelectedCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi/ghi log: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            var main = this.Parent?.Parent as MainForm;
            if (main != null)
            {
                main.OpenChildInternal(new DashboardForm(main));
            }
            else
            {
                // Fallback nếu chạy độc lập (ít khi)
                this.Close();
            }
        }
    }
}
