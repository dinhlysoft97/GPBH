using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.Dtos
{
    public class GridTyGia
    {
        public string Ma_nt { get; set; }               // Mã ngoại tệ
        public DateTime Ngay_ap_dung { get; set; }     // Ngày áp dụng
        public decimal Ty_gia { get; set; }             // Tỷ giá
    }
}
