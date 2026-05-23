using System;
using System.Data;
using System.Data.SqlClient;
using QuanLySinhVien.Data;

namespace QuanLySinhVien.Services
{
    public class StatisticalService
    {
        // Tab 1: Việc làm theo khoảng thời gian (NgayBatDau) - Aggregated
        public DataTable GetEmploymentStatsByMonth(DateTime fromDate, DateTime toDate, bool onlyPostGrad)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        YEAR(LS.NgayBatDau) AS Nam,
                        MONTH(LS.NgayBatDau) AS Thang,
                        COUNT(DISTINCT LS.MaSV) AS SoSinhVienCoViec
                    FROM LichSuCongTac LS
                    INNER JOIN SinhVien SV ON LS.MaSV = SV.MaSV
                    WHERE LS.NgayBatDau BETWEEN @FromDate AND @ToDate
                      AND SV.MaSV IS NOT NULL";

                if (onlyPostGrad)
                {
                    sql += " AND YEAR(LS.NgayBatDau) >= SV.NamTotNghiep";
                }

                sql += @"
                    GROUP BY YEAR(LS.NgayBatDau), MONTH(LS.NgayBatDau)
                    ORDER BY Nam, Thang";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Tab 2: Thống kê đúng chuyên ngành
        public DataTable GetMajorAlignmentStats(string maNganh, string maKhoa)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        NH.TenNganh,
                        KH.NienKhoa,
                        SUM(CASE WHEN LS.DungChuyenNganh = 1 THEN 1 ELSE 0 END) AS SoDungNganh,
                        SUM(CASE WHEN LS.DungChuyenNganh = 0 THEN 1 ELSE 0 END) AS SoTraiNganh,
                        COUNT(*) AS Tong
                    FROM LichSuCongTac LS
                    INNER JOIN SinhVien SV ON LS.MaSV = SV.MaSV
                    LEFT JOIN NganhHoc NH ON SV.MaNganh = NH.MaNganh
                    LEFT JOIN KhoaHoc KH  ON SV.MaKhoaHoc = KH.MaKhoaHoc
                    WHERE 1=1";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(maNganh))
                    {
                        sql += " AND SV.MaNganh = @MaNganh";
                        cmd.Parameters.AddWithValue("@MaNganh", maNganh);
                    }

                    if (!string.IsNullOrEmpty(maKhoa))
                    {
                        sql += " AND SV.MaKhoaHoc = @MaKhoaHoc";
                        cmd.Parameters.AddWithValue("@MaKhoaHoc", maKhoa);
                    }

                    sql += @"
                        GROUP BY NH.TenNganh, KH.NienKhoa
                        ORDER BY NH.TenNganh, KH.NienKhoa";

                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetAllKhoas()
        {
             using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = "SELECT MaKhoaHoc, NienKhoa FROM KhoaHoc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Tab 3: Thống kê theo mức lương (Phân nhóm)
        public DataTable GetSalaryDistributionStats(int? namTotNghiep)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        CASE 
                            WHEN LS.MucLuong < 5000000 THEN N'< 5 triệu'
                            WHEN LS.MucLuong >= 5000000 AND LS.MucLuong <= 10000000 THEN N'5 - 10 triệu'
                            WHEN LS.MucLuong > 10000000 THEN N'> 10 triệu'
                            ELSE N'Không rõ'
                        END AS NhomLuong,
                        COUNT(DISTINCT LS.MaSV) AS SoSinhVien
                    FROM LichSuCongTac LS
                    INNER JOIN SinhVien SV ON LS.MaSV = SV.MaSV
                    WHERE LS.MucLuong IS NOT NULL";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (namTotNghiep.HasValue && namTotNghiep.Value > 0)
                    {
                        // Removed filter
                    }

                    sql += @"
                        GROUP BY CASE 
                            WHEN LS.MucLuong < 5000000 THEN N'< 5 triệu'
                            WHEN LS.MucLuong >= 5000000 AND LS.MucLuong <= 10000000 THEN N'5 - 10 triệu'
                            WHEN LS.MucLuong > 10000000 THEN N'> 10 triệu'
                            ELSE N'Không rõ'
                        END";

                    cmd.CommandText = sql;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Generic Save Report
        public void SaveGenericReport(string tenThongKe, string reportData)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO DuLieuPhanTichTam(MaPhien, TenThongKe, GiaTri, NgayTao)
                    VALUES(@MaPhien, @TenThongKe, @GiaTri, @NgayTao)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhien", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@TenThongKe", tenThongKe);
                    
                    // Safety check/truncate for GiaTri (max 255)
                    string safeVal = reportData ?? "";
                    if (safeVal.Length > 255) safeVal = safeVal.Substring(0, 255);
                    
