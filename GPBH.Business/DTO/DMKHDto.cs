using System;

namespace GPBH.Business.DTO
{
    public class DMKHDto
    {
        public string Passport { get; set; }         // Passport/CCCD (PK)
        public string Ho { get; set; }               // Họ
        public string Ten_dem { get; set; }          // Tên đệm
        public string Ten { get; set; }              // Tên
        public DateTime? Ngay_cap { get; set; }      // Ngày cấp
        public DateTime? Ngay_hh { get; set; }       // Ngày hết hạn
        public string Quoc_gia { get; set; }         // Quốc gia
        public string Ten_Quoc_Gia { get; set; }         // Tên Quốc gia
        public string Gioi_tinh { get; set; }        // Giới tính
        public DateTime? Ngay_sinh { get; set; }     // Ngày sinh
        public string Dia_chi { get; set; }          // Địa chỉ
        public string Dien_thoai { get; set; }       // Điện thoại
        public string Email { get; set; }            // Email

        // Ngày cấp (xuất nhập cảnh)
        public DateTime? Xnc_ngay_cap { get; set; }

        // Ngày hết hạn (xuất nhập cảnh)
        public DateTime? Xnc_ngay_hh { get; set; }

        // Số hiệu
        public string So_hieu { get; set; }

        // Tên tàu bay
        public string Ten_tau_bay { get; set; }

        // Hạn mức
        public decimal? Han_muc { get; set; }

    }
}
