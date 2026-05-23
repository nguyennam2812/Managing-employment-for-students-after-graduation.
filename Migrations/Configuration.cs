using System.Data.Entity.Migrations;
using QuanLySinhVien.Data;

namespace QuanLySinhVien.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Không seed tài khoản mặc định ở UserAccount nữa.
            // Việc đăng nhập/ủy quyền đã chuyển sang bảng TaiKhoanQuanTri.
        }
    }
}
