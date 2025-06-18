using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.Dtos
{
    public class GridHangHoa
    {
        public string Ma_hh { get; set; }             // Mã hàng (PK)
        public string Ten_hh { get; set; }            // Tên hàng
        public string Dvt { get; set; }               // Đơn vị tính
        public string Ma_nhom_hh { get; set; }        // Nhóm hàng
        public string Thuong_hieu { get; set; }       // Thương hiệu
        public string Ma_nsx { get; set; }            // Mã nhà sản xuất
        public string Ten_nsx { get; set; }           // Tên nhà sản xuất
        public string Nuoc_sx { get; set; }           // Nước sản xuất
        public decimal? Chieu_dai { get; set; }       // Chiều dài
        public decimal? Trong_luong { get; set; }     // Trọng lượng
        public decimal? Chieu_cao { get; set; }       // Chiều cao
        public bool Ksd { get; set; }                 // Không sử dụng
    }
}
