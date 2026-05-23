using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien.Services
{
    public class StudentJobService
    {
        private readonly SurveyDbContext _db;
        public StudentJobService(SurveyDbContext db)
        {
            _db = db;
        }

        // SinhVien CRUD
        public IEnumerable<SV> GetSinhViens()
        {
            // Include NganhHoc và KhoaHoc (Lop deleted)
            return _db.SinhViens
                .Include(s => s.NganhHoc)
                .Include(s => s.KhoaHoc)
                //.Include(s => s.Lop)
                .OrderByDescending(s => s.MaSV)
                .ToList();
        }

        public SV GetSinhVien(string maSv)
        {
            return _db.SinhViens.FirstOrDefault(s => s.MaSV == maSv);
        }

        public bool SinhVienExists(string maSv)
        {
            return _db.SinhViens.Any(s => s.MaSV == maSv);
        }

        public IEnumerable<NganhHoc> GetNganhHocs()
        {
            return _db.NganhHocs.OrderBy(n => n.TenNganh).ToList();
        }

        public IEnumerable<KhoaHoc> GetKhoaHocs()
        {
            return _db.KhoaHocs.OrderBy(k => k.MaKhoaHoc).ToList();
        }

        // GetLops method removed as table Lop is deleted

        // Lấy danh sách SV với thông tin hiển thị đầy đủ (tiếng Việt)
        public List<SinhVienDisplay> GetSinhViensForDisplay()
        {
            return _db.SinhViens
                .Include(s => s.NganhHoc)
                .Include(s => s.KhoaHoc)
                //.Include(s => s.Lop)
                .OrderByDescending(s => s.MaSV)
                .ToList()
                .Select(s => new SinhVienDisplay
                {
                    MaSV = s.MaSV,
                    HoTen = s.HoTen,
                    NgaySinh = s.NgaySinh,
                    Email = s.EmailCaNhan,
                    SoDienThoai = s.SoDienThoai,

                    TenNganh = s.NganhHoc?.TenNganh ?? "",
                    NienKhoa = s.KhoaHoc?.NienKhoa ?? "",
                    TenLop = s.MaLop ?? ""
                })
                .ToList();
        }

        public async Task<List<SinhVienDisplay>> GetSinhViensForDisplayAsync()
        {
            var list = await _db.SinhViens
                .Include(s => s.NganhHoc)
                .Include(s => s.KhoaHoc)
                //.Include(s => s.Lop)
                .OrderByDescending(s => s.MaSV)
                .ToListAsync();

            return list.Select(s => new SinhVienDisplay
            {
                MaSV = s.MaSV,
                HoTen = s.HoTen,
                NgaySinh = s.NgaySinh,
                Email = s.EmailCaNhan,
                SoDienThoai = s.SoDienThoai,

                TenNganh = s.NganhHoc?.TenNganh ?? "",
                NienKhoa = s.KhoaHoc?.NienKhoa ?? "",
                TenLop = s.MaLop ?? ""
            }).ToList();
        }

        // Lấy lịch sử công tác của một sinh viên
        public List<LichSuCongTacDisplay> GetLichSuCongTacForDisplay(string maSV)
        {
            return _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Where(l => l.MaSV == maSV)
                .OrderByDescending(l => l.NgayBatDau)
                .ToList()
                .Select(l => new LichSuCongTacDisplay
                {
                    MaLichSu = l.MaLichSu,
                    TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = l.ViTriCongViec,
                    NgayBatDau = l.NgayBatDau,
                    NgayKetThuc = l.NgayKetThuc,
                    TrangThai = l.TrangThaiXacThuc
                })
                .ToList();
        }

        public void SaveSinhVien(SV sv)
        {
            var tracked = _db.SinhViens.Find(sv.MaSV);
            if (tracked == null) _db.SinhViens.Add(sv);
            else _db.Entry(tracked).CurrentValues.SetValues(sv);
            _db.SaveChanges();
        }

        public void DeleteSinhVien(string maSv)
        {
            var sv = _db.SinhViens.Find(maSv);
            if (sv != null)
            {
                // 1. Xóa kết quả khảo sát
                var ketQuas = _db.KetQuaKhaoSats.Where(x => x.MaSV == maSv).ToList();
                _db.KetQuaKhaoSats.RemoveRange(ketQuas);

                // 2. Xóa phân công khảo sát (nếu có)
                var phanCongs = _db.PhanCongKhaoSats.Where(x => x.MaSV == maSv).ToList();
                _db.PhanCongKhaoSats.RemoveRange(phanCongs);

                // 3. Xóa lịch sử công tác (và phản hồi xác thực liên quan)
                var lichSus = _db.LichSuCongTacs.Where(x => x.MaSV == maSv).ToList();
                foreach (var ls in lichSus)
                {
                    var phanHois = _db.PhanHoiXacThucTams.Where(p => p.MaLichSu == ls.MaLichSu).ToList();
                    _db.PhanHoiXacThucTams.RemoveRange(phanHois);
                }
                _db.LichSuCongTacs.RemoveRange(lichSus);

                // 4. Xóa tài khoản quản trị (nếu sinh viên có tài khoản)
                var taiKhoans = _db.TaiKhoanQuanTris.Where(x => x.MaSV == maSv).ToList();
                _db.TaiKhoanQuanTris.RemoveRange(taiKhoans);

                // 5. Xóa sinh viên
                _db.SinhViens.Remove(sv);
                
                _db.SaveChanges();
            }
        }

        public IEnumerable<ViecLam> GetViecLamsBySinhVien(string maSv) => new List<ViecLam>();
        public void SaveViecLam(ViecLam vl) { }
        public void DeleteViecLam(int id) { }

        // LichSuCongTac CRUD
        public LichSuCongTac GetLichSuCongTac(int id)
        {
            return _db.LichSuCongTacs.Find(id);
        }

        public void SaveLichSuCongTac(LichSuCongTac ls)
        {
            var tracked = _db.LichSuCongTacs.Find(ls.MaLichSu);
            if (tracked == null) _db.LichSuCongTacs.Add(ls);
            else _db.Entry(tracked).CurrentValues.SetValues(ls);
            _db.SaveChanges();
        }

        public void DeleteLichSuCongTac(int id)
        {
            var ls = _db.LichSuCongTacs.Find(id);
            if (ls != null)
            {
                _db.LichSuCongTacs.Remove(ls);
                _db.SaveChanges();
            }
        }

        // DoanhNghiep CRUD
        public DoanhNghiep GetDoanhNghiep(int id)
        {
            return _db.DoanhNghieps.Find(id);
        }

        public void SaveDoanhNghiep(DoanhNghiep dn)
        {
            var tracked = _db.DoanhNghieps.Find(dn.MaDN);
            if (tracked == null) _db.DoanhNghieps.Add(dn);
            else _db.Entry(tracked).CurrentValues.SetValues(dn);
            _db.SaveChanges();
        }

        public void DeleteDoanhNghiep(int id)
        {
            var dn = _db.DoanhNghieps.Find(id);
            if (dn != null)
            {
                // 1. Xóa lịch sử công tác liên quan (và phản hồi xác thực con của nó)
                var lichSus = _db.LichSuCongTacs.Where(x => x.MaDN == id).ToList();
                foreach (var ls in lichSus)
                {
                    var phanHois = _db.PhanHoiXacThucTams.Where(p => p.MaLichSu == ls.MaLichSu).ToList();
                    _db.PhanHoiXacThucTams.RemoveRange(phanHois);
                }
                _db.LichSuCongTacs.RemoveRange(lichSus);

                // 2. Xóa doanh nghiệp
                _db.DoanhNghieps.Remove(dn);
                _db.SaveChanges();
            }
        }


    }

    // DTO để hiển thị sinh viên với tên cột tiếng Việt
    public class SinhVienDisplay
    {
        [System.ComponentModel.DisplayName("Mã SV")]
        public string MaSV { get; set; }

        [System.ComponentModel.DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [System.ComponentModel.DisplayName("Ngày sinh")]
        public System.DateTime? NgaySinh { get; set; }

        [System.ComponentModel.DisplayName("Email")]
        public string Email { get; set; }

        [System.ComponentModel.DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }



        // TinhTrang removed - not part of thesis requirements

        [System.ComponentModel.DisplayName("Ngành học")]
        public string TenNganh { get; set; }

        [System.ComponentModel.DisplayName("Niên khóa")]
        public string NienKhoa { get; set; }

        [System.ComponentModel.DisplayName("Lớp")]
        public string TenLop { get; set; }
    }

    // DTO để hiển thị lịch sử công tác với tên cột tiếng Việt
    public class LichSuCongTacDisplay
    {
        [System.ComponentModel.DisplayName("Mã")]
        public int MaLichSu { get; set; }

        [System.ComponentModel.DisplayName("Doanh nghiệp")]
        public string TenDoanhNghiep { get; set; }

        [System.ComponentModel.DisplayName("Vị trí công việc")]
        public string ViTriCongViec { get; set; }

        [System.ComponentModel.DisplayName("Ngày bắt đầu")]
        public System.DateTime? NgayBatDau { get; set; }

        [System.ComponentModel.DisplayName("Ngày kết thúc")]
        public System.DateTime? NgayKetThuc { get; set; }

        [System.ComponentModel.DisplayName("Trạng thái")]
        public string TrangThai { get; set; }
    }
}
