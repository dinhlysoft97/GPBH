namespace GPBH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addViewBaoCaoKhacHang : DbMigration
    {
        public override void Up()
        {
            Sql(@"
         CREATE VIEW vw_BaoCaoBanTheoKhachHang AS
         SELECT 
         ph.Ma_cua_hang AS Noi_ban,
         LTRIM(RTRIM(kh.Ho + ' ' + kh.Ten_dem + ' ' + kh.Ten)) AS Ten_khachhang,
         kh.Passport,
         ph.Ngay_chung_tu AS Ngay_ban,
         ph.So_chung_tu AS So_don_hang,
         ph.Ma_phieu AS Ma_phieu,
         ct.Ten_hh AS Ten_hang,
         ct.Ma_hh AS Ma_hang,
         ct.So_luong AS So_luong,
         ph.Ma_nt AS Ma_ngoaite,
         ph.Tong_thu_nt AS Thanh_tien,
         ph.Tong_thu AS Thanh_tien_vn,
         ph.Tong_tien_hang_nt As Tong_tien_hang_nt,
         ph.Tong_nhan AS Tong_nhan,
         ph.Tra_lai_nt As Tra_lai_nt,
         ph.Ma_tra_lai As Ma_tra_lai,
         ph.Ty_gia As Ty_gia
     FROM XPH5 ph
     INNER JOIN XCT5 ct ON ph.Ma_phieu = ct.Ma_phieu
     INNER JOIN DMKH kh ON ph.Passport = kh.Passport
     INNER JOIN DMHH hh ON ct.Ma_hh = hh.Ma_hh
     ");

        }

        public override void Down()
        {
            Sql("DROP VIEW vw_BaoCaoBanTheoKhachHang");
        }
    }
}
