using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using QuanLySinhVien.Data;

namespace QuanLySinhVien.Services
{
    public class NotificationService
    {
        // 1. Get List of Students for Notification
        public DataTable GetStudentsForNotification(string maKhoa, string maNganh, int? namTN, int daysThreshold)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                // Query to get students - find all students matching filters
                // Note: NgayCapNhat column doesn't exist in SinhVien, so we just get all matching students
                string sql = @"
                    SELECT 
                        SV.MaSV, SV.HoTen, SV.EmailCaNhan, 
                        KH.NienKhoa, NH.TenNganh
                    FROM SinhVien SV
                    LEFT JOIN KhoaHoc KH ON SV.MaKhoaHoc = KH.MaKhoaHoc
                    LEFT JOIN NganhHoc NH ON SV.MaNganh = NH.MaNganh
                    WHERE 1=1";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Removed @ThresholdDate since NgayCapNhat doesn't exist

                    if (!string.IsNullOrEmpty(maKhoa))
                    {
                        sql += " AND SV.MaKhoaHoc = @MaKhoaHoc";
                        cmd.Parameters.AddWithValue("@MaKhoaHoc", maKhoa);
                    }
                    if (!string.IsNullOrEmpty(maNganh))
                    {
                        sql += " AND SV.MaNganh = @MaNganh";
                        cmd.Parameters.AddWithValue("@MaNganh", maNganh);
                    }
                    if (namTN.HasValue && namTN.Value > 0)
                    {
                        sql += " AND SV.NamTotNghiep = @NamTotNghiep";
                        cmd.Parameters.AddWithValue("@NamTotNghiep", namTN.Value);
                    }

                    cmd.CommandText = sql;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;     
                }
            }
        }

        // 2. Send Email (HARDCODED SETTINGS)
        public void SendEmail(string toEmail, string subject, string content)
        {
            try 
            {
                // ==========================================
                // CẤU HÌNH SMTP (Server Postfix của bạn)
                // ==========================================
                string host = "mail.215tohieu.io.vn"; 
                int port = 25; 
                bool enableSsl = false; 
                string fromEmail = "hethong@mail.215tohieu.io.vn"; 
                string password = ""; // ĐỂ TRỐNG nếu không có mật khẩu
                // ==========================================

                using (SmtpClient client = new SmtpClient(host, port))
                {
                    client.EnableSsl = enableSsl;
                    
                    if (!string.IsNullOrEmpty(password))
                    {
                        client.Credentials = new NetworkCredential(fromEmail, password);
                    }
                    else
                    {
                        // Gửi không cần mật khẩu (Anonymous / IP Whitelist)
                        client.UseDefaultCredentials = false;
                    }

                    client.Timeout = 20000; // 20s

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(fromEmail, "Phong Cong Tac Sinh Vien");
                    mail.To.Add(toEmail);
                    mail.Subject = subject;
                    mail.Body = content;
                    mail.IsBodyHtml = false; 

                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi gửi Email: " + ex.Message);
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

        public DataTable GetGraduationYears()
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                string sql = "SELECT DISTINCT NamTotNghiep FROM SinhVien WHERE NamTotNghiep IS NOT NULL ORDER BY NamTotNghiep DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3. Log Notification History
        public void SaveThongBaoLog(string loaiDot, int soSV, System.Collections.Generic.List<string> dsMaSV)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateDefault())
            {
                conn.Open();
                
                var sb = new System.Text.StringBuilder();
                sb.AppendLine($"LoaiDot={loaiDot};SoSinhVien={soSV};NgayGui={DateTime.Now}");
                string listStr = string.Join(",", dsMaSV);
                if (listStr.Length > 2000) listStr = listStr.Substring(0, 2000) + "..."; // Safety truncate
                sb.AppendLine("DanhSachMaSV=" + listStr);

                string sql = @"
                    INSERT INTO DuLieuPhanTichTam(MaPhien, TenThongKe, GiaTri, NgayTao)
                    VALUES(@MaPhien, @TenThongKe, @GiaTri, @NgayTao)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhien", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@TenThongKe", "GUI_THONG_BAO_DINH_KY");
                    cmd.Parameters.AddWithValue("@GiaTri", sb.ToString());
                    cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
