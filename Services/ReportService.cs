using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien.Services
{
    public class ReportService
    {
        private readonly SurveyDbContext _db;
        public ReportService(SurveyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Đếm số lượng sinh viên có việc làm theo từng tháng trong năm
        /// </summary>
        public IEnumerable<EmploymentCount> DemSoLuongCoViecTheoThang(int nam)
        {
            var result = _db.LichSuCongTacs
                .Where(l => l.NgayBatDau.HasValue && l.NgayBatDau.Value.Year == nam)
                .ToList()
                .GroupBy(l => l.NgayBatDau.Value.Month)
                .Select(g => new EmploymentCount
                {
                    Key = $"Tháng {g.Key}",
                    Count = g.Select(x => x.MaSV).Distinct().Count()
                })
                .OrderBy(e => int.Parse(e.Key.Replace("Tháng ", "")))
                .ToList();
            return result;
        }

        /// <summary>
        /// Đếm số lượng sinh viên có việc làm theo từng năm
        /// </summary>
        public IEnumerable<EmploymentCount> DemSoLuongCoViecTheoNam(int fromYear, int toYear)
        {
            var result = _db.LichSuCongTacs
                .Where(l => l.NgayBatDau.HasValue && 
                            l.NgayBatDau.Value.Year >= fromYear && 
                            l.NgayBatDau.Value.Year <= toYear)
                .ToList()
                .GroupBy(l => l.NgayBatDau.Value.Year)
                .Select(g => new EmploymentCount
                {
                    Key = g.Key.ToString(),
                    Count = g.Select(x => x.MaSV).Distinct().Count()
                })
                .OrderBy(e => e.Key)
                .ToList();
            return result;
        }

        /// <summary>
        /// Thống kê theo doanh nghiệp
        /// </summary>
        public IEnumerable<EmploymentCount> ThongKeTheoDoanhNghiep()
        {
            var result = _db.LichSuCongTacs
                .GroupBy(l => l.DoanhNghiep.TenDN ?? "Không xác định")
                .Select(g => new EmploymentCount
                {
                    Key = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToList();
            return result;
        }

        /// <summary>
        /// Thống kê theo vị trí công việc
        /// </summary>
        public IEnumerable<EmploymentCount> ThongKeTheoViTriCongViec()
        {
            var result = _db.LichSuCongTacs
                .GroupBy(l => l.ViTriCongViec ?? "Không xác định")
                .Select(g => new EmploymentCount
                {
                    Key = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToList();
            return result;
        }

        /// <summary>
        /// Thống kê theo trạng thái xác thực
        /// </summary>
        public IEnumerable<EmploymentCount> ThongKeTheoTrangThaiXacThuc()
        {
            var result = _db.LichSuCongTacs
                .GroupBy(l => l.TrangThaiXacThuc ?? "Chưa xác thực")
                .Select(g => new EmploymentCount
                {
                    Key = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(e => e.Count)
                .ToList();
            return result;
        }

        /// <summary>
        /// Đếm tổng số lượng lịch sử công tác
        /// </summary>
        public int DemTongSoLichSuCongTac()
        {
            return _db.LichSuCongTacs.Count();
        }

        public IEnumerable<ThongBaoLich> LichThongBaoDenHan(DateTime asOf)
        {
            // Không có bảng ThongBaoLich trong schema hiện tại
            return Enumerable.Empty<ThongBaoLich>();
        }
    }

    public class EmploymentCount
    {
        public string Key { get; set; }
        public int Count { get; set; }
    }
}
