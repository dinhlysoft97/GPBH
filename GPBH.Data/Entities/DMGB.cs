using GPBH.Data.Configurations;
using System;

namespace GPBH.Data.Entities
{
    public class DMGB
    {
        public string Ma_cua_hang { get; set; }        // Mã cửa hàng (PK)
        public DateTime Ngay_ap_dung { get; set; }     // Ngày áp dụng (PK)
        public string Ma_hh { get; set; }              // Mã hàng hóa (PK)
        public decimal Gia_ban { get; set; }           // Giá bán
        public SysDMCuaHang SysDMCuaHang { get; set; } // Thông tin cửa hàng liên kết
        public DMHH DMHH { get; set; }                 // Thông tin hàng hóa liên kết
    }
}
