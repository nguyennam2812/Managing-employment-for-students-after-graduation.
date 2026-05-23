using System;
using System.ComponentModel;

namespace QuanLySinhVien.Services
{
    // Note: SinhVienDisplay và LichSuCongTacDisplay được định nghĩa trong StudentJobService.cs

    // DTO để hiển thị doanh nghiệp
    public class DoanhNghiepDisplay
    {
        [DisplayName("Mã DN")]
        public int MaDN { get; set; }

        [DisplayName("Tên doanh nghiệp")]
        public string TenDN { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Lĩnh vực hoạt động")]
        public string LinhVuc { get; set; }

        [DisplayName("Email liên hệ")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }
    }

    // DTO để hiển thị phiếu khảo sát
    public class PhieuKhaoSatDisplay
    {
        [DisplayName("Mã phiếu")]
        public int MaPhieu { get; set; }

        [DisplayName("Tên đợt khảo sát")]
        public string TenDot { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [DisplayName("Ngày hết hạn")]
        public DateTime? NgayHetHan { get; set; }

        [System.ComponentModel.DisplayName("Trạng thái")]
        public string TrangThai { get; set; }
    }

    // DTO để hiển thị kết quả khảo sát
    // DTO để hiển thị kết quả khảo sát
    public class KetQuaKhaoSatDisplay
    {
        [DisplayName("Mã KQ")]
        public int MaKetQua { get; set; }

        [DisplayName("Mã SV")]
        public string MaSV { get; set; }

        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [DisplayName("Đợt khảo sát")]
        public string TenDotKhaoSat { get; set; }

        [DisplayName("Ngành")]
        public string TenNganh { get; set; }

        [DisplayName("Khóa")]
        public string NienKhoa { get; set; }

        [DisplayName("Ngày trả lời")]
        public DateTime? NgayTraLoi { get; set; }

        [DisplayName("Nội dung")]
        public string NoiDung { get; set; }
    }

    // DTO để hiển thị báo cáo thống kê
    public class ThongKeDisplay
    {
        [DisplayName("Tiêu chí")]
        public string Key { get; set; }

        [DisplayName("Số lượng")]
        public int Count { get; set; }
    }

    // DTO để hiển thị tài khoản
    public class TaiKhoanDisplay
    {
        [DisplayName("Mã TK")]
        public int MaTaiKhoan { get; set; }

        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [DisplayName("Quyền hạn")]
        public string QuyenHan { get; set; }

        [DisplayName("Mã SV")]
        public string MaSV { get; set; }
    }

    // DTO để hiển thị phản hồi xác thực
    public class PhanHoiXacThucDisplay
    {
        [DisplayName("Mã")]
        public int MaPhanHoi { get; set; }

        [DisplayName("Mã lịch sử")]
        public int MaLichSu { get; set; }

        [DisplayName("Ngày phản hồi")]
        public DateTime? NgayPhanHoi { get; set; }

        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; }

        [DisplayName("Đã xử lý")]
        public bool DaXuLy { get; set; }
    }

    // === FILTER MODELS ===

    public class SinhVienFilterModel
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string NganhHoc { get; set; }
        public string KhoaHoc { get; set; }
        public string Lop { get; set; }
        public string TinhTrang { get; set; }
    }

    public class DoanhNghiepFilterModel
    {
        public string TenDN { get; set; }
        public string LinhVuc { get; set; }
        public string DiaChi { get; set; }
    }

    public class LichSuCongTacFilterModel
    {
        public string MaSV { get; set; }
        public string HoTenSV { get; set; }
        public string TenDN { get; set; }
        public string ViTri { get; set; }
        public string TrangThai { get; set; }
    }

    // === DYNAMIC SURVEY MODELS ===
    
    [System.Runtime.Serialization.DataContract]
    public class QuestionItem
    {
        [System.Runtime.Serialization.DataMember]
        public int Id { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Type { get; set; } // Text, Radio, Checkbox, Number

        [System.Runtime.Serialization.DataMember]
        public string Question { get; set; }

        [System.Runtime.Serialization.DataMember]
        public System.Collections.Generic.List<string> Options { get; set; } = new System.Collections.Generic.List<string>();
    }
}
