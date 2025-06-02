using GPBH.Data.Configurations;

namespace GPBH.Data.Entities
{
    public class XCT5
    {
        // Mã phiếu
        public string Ma_phieu { get; set; }

        // STT dòng trong phiếu
        public int Stt { get; set; }

        // Mã hàng hóa
        public string Ma_hh { get; set; }

        // Tên hàng hóa
        public string Ten_hh { get; set; }

        // Đơn vị tính
        public string Dvt { get; set; }

        // Số lượng
        public decimal? So_luong { get; set; }

        // Giá bán
        public decimal? Gia_ban { get; set; }

        // Giá bán ngoại tệ
        public decimal? Gia_ban_nt { get; set; }

        // Tỷ lệ giảm giá (%)
        public decimal? Gg_ty_le { get; set; }

        // Tiền giảm giá
        public decimal? Gg_tien { get; set; }

        // Tiền giảm giá ngoại tệ
        public decimal? Gg_tien_nt { get; set; }

        // Thành tiền
        public decimal? Tien_ban { get; set; }

        // Thành tiền ngoại tệ
        public decimal? Tien_ban_nt { get; set; }

        // Lý do giảm giá
        public string Gg_ly_do { get; set; }

        // Số tờ khai
        public string So_to_khai { get; set; }

        public XPH5 XPH5 { get; set; } // Phiếu xuất hàng liên kết
        public DMHH DMHH { get; set; } // Hàng hóa liên kết
    }
}
