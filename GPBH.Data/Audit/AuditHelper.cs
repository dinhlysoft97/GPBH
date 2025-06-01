using System;
using System.Data.Entity;

namespace GPBH.Data.Audit
{
    public static class AuditHelper
    {
        public static void SetAuditFields(DbContext context, string userName)
        {
            var entries = context.ChangeTracker.Entries<BaseAuditableEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.NguoiTao = userName;
                    entry.Entity.NgayTao = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.NguoiSua = userName;
                    entry.Entity.NgaySua = DateTime.Now;
                }
            }
        }
    }
}
