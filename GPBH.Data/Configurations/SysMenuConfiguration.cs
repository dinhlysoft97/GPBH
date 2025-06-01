using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class SysMenuConfiguration : EntityTypeConfiguration<SysMenu>
    {
        public SysMenuConfiguration()
        {
            // Table name
            ToTable("SysMenu");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Key)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.MenuName)
                .HasMaxLength(50);
        }
    }
}
