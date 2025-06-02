using GPBH.Data.Audit;
using GPBH.Data.Configurations;
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
        public DbSet<SysDMDV> SysDMDV { get; set; }
        public DbSet<SysDMCuaHang> SysDMCuaHang { get; set; }
        public DbSet<DMca> DMca { get; set; }
        public DbSet<SysDMNSD> SysDMNSD { get; set; }
        public DbSet<SysMenu> SysMenu{ get; set; }
        public DbSet<SysPhanQuyen> SysPhanQuyen { get; set; }
        public DbSet<DMQG> DMQG { get; set; }
        public DbSet<DMKH> DMKH { get; set; }
        public DbSet<DMNT> DMNT { get; set; }
        public DbSet<DMTG> DMTG { get; set; }
        public DbSet<DMHH> DMHH { get; set; }
        public DbSet<DMGB> DMGB { get; set; }
        public DbSet<XPH5> XPH5 { get; set; }
        public DbSet<XCT5> XCT5 { get; set; }
        public DbSet<TokhaiHH> TokhaiHH { get; set; }
        public DbSet<SysDMCT> SysDMCT { get; set; }
        public DbSet<SysSoChungTu> SysSoChungTu { get; set; }
        public DbSet<SysConfig> SysConfig { get; set; }

        public override int SaveChanges()
        {
            AuditHelper.SetAuditFields(this, CurrentUserName);
            return base.SaveChanges();
        }
    }
}