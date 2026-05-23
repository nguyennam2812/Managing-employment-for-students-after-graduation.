using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien.Dialogs
{
    public class DoanhNghiepEditForm : Form
    {
        private readonly TextBox _txtMaDn;
        private readonly TextBox _txtTenDn;
        private readonly TextBox _txtDiaChi;
        private readonly TextBox _txtLinhVuc;
        private readonly TextBox _txtEmail;
        private readonly TextBox _txtSoDienThoai;
        private readonly Button _btnSave;
        private readonly Button _btnCancel;
        private readonly DoanhNghiep _existing;  // Lưu entity gốc để có MaDN khi cập nhật

        public DoanhNghiep Result { get; private set; }

        public DoanhNghiepEditForm(DoanhNghiep existing = null)
        {
            Text = existing == null ? "Thêm doanh nghiệp" : "Cập nhật doanh nghiệp";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(10);
            MinimumSize = new Size(280, 250);

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

            _txtMaDn = CreateTextBox(50);
            _txtTenDn = CreateTextBox(255);
            _txtDiaChi = CreateTextBox(500);
            _txtLinhVuc = CreateTextBox(255);
            _txtEmail = CreateTextBox(255);
            _txtSoDienThoai = CreateTextBox(20);

            // Chỉ hiển thị Mã DN khi cập nhật (vì database tự tạo khi thêm mới)
            if (existing != null)
            {
                AddRow(layout, "Mã DN", _txtMaDn, true);
            }
            AddRow(layout, "Tên doanh nghiệp", _txtTenDn);
            AddRow(layout, "Địa chỉ", _txtDiaChi);
            AddRow(layout, "Lĩnh vực", _txtLinhVuc);
            AddRow(layout, "Email liên hệ", _txtEmail);
            AddRow(layout, "Số điện thoại", _txtSoDienThoai);

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

            _existing = existing;
            if (existing != null)
            {
                _txtMaDn.Text = existing.MaDN.ToString();
                _txtTenDn.Text = existing.TenDN;
                _txtDiaChi.Text = existing.DiaChi;
                _txtLinhVuc.Text = existing.LinhVucHoatDong;
                _txtEmail.Text = existing.EmailLienHe;
                _txtSoDienThoai.Text = existing.SoDienThoai;
            }
        }

        private static TextBox CreateTextBox(int maxLength)
        {
            return new TextBox { Dock = DockStyle.Fill, MaxLength = maxLength };
        }

        private static void AddRow(TableLayoutPanel layout, string label, Control control, bool readOnly = false)
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
            if (control is TextBox textBox)
            {
                textBox.ReadOnly = readOnly;
                textBox.BackColor = readOnly ? SystemColors.ControlLight : SystemColors.Window;
            }

            var rowIndex = layout.RowCount;
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowCount++;
            layout.Controls.Add(lbl, 0, rowIndex);
            layout.Controls.Add(control, 1, rowIndex);
        }

        private void OnSave(object sender, EventArgs e)
        {
            var ten = _txtTenDn.Text?.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên doanh nghiệp không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtTenDn.Focus();
                return;
            }

            Result = new DoanhNghiep
            {
                MaDN = _existing?.MaDN ?? 0,  // 0 = database tự tạo ID mới
                TenDN = ten,
                DiaChi = _txtDiaChi.Text?.Trim(),
                LinhVucHoatDong = _txtLinhVuc.Text?.Trim(),
                EmailLienHe = _txtEmail.Text?.Trim(),
                SoDienThoai = _txtSoDienThoai.Text?.Trim()
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
