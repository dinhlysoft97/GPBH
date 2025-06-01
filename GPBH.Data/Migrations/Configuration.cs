using GPBH.Data.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GPBH.Data.Migrations
{
    internal sealed class AppDbMigrationsConfiguration : DbMigrationsConfiguration<AppDbContext>
    {
        public AppDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            // Seed dữ liệu mẫu nếu cần

            // tạo user admin
            AddUserAdmin(context);

            // Add thêm các menu mẫu
            AddMenu(context);
        }

        private static void AddMenu(AppDbContext context)
        {
            if (!context.SysMenu.Any())
            {
                context.SysMenu.AddOrUpdate(
                    new SysMenu { MenuName = "Đơn hàng", Type = SysMenuType.Document, Key = "DonHang", Report = false, BasicRight = true, Picture = "banhang", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Bán hàng theo khách hàng", Type = SysMenuType.Report, Key = "BanHangTheoKhachHang", Report = false, BasicRight = true, Picture = "baocaobanhang", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Khách hàng", Key = "KhachHang", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Quốc gia", Key = "QuocGia", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 2 }
                );
                context.SaveChanges();
            }
        }

        private static void AddUserAdmin(AppDbContext context)
        {
            var userAdmin = context.SysDMNSD.Where(z => z.TenDangNhap == "admin").FirstOrDefault();
            if (userAdmin != null) return;

            var entityUser = new SysDMNSD
            {
                TenDangNhap = "admin",
                TenDayDu = "Quản trị hệ thống",
                MatKhau = HashPassword("admin"), // Mật khẩu cần được mã hóa trước khi lưu
                IsAdmin = true,
                Ksd = true,
                NguoiTao = "system",
                NgayTao = DateTime.Now
            };
            context.SysDMNSD.Add(entityUser);
            context.SaveChanges();
        }

        /// <summary>
        /// Hàm mã hóa mật khẩu sử dụng SHA-256
        /// </summary>
        private static string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}