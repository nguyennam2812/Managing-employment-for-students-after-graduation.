using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySinhVien.Models
{
    [Table("UserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }

        [Required]
        [MaxLength(100)] public string Username { get; set; }

        [Required]
        [MaxLength(512)] public string PasswordHash { get; set; }

        [MaxLength(256)] public string PasswordSalt { get; set; }

        [MaxLength(50)] public string Role { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    [Table("Khoa")]
    public class Khoa
    {
        [Key]
        public int KhoaId { get; set; }
        [MaxLength(50)] public string MaKhoa { get; set; }
        [MaxLength(255)] public string TenKhoa { get; set; }
        [MaxLength(1000)] public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Lop> Lops { get; set; }
    }

    [Table("KhoaHoc")]
    public class KhoaHoc
    {
        [Key]
        public int KhoaHocId { get; set; }
        [MaxLength(50)] public string MaKhoaHoc { get; set; }
        public int NamBatDau { get; set; }
        [MaxLength(1000)] public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Lop> Lops { get; set; }
    }

    [Table("Lop")]
    public class Lop
    {
        [Key]
        public int LopId { get; set; }
        [MaxLength(50)] public string MaLop { get; set; }
        [MaxLength(255)] public string TenLop { get; set; }

        public int KhoaId { get; set; }
        [ForeignKey(nameof(KhoaId))] public virtual Khoa Khoa { get; set; }

        public int KhoaHocId { get; set; }
        [ForeignKey(nameof(KhoaHocId))] public virtual KhoaHoc KhoaHoc { get; set; }

        [MaxLength(1000)] public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }

    [Table("SinhVien")]
    public class SinhVien
    {
        [Key]
        public int SinhVienId { get; set; }
        [MaxLength(50)] public string MaSV { get; set; }
        [MaxLength(255)] public string HoTen { get; set; }
        [MaxLength(10)] public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        [MaxLength(255)] public string Email { get; set; }
        [MaxLength(255)] public string FacebookId { get; set; }
        [MaxLength(30)] public string DienThoai { get; set; }

        public int? KhoaId { get; set; }
        [ForeignKey(nameof(KhoaId))] public virtual Khoa Khoa { get; set; }

        public int? KhoaHocId { get; set; }
        [ForeignKey(nameof(KhoaHocId))] public virtual KhoaHoc KhoaHoc { get; set; }

        public int? LopId { get; set; }
        [ForeignKey(nameof(LopId))] public virtual Lop Lop { get; set; }


        [MaxLength(500)] public string DiaChi { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ViecLam> ViecLams { get; set; }
    }

    [Table("CoQuan")]
    public class CoQuan
    {
        [Key]
        public int CoQuanId { get; set; }
        [MaxLength(255)] public string TenCoQuan { get; set; }
        [MaxLength(255)] public string NganhNghe { get; set; }
        [MaxLength(500)] public string DiaChi { get; set; }
        [MaxLength(255)] public string Website { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ViecLam> ViecLams { get; set; }
    }

    [Table("ViecLam")]
    public class ViecLam
    {
        [Key]
        public int ViecLamId { get; set; }

        public int SinhVienId { get; set; }
        [ForeignKey(nameof(SinhVienId))] public virtual SinhVien SinhVien { get; set; }

        public int? CoQuanId { get; set; }
        [ForeignKey(nameof(CoQuanId))] public virtual CoQuan CoQuan { get; set; }

        [MaxLength(255)] public string TenCoQuanTuyDo { get; set; }
        [MaxLength(255)] public string ChucDanh { get; set; }
        [MaxLength(2000)] public string MoTaCongViec { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public decimal? Luong { get; set; }
        [MaxLength(10)] public string DonViTienTe { get; set; }
        public bool? DungChuyenNganh { get; set; }
        [MaxLength(100)] public string LoaiHinh { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    [Table("MucLuong")]
    public class MucLuong
    {
        [Key]
        public int MucLuongId { get; set; }
        [MaxLength(100)] public string Nhan { get; set; }
        public decimal? MinLuong { get; set; }
        public decimal? MaxLuong { get; set; }
        public int ThuTu { get; set; }
    }

    [Table("ThongBaoLich")]
    public class ThongBaoLich
    {
        [Key]
        public int ThongBaoLichId { get; set; }
        public int SinhVienId { get; set; }
        [ForeignKey(nameof(SinhVienId))] public virtual SinhVien SinhVien { get; set; }

        // Kenh: Email, Facebook, Zalo, ...
        [MaxLength(50)] public string Kenh { get; set; }
        // TanSuat: Monthly, Quarterly, Yearly
        [MaxLength(50)] public string TanSuat { get; set; }
        public bool Active { get; set; }
        public DateTime? NextRunAt { get; set; }
        public DateTime? LastRunAt { get; set; }
        [MaxLength(500)] public string GhiChu { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    [Table("AuditLog")]
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TableName { get; set; }

        [Required]
        [MaxLength(50)]
        public string RecordId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Action { get; set; } // Update, Insert, Delete

        public string OldValue { get; set; } // JSON or Description
        public string NewValue { get; set; } // JSON or Description

        [MaxLength(100)]
        public string ChangedBy { get; set; }

        public DateTime ChangedDate { get; set; } = DateTime.UtcNow;
    }
}
