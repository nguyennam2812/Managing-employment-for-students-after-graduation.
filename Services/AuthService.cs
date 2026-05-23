using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;

namespace QuanLySinhVien.Services
{
    public class AuthService
    {
        private readonly SurveyDbContext _db;

        public AuthService(SurveyDbContext db)
        {
            _db = db;
        }

        public TaiKhoanQuanTri GetAccountByUsername(string username)
        {
            return _db.TaiKhoanQuanTris.AsNoTracking()
                .FirstOrDefault(a => a.TenDangNhap == username);
        }
        
        // Trả về false nếu không tìm thấy user, true nếu login thành công, throw exception nếu sai pass
        public TaiKhoanQuanTri Authenticate(string username, string password, out bool needsUpgrade)
        {
             needsUpgrade = false;
             var accounts = _db.TaiKhoanQuanTris.AsNoTracking().ToList();
             var account = accounts.FirstOrDefault(a => string.Equals((a.TenDangNhap ?? "").Trim(), username, StringComparison.OrdinalIgnoreCase));
             
             if (account == null) return null;

             var storedPassword = account.MatKhau?.Trim();
             var inputPassword = password.Trim();
             
             if (PasswordHelper.IsHashed(storedPassword))
             {
                 if (PasswordHelper.VerifyPassword(storedPassword, inputPassword))
                     return account;
             }
             else
             {
                 // Plain text check
                 if (string.Equals(storedPassword, inputPassword, StringComparison.Ordinal))
                 {
                     needsUpgrade = true; // Mark for lazy migration
                     return account;
                 }
             }

             throw new UnauthorizedAccessException("Mật khẩu không đúng");
        }

        public void UpgradePassword(int accountId, string newHash)
        {
            var acc = _db.TaiKhoanQuanTris.Find(accountId);
            if (acc != null)
            {
                acc.MatKhau = newHash;
                _db.SaveChanges();
            }
        }

        public void CreateAccount(TaiKhoanQuanTri account)
        {
            if (_db.TaiKhoanQuanTris.Any(a => a.TenDangNhap == account.TenDangNhap))
                throw new InvalidOperationException("Tên đăng nhập đã tồn tại.");
            
            _db.TaiKhoanQuanTris.Add(account);
            _db.SaveChanges();
        }

        public void DeleteAccount(int accountId)
        {
            var acc = _db.TaiKhoanQuanTris.Find(accountId);
            if (acc != null)
            {
                _db.TaiKhoanQuanTris.Remove(acc);
                _db.SaveChanges();
            }
        }

        public bool AccountExists(string username)
        {
            return _db.TaiKhoanQuanTris.Any(a => a.TenDangNhap == username);
        }
    }
}
