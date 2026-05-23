using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using QuanLySinhVien.Schema;
using AuditLog = QuanLySinhVien.Models.AuditLog;

namespace QuanLySinhVien.Data
{
    // DbContext ánh xạ 1-1 với sơ đồ bạn gửi
    public class SurveyDbContext : DbContext
    {
        static SurveyDbContext()
        {
            Database.SetInitializer<SurveyDbContext>(null);
        }

        public SurveyDbContext() : base(SqlConnectionFactory.CreateDefault(), true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<SV> SinhViens { get; set; }
        public DbSet<NganhHoc> NganhHocs { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        //public DbSet<Lop> Lops { get; set; } // Deleted Table
        public DbSet<DoanhNghiep> DoanhNghieps { get; set; }
        public DbSet<LichSuCongTac> LichSuCongTacs { get; set; }
        public DbSet<PhanHoiXacThucTam> PhanHoiXacThucTams { get; set; }
        public DbSet<PhieuKhaoSat> PhieuKhaoSats { get; set; }
        public DbSet<KetQuaKhaoSat> KetQuaKhaoSats { get; set; }
        public DbSet<PhanCongKhaoSat> PhanCongKhaoSats { get; set; }
        public DbSet<DuLieuPhanTichTam> DuLieuPhanTichTams { get; set; }
        public DbSet<TaiKhoanQuanTri> TaiKhoanQuanTris { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
