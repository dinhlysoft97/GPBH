using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class DMcaConfiguration : EntityTypeConfiguration<DMca>
    {
        public DMcaConfiguration()
        {
            // Table name
            ToTable("DMca");

            // Primary Key
            HasKey(t => t.Ma_ca);

            // Properties
            Property(t => t.Ma_ca)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ten_ca)
                .HasMaxLength(50);

            Property(t => t.Gio_bd)
                .HasMaxLength(5);

            Property(t => t.Gio_kt)
                .HasMaxLength(5);
        }
    }
}
