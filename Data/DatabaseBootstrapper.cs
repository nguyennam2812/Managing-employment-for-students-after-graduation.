using System.Data.Entity;

namespace QuanLySinhVien.Data
{
    public static class DatabaseBootstrapper
    {
        public static void EnsureAuthSchema()
        {
            return;
        }

        public static void EnsureSurveySchema()
        {
            using (var ctx = new SurveyDbContext())
            {
                var sql = @"
-- ========== Danh muc ==========
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NganhHoc]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[NganhHoc](
        [MaNganh] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [TenNganh] NVARCHAR(255) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KhoaHoc]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[KhoaHoc](
        [MaKhoaHoc] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [NienKhoa] NVARCHAR(100) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SinhVien]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[SinhVien](
        [MaSV] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [HoTen] NVARCHAR(255) NULL,
        [NgaySinh] DATETIME NULL,
        [EmailCaNhan] NVARCHAR(255) NULL,
        [SoDienThoai] NVARCHAR(30) NULL,
        [NamTotNghiep] INT NULL,
        -- [TinhTrangViecLam] removed - not part of thesis requirements
        [MaNganh] NVARCHAR(50) NULL,
        [MaKhoaHoc] NVARCHAR(50) NULL,
        [MaLop] NVARCHAR(50) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SinhVien_NganhHoc')
BEGIN
    ALTER TABLE [dbo].[SinhVien]
    ADD CONSTRAINT [FK_SinhVien_NganhHoc]
        FOREIGN KEY ([MaNganh]) REFERENCES [dbo].[NganhHoc]([MaNganh]);
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SinhVien_KhoaHoc')
BEGIN
    ALTER TABLE [dbo].[SinhVien]
    ADD CONSTRAINT [FK_SinhVien_KhoaHoc]
        FOREIGN KEY ([MaKhoaHoc]) REFERENCES [dbo].[KhoaHoc]([MaKhoaHoc]);
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DoanhNghiep]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[DoanhNghiep](
        [MaDN] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [TenDN] NVARCHAR(255) NULL,
        [DiaChi] NVARCHAR(500) NULL,
        [LinhVucHoatDong] NVARCHAR(255) NULL,
        [EmailLienHe] NVARCHAR(255) NULL,
        [SoDienThoai] NVARCHAR(20) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LichSuCongTac]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[LichSuCongTac](
        [MaLichSu] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [MaSV] NVARCHAR(50) NULL,
        [MaDN] INT NULL,
        [ViTriCongViec] NVARCHAR(255) NULL,
        [NgayBatDau] DATETIME NULL,
        [NgayKetThuc] DATETIME NULL,
        [TrangThaiXacThuc] NVARCHAR(100) NULL,
        [MucLuong] DECIMAL(18,2) NULL,
        [DungChuyenNganh] BIT NULL,
        [TrangThai] NVARCHAR(50) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_LichSuCongTac_SinhVien')
BEGIN
    ALTER TABLE [dbo].[LichSuCongTac]
    ADD CONSTRAINT [FK_LichSuCongTac_SinhVien]
        FOREIGN KEY ([MaSV]) REFERENCES [dbo].[SinhVien]([MaSV]);
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_LichSuCongTac_DoanhNghiep')
BEGIN
    ALTER TABLE [dbo].[LichSuCongTac]
    ADD CONSTRAINT [FK_LichSuCongTac_DoanhNghiep]
        FOREIGN KEY ([MaDN]) REFERENCES [dbo].[DoanhNghiep]([MaDN]);
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhanHoiXacThucTam]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[PhanHoiXacThucTam](
        [MaPhanHoi] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [MaLichSu] NVARCHAR(50) NULL,
        [NgayPhanHoi] DATETIME NULL,
        [TrangThaiPhanHoi] NVARCHAR(100) NULL,
        [DaXuLy] BIT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_PhanHoiXacThucTam_LichSuCongTac')
BEGIN
    ALTER TABLE [dbo].[PhanHoiXacThucTam]
    ADD CONSTRAINT [FK_PhanHoiXacThucTam_LichSuCongTac]
        FOREIGN KEY ([MaLichSu]) REFERENCES [dbo].[LichSuCongTac]([MaLichSu]);
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuKhaoSat]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[PhieuKhaoSat](
        [MaPhieu] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [TenDotKhaoSat] NVARCHAR(255) NULL,
        [NgayTao] DATETIME NULL,
        [NgayHetHan] DATETIME NULL,
        [TrangThaiPhieu] NVARCHAR(100) NULL,
        [NoiDungCauHoi] NVARCHAR(MAX) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KetQuaKhaoSat]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[KetQuaKhaoSat](
        [MaKetQua] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [MaPhieu] NVARCHAR(50) NULL,
        [MaSV] NVARCHAR(50) NULL,
        [NgayTraLoi] DATETIME NULL,
        [NoiDungChiTiet] NVARCHAR(2000) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_KetQuaKhaoSat_PhieuKhaoSat')
BEGIN
    ALTER TABLE [dbo].[KetQuaKhaoSat]
    ADD CONSTRAINT [FK_KetQuaKhaoSat_PhieuKhaoSat]
        FOREIGN KEY ([MaPhieu]) REFERENCES [dbo].[PhieuKhaoSat]([MaPhieu]);
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_KetQuaKhaoSat_SinhVien')
BEGIN
    ALTER TABLE [dbo].[KetQuaKhaoSat]
    ADD CONSTRAINT [FK_KetQuaKhaoSat_SinhVien]
        FOREIGN KEY ([MaSV]) REFERENCES [dbo].[SinhVien]([MaSV]);
END

-- Fix: Drop table to ensure clean state for dynamic creation
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhanCongKhaoSat]') AND type = N'U')
BEGIN
    DROP TABLE [dbo].[PhanCongKhaoSat];
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhanCongKhaoSat]') AND type = N'U')
BEGIN
    -- Dynamic SQL to get exact MaSV type from SinhVien
    DECLARE @MaSVType NVARCHAR(128);
    
