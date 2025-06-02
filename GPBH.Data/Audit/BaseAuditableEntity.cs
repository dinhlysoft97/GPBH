using System;

namespace GPBH.Data.Audit
{
    public abstract class BaseAuditableEntity
    {
        public string Nguoi_tao { get; set; }        // Người tạo
        public DateTime? Ngay_tao { get; set; }      // Ngày tạo
        public string Nguoi_sua { get; set; }        // Người sửa
        public DateTime? Ngay_sua { get; set; }      // Ngày sửa
    }
}
