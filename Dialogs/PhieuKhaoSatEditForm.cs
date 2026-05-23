using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien.Dialogs
{
    public class PhieuKhaoSatEditForm : Form
    {
        private readonly TextBox _txtTenDot;
        private readonly DateTimePicker _dtNgayTao;
        private readonly DateTimePicker _dtNgayHetHan;
        private readonly TextBox _txtTrangThai;
        private readonly TextBox _txtNoiDungCauHoi; // New field
        private readonly Button _btnSave;
        private readonly Button _btnCancel;
        private readonly int _existingId;  // Lưu MaPhieu khi cập nhật

        public PhieuKhaoSat Result { get; private set; }

        public PhieuKhaoSatEditForm(PhieuKhaoSat existing = null)
        {
            _existingId = existing?.MaPhieu ?? 0;
            Text = existing == null ? "Thêm phiếu khảo sát" : "Cập nhật phiếu khảo sát";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(10);
            MinimumSize = new Size(500, 400); // Increased size

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

            _txtTenDot = CreateTextBox(255);
            _dtNgayTao = CreateDatePicker();
            _dtNgayHetHan = CreateDatePicker();
            _txtTrangThai = CreateTextBox(30);
            
            // Allow multiline for Question Content
            _txtNoiDungCauHoi = new TextBox 
            { 
                Dock = DockStyle.Fill, 
                Multiline = true, 
                Height = 100, 
                ScrollBars = ScrollBars.Vertical 
            };

            AddRow(layout, "Tên đợt khảo sát", _txtTenDot);
            AddRow(layout, "Ngày tạo", _dtNgayTao);
            AddRow(layout, "Ngày hết hạn", _dtNgayHetHan);
            AddRow(layout, "Trạng thái", _txtTrangThai);
            AddRow(layout, "Nội dung câu hỏi\n(mỗi câu 1 dòng)", _txtNoiDungCauHoi);

            _btnSave = new Button { Text = "Lưu", AutoSize = true };
            _btnSave.Click += OnSave;
            _btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, AutoSize = true };

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

            if (existing != null)
            {
                _txtTenDot.Text = existing.TenDotKhaoSat;
                _dtNgayTao.Value = existing.NgayTao;
                _dtNgayTao.Checked = true;
                if (existing.NgayHetHan.HasValue)
                {
                    _dtNgayHetHan.Value = existing.NgayHetHan.Value;
                    _dtNgayHetHan.Checked = true;
                }
                _txtTrangThai.Text = existing.TrangThaiPhieu;
                _txtNoiDungCauHoi.Text = existing.NoiDungCauHoi;
            }
            else
            {
                _dtNgayTao.Value = DateTime.Today;
                _dtNgayTao.Checked = true;
                _txtTrangThai.Text = "Mới tạo";
            }
        }

        private static TextBox CreateTextBox(int maxLength)
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                MaxLength = maxLength
            };
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
            var ten = _txtTenDot.Text?.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên đợt khảo sát không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtTenDot.Focus();
                return;
            }

            var ngayTao = _dtNgayTao.Checked ? _dtNgayTao.Value : DateTime.Now;
            var ngayHetHan = _dtNgayHetHan.Checked ? _dtNgayHetHan.Value : (DateTime?)null;
            if (ngayHetHan.HasValue && ngayHetHan < ngayTao)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn hoặc bằng ngày tạo.", "Sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _dtNgayHetHan.Focus();
                return;
            }

            Result = new PhieuKhaoSat
            {
                MaPhieu = _existingId,  // 0 = thêm mới (database tự tạo), > 0 = cập nhật
                TenDotKhaoSat = ten,
                NgayTao = ngayTao,
                NgayHetHan = ngayHetHan,
                TrangThaiPhieu = _txtTrangThai.Text?.Trim(),
                NoiDungCauHoi = _txtNoiDungCauHoi.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