    SELECT @MaSVType = 
        TYPE_NAME(system_type_id) + 
        CASE 
            WHEN system_type_id IN (231, 239) AND max_length = -1 THEN '(MAX)' -- nvarchar/nchar
            WHEN system_type_id IN (231, 239) THEN '(' + CAST(max_length/2 AS VARCHAR) + ')' 
            WHEN system_type_id IN (167, 175) AND max_length = -1 THEN '(MAX)' -- varchar/char
            WHEN system_type_id IN (167, 175) THEN '(' + CAST(max_length AS VARCHAR) + ')'
            ELSE ''
        END
    FROM sys.columns 
    WHERE object_id = OBJECT_ID(N'[dbo].[SinhVien]') AND name = 'MaSV';

    -- Default if not found (shouldn't happen if SinhVien exists)
    IF @MaSVType IS NULL SET @MaSVType = 'NVARCHAR(50)';

    DECLARE @Sql NVARCHAR(MAX);
    SET @Sql = 'CREATE TABLE [dbo].[PhanCongKhaoSat](
        [MaPhanCong] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [MaPhieu] INT NOT NULL,
        [MaSV] ' + @MaSVType + ' NULL,
        [NgayPhanCong] DATETIME NULL
    )';
    
    EXEC sp_executesql @Sql;
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_PhanCongKhaoSat_PhieuKhaoSat')
BEGIN
    ALTER TABLE [dbo].[PhanCongKhaoSat]
    ADD CONSTRAINT [FK_PhanCongKhaoSat_PhieuKhaoSat]
        FOREIGN KEY ([MaPhieu]) REFERENCES [dbo].[PhieuKhaoSat]([MaPhieu]);
END

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_PhanCongKhaoSat_SinhVien')
BEGIN
    ALTER TABLE [dbo].[PhanCongKhaoSat]
    ADD CONSTRAINT [FK_PhanCongKhaoSat_SinhVien]
        FOREIGN KEY ([MaSV]) REFERENCES [dbo].[SinhVien]([MaSV]);
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DuLieuPhanTichTam]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[DuLieuPhanTichTam](
        [MaPhien] NVARCHAR(50) NOT NULL PRIMARY KEY,
        [TenThongKe] NVARCHAR(255) NULL,
        [GiaTri] NVARCHAR(2000) NULL,
        [NgayTao] DATETIME NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoanQuanTri]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[TaiKhoanQuanTri](
        [MaTaiKhoan] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [TenDangNhap] NVARCHAR(50) NOT NULL,
        [MatKhau] NVARCHAR(255) NOT NULL,
        [HoTenNguoiDung] NVARCHAR(100) NULL,
        [QuyenHan] NVARCHAR(20) NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog]') AND type = N'U')
BEGIN
    CREATE TABLE [dbo].[AuditLog](
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [TableName] NVARCHAR(50) NOT NULL,
        [RecordId] NVARCHAR(50) NOT NULL,
        [Action] NVARCHAR(20) NOT NULL,
        [OldValue] NVARCHAR(MAX) NULL,
        [NewValue] NVARCHAR(MAX) NULL,
        [ChangedBy] NVARCHAR(100) NULL,
        [ChangedDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
    );
END
";

                ctx.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
            }
        }
    }
}
