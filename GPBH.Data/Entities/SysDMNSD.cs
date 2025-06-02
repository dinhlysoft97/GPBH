using GPBH.Data.Audit;
using System.Collections.Generic;

namespace GPBH.Data.Entities
{
    public class SysDMNSD : BaseAuditableEntity
    {
        // Tên đăng nhập (Primary Key)
        public string TenDangNhap { get; set; }

        // Tên đầy đủ
        public string TenDayDu { get; set; }

        // Mật khẩu
        public string MatKhau { get; set; }

        // Là admin
        public bool IsAdmin { get; set; }

        // =1 mới cho đăng nhập
        public bool Ksd { get; set; }

        public virtual List<SysPhanQuyen> SysPhanQuyens { get; set; } // Danh sách phân quyền liên kết
    }
}
