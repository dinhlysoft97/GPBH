namespace GPBH.Data.Configurations
{
    using GPBH.Data.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class SystemSettingConfiguration : EntityTypeConfiguration<SystemSetting>
    {
        public SystemSettingConfiguration()
        {
            // Table name
            ToTable("SystemSetting");

            // Primary Key
            HasKey(t => new { t.Ma_cua_hang, t.Key });

            // Properties
            Property(t => t.Ma_cua_hang)
                .HasMaxLength(20);

            // Relationships
            HasRequired(x => x.SysDMCuaHang)
           .WithMany(c => c.SystemSettings)
           .HasForeignKey(x => x.Ma_cua_hang);
        }
    }
}
