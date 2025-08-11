using System;

namespace GPBH.Data.Entities
{
    public class ViewBaoCaoKhacHang
    {
        public string Noi_ban { get; set; }                        // ph.Ma_cua_hang
        public string Ten_khachhang { get; set; }                  // LTRIM(RTRIM(kh.Ho + ' ' + kh.Ten_dem + ' ' + kh.Ten))
        public string Passport { get; set; }                       // kh.Passport
        public DateTime Ngay_ban { get; set; }                     // ph.Ngay_chung_tu
        public string So_don_hang { get; set; }                    // ph.So_chung_tu
        public string Ma_phieu { get; set; }                       // ph.Ma_phieu
        public string Ten_hang { get; set; }                       // ct.Ten_hh
        public string Ma_hang { get; set; }                        // ct.Ma_hh
        public decimal So_luong { get; set; }                      // ct.So_luong
        public string Ma_ngoaite { get; set; }                     // ph.Ma_nt
        public decimal Thanh_tien { get; set; }                    // ph.Tong_thu_nt
        public decimal Thanh_tien_vn { get; set; }                 // ph.Tong_thu
        public decimal Tong_tien_hang_nt { get; set; }             // ph.Tong_tien_hang_nt
        public decimal Tong_nhan { get; set; }                     // ph.Tong_nhan
        public decimal Tra_lai_nt { get; set; }                    // ph.Tra_lai_nt
        public string Ma_tra_lai { get; set; }                     // ph.Ma_tra_lai
        public decimal Ty_gia { get; set; }                        // ph.Ty_gia
        public string Ma_hs { get; set; }                          // ct.So_to_khai
    }
}
