using System;

namespace GPBH.Business.Dtos
{
        public class TyGiaNT
        {
            public string Ma_nt { get; set; }               // Mã ngoại tệ
            public DateTime Ngay_ap_dung { get; set; }     // Ngày áp dụng
            public decimal Ty_gia { get; set; }             // Tỷ giá
        }
}
