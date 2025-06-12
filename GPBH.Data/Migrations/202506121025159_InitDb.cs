namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DMca",
                c => new
                    {
                        Ma_ca = c.String(nullable: false, maxLength: 20),
                        Ten_ca = c.String(maxLength: 50),
                        Gio_bd = c.String(maxLength: 5),
                        Gio_kt = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Ma_ca);
            
            CreateTable(
                "dbo.DMGB",
                c => new
                    {
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Ngay_ap_dung = c.DateTime(nullable: false),
                        Ma_hh = c.String(nullable: false, maxLength: 20),
                        Gia_ban = c.Decimal(nullable: false, precision: 28, scale: 8),
                    })
                .PrimaryKey(t => new { t.Ma_cua_hang, t.Ngay_ap_dung, t.Ma_hh })
                .ForeignKey("dbo.DMHH", t => t.Ma_hh, cascadeDelete: true)
                .ForeignKey("dbo.SysDMCuaHang", t => t.Ma_cua_hang, cascadeDelete: true)
                .Index(t => t.Ma_cua_hang)
                .Index(t => t.Ma_hh);
            
            CreateTable(
                "dbo.DMHH",
                c => new
                    {
                        Ma_hh = c.String(nullable: false, maxLength: 20),
                        Ten_hh = c.String(maxLength: 50),
                        Dvt = c.String(maxLength: 20),
                        Ma_nhom_hh = c.String(maxLength: 20),
                        Thuong_hieu = c.String(maxLength: 50),
                        Ma_nsx = c.String(maxLength: 20),
                        Ten_nsx = c.String(maxLength: 100),
                        Nuoc_sx = c.String(maxLength: 20),
                        Chieu_dai = c.Decimal(precision: 28, scale: 8),
                        Trong_luong = c.Decimal(precision: 28, scale: 8),
                        Chieu_cao = c.Decimal(precision: 28, scale: 8),
                        Ksd = c.Boolean(nullable: false),
                        Nguoi_tao = c.String(maxLength: 20),
                        Ngay_tao = c.DateTime(),
                        Nguoi_sua = c.String(maxLength: 20),
                        Ngay_sua = c.DateTime(),
                    })
                .PrimaryKey(t => t.Ma_hh);
            
            CreateTable(
                "dbo.TokhaiHH",
                c => new
                    {
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Ma_kho = c.String(nullable: false, maxLength: 20),
                        So_to_khai = c.String(nullable: false, maxLength: 20),
                        Ma_hh = c.String(nullable: false, maxLength: 20),
                        Ngay_nhap = c.DateTime(),
                        So_luong = c.Decimal(precision: 28, scale: 8),
                        Da_xuat = c.Decimal(precision: 28, scale: 8),
                        Con_lai = c.Decimal(precision: 28, scale: 8),
                    })
                .PrimaryKey(t => new { t.Ma_cua_hang, t.Ma_kho, t.So_to_khai, t.Ma_hh })
                .ForeignKey("dbo.DMHH", t => t.Ma_hh, cascadeDelete: true)
                .ForeignKey("dbo.SysDMCuaHang", t => t.Ma_cua_hang, cascadeDelete: true)
                .Index(t => t.Ma_cua_hang)
                .Index(t => t.Ma_hh);
            
            CreateTable(
                "dbo.SysDMCuaHang",
                c => new
                    {
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Ma_dv = c.String(nullable: false, maxLength: 3),
                        Ten_cua_hang = c.String(maxLength: 200),
                        Dia_chi = c.String(maxLength: 200),
                        Ma_nhom_kh = c.String(maxLength: 20),
                        Ma_loai_hinh = c.String(maxLength: 20),
                        Ma_doi_tuong = c.String(maxLength: 20),
                        Ma_nt = c.String(maxLength: 3),
                        Ma_qd = c.String(),
                        Han_muc_tm = c.Decimal(nullable: false, precision: 28, scale: 8),
                        Ma_cqt = c.String(maxLength: 50),
                        Nhap_ttxnc = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_cua_hang)
                .ForeignKey("dbo.SysDMDV", t => t.Ma_dv, cascadeDelete: true)
                .Index(t => t.Ma_dv);
            
            CreateTable(
                "dbo.SysDMDV",
                c => new
                    {
                        Ma_dv = c.String(nullable: false, maxLength: 3),
                        Ten_dv = c.String(maxLength: 100),
                        Dia_chi = c.String(maxLength: 100),
                        Ma_so_thue = c.String(maxLength: 20),
                        Ma_hqcq = c.String(maxLength: 20),
                        So_dien_thoai = c.String(maxLength: 20),
                        So_fax = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Nlh_ho_ten = c.String(maxLength: 50),
                        Nlh_chuc_vu = c.String(maxLength: 50),
                        Nlh_Sdt = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Ma_dv);
            
            CreateTable(
                "dbo.SystemSetting",
                c => new
                    {
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Key = c.String(nullable: false, maxLength: 128),
                        Ten = c.String(),
                        GiaTri = c.String(),
                        Mota = c.String(),
                    })
                .PrimaryKey(t => new { t.Ma_cua_hang, t.Key })
                .ForeignKey("dbo.SysDMCuaHang", t => t.Ma_cua_hang, cascadeDelete: true)
                .Index(t => t.Ma_cua_hang);
            
            CreateTable(
                "dbo.XPH5",
                c => new
                    {
                        Ma_phieu = c.String(nullable: false, maxLength: 50),
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Ma_chung_tu = c.String(maxLength: 3),
                        So_chung_tu = c.String(maxLength: 50),
                        Ngay_chung_tu = c.DateTime(nullable: false),
                        Ma_nt = c.String(nullable: false, maxLength: 3),
                        Ty_gia = c.Decimal(precision: 28, scale: 8),
                        Ma_quay = c.String(maxLength: 20),
                        Ma_cqt = c.String(maxLength: 50),
                        Xuat_hddt = c.Boolean(nullable: false),
                        So_hddt = c.String(maxLength: 20),
                        Xuat_hq = c.Boolean(nullable: false),
                        Ma_kho = c.String(maxLength: 20),
                        Passport = c.String(maxLength: 20),
                        Ten_khach = c.String(maxLength: 100),
                        Tt1_loai = c.String(maxLength: 10),
                        Tt1_ma_nt = c.String(maxLength: 3),
                        Tt1_tien_tt = c.Decimal(precision: 28, scale: 8),
                        Tt1_tien_nt = c.Decimal(precision: 28, scale: 8),
                        Tt2_loai = c.String(maxLength: 10),
                        Tt2_ma_nt = c.String(maxLength: 3),
                        Tt2_tien_tt = c.Decimal(precision: 28, scale: 8),
                        Tt2_tien_nt = c.Decimal(precision: 28, scale: 8),
                        Tt3_loai = c.String(maxLength: 10),
                        Tt3_ma_nt = c.String(maxLength: 3),
                        Tt3_tien_tt = c.Decimal(precision: 28, scale: 8),
                        Tt3_tien_nt = c.Decimal(precision: 28, scale: 8),
                        Tt_tong = c.Decimal(precision: 28, scale: 8),
                        Tong_nhan = c.Decimal(precision: 28, scale: 8),
                        Tra_lai = c.Decimal(precision: 28, scale: 8),
                        Ma_tra_lai = c.String(maxLength: 3),
                        Tra_lai_nt = c.Decimal(precision: 28, scale: 8),
                        Tong_tien_hang = c.Decimal(precision: 28, scale: 8),
                        Tong_tien_hang_nt = c.Decimal(precision: 28, scale: 8),
                        Tong_giam_gia = c.Decimal(precision: 28, scale: 8),
                        Tong_giam_gia_nt = c.Decimal(precision: 28, scale: 8),
                        Tong_thu = c.Decimal(precision: 28, scale: 8),
                        Tong_thu_nt = c.Decimal(precision: 28, scale: 8),
                        Tong_so_luong = c.Decimal(precision: 28, scale: 8),
                        Xnc_ngay_cap = c.DateTime(),
                        Xnc_ngay_hh = c.DateTime(),
                        So_hieu = c.String(maxLength: 20),
                        Ten_tau_bay = c.String(maxLength: 20),
                        Han_muc = c.Decimal(precision: 28, scale: 8),
                        Ma_nhom_kh = c.String(maxLength: 20),
                        Ma_loai_hinh = c.String(maxLength: 20),
                        Ma_doi_tuong = c.String(maxLength: 20),
                        Trang_thai = c.Int(nullable: false),
                        Nguoi_tao = c.String(maxLength: 20),
                        Ngay_tao = c.DateTime(),
                        Nguoi_sua = c.String(maxLength: 20),
                        Ngay_sua = c.DateTime(),
                    })
                .PrimaryKey(t => t.Ma_phieu)
                .ForeignKey("dbo.DMNT", t => t.Ma_nt, cascadeDelete: true)
                .ForeignKey("dbo.SysDMCuaHang", t => t.Ma_cua_hang, cascadeDelete: true)
                .Index(t => t.Ma_cua_hang)
                .Index(t => t.Ma_nt);
            
            CreateTable(
                "dbo.DMNT",
                c => new
                    {
                        Ma_nt = c.String(nullable: false, maxLength: 3),
                        Ksd = c.Boolean(nullable: false),
                        Nguoi_tao = c.String(maxLength: 20),
                        Ngay_tao = c.DateTime(),
                        Nguoi_sua = c.String(maxLength: 20),
                        Ngay_sua = c.DateTime(),
                    })
                .PrimaryKey(t => t.Ma_nt);
            
            CreateTable(
                "dbo.DMTG",
                c => new
                    {
                        Ma_nt = c.String(nullable: false, maxLength: 3),
                        Ngay_ap_dung = c.DateTime(nullable: false),
                        Ty_gia = c.Decimal(nullable: false, precision: 28, scale: 8),
                        Nguoi_tao = c.String(maxLength: 20),
                        Ngay_tao = c.DateTime(),
                        Nguoi_sua = c.String(maxLength: 20),
                        Ngay_sua = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.Ma_nt, t.Ngay_ap_dung })
                .ForeignKey("dbo.DMNT", t => t.Ma_nt, cascadeDelete: true)
                .Index(t => t.Ma_nt);
            
            CreateTable(
                "dbo.XCT5",
                c => new
                    {
                        Ma_phieu = c.String(nullable: false, maxLength: 50),
                        Stt = c.Int(nullable: false),
                        Ma_hh = c.String(nullable: false, maxLength: 20),
                        Ten_hh = c.String(maxLength: 50),
                        Dvt = c.String(maxLength: 20),
                        So_luong = c.Decimal(precision: 28, scale: 8),
                        Gia_ban = c.Decimal(precision: 28, scale: 8),
                        Gia_ban_nt = c.Decimal(precision: 28, scale: 8),
                        Gg_ty_le = c.Decimal(precision: 28, scale: 8),
                        Gg_tien = c.Decimal(precision: 28, scale: 8),
                        Gg_tien_nt = c.Decimal(precision: 28, scale: 8),
                        Tien_ban = c.Decimal(precision: 28, scale: 8),
                        Tien_ban_nt = c.Decimal(precision: 28, scale: 8),
                        Gg_ly_do = c.String(maxLength: 50),
                        So_to_khai = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => new { t.Ma_phieu, t.Stt })
                .ForeignKey("dbo.DMHH", t => t.Ma_hh, cascadeDelete: true)
                .ForeignKey("dbo.XPH5", t => t.Ma_phieu, cascadeDelete: true)
                .Index(t => t.Ma_phieu)
                .Index(t => t.Ma_hh);
            
            CreateTable(
                "dbo.DMKH",
                c => new
                    {
                        Passport = c.String(nullable: false, maxLength: 8),
                        Ho = c.String(maxLength: 20),
                        Ten_dem = c.String(maxLength: 20),
                        Ten = c.String(maxLength: 20),
                        Ngay_cap = c.DateTime(),
                        Ngay_hh = c.DateTime(),
                        Quoc_gia = c.String(nullable: false, maxLength: 20),
                        Gioi_tinh = c.String(maxLength: 1),
                        Ngay_sinh = c.DateTime(),
                        Dia_chi = c.String(maxLength: 200),
                        Dien_thoai = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Xnc_ngay_cap = c.DateTime(),
                        Xnc_ngay_hh = c.DateTime(),
                        So_hieu = c.String(),
                        Ten_tau_bay = c.String(),
                        Han_muc = c.Decimal(precision: 18, scale: 2),
                        Nguoi_tao = c.String(maxLength: 20),
                        Ngay_tao = c.DateTime(),
                        Nguoi_sua = c.String(maxLength: 20),
                        Ngay_sua = c.DateTime(),
                    })
                .PrimaryKey(t => t.Passport)
                .ForeignKey("dbo.DMQG", t => t.Quoc_gia, cascadeDelete: true)
                .Index(t => t.Quoc_gia);
            
            CreateTable(
                "dbo.DMQG",
                c => new
                    {
                        Quoc_gia = c.String(nullable: false, maxLength: 20),
                        Ten_Quoc_gia = c.String(),
                        Ksd = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Quoc_gia);
            
            CreateTable(
                "dbo.SysDinh_dang_form",
                c => new
                    {
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Code_name = c.String(nullable: false, maxLength: 20),
                        MenuId = c.String(nullable: false, maxLength: 20),
                        Field_name = c.String(nullable: false, maxLength: 50),
                        Field_type = c.String(maxLength: 50),
                        Field_title = c.String(maxLength: 255),
                        Field_order = c.Int(nullable: false),
                        Field_hide = c.Boolean(nullable: false),
                        Field_width = c.Int(nullable: false),
                        Field_format = c.String(maxLength: 20),
                        Default_sort = c.Int(nullable: false),
                        Ten_ban = c.String(),
                        Stt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ma_cua_hang, t.Code_name, t.MenuId, t.Field_name });
            
            CreateTable(
                "dbo.SysDMCT",
                c => new
                    {
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Ma_chung_tu = c.String(nullable: false, maxLength: 3),
                        Ma_nt = c.String(maxLength: 3),
                        So_lien = c.Int(),
                        Sp_xu_ly = c.String(maxLength: 50),
                        Ph = c.String(maxLength: 50),
                        Ct = c.String(maxLength: 50),
                        Dau_so = c.String(maxLength: 50),
                        So_phieu = c.Int(nullable: false),
                        Cuoi_so = c.String(maxLength: 50),
                        Cach_danh_so = c.String(maxLength: 1),
                        PhFieldlist2IN = c.String(maxLength: 1000),
                        CtFieldlist2IN = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => new { t.Ma_cua_hang, t.Ma_chung_tu });
            
            CreateTable(
                "dbo.SysDMNSD",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 20),
                        TenDayDu = c.String(maxLength: 50),
                        MatKhau = c.String(maxLength: 500),
                        IsAdmin = c.Boolean(nullable: false),
                        Ksd = c.Boolean(nullable: false),
                        CapLaiQuyen = c.Boolean(nullable: false),
                        Nguoi_tao = c.String(maxLength: 20),
                        Ngay_tao = c.DateTime(),
                        Nguoi_sua = c.String(maxLength: 20),
                        Ngay_sua = c.DateTime(),
                    })
                .PrimaryKey(t => t.TenDangNhap)
                .Index(t => t.TenDangNhap, unique: true);
            
            CreateTable(
                "dbo.SysPhanQuyen",
                c => new
                    {
                        MenuId = c.String(nullable: false, maxLength: 100),
                        Ten_dang_nhap = c.String(nullable: false, maxLength: 20),
                        Xem = c.Boolean(),
                        Them = c.Boolean(),
                        Sua = c.Boolean(),
                        Xoa = c.Boolean(),
                        In = c.Boolean(),
                        Excel = c.Boolean(),
                        Nguoi_tao = c.String(maxLength: 20),
                        Ngay_tao = c.DateTime(),
                        Nguoi_sua = c.String(maxLength: 20),
                        Ngay_sua = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.MenuId, t.Ten_dang_nhap })
                .ForeignKey("dbo.SysDMNSD", t => t.Ten_dang_nhap, cascadeDelete: true)
                .ForeignKey("dbo.SysMenu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.Ten_dang_nhap);
            
            CreateTable(
                "dbo.SysMenu",
                c => new
                    {
                        MenuId = c.String(nullable: false, maxLength: 100),
                        MenuName = c.String(maxLength: 50),
                        Type = c.Int(nullable: false),
                        Report = c.Boolean(nullable: false),
                        BasicRight = c.Boolean(nullable: false),
                        Picture = c.String(),
                        Active = c.Boolean(nullable: false),
                        Stt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.SysSoChungTu",
                c => new
                    {
                        Ma_cua_hang = c.String(nullable: false, maxLength: 20),
                        Ma_chung_tu = c.String(nullable: false, maxLength: 3),
                        Thang = c.Int(nullable: false),
                        Nam = c.Int(nullable: false),
                        So_phieu = c.String(nullable: false, maxLength: 50),
                        Ngay_lap = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.Ma_cua_hang, t.Ma_chung_tu, t.Thang, t.Nam, t.So_phieu });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysPhanQuyen", "MenuId", "dbo.SysMenu");
            DropForeignKey("dbo.SysPhanQuyen", "Ten_dang_nhap", "dbo.SysDMNSD");
            DropForeignKey("dbo.DMKH", "Quoc_gia", "dbo.DMQG");
            DropForeignKey("dbo.DMGB", "Ma_cua_hang", "dbo.SysDMCuaHang");
            DropForeignKey("dbo.DMGB", "Ma_hh", "dbo.DMHH");
            DropForeignKey("dbo.TokhaiHH", "Ma_cua_hang", "dbo.SysDMCuaHang");
            DropForeignKey("dbo.XCT5", "Ma_phieu", "dbo.XPH5");
            DropForeignKey("dbo.XCT5", "Ma_hh", "dbo.DMHH");
            DropForeignKey("dbo.XPH5", "Ma_cua_hang", "dbo.SysDMCuaHang");
            DropForeignKey("dbo.XPH5", "Ma_nt", "dbo.DMNT");
            DropForeignKey("dbo.DMTG", "Ma_nt", "dbo.DMNT");
            DropForeignKey("dbo.SystemSetting", "Ma_cua_hang", "dbo.SysDMCuaHang");
            DropForeignKey("dbo.SysDMCuaHang", "Ma_dv", "dbo.SysDMDV");
            DropForeignKey("dbo.TokhaiHH", "Ma_hh", "dbo.DMHH");
            DropIndex("dbo.SysPhanQuyen", new[] { "Ten_dang_nhap" });
            DropIndex("dbo.SysPhanQuyen", new[] { "MenuId" });
            DropIndex("dbo.SysDMNSD", new[] { "TenDangNhap" });
            DropIndex("dbo.DMKH", new[] { "Quoc_gia" });
            DropIndex("dbo.XCT5", new[] { "Ma_hh" });
            DropIndex("dbo.XCT5", new[] { "Ma_phieu" });
            DropIndex("dbo.DMTG", new[] { "Ma_nt" });
            DropIndex("dbo.XPH5", new[] { "Ma_nt" });
            DropIndex("dbo.XPH5", new[] { "Ma_cua_hang" });
            DropIndex("dbo.SystemSetting", new[] { "Ma_cua_hang" });
            DropIndex("dbo.SysDMCuaHang", new[] { "Ma_dv" });
            DropIndex("dbo.TokhaiHH", new[] { "Ma_hh" });
            DropIndex("dbo.TokhaiHH", new[] { "Ma_cua_hang" });
            DropIndex("dbo.DMGB", new[] { "Ma_hh" });
            DropIndex("dbo.DMGB", new[] { "Ma_cua_hang" });
            DropTable("dbo.SysSoChungTu");
            DropTable("dbo.SysMenu");
            DropTable("dbo.SysPhanQuyen");
            DropTable("dbo.SysDMNSD");
            DropTable("dbo.SysDMCT");
            DropTable("dbo.SysDinh_dang_form");
            DropTable("dbo.DMQG");
            DropTable("dbo.DMKH");
            DropTable("dbo.XCT5");
            DropTable("dbo.DMTG");
            DropTable("dbo.DMNT");
            DropTable("dbo.XPH5");
            DropTable("dbo.SystemSetting");
            DropTable("dbo.SysDMDV");
            DropTable("dbo.SysDMCuaHang");
            DropTable("dbo.TokhaiHH");
            DropTable("dbo.DMHH");
            DropTable("dbo.DMGB");
            DropTable("dbo.DMca");
        }
    }
}
