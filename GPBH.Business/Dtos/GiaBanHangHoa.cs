using System;

namespace GPBH.Business.Dtos
{
    public class GiaBanHangHoa
    {
        public string Ma_cua_hang { get; set; }        // Mã cửa hàng (PK)
        public DateTime Ngay_ap_dung { get; set; }     // Ngày áp dụng (PK)
        public string Ma_hh { get; set; }              // Mã hàng hóa (PK)
        public decimal Gia_ban { get; set; }           // Giá bán

        public TyGiaNT TyGiaNT { get; set; } // Tỷ giá ngoại tệ liên kết
    }
}
