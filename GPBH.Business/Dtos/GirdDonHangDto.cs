using System;

namespace GPBH.Business.Dtos
{
    public  class GirdDonHangDto
    {
        // Mã cửa hàng
        public string Ma_cua_hang { get; set; }

        // mã phiếu
        public string Ma_phieu { get; set; }

        public int Stt { get; set; }

        // Số chứng từ
        public string So_chung_tu { get; set; }

        // Ngày lập chứng từ (mặc định ngày hiện tại)
        public DateTime? Ngay_chung_tu { get; set; }
        
        // Passport
        public string Passport { get; set; }

        // Tên khách
        public string Ten_khach { get; set; }

        // Tổng tiền hàng ngoại tệ
        public decimal? Tong_tien_hang_nt { get; set; }

        // Tổng nhận
        public decimal? Tong_nhan { get; set; }

        // Tổng nhận
        public decimal? Tra_lai_nt { get; set; }

        // Tỷ giá (lấy từ danh mục tỷ giá theo ma_nt và ngày áp dụng gần nhất)
        public decimal? Ty_gia { get; set; }
    }
}
