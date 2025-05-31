using GPBH.Data.Entities;
using System.Data.Entity;

namespace GPBH.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tự động đăng ký tất cả Configuration class
            modelBuilder.Configurations.AddFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public AppDbContext() : base("name=AppDbContext") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}