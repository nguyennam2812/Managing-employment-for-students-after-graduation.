using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using QuanLySinhVien.Security;

namespace QuanLySinhVien
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ensure schema on startup unless explicitly skipped (useful for remote SQL)
            var skipBootstrap = string.Equals(ConfigurationManager.AppSettings["SkipSchemaBootstrap"], "true", StringComparison.OrdinalIgnoreCase);
            if (!skipBootstrap)
            {
                try
                {
                    global::QuanLySinhVien.Data.DatabaseBootstrapper.EnsureAuthSchema();
                    // Ensure schema that matches the provided database diagram
                    global::QuanLySinhVien.Data.DatabaseBootstrapper.EnsureSurveySchema();
                }
                catch (Exception ex)
                {
                    var root = ex;
                    while (root.InnerException != null) root = root.InnerException;
                    MessageBox.Show(
                        "Không thể khởi tạo CSDL. Kiểm tra quyền trên SQL Server hoặc ConnectionString.\n\n" +
                        $"Lỗi: {root.Message}",
                        "Lỗi khởi tạo CSDL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            
            RunLoginLoop();
        }

        private static void RunLoginLoop()
        {
            while (true)
            {
                using (var login = new LoginForm())
                {
                    var result = login.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        // Người dùng hủy đăng nhập -> thoát ứng dụng
                        return;
                    }
                }

                try
                {
                    // Kiểm tra role và mở form tương ứng
                    if (AuthContext.IsStudent)
                    {
                        // Sinh viên: Mở form khảo sát riêng
                        using (var frmSV = new StudentDashboardForm())
                        {
                            var dialogResult = frmSV.ShowDialog();
                            
                            // Nếu sinh viên đăng xuất (DialogResult.Abort), quay lại vòng lặp đăng nhập
                            if (dialogResult == DialogResult.Abort)
                            {
                                continue;
                            }
                        }
                        // Nếu sinh viên đóng form thông thường, thoát ứng dụng
                        return;
                    }
                    else
                    {
                        // Admin/Giáo viên: Mở MainForm
                        using (var mainForm = new MainForm())
                        {
                            var mainResult = mainForm.ShowDialog();
                            
                            // Nếu đăng xuất (DialogResult.Retry), quay lại vòng lặp đăng nhập
                            if (mainResult == DialogResult.Retry)
                            {
                                continue;
                            }
                        }
                        // Nếu đóng form thông thường, thoát ứng dụng
                        return;
                    }
                }
                catch (Exception ex)
                {
                    var root = ex;
                    while (root.InnerException != null) root = root.InnerException;
                    MessageBox.Show(
                        "Lỗi khi khởi tạo Form:\n\n" +
                        $"Lỗi: {root.Message}\n\n" +
                        $"Stack Trace: {root.StackTrace}",
                        "Lỗi khởi tạo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
