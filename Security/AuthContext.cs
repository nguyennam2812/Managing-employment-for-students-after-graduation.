namespace QuanLySinhVien.Security
{
    public static class AuthContext
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        
        // Mã sinh viên (chỉ dùng cho role SINH VIEN)
        public static string MaSinhVien { get; set; }

        private static string NormalizeRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role)) return string.Empty;
            var lower = role.Trim().ToLowerInvariant();
            return lower.Replace(" ", string.Empty).Replace("_", string.Empty);
        }

        public static bool IsAdmin
        {
            get
            {
                var r = NormalizeRole(Role);
                return r == "admin" || r == "quantri" || r == "administrator";
            }
        }

        public static bool IsStudent
        {
            get
            {
                var r = NormalizeRole(Role);
                return r == "sinhvien" || r == "student";
            }
        }

        // Quyền chỉnh sửa dữ liệu hệ thống: Admin toàn quyền, Giáo viên có quyền sửa nhưng không xóa
        public static bool IsEditor => IsAdmin;
        
        // Quyền xem và sửa (nhưng không xóa): Chỉ Admin (Giáo viên chỉ xem)
        public static bool CanViewAndEdit => IsAdmin;
        
        // Quyền xóa: chỉ Admin
        public static bool CanDelete => IsAdmin;
        
        // Quyền tạo tài khoản: chỉ Admin
        public static bool CanCreateAccount => IsAdmin;
    }
}
