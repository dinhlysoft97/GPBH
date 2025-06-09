using GPBH.Data.Configurations;
using GPBH.Data.Entities;
using System;
using System.Collections.Generic;
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

            // DM Quốc gia
            AddDMQG(context);

            // DM TG và NT
            ADDTGvaNT(context);

            // DM Cửa Hàng
            AddDMCH(context);

            // DM Hàng Hóa
            AddHangHoa(context);

            // Add DM giá bán
            ADDDanhMucGiaBan(context);
        }

        private void ADDDanhMucGiaBan(AppDbContext context)
        {
            if (!context.DMGB.Any())
            {
                var fakeGiaBanList = new List<DMGB>
                {
                    new DMGB
                    {
                        Ma_cua_hang = "CH01",
                        Ngay_ap_dung = new DateTime(2025, 6, 1),
                        Ma_hh = "HH001",
                        Gia_ban = 5
                    },
                    new DMGB
                    {
                        Ma_cua_hang = "CH01",
                        Ngay_ap_dung = new DateTime(2025, 6, 10),
                        Ma_hh = "HH002",
                        Gia_ban = 6
                    },
                    new DMGB
                    {
                        Ma_cua_hang = "CH01",
                        Ngay_ap_dung = new DateTime(2025, 6, 1),
                        Ma_hh = "HH002",
                        Gia_ban = 6
                    },
                    new DMGB
                    {
                        Ma_cua_hang = "CH01",
                        Ngay_ap_dung = new DateTime(2025, 6, 1),
                        Ma_hh = "HH003",
                        Gia_ban = 7
                    }
                };
                context.DMGB.AddRange(fakeGiaBanList);
                context.SaveChanges();
            }
        }

        private void ADDTGvaNT(AppDbContext context)
        {
            if (!context.DMNT.Any())
            {
                var fakeNgoaiTeList = new List<DMNT>
                {
                    new DMNT { Ma_nt = "VND", Ksd = true },
                    new DMNT { Ma_nt = "USD", Ksd = true },
                    new DMNT { Ma_nt = "EUR", Ksd = true },
                    new DMNT { Ma_nt = "JPY", Ksd = true },
                    new DMNT { Ma_nt = "THB", Ksd = true },
                    new DMNT { Ma_nt = "AUD", Ksd = true }
                };
                context.DMNT.AddRange(fakeNgoaiTeList);
                context.SaveChanges();
            }

            if (!context.DMTG.Any())
            {
                var fakeTyGiaList = new List<DMTG>
                {
                    new DMTG { Ma_nt = "VND", Ty_gia = 1.0m, Ngay_ap_dung = DateTime.Now },
                    new DMTG { Ma_nt = "USD", Ty_gia = 23000.0m, Ngay_ap_dung = new DateTime(2025,06,12)  },
                    new DMTG { Ma_nt = "USD", Ty_gia = 24000.0m, Ngay_ap_dung = new DateTime(2025,06,01) },
                    new DMTG { Ma_nt = "EUR", Ty_gia = 25000.0m, Ngay_ap_dung = DateTime.Now },
                    new DMTG { Ma_nt = "JPY", Ty_gia = 200.0m, Ngay_ap_dung = DateTime.Now },
                    new DMTG { Ma_nt = "THB", Ty_gia = 700.0m, Ngay_ap_dung = DateTime.Now },
                    new DMTG { Ma_nt = "AUD", Ty_gia = 15000.0m, Ngay_ap_dung = DateTime.Now }
                };

                context.DMTG.AddRange(fakeTyGiaList);
                context.SaveChanges();
            }
        }

        private void AddHangHoa(AppDbContext context)
        {
            if (!context.DMHH.Any())
            {
                var fakeHangHoaList = new List<DMHH>
                {
                    new DMHH
                    {
                        Ma_hh = "HH001",
                        Ten_hh = "Bánh quy AFC",
                        Dvt = "Hộp",
                        Ma_nhom_hh = "NH01",
                        Thuong_hieu = "Kinh Đô",
                        Ma_nsx = "NSX01",
                        Ten_nsx = "Công ty Kinh Đô",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 20.5m,
                        Trong_luong = 0.25m,
                        Chieu_cao = 5.2m,
                        Ksd = true
                    },
                    new DMHH
                    {
                        Ma_hh = "HH002",
                        Ten_hh = "Sữa tươi Vinamilk",
                        Dvt = "Thùng",
                        Ma_nhom_hh = "NH02",
                        Thuong_hieu = "Vinamilk",
                        Ma_nsx = "NSX02",
                        Ten_nsx = "Công ty Vinamilk",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 35.0m,
                        Trong_luong = 10.0m,
                        Chieu_cao = 25.0m,
                        Ksd = true
                    },
                    new DMHH
                    {
                        Ma_hh = "HH003",
                        Ten_hh = "Bột giặt Omo",
                        Dvt = "Túi",
                        Ma_nhom_hh = "NH03",
                        Thuong_hieu = "Unilever",
                        Ma_nsx = "NSX03",
                        Ten_nsx = "Unilever Việt Nam",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 15.2m,
                        Trong_luong = 3.5m,
                        Chieu_cao = 8.7m,
                        Ksd = true
                    },
                    new DMHH
                    {
                        Ma_hh = "HH004",
                        Ten_hh = "Mì Hảo Hảo",
                        Dvt = "Thùng",
                        Ma_nhom_hh = "NH01",
                        Thuong_hieu = "Acecook",
                        Ma_nsx = "NSX04",
                        Ten_nsx = "Acecook Việt Nam",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 40.0m,
                        Trong_luong = 12.0m,
                        Chieu_cao = 30.0m,
                        Ksd = true
                    },
                    new DMHH
                    {
                        Ma_hh = "HH005",
                        Ten_hh = "Nước suối Lavie",
                        Dvt = "Chai",
                        Ma_nhom_hh = "NH04",
                        Thuong_hieu = "Lavie",
                        Ma_nsx = "NSX05",
                        Ten_nsx = "Nestlé Waters",
                        Nuoc_sx = "Pháp",
                        Chieu_dai = 6.5m,
                        Trong_luong = 0.5m,
                        Chieu_cao = 20.0m,
                        Ksd = true
                    }
                };
                context.DMHH.AddRange(fakeHangHoaList);
                context.SaveChanges();
            }
        }

        private void AddDMCH(AppDbContext context)
        {
            if (!context.SysDMDV.Any())
            {
                context.SysDMDV.Add(new SysDMDV
                {
                    Ma_dv = "DV1",
                    Ten_dv = "Đơn vị 01",
                    Dia_chi = "123 Đường A, Quận 1, TP.HCM",
                    Ma_so_thue = "123123123",
                });
                context.SaveChanges();
            }

            if (!context.SysDMCuaHang.Any())
            {
                context.SysDMCuaHang.Add(new SysDMCuaHang
                {
                    Ma_dv = "DV1",
                    Ma_cua_hang = "CH01",
                    Ten_cua_hang = "Cửa Hàng 01",
                    Dia_chi = "123 Đường A, Quận 1, TP.HCM",
                    Ma_nhom_kh = "NKH01",
                    Ma_loai_hinh = "LH01",
                    Ma_doi_tuong = "DT001",
                    Ma_nt = "USD",
                    Han_muc_tm = 15000000,
                    Ma_cqt = "CQT01",
                    Nhap_ttxnc = true
                });
                context.SysDMCuaHang.Add(new SysDMCuaHang
                {
                    Ma_dv = "DV1",
                    Ma_cua_hang = "CH02",
                    Ten_cua_hang = "Cửa Hàng 02",
                    Dia_chi = "123 Đường A, Quận 1, TP.HCM",
                    Ma_nhom_kh = "NKH01",
                    Ma_loai_hinh = "LH01",
                    Ma_doi_tuong = "DT001",
                    Ma_nt = "MYR",
                    Han_muc_tm = 15000000,
                    Ma_cqt = "CQT01",
                    Nhap_ttxnc = true
                });
                context.SaveChanges();
            }
        }

        private void AddDMQG(AppDbContext context)
        {
            if (!context.DMQG.Any())
            {
                context.DMQG.Add(new DMQG
                {
                    Quoc_gia = "VN",
                    Ten_Quoc_gia = "Việt Nam",
                    Ksd = true,
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