                    cmd.Parameters.AddWithValue("@GiaTri", safeVal);
                    cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetGraduationYears()
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                // Return empty/dummy table as feature is removed
                return new DataTable(); // Empty
            }
        }

        // Drill-down: Get students who started job in a specific month/year
        public DataTable GetStudentsByMonth(int year, int month)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    SELECT DISTINCT
                        SV.MaSV,
                        SV.HoTen,
                        NH.TenNganh,
                        KH.NienKhoa,
                        DN.TenDN AS DoanhNghiep,
                        LS.ViTriCongViec,
                        LS.MucLuong,
                        LS.NgayBatDau
                    FROM LichSuCongTac LS
                    INNER JOIN SinhVien SV ON LS.MaSV = SV.MaSV
                    LEFT JOIN NganhHoc NH ON SV.MaNganh = NH.MaNganh
                    LEFT JOIN KhoaHoc KH ON SV.MaKhoaHoc = KH.MaKhoaHoc
                    LEFT JOIN DoanhNghiep DN ON LS.MaDN = DN.MaDN
                    WHERE YEAR(LS.NgayBatDau) = @Year AND MONTH(LS.NgayBatDau) = @Month
                    ORDER BY SV.HoTen";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Drill-down: Get students by major alignment (TenNganh, NienKhoa, isDungNganh)
        public DataTable GetStudentsByMajorAlignment(string tenNganh, string nienKhoa, bool isDungNganh)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    SELECT DISTINCT
                        SV.MaSV,
                        SV.HoTen,
                        NH.TenNganh,
                        KH.NienKhoa,
                        DN.TenDN AS DoanhNghiep,
                        LS.ViTriCongViec,
                        LS.MucLuong,
                        CASE WHEN LS.DungChuyenNganh = 1 THEN N'Đúng' ELSE N'Trái' END AS PhuHopNganh
                    FROM LichSuCongTac LS
                    INNER JOIN SinhVien SV ON LS.MaSV = SV.MaSV
                    LEFT JOIN NganhHoc NH ON SV.MaNganh = NH.MaNganh
                    LEFT JOIN KhoaHoc KH ON SV.MaKhoaHoc = KH.MaKhoaHoc
                    LEFT JOIN DoanhNghiep DN ON LS.MaDN = DN.MaDN
                    WHERE LS.DungChuyenNganh = @IsDung";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IsDung", isDungNganh ? 1 : 0);

                    if (!string.IsNullOrEmpty(tenNganh))
                    {
                        sql += " AND NH.TenNganh = @TenNganh";
                        cmd.Parameters.AddWithValue("@TenNganh", tenNganh);
                    }
                    if (!string.IsNullOrEmpty(nienKhoa))
                    {
                        sql += " AND KH.NienKhoa = @NienKhoa";
                        cmd.Parameters.AddWithValue("@NienKhoa", nienKhoa);
                    }

                    sql += " ORDER BY SV.HoTen";
                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Drill-down: Get students by salary range
        public DataTable GetStudentsBySalaryRange(string nhomLuong)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    SELECT DISTINCT
                        SV.MaSV,
                        SV.HoTen,
                        NH.TenNganh,
                        KH.NienKhoa,
                        DN.TenDN AS DoanhNghiep,
                        LS.ViTriCongViec,
                        LS.MucLuong
                    FROM LichSuCongTac LS
                    INNER JOIN SinhVien SV ON LS.MaSV = SV.MaSV
                    LEFT JOIN NganhHoc NH ON SV.MaNganh = NH.MaNganh
                    LEFT JOIN KhoaHoc KH ON SV.MaKhoaHoc = KH.MaKhoaHoc
                    LEFT JOIN DoanhNghiep DN ON LS.MaDN = DN.MaDN
                    WHERE LS.MucLuong IS NOT NULL";

                // Parse nhomLuong to add WHERE clause
                if (nhomLuong == "< 5 triệu")
                {
                    sql += " AND LS.MucLuong < 5000000";
                }
                else if (nhomLuong == "5 - 10 triệu")
                {
                    sql += " AND LS.MucLuong >= 5000000 AND LS.MucLuong <= 10000000";
                }
                else if (nhomLuong == "> 10 triệu")
                {
                    sql += " AND LS.MucLuong > 10000000";
                }
                // else: "Không rõ" - no filter

                sql += " ORDER BY SV.HoTen";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Helper: Get list of Nganh for ComboBox
        public DataTable GetAllMajors()
        {
             using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = "SELECT MaNganh, TenNganh FROM NganhHoc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
