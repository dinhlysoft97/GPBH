using System;
using System.Drawing;

namespace GPBH.Business.Dtos
{
    public class GirdNguoiSuDungDto
    { 
        // Số thứ tự
        public int Stt { get; set; }

        public Image PhanQuyen { get; set; }
        // Tên đăng nhập (Primary Key)
        public string TenDangNhap { get; set; } = string.Empty;

        // Tên đầy đủ
        public string TenDayDu { get; set; } = string.Empty;

        // =1 mới cho đăng nhập
        public bool Ksd { get; set; } 

        public bool CapLaiQuyen { get; set; }

        public string Nguoi_tao { get; set; }        // Người tạo

        public DateTime? Ngay_tao { get; set; }      // Ngày tạo

        public string Nguoi_sua { get; set; }        // Người sửa

        public DateTime? Ngay_sua { get; set; }      // Ngày sửa
    }
}
