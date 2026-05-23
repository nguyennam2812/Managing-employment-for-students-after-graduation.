# HỆ THỐNG PHÂN QUYỀN

## Tổng quan
Hệ thống sử dụng mô hình **RBAC (Role-Based Access Control)** với 3 vai trò chính:
- **ADMIN** - Quản trị viên
- **GIAO VIEN** - Giáo viên  
- **SINH VIEN** - Sinh viên

## Bảng phân quyền chi tiết

| Phạm vi dữ liệu | Toàn trưởng | Chi xem Khoa/Lớp minh quản lý | Chi xem dữ liệu CỦA MÌNH |
|-----------------|-------------|-------------------------------|--------------------------|
| **Quản lý Hồ sơ SV (D1)** | Xem, Thêm, Sửa, Xóa (ADMIN) | Chi Xem & Sửa - không được Xóa (GIÁO VIÊN) | Chi Xem & Sửa thông tin cá nhân/việc làm của mình (SINH VIÊN) |
| **Quản lý Doanh nghiệp (D2)** | Toàn quyền (ADMIN) | Chi Xem (GIÁO VIÊN) | Chi Xem - khi chọn nơi làm việc (SINH VIÊN) |
| **Quản lý Tài khoản (D6)** | Được phép - Tạo acc cho GV (ADMIN) | **KHÔNG** được phép truy cập (GIÁO VIÊN) | **KHÔNG** được phép truy cập (SINH VIÊN) |
| **Gửi Khảo sát (D4)** | Toàn quyền - Tạo & Gửi (ADMIN) | Chi Xem báo cáo (GIÁO VIÊN) | Làm khảo sát - Trả lời (SINH VIÊN) |
| **Xác thực (D3/D7)** | Toàn quyền duyệt (ADMIN) | Chi Xem trạng thái (GIÁO VIÊN) | Xem trạng thái xác thực của mình (SINH VIÊN) |
| **Báo cáo & Thống kê** | Xem tất cả báo cáo (ADMIN) | Xem báo cáo của Khoa mình (GIÁO VIÊN) | Không được xem (SINH VIÊN) |

## Triển khai kỹ thuật

### 1. Cấu trúc Database
Bảng `TaiKhoanQuanTri` có cột `QuyenHan` với các giá trị:
- `ADMIN` - Toàn quyền
- `GIAO VIEN` - Quyền hạn chế
- `SINH VIEN` - Chỉ xem/sửa dữ liệu của mình

### 2. Class AuthContext
```csharp
public static class AuthContext
{
    public static string Username { get; set; }
    public static string Role { get; set; }
    public static string MaSinhVien { get; set; } // Cho SINH VIEN
    
    // Properties kiểm tra quyền
    public static bool IsAdmin { get; }
    public static bool IsTeacher { get; }
    public static bool IsStudent { get; }
    public static bool CanViewAndEdit { get; } // Admin + GV
    public static bool CanDelete { get; }      // Chỉ Admin
    public static bool CanCreateAccount { get; } // Chỉ Admin
}
```

### 3. Áp dụng phân quyền

#### MainForm (Menu chính)
- **ADMIN**: Truy cập tất cả menu
- **GIÁO VIÊN**: Không truy cập Quản lý Tài khoản, Quản lý Sinh viên (Khoa/CN)
- **SINH VIÊN**: Chỉ truy cập menu Nghiệp vụ (Gửi khảo sát, Xem xác thực)

#### QuanLyTaiKhoanForm
- Chỉ **ADMIN** được truy cập
- Form tự động đóng nếu không phải Admin

#### QuanLyDoanhNghiepForm
- **ADMIN**: Toàn quyền (Thêm, Sửa, Xóa)
- **GIÁO VIÊN**: Chỉ xem (ReadOnly, disable các nút)
- **SINH VIÊN**: Không truy cập

#### QuanLyPhieuKhaoSatForm
- **ADMIN**: Tạo & gửi phiếu khảo sát
- **GIÁO VIÊN**: Chỉ xem báo cáo
- **SINH VIÊN**: Không truy cập (làm qua menu Nghiệp vụ)

#### XuLyXacThucForm
- **ADMIN**: Toàn quyền duyệt xác thực
- **GIÁO VIÊN**: Xem trạng thái (không duyệt)
- **SINH VIÊN**: Chỉ xem dữ liệu của mình (filter theo MaSV)

#### GuiKhaoSatForm
- Tất cả role đều làm được (Trả lời khảo sát)
- **SINH VIÊN**: Chỉ xem thông tin của mình

#### BaoCaoForm
- **ADMIN**: Xem tất cả báo cáo
- **GIÁO VIÊN**: Xem báo cáo (có thể filter theo khoa)
- **SINH VIÊN**: Không truy cập

#### QuanLySinhVien (Form chính)
- **ADMIN**: Xem, Thêm, Sửa, **Xóa**
- **GIÁO VIÊN**: Xem, Thêm, Sửa (KHÔNG xóa - nút btnDeleteSV bị disable)
- **SINH VIÊN**: Không truy cập form này

## Lưu ý khi sử dụng

### Đăng nhập
- Tên đăng nhập và mật khẩu lưu trong bảng `TaiKhoanQuanTri`
- Với **SINH VIÊN**: `TenDangNhap` = `MaSV` (mã sinh viên)

### Data Scope (Phạm vi dữ liệu)
- **ADMIN**: Xem toàn bộ
- **GIÁO VIÊN**: Xem toàn bộ nhưng không xóa
- **SINH VIÊN**: Chỉ xem/sửa dữ liệu có `MaSV` = `AuthContext.MaSinhVien`

### Ví dụ accounts mẫu
```sql
INSERT INTO TaiKhoanQuanTri (TenDangNhap, MatKhau, HoTenNguoiDung, QuyenHan)
VALUES 
    ('admin', 'hoang', 'Lưu Hoàng', 'ADMIN'),
    ('giaovien', 'hoang', 'Lưu Hoàng', 'GIAO VIEN'),
    ('sinhvien', 'hoang', 'Lưu Hoàng', 'SINH VIEN');
```

## Mở rộng trong tương lai

1. **Thêm MaKhoa cho Giáo viên** - Filter báo cáo theo khoa
2. **Audit Log** - Ghi lại thao tác của user
3. **Permission-based** - Phân quyền chi tiết theo từng chức năng
4. **Password hash** - Mã hóa mật khẩu (hiện tại plain text)
5. **Token-based Auth** - Sử dụng JWT cho API
