using System.Data.Entity.Migrations;

namespace GPBH.Data.Migrations
{
    internal sealed class AppDbMigrationsConfiguration : DbMigrationsConfiguration<AppDbContext>
    {
        public AppDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            // Seed dữ liệu mẫu nếu cần
        }
    }
}