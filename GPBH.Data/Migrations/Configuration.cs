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

            // Add SysDMCT
            AddSysDMCT(context);

            // Add To khai HH
            AddToKhaiHH(context);
        }

        private void AddToKhaiHH(AppDbContext context)
        {
            if (!context.TokhaiHH.Any())
            {
                var toKhaiList = new List<TokhaiHH>
                {
                    new TokhaiHH
                    {
                        Ma_cua_hang = "CH01",
                        Ma_kho = "KHO01",
                        So_to_khai = "123",
                        Ngay_nhap = new DateTime(2025, 6, 1),
                        Ma_hh = "SP0001",
                        So_luong = 10,
                        Da_xuat = 0,
                        Con_lai = 10
                    },
                    new TokhaiHH
                    {
                        Ma_cua_hang = "CH01",
                        Ma_kho = "KHO01",
                        So_to_khai = "456",
                        Ngay_nhap = new DateTime(2025, 6, 2),
                        Ma_hh = "SP0001",
                        So_luong = 10,
                        Da_xuat = 0,
                        Con_lai = 10
                    },
                    new TokhaiHH
                    {
                        Ma_cua_hang = "CH01",
                        Ma_kho = "KHO01",
                        So_to_khai = "123",
                        Ngay_nhap = new DateTime(2025, 6, 1),
                        Ma_hh = "ABC123",
                        So_luong = 5,
                        Da_xuat = 0,
                        Con_lai = 5
                    },
                    new TokhaiHH
                    {
                        Ma_cua_hang = "CH01",
                        Ma_kho = "KHO01",
                        So_to_khai = "456",
                        Ngay_nhap = new DateTime(2025, 6, 2),
                        Ma_hh = "ABC123",
                        So_luong = 10,
                        Da_xuat = 0,
                        Con_lai = 10
                    },
                };
                context.TokhaiHH.AddRange(toKhaiList);
                context.SaveChanges();
            }
        }

        private void AddSysDMCT(AppDbContext context)
        {
            if (!context.SysDMCT.Any())
            {
                var sysDMCTList = new List<SysDMCT>
                {
                    new SysDMCT
                    {
                        Ma_cua_hang = "CH01",
                        Ma_chung_tu = "X05",
                        Ma_nt = "USD",
                        So_lien = 2,
                        Sp_xu_ly = "sp_XuLyPhieuXuatKho",
                        Ph = "XPH5",
                        Ct = "XCT5",
                        Dau_so = "X05/{mm}/{yyyy}-",
                        So_phieu = 5,
                        Cuoi_so = "-ABC",
                        Cach_danh_so = "1", // Theo tháng
                        PhFieldlist2IN = "Ma_phieu,Ngay_lap,Ten_kh,Dia_chi",
                        CtFieldlist2IN = "Ma_vt,Ten_vt,So_luong,Don_gia"
                    },
                    new SysDMCT
                    {
                        Ma_cua_hang = "CH02",
                        Ma_chung_tu = "X05",
                        Ma_nt = "USD",
                        So_lien = 1,
                        Sp_xu_ly = "sp_XuLyPhieuNhapKho",
                        Ph = "XPH5",
                        Ct = "XCT5",
                        Dau_so = "PNK/{yy}-",
                        So_phieu = 4,
                        Cuoi_so = "",
                        Cach_danh_so = "0", // Theo năm
                        PhFieldlist2IN = "Ma_phieu,Ngay_lap,Ten_ncc,Dia_chi",
                        CtFieldlist2IN = "Ma_vt,Ten_vt,So_luong,Don_gia"
                    }
                 };
                context.SysDMCT.AddRange(sysDMCTList);
                context.SaveChanges();
            }
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
                        Ma_hh = "SP0001",
                        Gia_ban = 5
                    },
                    new DMGB
                    {
                        Ma_cua_hang = "CH01",
                        Ngay_ap_dung = new DateTime(2025, 6, 10),
                        Ma_hh = "ABC123",
                        Gia_ban = 6
                    },
                    new DMGB
                    {
                        Ma_cua_hang = "CH01",
                        Ngay_ap_dung = new DateTime(2025, 6, 1),
                        Ma_hh = "ABC123",
                        Gia_ban = 6
                    },
                    new DMGB
                    {
                        Ma_cua_hang = "CH01",
                        Ngay_ap_dung = new DateTime(2025, 6, 1),
                        Ma_hh = "X12YZ",
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
                    new DMNT { Ma_nt = "VND", Ksd = false },
                    new DMNT { Ma_nt = "USD", Ksd = false },
                    new DMNT { Ma_nt = "EUR", Ksd = false },
                    new DMNT { Ma_nt = "JPY", Ksd = false },
                    new DMNT { Ma_nt = "THB", Ksd = false },
                    new DMNT { Ma_nt = "AUD", Ksd = false }
                };
                context.DMNT.AddRange(fakeNgoaiTeList);
                context.SaveChanges();
            }

            if (!context.DMTG.Any())
            {
                var fakeTyGiaList = new List<DMTG>
                {
                    new DMTG { Ma_nt = "VND", Ty_gia = 1.0m, Ngay_ap_dung = new DateTime(2025,06,01) },
                    new DMTG { Ma_nt = "USD", Ty_gia = 23000.0m, Ngay_ap_dung = new DateTime(2025,06,12) },
                    new DMTG { Ma_nt = "USD", Ty_gia = 24000.0m, Ngay_ap_dung = new DateTime(2025,06,01) },
                    new DMTG { Ma_nt = "EUR", Ty_gia = 25000.0m, Ngay_ap_dung = new DateTime(2025,06,01) },
                    new DMTG { Ma_nt = "JPY", Ty_gia = 200.0m, Ngay_ap_dung = new DateTime(2025, 06, 01) },
                    new DMTG { Ma_nt = "THB", Ty_gia = 700.0m, Ngay_ap_dung = new DateTime(2025, 06, 01) },
                    new DMTG { Ma_nt = "AUD", Ty_gia = 15000.0m, Ngay_ap_dung = new DateTime(2025, 06, 01)}
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
                        Ma_hh = "SP0001",
                        Ten_hh = "Trà xanh Lipton",
                        Dvt = "Hộp",
                        Ma_nhom_hh = "NH10",
                        Thuong_hieu = "Lipton",
                        Ma_nsx = "NSX11",
                        Ten_nsx = "Lipton Việt Nam",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 18.0m,
                        Trong_luong = 0.18m,
                        Chieu_cao = 4.5m,
                        Ksd = false
                    },
                    new DMHH
                    {
                        Ma_hh = "ABC123",
                        Ten_hh = "Cà phê Trung Nguyên",
                        Dvt = "Gói",
                        Ma_nhom_hh = "NH11",
                        Thuong_hieu = "Trung Nguyên",
                        Ma_nsx = "NSX12",
                        Ten_nsx = "Trung Nguyên Legend",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 11.0m,
                        Trong_luong = 0.5m,
                        Chieu_cao = 8.0m,
                        Ksd = false
                    },
                    new DMHH
                    {
                        Ma_hh = "X12YZ",
                        Ten_hh = "Nước ép Vfresh",
                        Dvt = "Chai",
                        Ma_nhom_hh = "NH12",
                        Thuong_hieu = "Vfresh",
                        Ma_nsx = "NSX13",
                        Ten_nsx = "Vinamilk",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 7.0m,
                        Trong_luong = 0.35m,
                        Chieu_cao = 17.0m,
                        Ksd = false
                    },
                    new DMHH
                    {
                        Ma_hh = "QWERTY",
                        Ten_hh = "Kem Wall's",
                        Dvt = "Hộp",
                        Ma_nhom_hh = "NH13",
                        Thuong_hieu = "Wall's",
                        Ma_nsx = "NSX14",
                        Ten_nsx = "Unilever",
                        Nuoc_sx = "Thái Lan",
                        Chieu_dai = 10.0m,
                        Trong_luong = 0.6m,
                        Chieu_cao = 6.0m,
                        Ksd = false
                    },
                    new DMHH
                    {
                        Ma_hh = "987ZYX",
                        Ten_hh = "Yến sào Khánh Hoà",
                        Dvt = "Hộp",
                        Ma_nhom_hh = "NH14",
                        Thuong_hieu = "Yến sào Khánh Hoà",
                        Ma_nsx = "NSX15",
                        Ten_nsx = "Công ty Yến sào Khánh Hoà",
                        Nuoc_sx = "Việt Nam",
                        Chieu_dai = 16.0m,
                        Trong_luong = 0.25m,
                        Chieu_cao = 5.0m,
                        Ksd = false
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
                    Ma_nt_qd = "VND",
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
                    Ma_nt_qd = "VND",
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
                    Ksd = false,
                });
                context.SaveChanges();
            }
        }

        private static void AddMenu(AppDbContext context)
        {
            if (!context.SysMenu.Any())
            {
                context.SysMenu.AddOrUpdate(
                    // đơn hàng
                    new SysMenu { MenuName = "Màn hình chính", Type = SysMenuType.Document, MenuId = "DonHang", Report = false, BasicRight = true, Picture = "", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Tạo đơn hàng", Type = SysMenuType.Document, MenuId = "TaoDonHang", Report = false, BasicRight = true, Picture = "", Active = true, Stt = 2 },
                    new SysMenu { MenuName = "Nhận trả hàng", Type = SysMenuType.Document, MenuId = "NhanTraHang", Report = false, BasicRight = true, Picture = "", Active = true, Stt = 3 },
                    new SysMenu { MenuName = "Xuất hóa đơn", Type = SysMenuType.Document, MenuId = "XoaHoaDon", Report = false, BasicRight = true, Picture = "", Active = true, Stt = 4 },

                    // báo cáo
                    new SysMenu { MenuName = "Bán hàng theo khách hàng", Type = SysMenuType.Report, MenuId = "BanHangTheoKhachHang", Report = false, BasicRight = true, Picture = "", Active = true, Stt = 1 },

                    // danh mục
                    new SysMenu { MenuName = "Ca", MenuId = "Ca", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Quốc gia", MenuId = "QuocGia", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 2 },
                    new SysMenu { MenuName = "Khách hàng", MenuId = "KhachHang", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 3 },
                    new SysMenu { MenuName = "Ngoại tê", MenuId = "NgoaiTe", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 4 },
                    new SysMenu { MenuName = "Tỷ giá", MenuId = "TyGia", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 5 },
                    new SysMenu { MenuName = "Hành hóa", MenuId = "HangHoa", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 6 },
                    new SysMenu { MenuName = "Giá bán", MenuId = "GiaBan", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 7 },
                    new SysMenu { MenuName = "Định dạng form", MenuId = "DinhDangForm", Type = SysMenuType.Category, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 8 },

                    // cài đặt
                    new SysMenu { MenuName = "Tham số", MenuId = "ThamSo", Type = SysMenuType.Setting, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 1 },
                    new SysMenu { MenuName = "Đổi mật khâu", MenuId = "DoiMatKhau", Type = SysMenuType.Setting, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 2 },
                    new SysMenu { MenuName = "Người dùng", MenuId = "NguoiDung", Type = SysMenuType.Setting, Report = false, BasicRight = true, Picture = "", Active = true, Stt = 3 }
                );
                context.SaveChanges();
            }
        }

        private static void AddUserAdmin(AppDbContext context)
        {
            var userAdmin = context.SysDMNSD.Where(z => z.TenDangNhap == "SuperAdmin").FirstOrDefault();
            if (userAdmin != null) return;

            var entityUser = new SysDMNSD
            {
                TenDangNhap = "SuperAdmin",
                TenDayDu = "Quản trị hệ thống",
                MatKhau = HashPassword("SuperAdmin"), // Mật khẩu cần được mã hóa trước khi lưu
                IsAdmin = true,
                Ksd = false,
                CapLaiQuyen = false,
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