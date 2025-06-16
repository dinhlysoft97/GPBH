namespace GPBH.Business.Dtos
{
    public class GirdDonHangChiTietDto
    { // Mã hàng hóa
        public string Ma_hh { get; set; }

        // Tên hàng hóa
        public string Ten_hh { get; set; }

        // Số lượng
        public decimal? So_luong { get; set; }

        // Giá bán
        public decimal? Gia_ban_nt { get; set; }

        public decimal? Gia_ban { get; set; }

        // Giá bán ngoại tệ

        public decimal? Gg_ty_le { get; set; }

        // Tiền giảm giá ngoại tệ
        public decimal? Gg_tien_nt { get; set; }

        // Tiền giảm giá
        public decimal? Gg_tien { get; set; }

        // Thành tiền ngoại tệ
        public decimal? Tien_ban_nt { get; set; }

        // Thành tiền
        public decimal? Tien_ban { get; set; }
    }
}
