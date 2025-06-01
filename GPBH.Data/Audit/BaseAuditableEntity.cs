using System;

namespace GPBH.Data.Audit
{
    public abstract class BaseAuditableEntity
    {
        public string NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }
    }
}
