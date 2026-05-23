using System;
using System.Data;
using System.Data.SqlClient;
using QuanLySinhVien.Data;

namespace QuanLySinhVien.Services
{
    public class VerificationService
    {
        public DataTable GetPendingVerifications()
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    SELECT LS.MaLichSu, LS.MaSV, SV.HoTen,
                           LS.MaDN, DN.TenDN, DN.EmailLienHe,
                           LS.ViTriCongViec, LS.NgayBatDau,
                           LS.MucLuong, LS.DungChuyenNganh, LS.TrangThaiXacThuc
                    FROM LichSuCongTac LS
                    INNER JOIN SinhVien SV ON LS.MaSV = SV.MaSV
                    INNER JOIN DoanhNghiep DN ON LS.MaDN = DN.MaDN
                    WHERE LS.TrangThaiXacThuc = 'CHO_XAC_THUC'";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void SendVerificationEmail(string maLS, string email)
        {
            // Simulate sending email and log to DB
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO DuLieuPhanTichTam(TenThongKe, GiaTri, NgayTao)
                    VALUES(@TenThongKe, @GiaTri, @NgayTao)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenThongKe", "GUI_MAIL_XACTHUC_" + maLS);
                    cmd.Parameters.AddWithValue("@GiaTri",
                        $"MaLichSu={maLS};EmailDN={email};ThoiGian={DateTime.Now}");
                    cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SubmitFeedback(int maLS, string ttPhanHoi, string noiDung, bool daXuLy)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1. INSERT PhanHoiXacThucTam
                    string sqlInsert = @"
                        INSERT INTO PhanHoiXacThucTam(MaLichSu, NgayPhanHoi, TrangThaiPhanHoi, DaXuLy, NoiDungChiTiet)
                        VALUES(@MaLichSu, @NgayPH, @TrangThai, @DaXuLy, @NoiDung)";

                    using (SqlCommand cmd = new SqlCommand(sqlInsert, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaLichSu", maLS);
                        cmd.Parameters.AddWithValue("@NgayPH", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TrangThai", ttPhanHoi);
                        cmd.Parameters.AddWithValue("@DaXuLy", daXuLy);
                        cmd.Parameters.AddWithValue("@NoiDung", (object)noiDung ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. UPDATE LichSuCongTac.TrangThaiXacThuc
                    string trangThaiXacThuc;
                    switch (ttPhanHoi)
                    {
                        case "DUNG": trangThaiXacThuc = "DA_XAC_THUC"; break;
                        case "SAI": trangThaiXacThuc = "TU_CHOI"; break;
                        case "CAN_BO_SUNG": trangThaiXacThuc = "CAN_BO_SUNG"; break;
                        default: trangThaiXacThuc = "CHO_XAC_THUC"; break;
                    }

                    string sqlUpdate = @"
                        UPDATE LichSuCongTac
                        SET TrangThaiXacThuc = @TT
                        WHERE MaLichSu = @MaLichSu";

                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@TT", trangThaiXacThuc);
                        cmd.Parameters.AddWithValue("@MaLichSu", maLS);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw; // Re-throw to let caller handle message
                }
            }
        }
    }
}
