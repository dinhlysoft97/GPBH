using GPBH.Data.Audit;
using GPBH.Data.Entities;
using System.Data.Entity;

namespace GPBH.Data
{
    public class AppDbContext : DbContext
    {
        public static string CurrentUserName { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tự động đăng ký tất cả Configuration class
            modelBuilder.Configurations.AddFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public AppDbContext() : base("name=AppDbContext") { }

        public DbSet<SysDMNSD> SysDMNSD { get; set; }

        public override int SaveChanges()
        {
            AuditHelper.SetAuditFields(this, CurrentUserName); 
            return base.SaveChanges();
        }
    }
}