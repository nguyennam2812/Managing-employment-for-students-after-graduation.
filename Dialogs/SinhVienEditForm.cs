using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;
using AuditLog = QuanLySinhVien.Models.AuditLog;


namespace QuanLySinhVien.Dialogs
{
    public class SinhVienEditForm : Form
    {
        private readonly SurveyDbContext _db;
        private readonly Services.StudentJobService _sjService;
        private readonly Services.AuthService _authService;

        private readonly TextBox _txtMaSV;
        private readonly TextBox _txtHoTen;
        private readonly DateTimePicker _dtNgaySinh;
        private readonly TextBox _txtEmail;
        private readonly TextBox _txtSoDT;

        // _cboTinhTrang removed - TinhTrangViecLam not part of thesis requirements
        private readonly ComboBox _cboNganh;
        private readonly ComboBox _cboKhoaHoc;
        private readonly TextBox _txtLop; // Changed from ComboBox
        private readonly CheckBox _chkTaoTaiKhoan;
        private readonly TextBox _txtMatKhau;
        private readonly Button _btnSave;
        private readonly Button _btnCancel;
        private readonly Button _btnViewLog;
        private readonly SV _existing;

        public SV Result { get; private set; }
        public TaiKhoanQuanTri TaiKhoanMoi { get; private set; }

        public SinhVienEditForm(SurveyDbContext db, SV existing = null)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _sjService = new Services.StudentJobService(_db);
            _authService = new Services.AuthService(_db);
            _existing = existing;


