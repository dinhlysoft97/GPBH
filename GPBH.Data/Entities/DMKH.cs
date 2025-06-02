using GPBH.Data.Audit;
using System;

namespace GPBH.Data.Entities
{
    public class DMKH : BaseAuditableEntity
    {
        public string Passport { get; set; }         // Passport/CCCD (PK)
        public string Ho { get; set; }               // Họ
        public string Ten_dem { get; set; }          // Tên đệm
        public string Ten { get; set; }              // Tên
        public DateTime? Ngay_cap { get; set; }      // Ngày cấp
        public DateTime? Ngay_hh { get; set; }       // Ngày hết hạn
        public string Quoc_gia { get; set; }         // Quốc gia
        public string Gioi_tinh { get; set; }        // Giới tính
        public DateTime? Ngay_sinh { get; set; }     // Ngày sinh
        public string Dia_chi { get; set; }          // Địa chỉ
        public string Dien_thoai { get; set; }       // Điện thoại
        public string Di_dong { get; set; }          // Di động
        public string Email { get; set; }            // Email
        public DMQG DMQG { get; set; }       // Người tạo
    }
}
