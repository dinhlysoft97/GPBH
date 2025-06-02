using GPBH.Data.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

            // Add SysConfin
            AddSysConfig(context);
        }

        private static void AddSysConfig(AppDbContext context)
        {
            if (!context.SysConfig.Any())
            {
                context.SysConfig.Add(new SysConfig
                {
                    Id = 1,
                    Han_muc_giao_dich_tien_mat = 15000000,
                    Loai_tien_ap_dung_khi_ban_hang = "VND",
                    Ma_co_quan_thue = "1234567890",
                });
                context.SaveChanges();
            }
        }

        private static void AddMenu(AppDbContext context)
        {
            if (!context.SysMenu.Any())
            {
                context.SysMenu.AddOrUpdate(
                    new SysMenu { MenuName = "Đơn hàng", Type = SysMenuType.Document, MenuId = "DonHang", Report = false, BasicRight = true, Picture = "banhang", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Bán hàng theo khách hàng", Type = SysMenuType.Report, MenuId = "BanHangTheoKhachHang", Report = false, BasicRight = true, Picture = "baocaobanhang", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Đơn vị", MenuId = "DonVi", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Cửa hàng", MenuId = "CuaHang", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 2 },
                    new SysMenu { MenuName = "Ca", MenuId = "Ca", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 3 },
                    new SysMenu { MenuName = "Người dùng", MenuId = "NguoiDung", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 4 },
                    new SysMenu { MenuName = "Phân quyền", MenuId = "PhanQuyen", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 5 },
                    new SysMenu { MenuName = "Quốc gia", MenuId = "QuocGia", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 6 },
                    new SysMenu { MenuName = "Khách hàng", MenuId = "KhachHang", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 7 },
                    new SysMenu { MenuName = "Ngoại tê", MenuId = "NgoaiTe", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 8 },
                    new SysMenu { MenuName = "Tỷ giá", MenuId = "TyGia", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 9 },
                    new SysMenu { MenuName = "Hành hóa", MenuId = "HangHoa", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 10 },
                    new SysMenu { MenuName = "Giá bán", MenuId = "GiaBan", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 11 }
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
                Nguoi_tao = "system",
                Ngay_tao = DateTime.Now
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