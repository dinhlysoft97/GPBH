using GPBH.Data.Migrations;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GPBH.Data.Helper
{
    public static class MigrationHelper
    {
        public static void EnsureDbMigrated()
        {
            var migrator = new DbMigrator(new AppDbMigrationsConfiguration());

            // Lấy migration đã áp dụng
            var appliedMigrations = migrator.GetDatabaseMigrations().ToList();

            // Lấy migration có thể apply (chưa chạy)
            var pendingMigrations = migrator.GetPendingMigrations().ToList();

            if (pendingMigrations.Any())
            {
                // Chỉ migrate lên migration mới nhất
                
                var newestMigration = pendingMigrations.Last();

                migrator.Update(newestMigration);
            }
        }
    }
}
