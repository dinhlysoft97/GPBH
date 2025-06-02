using GPBH.Data.Audit;
using GPBH.Data.Entities;
using System;
using System.Collections.Generic;

namespace GPBH.Data.Configurations
{
    public class DMHH : BaseAuditableEntity
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
        public virtual List<DMGB> DMGBs { get; set; } // Danh sách nhóm giá bán liên kết
        public virtual List<XCT5> XCT5s { get; set; } // Danh sách chứng từ liên kết
        public virtual List<TokhaiHH> TokhaiHHs { get; set; } // Danh sách tờ khai hải quan liên kết
    }
}
