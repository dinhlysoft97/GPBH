using GPBH.Data.Audit;
using System;

namespace GPBH.Data.Entities
{
    public class SysPhanQuyen : BaseAuditableEntity
    {
        // ID menu (PK)
        public string Menuid { get; set; }

        // Tên đăng nhập (PK)
        public string Ten_dang_nhap { get; set; }

        // Được xem
        public bool? Xem { get; set; }

        // Được thêm mới
        public bool? Them { get; set; }

        // Được sửa
        public bool? Sua { get; set; }

        // Được xóa
        public bool? Xoa { get; set; }

        // Được in
        public bool? In { get; set; }

        // Được xuất excel
        public bool? Excel { get; set; }

        public SysMenu SysMenu { get; set; } // Thông tin menu liên kết
        public SysDMNSD SysDMNSD { get; set; } // Thông tin người dùng liên kết
    }
}
