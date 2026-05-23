using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using QuanLySinhVien.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Data.Entity.Migrations;

namespace QuanLySinhVien.Data
{
    public class ApplicationDbContext : DbContext
    {
        static ApplicationDbContext()
        {
            // Disable auto migrations/initializers; manage schema via SQL or manual migrations
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
        }

        public ApplicationDbContext() : base(SqlConnectionFactory.CreateDefault(), true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<CoQuan> CoQuans { get; set; }
        public DbSet<ViecLam> ViecLams { get; set; }
        public DbSet<MucLuong> MucLuongs { get; set; }
        public DbSet<ThongBaoLich> ThongBaoLiches { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Keep table names as provided
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        private class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                // Seed default admin user if none exists
                if (!context.UserAccounts.Any())
                {
                    // Admin
                    AddUser(context, "admin", "admin123", "Admin");
                    // Phòng đào tạo (quản trị dữ liệu)
                    AddUser(context, "pdt", "pdt123", "PhongDaoTao");
                    // Người xem/SinhVien: chỉ xem
                    AddUser(context, "viewer", "viewer123", "Viewer");
                    AddUser(context, "sv", "sv123", "SinhVien");
                }

                base.Seed(context);
            }

            private static string GenerateSalt()
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    var saltBytes = new byte[16];
                    rng.GetBytes(saltBytes);
                    return System.Convert.ToBase64String(saltBytes);
                }
            }

            private static string HashPassword(string password, string salt)
            {
                using (var sha = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(password + salt);
                    var hash = sha.ComputeHash(bytes);
                    return System.Convert.ToBase64String(hash);
                }
            }

            private static void AddUser(ApplicationDbContext context, string username, string password, string role)
            {
                var salt = GenerateSalt();
                var hash = HashPassword(password, salt);
                context.UserAccounts.Add(new UserAccount
                {
                    Username = username,
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    Role = role,
                    IsActive = true
                });
            }
        }
    }
}
