using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien.Dialogs
{
    public class LichSuCongTacEditForm : Form
    {
        private readonly SurveyDbContext _db;
        private readonly ComboBox _cboSinhVien;
        private readonly ComboBox _cboDoanhNghiep;
        private readonly TextBox _txtViTri;
        private readonly DateTimePicker _dtNgayBatDau;
        private readonly DateTimePicker _dtNgayKetThuc;
        private readonly NumericUpDown _numMucLuong;
        private readonly CheckBox _chkDungChuyenNganh;
        private readonly ComboBox _cboTrangThai;
        private readonly Button _btnSave;
        private readonly Button _btnCancel;

        private readonly LichSuCongTac _existing;

        public LichSuCongTac Result { get; private set; }

        public LichSuCongTacEditForm(SurveyDbContext db, LichSuCongTac existing = null)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _existing = existing;
            
            Text = existing == null ? "Thêm lịch sử công tác" : "Cập nhật lịch sử công tác";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(10);
            MinimumSize = new Size(300, 280);

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

            _cboSinhVien = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList }; 
            _cboDoanhNghiep = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            _txtViTri = new TextBox { Dock = DockStyle.Fill, MaxLength = 100 };
            _dtNgayBatDau = CreateDatePicker();
            _dtNgayBatDau = CreateDatePicker();
            _dtNgayKetThuc = CreateDatePicker();
            
            _numMucLuong = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Minimum = 0,
                Maximum = 1000000000, // 1 billion
                DecimalPlaces = 0,
                Increment = 500000,
                ThousandsSeparator = true
            };

            _chkDungChuyenNganh = new CheckBox
            {
                Text = "Công việc đúng chuyên ngành đào tạo",
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            _cboTrangThai = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cboTrangThai.Items.AddRange(new object[] { "Chưa xác thực", "Đang xác thực", "Đã xác thực" });
            _cboTrangThai.SelectedIndex = 0;

            AddRow(layout, "Sinh viên", _cboSinhVien);
            AddRow(layout, "Doanh nghiệp", _cboDoanhNghiep);
            AddRow(layout, "Vị trí công việc", _txtViTri);
            AddRow(layout, "Ngày bắt đầu", _dtNgayBatDau);
            AddRow(layout, "Ngày bắt đầu", _dtNgayBatDau);
            AddRow(layout, "Ngày kết thúc", _dtNgayKetThuc);
            AddRow(layout, "Mức lương (VND)", _numMucLuong);
            AddRow(layout, "", _chkDungChuyenNganh);
            AddRow(layout, "Trạng thái xác thực", _cboTrangThai);

            _btnSave = new Button { Text = "Lưu", AutoSize = true };
            _btnSave.Click += OnSave;
            _btnCancel = new Button { Text = "Hủy", AutoSize = true, DialogResult = DialogResult.Cancel };

            var buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 10, 0, 0)
            };
            buttonPanel.Controls.Add(_btnSave);
            buttonPanel.Controls.Add(_btnCancel);

            Controls.Add(buttonPanel);
            Controls.Add(layout);

            AcceptButton = _btnSave;
            CancelButton = _btnCancel;

            LoadDropdowns();
            
            // Nếu edit thì fill dữ liệu
            if (existing != null)
            {
                // Chọn SV
                _cboSinhVien.SelectedValue = existing.MaSV;
                _cboSinhVien.Enabled = false; // Không cho đổi người khi sửa

                // Chọn DN
                _cboDoanhNghiep.SelectedValue = existing.MaDN;

                // Các field khác
                _txtViTri.Text = existing.ViTriCongViec;
                
                if (existing.NgayBatDau.HasValue) {
                    _dtNgayBatDau.Value = existing.NgayBatDau.Value;
                    _dtNgayBatDau.Checked = true;
                } else _dtNgayBatDau.Checked = false;

                if (existing.NgayKetThuc.HasValue) {
                    _dtNgayKetThuc.Value = existing.NgayKetThuc.Value;
                    _dtNgayKetThuc.Checked = true;
                } else _dtNgayKetThuc.Checked = false;

                if (existing.MucLuong.HasValue)
                    _numMucLuong.Value = existing.MucLuong.Value;
                
                if (existing.DungChuyenNganh.HasValue)
                    _chkDungChuyenNganh.Checked = existing.DungChuyenNganh.Value;

                if (!string.IsNullOrEmpty(existing.TrangThaiXacThuc))
                    _cboTrangThai.SelectedItem = existing.TrangThaiXacThuc;
            }
        }

        private static DateTimePicker CreateDatePicker()
        {
            return new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true,
                Dock = DockStyle.Fill
            };
        }

        private void LoadDropdowns()
        {
            var sinhVienList = _db.SinhViens
                .OrderBy(s => s.MaSV)
                .Select(s => new { s.MaSV, s.HoTen })
                .AsEnumerable()
                .Select(s => new ComboItemString
                {
                    Key = s.MaSV,
                    Display = string.IsNullOrWhiteSpace(s.HoTen) ? s.MaSV : $"{s.MaSV} - {s.HoTen}"
                })
                .ToList();

            var doanhNghiepList = _db.DoanhNghieps
                .OrderBy(d => d.TenDN)
                .Select(d => new { d.MaDN, d.TenDN })
                .AsEnumerable()
                .Select(d => new ComboItemInt
                {
                    Key = d.MaDN,
                    Display = !string.IsNullOrEmpty(d.TenDN) ? d.TenDN : d.MaDN.ToString()
                })
                .ToList();

            _cboSinhVien.DataSource = sinhVienList;
            _cboSinhVien.DisplayMember = nameof(ComboItemString.Display);
            _cboSinhVien.ValueMember = nameof(ComboItemString.Key);

            _cboDoanhNghiep.DataSource = doanhNghiepList;
            _cboDoanhNghiep.DisplayMember = nameof(ComboItemInt.Display);
            _cboDoanhNghiep.ValueMember = nameof(ComboItemInt.Key);

            if (!sinhVienList.Any() || !doanhNghiepList.Any())
            {
                MessageBox.Show("Cần có dữ liệu sinh viên và doanh nghiệp trước khi thêm lịch sử công tác.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _btnSave.Enabled = false;
            }
            else
            {
                // Tự động chọn item đầu tiên nếu chưa có gì được chọn và KHÔNG phải mode edit
                if (_existing == null)
                {
                    if (_cboSinhVien.SelectedIndex == -1 && sinhVienList.Any())
                        _cboSinhVien.SelectedIndex = 0;
                    if (_cboDoanhNghiep.SelectedIndex == -1 && doanhNghiepList.Any())
                        _cboDoanhNghiep.SelectedIndex = 0;
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
                Margin = new Padding(0, 6, 6, 6)
            };
            control.Margin = new Padding(0, 3, 0, 3);
            control.Dock = DockStyle.Fill;

            var rowIndex = layout.RowCount;
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowCount++;
            layout.Controls.Add(lbl, 0, rowIndex);
            layout.Controls.Add(control, 1, rowIndex);
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!_btnSave.Enabled)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            // Kiểm tra xem có item nào được chọn không
            if (_cboSinhVien.SelectedIndex == -1 || _cboSinhVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cboSinhVien.Focus();
                return;
            }

            if (_cboDoanhNghiep.SelectedIndex == -1 || _cboDoanhNghiep.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn doanh nghiệp.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cboDoanhNghiep.Focus();
                return;
            }

            var maSv = _cboSinhVien.SelectedValue as string;
            int? maDn = _cboDoanhNghiep.SelectedValue as int?;
            if (string.IsNullOrWhiteSpace(maSv))
            {
                MessageBox.Show("Vui lòng chọn sinh viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cboSinhVien.Focus();
                return;
            }
            if (!maDn.HasValue || maDn <= 0)
            {
                MessageBox.Show("Vui lòng chọn doanh nghiệp.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cboDoanhNghiep.Focus();
                return;
            }

            var ngayBatDau = _dtNgayBatDau.Checked ? _dtNgayBatDau.Value.Date : (DateTime?)null;
            var ngayKetThuc = _dtNgayKetThuc.Checked ? _dtNgayKetThuc.Value.Date : (DateTime?)null;
            if (ngayBatDau.HasValue && ngayKetThuc.HasValue && ngayKetThuc < ngayBatDau)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _dtNgayKetThuc.Focus();
                return;
            }

            Result = new LichSuCongTac
            {
                MaLichSu = _existing?.MaLichSu ?? 0, // Dùng ID cũ nếu update
                MaSV = maSv,
                MaDN = maDn.Value,
                ViTriCongViec = _txtViTri.Text?.Trim(),
                NgayBatDau = ngayBatDau,
                NgayKetThuc = ngayKetThuc,
                MucLuong = _numMucLuong.Value > 0 ? (decimal?)_numMucLuong.Value : null,
                DungChuyenNganh = _chkDungChuyenNganh.Checked,
                
                TrangThaiXacThuc = _cboTrangThai.SelectedIndex >= 0 && _cboTrangThai.SelectedItem != null 
                    ? _cboTrangThai.SelectedItem.ToString() 
                    : "Chưa xác thực"
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private sealed class ComboItemString
        {
            public string Key { get; set; }
            public string Display { get; set; }
        }

        private sealed class ComboItemInt
        {
            public int Key { get; set; }
            public string Display { get; set; }
        }
    }
}
