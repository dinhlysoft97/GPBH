using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class SysSoChungTuConfiguration : EntityTypeConfiguration<SysSoChungTu>
    {
        public SysSoChungTuConfiguration()
        {
            // Table name
            ToTable("SysSoChungTu");

            // Composite Primary Key (Ma_cua_hang + Ma_chung_tu + Thang + Nam + So_phieu)
            HasKey(t => new { t.Ma_cua_hang, t.Ma_chung_tu, t.Thang, t.Nam, t.So_phieu });

            // Properties
            Property(t => t.Ma_cua_hang)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ma_chung_tu)
                .IsRequired()
                .HasMaxLength(3);

            Property(t => t.Thang)
                .IsRequired();

            Property(t => t.Nam)
                .IsRequired();

            Property(t => t.Ngay_lap);

            Property(t => t.So_phieu)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
