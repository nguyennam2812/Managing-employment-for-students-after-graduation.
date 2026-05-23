using System;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Security;
using System.Data.Entity;

namespace QuanLySinhVien
{
    public partial class LoginForm : Form
    {
        public string LoggedInUsername { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = (txtUsername.Text ?? string.Empty).Trim();
            var password = txtPassword.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new SurveyDbContext())
                {
                    var authService = new Services.AuthService(db);
                    bool needsUpgrade;
                    
                    try 
                    {
                        var tk = authService.Authenticate(username, password, out needsUpgrade);
                        if (tk != null)
                        {
                            // Lazy Migration
                            if (needsUpgrade)
                            {
                                try { authService.UpgradePassword(tk.MaTaiKhoan, PasswordHelper.HashPassword(password)); }
                                catch { /* Ignore */ }
                            }

                            LoggedInUsername = tk.TenDangNhap;
                            AuthContext.Username = tk.TenDangNhap;
                            AuthContext.Role = (tk.QuyenHan ?? string.Empty).Trim();
                            AuthContext.MaSinhVien = tk.MaSV;

                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                         MessageBox.Show("Mật khẩu không đúng.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }
                }
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi hệ thống: " + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
