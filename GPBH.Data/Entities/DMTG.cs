using GPBH.Data.Audit;
using System;

namespace GPBH.Data.Entities
{
    public class DMTG : BaseAuditableEntity
    {
        public string Ma_nt { get; set; }               // Mã ngoại tệ
        public DateTime Ngay_ap_dung { get; set; }     // Ngày áp dụng
        public decimal Ty_gia { get; set; }             // Tỷ giá

        public DMNT DMNT { get; set; }           // Thông tin ngoại tệ liên kết
    }
}
