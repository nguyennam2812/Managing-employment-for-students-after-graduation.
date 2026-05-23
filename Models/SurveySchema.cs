using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySinhVien.Schema
{
    // =============== Danh mục chính ===============

    [Table("SinhVien")]
    public class SV
    {
        [Key]
        [Column("MaSV")]
        [MaxLength(10)]
        public string MaSV { get; set; }

        [MaxLength(100)] public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }

        [Column("EmailCaNhan")]
        [MaxLength(100)] public string EmailCaNhan { get; set; }

        [Column("SoDienThoai")]
        [MaxLength(15)] public string SoDienThoai { get; set; }



        // TinhTrangViecLam removed - derived from LichSuCongTac instead

        [Column("MaNganh")]
        [MaxLength(10)] public string MaNganh { get; set; }

        [Column("MaKhoaHoc")]
        [MaxLength(10)] public string MaKhoaHoc { get; set; }

        [ForeignKey(nameof(MaNganh))]
        public virtual NganhHoc NganhHoc { get; set; }

        [ForeignKey(nameof(MaKhoaHoc))]
        public virtual KhoaHoc KhoaHoc { get; set; }

        [Column("MaLop")]
        [MaxLength(20)] public string MaLop { get; set; }

        //[ForeignKey(nameof(MaLop))]
        //public virtual Lop Lop { get; set; }

        public virtual ICollection<LichSuCongTac> LichSuCongTacs { get; set; }
        public virtual ICollection<KetQuaKhaoSat> KetQuaKhaoSats { get; set; }
    }

    [Table("NganhHoc")]
    public class NganhHoc
    {
        [Key]
        [Column("MaNganh")]
        [MaxLength(10)] public string MaNganh { get; set; }

        [MaxLength(100)] public string TenNganh { get; set; }

        public virtual ICollection<SV> SinhViens { get; set; }
    }

    [Table("KhoaHoc")]
    public class KhoaHoc
    {
        [Key]
        [Column("MaKhoaHoc")]
        [MaxLength(10)] public string MaKhoaHoc { get; set; }

        [MaxLength(20)] public string NienKhoa { get; set; }

        public virtual ICollection<SV> SinhViens { get; set; }
        //public virtual ICollection<Lop> Lops { get; set; }
    }

    // Lop table deleted


    [Table("DoanhNghiep")]
    public class DoanhNghiep
    {
        [Key]
        [Column("MaDN")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDN { get; set; }

        [Column("TenDN")]
        [MaxLength(255)] public string TenDN { get; set; }

        [MaxLength(500)] public string DiaChi { get; set; }

        [Column("LinhVucHoatDong")]
        [MaxLength(100)] public string LinhVucHoatDong { get; set; }

        [Column("EmailLienHe")]
        [MaxLength(100)] public string EmailLienHe { get; set; }

        [Column("SoDienThoai")]
        [MaxLength(20)] public string SoDienThoai { get; set; }

        public virtual ICollection<LichSuCongTac> LichSuCongTacs { get; set; }
    }

    // =============== Nghiệp vụ việc làm ===============

    [Table("LichSuCongTac")]
    public class LichSuCongTac
    {
        [Key]
        [Column("MaLichSu")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLichSu { get; set; }

        [Column("MaSV")]
        [MaxLength(10)] public string MaSV { get; set; }

        [Column("MaDN")]
        public int MaDN { get; set; }

        [MaxLength(100)]
        [Column("ViTriCongViec")]
        public string ViTriCongViec { get; set; }

        [Column("NgayBatDau")]
        public DateTime? NgayBatDau { get; set; }

        [Column("NgayKetThuc")]
        public DateTime? NgayKetThuc { get; set; }

        [MaxLength(30)]
        [Column("TrangThaiXacThuc")]
        public string TrangThaiXacThuc { get; set; }

        // ========== Cột mới phục vụ thống kê ==========
        
        /// <summary>
        /// Mức lương (VND)
        /// </summary>
        [Column("MucLuong")]
        public decimal? MucLuong { get; set; }

        /// <summary>
        /// Đúng chuyên ngành: true = đúng ngành, false = trái ngành
        /// </summary>
        [Column("DungChuyenNganh")]
        public bool? DungChuyenNganh { get; set; }

        /// <summary>
        /// Trạng thái việc làm: Đang làm, Đã nghỉ
        /// </summary>
        [MaxLength(50)]
        [Column("TrangThai")]
        public string TrangThai { get; set; }

        [ForeignKey(nameof(MaSV))]
        public virtual SV SinhVien { get; set; }

        [ForeignKey(nameof(MaDN))]
        public virtual DoanhNghiep DoanhNghiep { get; set; }

        public virtual ICollection<PhanHoiXacThucTam> PhanHoiXacThucTams { get; set; }
    }

    [Table("PhanHoiXacThucTam")]
    public class PhanHoiXacThucTam
    {
        [Key]
        [Column("MaPhanHoi")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhanHoi { get; set; }

        [Column("MaLichSu")]
        public int MaLichSu { get; set; }

        public DateTime? NgayPhanHoi { get; set; }

        [MaxLength(30)] public string TrangThaiPhanHoi { get; set; }
        public bool DaXuLy { get; set; }
        
        public string NoiDungChiTiet { get; set; }

        [ForeignKey(nameof(MaLichSu))]
        public virtual LichSuCongTac LichSuCongTac { get; set; }
    }

    // =============== Khảo sát ===============

    [Table("PhieuKhaoSat")]
    public class PhieuKhaoSat
    {
        [Key]
        [Column("MaPhieu")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhieu { get; set; }

        [MaxLength(255)] public string TenDotKhaoSat { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayHetHan { get; set; }
        [MaxLength(30)] public string TrangThaiPhieu { get; set; }

        public string NoiDungCauHoi { get; set; } // JSON or text format

        public virtual ICollection<KetQuaKhaoSat> KetQuaKhaoSats { get; set; }
    }

    [Table("KetQuaKhaoSat")]
    public class KetQuaKhaoSat
    {
        [Key]
        [Column("MaKetQua")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKetQua { get; set; }

        [Column("MaPhieu")]
        public int MaPhieu { get; set; }

        [Column("MaSV")]
        [MaxLength(10)] public string MaSV { get; set; }

        public DateTime NgayTraLoi { get; set; }

        public string NoiDungChiTiet { get; set; }

        [ForeignKey(nameof(MaPhieu))]
        public virtual PhieuKhaoSat PhieuKhaoSat { get; set; }

        [ForeignKey(nameof(MaSV))]
        public virtual SV SinhVien { get; set; }
    }

    [Table("PhanCongKhaoSat")]
    public class PhanCongKhaoSat
    {
        [Key]
        [Column("MaPhanCong")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhanCong { get; set; }

        [Column("MaPhieu")]
        public int MaPhieu { get; set; }

        [Column("MaSV")]
        [MaxLength(10)] public string MaSV { get; set; }

        public DateTime NgayPhanCong { get; set; }

        [ForeignKey(nameof(MaPhieu))]
        public virtual PhieuKhaoSat PhieuKhaoSat { get; set; }

        [ForeignKey(nameof(MaSV))]
        public virtual SV SinhVien { get; set; }
    }

    // =============== Tạm/Phân tích ===============

    [Table("DuLieuPhanTichTam")]
    public class DuLieuPhanTichTam
    {
        [Key]
        [Column("MaPhien")]
        [MaxLength(50)] public string MaPhien { get; set; }

        [MaxLength(100)] public string TenThongKe { get; set; }

        [MaxLength(255)] public string GiaTri { get; set; }

        public DateTime NgayTao { get; set; }
    }

    // =============== Placeholder (không map bảng) cho phần UI cũ ===============
    [NotMapped]
    public class ViecLam
    {
        [MaxLength(10)] public string MaSV { get; set; }
        [MaxLength(100)] public string ViTriCongViec { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public bool? DungChuyenNganh { get; set; }
    }

    [NotMapped]
    public class ThongBaoLich
    {
        public int ThongBaoLichId { get; set; }
        public bool Active { get; set; }
        public DateTime? NextRunAt { get; set; }
        public DateTime? LastRunAt { get; set; }
        [MaxLength(500)] public string GhiChu { get; set; }
    }

    [Table("TaiKhoanQuanTri")]
    public class TaiKhoanQuanTri
    {
        [Key]
        [Column("MaTaiKhoan")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiKhoan { get; set; }

        [Column("TenDangNhap")]
        [MaxLength(50)] public string TenDangNhap { get; set; }

        [Column("MatKhau")]
        [MaxLength(255)] public string MatKhau { get; set; }

        [MaxLength(100)] public string HoTenNguoiDung { get; set; }
        [MaxLength(20)] public string QuyenHan { get; set; }

        // Liên kết với sinh viên (chỉ dùng cho role SinhVien)
        [Column("MaSV")]
        [MaxLength(10)] public string MaSV { get; set; }

        [ForeignKey(nameof(MaSV))]
        public virtual SV SinhVien { get; set; }
    }
}
