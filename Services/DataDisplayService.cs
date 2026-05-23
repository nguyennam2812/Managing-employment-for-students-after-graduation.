using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien.Services
{
    /// <summary>
    /// Service cung cấp dữ liệu hiển thị tiếng Việt cho các grid
    /// </summary>
    public class DataDisplayService
    {
        private readonly SurveyDbContext _db;

        public DataDisplayService(SurveyDbContext db)
        {
            _db = db;
        }

        // === SINH VIÊN ===
        public List<SinhVienDisplay> SearchSinhViens(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            return new StudentJobService(_db).GetSinhViensForDisplay()
                .Where(s => q == "" || 
                            s.MaSV.Contains(q) || 
                            s.HoTen.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            (s.TenLop != null && s.TenLop.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();
        }

        public List<SinhVienDisplay> FilterSinhViens(SinhVienFilterModel filter)
        {
            if (filter == null) return new StudentJobService(_db).GetSinhViensForDisplay();
            
            var query = new StudentJobService(_db).GetSinhViensForDisplay().AsQueryable();

            if (!string.IsNullOrEmpty(filter.MaSV)) 
                query = query.Where(s => s.MaSV.Contains(filter.MaSV));
            if (!string.IsNullOrEmpty(filter.HoTen)) 
                query = query.Where(s => s.HoTen.IndexOf(filter.HoTen, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(filter.Email)) 
                query = query.Where(s => s.Email != null && s.Email.Contains(filter.Email));
            if (!string.IsNullOrEmpty(filter.SoDienThoai)) 
                query = query.Where(s => s.SoDienThoai != null && s.SoDienThoai.Contains(filter.SoDienThoai));
            if (!string.IsNullOrEmpty(filter.NganhHoc)) 
                query = query.Where(s => s.TenNganh != null && s.TenNganh.IndexOf(filter.NganhHoc, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(filter.KhoaHoc)) 
                query = query.Where(s => s.NienKhoa != null && s.NienKhoa.Contains(filter.KhoaHoc));
            if (!string.IsNullOrEmpty(filter.Lop)) 
                query = query.Where(s => s.TenLop != null && s.TenLop.IndexOf(filter.Lop, StringComparison.OrdinalIgnoreCase) >= 0);
            // TinhTrang filter removed - not part of thesis requirements

            return query.ToList();
        }

        // === DOANH NGHIỆP ===
        public List<DoanhNghiepDisplay> GetDoanhNghiepsForDisplay()
        {
            return _db.DoanhNghieps
                .OrderBy(d => d.TenDN)
                .ToList()
                .Select(d => new DoanhNghiepDisplay
                {
                    MaDN = d.MaDN,
                    TenDN = d.TenDN,
                    DiaChi = d.DiaChi,
                    LinhVuc = d.LinhVucHoatDong,
                    Email = d.EmailLienHe,
                    SoDienThoai = d.SoDienThoai
                })
                .ToList();
        }

        public List<DoanhNghiepDisplay> SearchDoanhNghieps(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            return _db.DoanhNghieps
                .Where(d => q == "" || d.TenDN.Contains(q) || d.MaDN.ToString().Contains(q))
                .OrderBy(d => d.TenDN)
                .ToList()
                .Select(d => new DoanhNghiepDisplay
                {
                    MaDN = d.MaDN,
                    TenDN = d.TenDN,
                    DiaChi = d.DiaChi,
                    LinhVuc = d.LinhVucHoatDong,
                    Email = d.EmailLienHe,
                    SoDienThoai = d.SoDienThoai
                })
                .ToList();
        }

        public List<DoanhNghiepDisplay> FilterDoanhNghieps(DoanhNghiepFilterModel filter)
        {
            if (filter == null) return GetDoanhNghiepsForDisplay();

            var query = GetDoanhNghiepsForDisplay().AsQueryable();

            if (!string.IsNullOrEmpty(filter.TenDN))
                query = query.Where(d => d.TenDN != null && d.TenDN.IndexOf(filter.TenDN, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(filter.LinhVuc))
                query = query.Where(d => d.LinhVuc != null && d.LinhVuc.IndexOf(filter.LinhVuc, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(filter.DiaChi))
                query = query.Where(d => d.DiaChi != null && d.DiaChi.IndexOf(filter.DiaChi, StringComparison.OrdinalIgnoreCase) >= 0);

            return query.ToList();
        }

        // === PHIẾU KHẢO SÁT ===
        public List<PhieuKhaoSatDisplay> SearchPhieuKhaoSats(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            return _db.PhieuKhaoSats
                .Where(p => q == "" || p.TenDotKhaoSat.Contains(q))
                .OrderByDescending(p => p.NgayTao)
                .ToList()
                .Select(p => new PhieuKhaoSatDisplay
                {
                    MaPhieu = p.MaPhieu,
                    TenDot = p.TenDotKhaoSat,
                    NgayTao = p.NgayTao,
                    NgayHetHan = p.NgayHetHan,
                    TrangThai = p.TrangThaiPhieu
                })
                .ToList();
        }

        public List<PhieuKhaoSatDisplay> GetPhieuKhaoSatsForDisplay()
        {
            return _db.PhieuKhaoSats
                .OrderByDescending(p => p.NgayTao)
                .ToList()
                .Select(p => new PhieuKhaoSatDisplay
                {
                    MaPhieu = p.MaPhieu,
                    TenDot = p.TenDotKhaoSat,
                    NgayTao = p.NgayTao,
                    NgayHetHan = p.NgayHetHan,
                    TrangThai = p.TrangThaiPhieu
                })
                .ToList();
        }

        // === LỊCH SỬ CÔNG TÁC (toàn bộ) ===
        public List<LichSuCongTacFullDisplay> SearchLichSuCongTacs(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            return _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .Where(l => q == "" || 
                            l.SinhVien.HoTen.Contains(q) || 
                            l.DoanhNghiep.TenDN.Contains(q) || 
                            l.ViTriCongViec.Contains(q))
                .OrderByDescending(l => l.NgayBatDau)
                .ToList()
                .Select(l => new LichSuCongTacFullDisplay
                {
                    MaLichSu = l.MaLichSu,
                    MaSV = l.MaSV,
                    HoTen = l.SinhVien?.HoTen ?? "",
                    TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = l.ViTriCongViec,
                    NgayBatDau = l.NgayBatDau,
                    NgayKetThuc = l.NgayKetThuc,
                    TrangThai = l.TrangThaiXacThuc,
                    MucLuong = l.MucLuong,
                    DungChuyenNganh = l.DungChuyenNganh
                })
                .ToList();
        }

        public List<LichSuCongTacFullDisplay> FilterLichSuCongTacs(LichSuCongTacFilterModel filter)
        {
            if (filter == null) return GetLichSuCongTacsForDisplay();
            
            var query = GetLichSuCongTacsForDisplay().AsQueryable();

            if (!string.IsNullOrEmpty(filter.MaSV))
                query = query.Where(l => l.MaSV.Contains(filter.MaSV));
            if (!string.IsNullOrEmpty(filter.HoTenSV))
                query = query.Where(l => l.HoTen != null && l.HoTen.IndexOf(filter.HoTenSV, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(filter.TenDN))
                query = query.Where(l => l.TenDoanhNghiep != null && l.TenDoanhNghiep.IndexOf(filter.TenDN, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(filter.ViTri))
                query = query.Where(l => l.ViTriCongViec != null && l.ViTriCongViec.IndexOf(filter.ViTri, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(filter.TrangThai) && filter.TrangThai != "Tất cả")
                query = query.Where(l => l.TrangThai == filter.TrangThai);

            return query.ToList();
        }

        public List<LichSuCongTacFullDisplay> GetLichSuCongTacsForDisplay()
        {
            return _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .OrderByDescending(l => l.NgayBatDau)
                .ToList()
                .Select(l => new LichSuCongTacFullDisplay
                {
                    MaLichSu = l.MaLichSu,
                    MaSV = l.MaSV,
                    HoTen = l.SinhVien?.HoTen ?? "",
                    TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = l.ViTriCongViec,
                    NgayBatDau = l.NgayBatDau,
                    NgayKetThuc = l.NgayKetThuc,
                    TrangThai = l.TrangThaiXacThuc,
                    MucLuong = l.MucLuong,
                    DungChuyenNganh = l.DungChuyenNganh
                })
                .ToList();
        }

        // === TÀI KHOẢN ===
        public List<TaiKhoanDisplay> GetTaiKhoansForDisplay()
        {
            return _db.TaiKhoanQuanTris
                .OrderBy(t => t.TenDangNhap)
                .ToList()
                .Select(t => new TaiKhoanDisplay
                {
                    MaTaiKhoan = t.MaTaiKhoan,
                    TenDangNhap = t.TenDangNhap,
                    HoTen = t.HoTenNguoiDung,
                    QuyenHan = t.QuyenHan,
                    MaSV = t.MaSV
                })
                .ToList();
        }

        // === LỊCH SỬ CHỜ XÁC THỰC ===
        public List<LichSuChoXacThucDisplay> GetLichSuChoXacThuc(string maSinhVien = null)
        {
            var query = _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .Where(l => l.TrangThaiXacThuc == "Chưa xác thực");

            if (!string.IsNullOrWhiteSpace(maSinhVien))
                query = query.Where(l => l.MaSV == maSinhVien);

            return query
                .OrderBy(l => l.MaSV)
                .ToList()
                .Select(l => new LichSuChoXacThucDisplay
                {
                    MaLichSu = l.MaLichSu,
                    MaSV = l.MaSV,
                    HoTen = l.SinhVien?.HoTen ?? "",
                    TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = l.ViTriCongViec,
                    NgayBatDau = l.NgayBatDau,
                    TrangThai = l.TrangThaiXacThuc
                })
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách lịch sử chưa xác thực (NULL hoặc "Chưa xác thực")
        /// Tab 1: Chưa xác thực
        /// </summary>
        public List<LichSuChoXacThucDisplay> GetLichSuChuaXacThuc()
        {
            return _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .Where(l => l.TrangThaiXacThuc == null || l.TrangThaiXacThuc == "Chưa xác thực")
                .OrderBy(l => l.MaSV)
                .ToList()
                .Select(l => new LichSuChoXacThucDisplay
                {
                    MaLichSu = l.MaLichSu,
                    MaSV = l.MaSV,
                    HoTen = l.SinhVien?.HoTen ?? "",
                    TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = l.ViTriCongViec,
                    NgayBatDau = l.NgayBatDau,
                    TrangThai = l.TrangThaiXacThuc ?? "Chưa xác thực"
                })
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách lịch sử đang chờ phản hồi từ doanh nghiệp
        /// Tab 2: Đang chờ phản hồi
        /// </summary>
        public List<LichSuChoXacThucDisplay> GetLichSuDangChoXacThuc()
        {
            return _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .Where(l => l.TrangThaiXacThuc == "Đã gửi xác thực")
                .OrderBy(l => l.MaSV)
                .ToList()
                .Select(l => new LichSuChoXacThucDisplay
                {
                    MaLichSu = l.MaLichSu,
                    MaSV = l.MaSV,
                    HoTen = l.SinhVien?.HoTen ?? "",
                    TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = l.ViTriCongViec,
                    NgayBatDau = l.NgayBatDau,
                    TrangThai = l.TrangThaiXacThuc
                })
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách lịch sử đã được xác thực (Đúng hoặc Sai)
        /// Form 3: Đánh dấu tình trạng dữ liệu
        /// </summary>
        public List<LichSuDaXacThucDisplay> GetLichSuDaXacThuc()
        {
            return _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .Where(l => l.TrangThaiXacThuc == "Xác thực đúng" || l.TrangThaiXacThuc == "Xác thực sai")
                .OrderByDescending(l => l.NgayBatDau)
                .ToList()
                .Select(l => new LichSuDaXacThucDisplay
                {
                    MaLichSu = l.MaLichSu,
                    MaSV = l.MaSV,
                    HoTen = l.SinhVien?.HoTen ?? "",
                    TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = l.ViTriCongViec,
                    KetQua = l.TrangThaiXacThuc == "Xác thực đúng" ? "✅ Đúng" : "❌ Sai",
                    TrangThaiXuLy = "🟢 Đã xử lý"
                })
                .ToList();
        }

        // === PHẢN HỒI XÁC THỰC ===
        public List<PhanHoiXacThucDisplay> GetPhanHoiXacThuc(string maSinhVien = null)
        {
            var query = _db.PhanHoiXacThucTams
                .Include(p => p.LichSuCongTac);

            if (!string.IsNullOrWhiteSpace(maSinhVien))
                query = query.Where(p => p.LichSuCongTac != null && p.LichSuCongTac.MaSV == maSinhVien);

            return query
                .OrderByDescending(p => p.NgayPhanHoi)
                .ToList()
                .Select(p => new PhanHoiXacThucDisplay
                {
                    MaPhanHoi = p.MaPhanHoi,
                    MaLichSu = p.MaLichSu,
                    NgayPhanHoi = p.NgayPhanHoi,
                    TrangThai = p.TrangThaiPhanHoi,
                    DaXuLy = p.DaXuLy
                })
                .ToList();
        }

        /// <summary>
        /// Lấy danh sách phản hồi xác thực chưa xử lý (DaXuLy = false)
        /// Form 2: Ghi nhận phản hồi xác thực
        /// </summary>
        public List<PhanHoiXacThucFullDisplay> GetPhanHoiChuaXuLy()
        {
            return _db.PhanHoiXacThucTams
                .Include(p => p.LichSuCongTac)
                .Include(p => p.LichSuCongTac.SinhVien)
                .Include(p => p.LichSuCongTac.DoanhNghiep)
                .Where(p => p.DaXuLy == false)
                .OrderByDescending(p => p.NgayPhanHoi)
                .ToList()
                .Select(p => new PhanHoiXacThucFullDisplay
                {
                    MaPhanHoi = p.MaPhanHoi,
                    MaLichSu = p.MaLichSu,
                    MaSV = p.LichSuCongTac?.MaSV ?? "",
                    HoTen = p.LichSuCongTac?.SinhVien?.HoTen ?? "",
                    TenDoanhNghiep = p.LichSuCongTac?.DoanhNghiep?.TenDN ?? "",
                    ViTriCongViec = p.LichSuCongTac?.ViTriCongViec ?? "",
                    NgayPhanHoi = p.NgayPhanHoi,
                    TrangThaiPhanHoi = p.TrangThaiPhanHoi,
                    NoiDungChiTiet = p.NoiDungChiTiet,
                    KetQua = "" // Sẽ được chọn bởi admin
                })
                .ToList();
        }


        // === KẾT QUẢ KHẢO SÁT ===
        public List<KetQuaKhaoSatDisplay> GetKetQuaKhaoSatsForDisplay()
        {
            return _db.KetQuaKhaoSats
                .Include(k => k.SinhVien)
                .Include(k => k.PhieuKhaoSat)
                .OrderByDescending(k => k.NgayTraLoi)
                .ToList()
                .Select(k => new KetQuaKhaoSatDisplay
                {
                    MaKetQua = k.MaKetQua,
                    MaSV = k.MaSV,
                    HoTen = k.SinhVien?.HoTen ?? "",
                    TenDotKhaoSat = k.PhieuKhaoSat?.TenDotKhaoSat ?? "",
                    NgayTraLoi = k.NgayTraLoi,
                    NoiDung = k.NoiDungChiTiet
                })
                .ToList();
        }
        // === SINH VIÊN (ASYNC) ===
        public async Task<List<SinhVienDisplay>> SearchSinhViensAsync(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            var list = await new StudentJobService(_db).GetSinhViensForDisplayAsync();
            return list.Where(s => q == "" || 
                            s.MaSV.Contains(q) || 
                            s.HoTen.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            (s.TenLop != null && s.TenLop.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();
        }

        public async Task<List<SinhVienDisplay>> GetAllSinhViensAsync()
        {
            return await new StudentJobService(_db).GetSinhViensForDisplayAsync();
        }

        // === DOANH NGHIỆP (ASYNC) ===
        public async Task<List<DoanhNghiepDisplay>> GetDoanhNghiepsForDisplayAsync()
        {
            var list = await _db.DoanhNghieps.OrderBy(d => d.TenDN).ToListAsync();
            return list.Select(d => new DoanhNghiepDisplay
            {
                MaDN = d.MaDN,
                TenDN = d.TenDN,
                DiaChi = d.DiaChi,
                LinhVuc = d.LinhVucHoatDong,
                Email = d.EmailLienHe,
                SoDienThoai = d.SoDienThoai
            }).ToList();
        }

        public async Task<List<DoanhNghiepDisplay>> SearchDoanhNghiepsAsync(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            var list = await _db.DoanhNghieps
                .Where(d => q == "" || d.TenDN.Contains(q) || d.MaDN.ToString().Contains(q))
                .OrderBy(d => d.TenDN)
                .ToListAsync();

            return list.Select(d => new DoanhNghiepDisplay
            {
                MaDN = d.MaDN,
                TenDN = d.TenDN,
                DiaChi = d.DiaChi,
                LinhVuc = d.LinhVucHoatDong,
                Email = d.EmailLienHe,
                SoDienThoai = d.SoDienThoai
            }).ToList();
        }

        // === PHIẾU KHẢO SÁT (ASYNC) ===
        public async Task<List<PhieuKhaoSatDisplay>> SearchPhieuKhaoSatsAsync(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            var list = await _db.PhieuKhaoSats
                .Where(p => q == "" || p.TenDotKhaoSat.Contains(q))
                .OrderByDescending(p => p.NgayTao)
                .ToListAsync();

            return list.Select(p => new PhieuKhaoSatDisplay
            {
                MaPhieu = p.MaPhieu,
                TenDot = p.TenDotKhaoSat,
                NgayTao = p.NgayTao,
                NgayHetHan = p.NgayHetHan,
                TrangThai = p.TrangThaiPhieu
            }).ToList();
        }

        public async Task<List<PhieuKhaoSatDisplay>> GetPhieuKhaoSatsForDisplayAsync()
        {
            var list = await _db.PhieuKhaoSats
                .OrderByDescending(p => p.NgayTao)
                .ToListAsync();

            return list.Select(p => new PhieuKhaoSatDisplay
            {
                MaPhieu = p.MaPhieu,
                TenDot = p.TenDotKhaoSat,
                NgayTao = p.NgayTao,
                NgayHetHan = p.NgayHetHan,
                TrangThai = p.TrangThaiPhieu
            }).ToList();
        }

        // === LỊCH SỬ CÔNG TÁC (ASYNC) ===
        public async Task<List<LichSuCongTacFullDisplay>> SearchLichSuCongTacsAsync(string keyword)
        {
            var q = keyword?.Trim() ?? "";
            var list = await _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .Where(l => q == "" || 
                            l.SinhVien.HoTen.Contains(q) || 
                            l.MaSV.Contains(q) ||
                            l.DoanhNghiep.TenDN.Contains(q) || 
                            l.ViTriCongViec.Contains(q))
                .OrderByDescending(l => l.NgayBatDau)
                .ToListAsync();

            return list.Select(l => new LichSuCongTacFullDisplay
            {
                MaLichSu = l.MaLichSu,
                MaSV = l.MaSV,
                HoTen = l.SinhVien?.HoTen ?? "",
                TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                ViTriCongViec = l.ViTriCongViec,
                NgayBatDau = l.NgayBatDau,
                NgayKetThuc = l.NgayKetThuc,
                TrangThai = l.TrangThaiXacThuc,
                MucLuong = l.MucLuong,
                DungChuyenNganh = l.DungChuyenNganh
            }).ToList();
        }

        public async Task<List<LichSuCongTacFullDisplay>> GetLichSuCongTacsForDisplayAsync()
        {
            var list = await _db.LichSuCongTacs
                .Include(l => l.DoanhNghiep)
                .Include(l => l.SinhVien)
                .OrderByDescending(l => l.NgayBatDau)
                .ToListAsync();

            return list.Select(l => new LichSuCongTacFullDisplay
            {
                MaLichSu = l.MaLichSu,
                MaSV = l.MaSV,
                HoTen = l.SinhVien?.HoTen ?? "",
                TenDoanhNghiep = l.DoanhNghiep?.TenDN ?? "",
                ViTriCongViec = l.ViTriCongViec,
                NgayBatDau = l.NgayBatDau,
                NgayKetThuc = l.NgayKetThuc,
                TrangThai = l.TrangThaiXacThuc,
                MucLuong = l.MucLuong,
                DungChuyenNganh = l.DungChuyenNganh
            }).ToList();
        }

        // === TÀI KHOẢN (ASYNC) ===
        public async Task<List<TaiKhoanDisplay>> GetTaiKhoansForDisplayAsync()
        {
            var list = await _db.TaiKhoanQuanTris
                .OrderBy(t => t.TenDangNhap)
                .ToListAsync();

            return list.Select(t => new TaiKhoanDisplay
            {
                MaTaiKhoan = t.MaTaiKhoan,
                TenDangNhap = t.TenDangNhap,
                HoTen = t.HoTenNguoiDung,
                QuyenHan = t.QuyenHan,
                MaSV = t.MaSV
            }).ToList();
        }

        // === KẾT QUẢ KHẢO SÁT (ASYNC) ===
        public async Task<List<KetQuaKhaoSatDisplay>> GetKetQuaKhaoSatsForDisplayAsync()
        {
            var list = await _db.KetQuaKhaoSats
                .Include(k => k.SinhVien)
                .Include(k => k.PhieuKhaoSat)
                .OrderByDescending(k => k.NgayTraLoi)
                .ToListAsync();

            return list.Select(k => new KetQuaKhaoSatDisplay
            {
                MaKetQua = k.MaKetQua,
                MaSV = k.MaSV,
                HoTen = k.SinhVien?.HoTen ?? "",
                TenDotKhaoSat = k.PhieuKhaoSat?.TenDotKhaoSat ?? "",
                NgayTraLoi = k.NgayTraLoi,
                NoiDung = k.NoiDungChiTiet
            }).ToList();
        }
    }

    // === THÊM CÁC DTO TRONG DISPLAYMODELS.CS CHƯA CÓ ===

    // DTO hiển thị lịch sử công tác đầy đủ (có thông tin sinh viên)
    public class LichSuCongTacFullDisplay
    {
        [System.ComponentModel.DisplayName("Mã")]
        public int MaLichSu { get; set; }

        [System.ComponentModel.DisplayName("Mã SV")]
        public string MaSV { get; set; }

        [System.ComponentModel.DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [System.ComponentModel.DisplayName("Doanh nghiệp")]
        public string TenDoanhNghiep { get; set; }

        [System.ComponentModel.DisplayName("Vị trí công việc")]
        public string ViTriCongViec { get; set; }

        [System.ComponentModel.DisplayName("Ngày bắt đầu")]
        public DateTime? NgayBatDau { get; set; }

        [System.ComponentModel.DisplayName("Ngày kết thúc")]
        public DateTime? NgayKetThuc { get; set; }

        [System.ComponentModel.DisplayName("Trạng thái")]
        public string TrangThai { get; set; }

        [System.ComponentModel.DisplayName("Mức lương")]
        public decimal? MucLuong { get; set; }

        [System.ComponentModel.DisplayName("Đúng chuyên ngành")]
        public bool? DungChuyenNganh { get; set; }
    }

    // DTO hiển thị lịch sử chờ xác thực
    public class LichSuChoXacThucDisplay
    {
        [System.ComponentModel.DisplayName("Mã")]
        public int MaLichSu { get; set; }

        [System.ComponentModel.DisplayName("Mã SV")]
        public string MaSV { get; set; }

        [System.ComponentModel.DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [System.ComponentModel.DisplayName("Doanh nghiệp")]
        public string TenDoanhNghiep { get; set; }

        [System.ComponentModel.DisplayName("Vị trí công việc")]
        public string ViTriCongViec { get; set; }

        [System.ComponentModel.DisplayName("Ngày bắt đầu")]
        public DateTime? NgayBatDau { get; set; }

        [System.ComponentModel.DisplayName("Trạng thái")]
        public string TrangThai { get; set; }
    }

    // DTO hiển thị phản hồi xác thực đầy đủ (Form 2)
    public class PhanHoiXacThucFullDisplay
    {
        [System.ComponentModel.DisplayName("Mã PH")]
        public int MaPhanHoi { get; set; }

        [System.ComponentModel.DisplayName("Mã LS")]
        public int MaLichSu { get; set; }

        [System.ComponentModel.DisplayName("Mã SV")]
        public string MaSV { get; set; }

        [System.ComponentModel.DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [System.ComponentModel.DisplayName("Doanh nghiệp")]
        public string TenDoanhNghiep { get; set; }

        [System.ComponentModel.DisplayName("Vị trí")]
        public string ViTriCongViec { get; set; }

        [System.ComponentModel.DisplayName("Ngày phản hồi")]
        public DateTime? NgayPhanHoi { get; set; }

        [System.ComponentModel.DisplayName("Phản hồi DN")]
        public string TrangThaiPhanHoi { get; set; }

        [System.ComponentModel.DisplayName("Nội dung")]
        public string NoiDungChiTiet { get; set; }

        [System.ComponentModel.DisplayName("Kết quả")]
        public string KetQua { get; set; }
    }

    // DTO hiển thị lịch sử đã xác thực (Form 3)
    public class LichSuDaXacThucDisplay
    {
        [System.ComponentModel.DisplayName("Mã")]
        public int MaLichSu { get; set; }

        [System.ComponentModel.DisplayName("Mã SV")]
        public string MaSV { get; set; }

        [System.ComponentModel.DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [System.ComponentModel.DisplayName("Doanh nghiệp")]
        public string TenDoanhNghiep { get; set; }

        [System.ComponentModel.DisplayName("Vị trí")]
        public string ViTriCongViec { get; set; }

        [System.ComponentModel.DisplayName("Kết quả")]
        public string KetQua { get; set; }

        [System.ComponentModel.DisplayName("Trạng thái")]
        public string TrangThaiXuLy { get; set; }
    }

    // DTO hiển thị kết quả khảo sát

}
