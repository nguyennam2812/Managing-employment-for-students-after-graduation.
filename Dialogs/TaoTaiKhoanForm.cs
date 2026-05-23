
using System;
using System.Windows.Forms;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;

namespace QuanLySinhVien.Dialogs
{
    public partial class TaoTaiKhoanForm : Form
    {
        public TaiKhoanQuanTri NewAccount { get; private set; }

        public TaoTaiKhoanForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text.Trim();
            var pass = txtPass.Text; // Allow spaces? usually yes or trimmed. Let's keep as is.
            var name = txtName.Text.Trim();
            var masv = txtMaSV.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // Note: MaSV is optional in the schema (it can be null for Admin?), but for Student account it implies it should be there.
            // User said "Mặc định là sinh viên luôn".
            // If empty, maybe acceptable if the linked student doesn't exist yet but usually we want to link.
            // For now, allow empty but warn logic could be here. 
            // In schema: MaSV is linked. If we put a non-existent MaSV, DB foreign key might fail?
            // The constraint is `FK_TaiKhoanQuanTri_SinhVien`. So if MaSV is provided, it must exist.
            // If empty, it's null.
            
            // We won't check existence here (though better practice), we let the caller or DB handle it,
            // OR we rely on the caller to validate.
            // But to be safe, I'll pass it back.

            NewAccount = new TaiKhoanQuanTri
            {
                TenDangNhap = user,
                MatKhau = PasswordHelper.HashPassword(pass),
                HoTenNguoiDung = name,
                MaSV = string.IsNullOrEmpty(masv) ? null : masv,
                QuyenHan = "SINH VIEN" // Default as requested
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
