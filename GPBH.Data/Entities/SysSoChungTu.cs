using System;

namespace GPBH.Data.Entities
{
    public class SysSoChungTu
    {
        // Mã cửa hàng
        public string Ma_cua_hang { get; set; }

        // Mã chứng từ
        public string Ma_chung_tu { get; set; }

        // Tháng (=0 nếu sysDMCT.Cach_danh_so=1, ngược lại =month(ngay_lap))
        public int? Thang { get; set; }

        // Năm (Year(ngay_lap))
        public int? Nam { get; set; }

        // Ngày lập
        public DateTime? Ngay_lap { get; set; }

        // Số phiếu
        public string So_phieu { get; set; }
    }
}