            Text = existing == null ? "Thêm sinh viên" : "Cập nhật sinh viên";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Size = new Size(450, 550);
            Padding = new Padding(10);

            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 0,
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));

            // Tạo các controls
            _txtMaSV = new TextBox { Dock = DockStyle.Fill, MaxLength = 10 };
            _txtHoTen = new TextBox { Dock = DockStyle.Fill, MaxLength = 100 };
            _dtNgaySinh = new DateTimePicker 
            { 
                Dock = DockStyle.Fill, 
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true,
                Checked = false
            };
            _txtEmail = new TextBox { Dock = DockStyle.Fill, MaxLength = 100 };
            _txtSoDT = new TextBox { Dock = DockStyle.Fill, MaxLength = 15 };

            // _cboTinhTrang removed - TinhTrangViecLam not part of thesis requirements
            
            _cboNganh = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _cboKhoaHoc = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _txtLop = new TextBox { Dock = DockStyle.Fill, MaxLength = 20 }; // Changed from ComboBox

            // Tạo tài khoản
            _chkTaoTaiKhoan = new CheckBox 
            { 
                Text = "Tạo tài khoản cho sinh viên", 
                Dock = DockStyle.Fill,
                Checked = existing == null  // Mặc định tích khi thêm mới
            };
            _chkTaoTaiKhoan.CheckedChanged += (s, ev) => _txtMatKhau.Enabled = _chkTaoTaiKhoan.Checked;
            
            _txtMatKhau = new TextBox 
            { 
                Dock = DockStyle.Fill, 
                MaxLength = 50,
                UseSystemPasswordChar = true,
                Enabled = existing == null
            };

            // Thêm các row
            AddRow(layout, "Mã sinh viên", _txtMaSV);
            AddRow(layout, "Họ tên", _txtHoTen);
            AddRow(layout, "Ngày sinh", _dtNgaySinh);
            AddRow(layout, "Email cá nhân", _txtEmail);
            AddRow(layout, "Số điện thoại", _txtSoDT);

            // Tình trạng việc làm removed
            AddRow(layout, "Ngành học", _cboNganh);
            AddRow(layout, "Khóa học", _cboKhoaHoc);
            AddRow(layout, "Lớp (Mã)", _txtLop); // Changed label
            AddRow(layout, "", _chkTaoTaiKhoan);
            AddRow(layout, "Mật khẩu", _txtMatKhau);

            _btnSave = new Button { Text = "Lưu", Width = 80, Height = 30 };
            _btnSave.Click += OnSave;
            _btnCancel = new Button { Text = "Hủy", Width = 80, Height = 30, DialogResult = DialogResult.Cancel };
            _btnViewLog = new Button { Text = "Lịch sử thay đổi", Width = 120, Height = 30, Visible = false };
            if (existing != null && Security.AuthContext.IsAdmin)
            {
                _btnViewLog.Visible = true;
                _btnViewLog.Click += (s, ev) => new QuanLyLichSuThayDoiForm(existing.MaSV).ShowDialog(this);
            }

            var buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Top,
                Height = 45,
                Padding = new Padding(0, 10, 0, 0)
            };
            buttonPanel.Controls.Add(_btnCancel);
            buttonPanel.Controls.Add(_btnSave);
            buttonPanel.Controls.Add(_btnViewLog);

            Controls.Add(buttonPanel);
            Controls.Add(layout);

            AcceptButton = _btnSave;
            CancelButton = _btnCancel;

            LoadDropdowns();

            // Điền dữ liệu nếu đang sửa
            if (existing != null)
            {
                _txtMaSV.Text = existing.MaSV;
                _txtMaSV.ReadOnly = true;  // Không cho sửa mã SV khi update
                _txtMaSV.BackColor = SystemColors.ControlLight;
                
                _txtHoTen.Text = existing.HoTen;
                if (existing.NgaySinh.HasValue)
                {
                    _dtNgaySinh.Value = existing.NgaySinh.Value;
                    _dtNgaySinh.Checked = true;
                }
                _txtEmail.Text = existing.EmailCaNhan;
                _txtSoDT.Text = existing.SoDienThoai;

                
                // TinhTrangViecLam binding removed
                
                SelectComboValue(_cboNganh, existing.MaNganh);
                SelectComboValue(_cboKhoaHoc, existing.MaKhoaHoc);
                
                _txtLop.Text = existing.MaLop; // Changed from SelectComboValue
            }
            else
            {
            // Default selected state for TinhTrang removed
            }
        }

        private void LoadDropdowns()
        {
            // Load ngành học
            var nganhList = _sjService.GetNganhHocs()

                .Select(n => new ComboItem { Key = n.MaNganh, Display = n.TenNganh ?? n.MaNganh })
                .ToList();
            nganhList.Insert(0, new ComboItem { Key = null, Display = "(Chọn ngành)" });
            _cboNganh.DataSource = nganhList;
            _cboNganh.DisplayMember = nameof(ComboItem.Display);
            _cboNganh.ValueMember = nameof(ComboItem.Key);

            // Load khóa học  
            var khoaHocList = _sjService.GetKhoaHocs()

                .Select(k => new ComboItem { Key = k.MaKhoaHoc, Display = k.NienKhoa ?? k.MaKhoaHoc })
                .ToList();
            khoaHocList.Insert(0, new ComboItem { Key = null, Display = "(Chọn khóa)" });
            _cboKhoaHoc.DataSource = khoaHocList;
            _cboKhoaHoc.DisplayMember = nameof(ComboItem.Display);
            _cboKhoaHoc.ValueMember = nameof(ComboItem.Key);
            _cboKhoaHoc.ValueMember = nameof(ComboItem.Key);

            // Load lớp REMOVED
        }
        
        private void SelectComboValue(ComboBox cbo, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i] is ComboItem item && item.Key == value)
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }
        }

        private static void AddRow(TableLayoutPanel layout, string label, Control control)
        {
            var lbl = new Label
            {
                Text = label,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 8, 6, 6)
            };
            control.Margin = new Padding(0, 5, 0, 5);

            var rowIndex = layout.RowCount;
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowCount++;
            layout.Controls.Add(lbl, 0, rowIndex);
            layout.Controls.Add(control, 1, rowIndex);
        }

        private void OnSave(object sender, EventArgs e)
        {
            var maSV = _txtMaSV.Text?.Trim();
            var hoTen = _txtHoTen.Text?.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtMaSV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtHoTen.Focus();
                return;
            }

            // Kiểm tra trùng mã khi thêm mới
            if (_existing == null && _sjService.SinhVienExists(maSV))

            {
                MessageBox.Show("Mã sinh viên đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtMaSV.Focus();
                return;
            }

            // Kiểm tra mật khẩu nếu tạo tài khoản
            if (_chkTaoTaiKhoan.Checked)
            {
                var matKhau = _txtMatKhau.Text?.Trim();
                if (string.IsNullOrWhiteSpace(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _txtMatKhau.Focus();
                    return;
                }

                // Kiểm tra tài khoản đã tồn tại
                if (_authService.AccountExists(maSV))

                {
                    MessageBox.Show("Tài khoản cho sinh viên này đã tồn tại.", "Trùng tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _chkTaoTaiKhoan.Checked = false;
                    return;
                }

                TaiKhoanMoi = new TaiKhoanQuanTri
                {
                    TenDangNhap = maSV,
                    MatKhau = PasswordHelper.HashPassword(matKhau),
                    HoTenNguoiDung = hoTen,
                    QuyenHan = "SINH VIEN",
                    MaSV = maSV
                };

            }

            // Nếu đang sửa, cập nhật _existing
            if (_existing != null)
            {
                // Capture old values for logging
                var oldValues = new System.Text.StringBuilder();
                var newValues = new System.Text.StringBuilder();
                bool hasChanges = false;

                if (_existing.HoTen != hoTen)
                {
                    oldValues.AppendLine($"Họ tên: {_existing.HoTen}");
                    newValues.AppendLine($"Họ tên: {hoTen}");
                    hasChanges = true;
                    _existing.HoTen = hoTen;
                }

                var newNgaySinh = _dtNgaySinh.Checked ? _dtNgaySinh.Value.Date : (DateTime?)null;
                if (_existing.NgaySinh != newNgaySinh)
                {
                    oldValues.AppendLine($"Ngày sinh: {_existing.NgaySinh:dd/MM/yyyy}");
                    newValues.AppendLine($"Ngày sinh: {newNgaySinh:dd/MM/yyyy}");
                    hasChanges = true;
                    _existing.NgaySinh = newNgaySinh;
                }

                var newEmail = _txtEmail.Text?.Trim();
                if (_existing.EmailCaNhan != newEmail)
                {
                    oldValues.AppendLine($"Email: {_existing.EmailCaNhan}");
                    newValues.AppendLine($"Email: {newEmail}");
                    hasChanges = true;
                    _existing.EmailCaNhan = newEmail;
                }

                var newSDT = _txtSoDT.Text?.Trim();
                if (_existing.SoDienThoai != newSDT)
                {
                    oldValues.AppendLine($"SĐT: {_existing.SoDienThoai}");
                    newValues.AppendLine($"SĐT: {newSDT}");
                    hasChanges = true;
                    _existing.SoDienThoai = newSDT;
                }



                // TinhTrangViecLam comparison removed - not part of thesis

                var newNganh = _cboNganh.SelectedValue as string;
                if (_existing.MaNganh != newNganh)
                {
                    oldValues.AppendLine($"Ngành: {_existing.MaNganh}");
                    newValues.AppendLine($"Ngành: {newNganh}");
                    hasChanges = true;
                    _existing.MaNganh = newNganh;
                }

                var newKhoaHoc = _cboKhoaHoc.SelectedValue as string;
                if (_existing.MaKhoaHoc != newKhoaHoc)
                {
                    oldValues.AppendLine($"Khóa: {_existing.MaKhoaHoc}");
                    newValues.AppendLine($"Khóa: {newKhoaHoc}");
                    hasChanges = true;
                    _existing.MaKhoaHoc = newKhoaHoc;
                    _existing.MaKhoaHoc = newKhoaHoc;
                }

                var newLop = _txtLop.Text?.Trim(); // Changed to TextBox
                if (_existing.MaLop != newLop)
                {
                    oldValues.AppendLine($"Lớp: {_existing.MaLop}");
                    newValues.AppendLine($"Lớp: {newLop}");
                    hasChanges = true;
                    _existing.MaLop = newLop;
                }
                
                if (hasChanges)
                {
                    var log = new AuditLog
                    {
                        TableName = "SinhVien",
                        RecordId = _existing.MaSV,
                        Action = "Update",
                        OldValue = oldValues.ToString().Trim(),
                        NewValue = newValues.ToString().Trim(),
                        ChangedBy = Security.AuthContext.Username,
                        ChangedDate = DateTime.UtcNow
                    };
                    _db.AuditLogs.Add(log);
                }

                Result = _existing;
            }
            else
            {
                // Insert case - log creation
                Result = new SV
                {
                    MaSV = maSV,
                    HoTen = hoTen,
                    NgaySinh = _dtNgaySinh.Checked ? _dtNgaySinh.Value.Date : (DateTime?)null,
                    EmailCaNhan = _txtEmail.Text?.Trim(),
                    SoDienThoai = _txtSoDT.Text?.Trim(),

                    // TinhTrangViecLam removed - not part of thesis
                    MaNganh = _cboNganh.SelectedValue as string,
                    MaKhoaHoc = _cboKhoaHoc.SelectedValue as string,
                    MaLop = _txtLop.Text?.Trim() // Changed to TextBox
                };

                var log = new AuditLog
                {
                    TableName = "SinhVien",
                    RecordId = maSV,
                    Action = "Insert",
                    OldValue = null,
                    NewValue = $"Thêm mới sinh viên: {hoTen}",
                    ChangedBy = Security.AuthContext.Username,
                    ChangedDate = DateTime.UtcNow
                };
                _db.AuditLogs.Add(log);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private sealed class ComboItem
        {
            public string Key { get; set; }
            public string Display { get; set; }
        }
    }
}
