using GPBH.Data.Configurations;
using System;

namespace GPBH.Data.Entities
{
    public class TokhaiHH
    {
        // Mã cửa hàng
        public string Ma_cua_hang { get; set; }

        // Mã kho
        public string Ma_kho { get; set; }

        // Số tờ khai
        public string So_to_khai { get; set; }

        // Ngày nhập
        public DateTime? Ngay_nhap { get; set; }

        // Mã hàng hóa
        public string Ma_hh { get; set; }

        // Số lượng
        public decimal? So_luong { get; set; }

        // Đã xuất
        public decimal? Da_xuat { get; set; }

        // Còn lại
        public decimal? Con_lai { get; set; }

        public SysDMCuaHang SysDMCuaHang { get; set; } // Thông tin cửa hàng liên kết
        public DMHH DMHH { get; set; } // Thông tin hàng hóa liên kết
    }
}
