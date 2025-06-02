using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class XCT5Configuration : EntityTypeConfiguration<XCT5>
    {
        public XCT5Configuration()
        {
            // Table name
            ToTable("XCT5");

            // Primary Key (Ma_phieu + Stt)
            HasKey(t => new { t.Ma_phieu, t.Stt });

            // Properties
            Property(t => t.Ma_phieu)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Stt)
                .IsRequired();

            Property(t => t.Ma_hh)
                .HasMaxLength(20);

            Property(t => t.Ten_hh)
                .HasMaxLength(50);

            Property(t => t.Dvt)
                .HasMaxLength(20);

            Property(t => t.So_luong)
                .HasPrecision(19, 4);

            Property(t => t.Gia_ban)
                .HasPrecision(19, 4);

            Property(t => t.Gia_ban_nt)
                .HasPrecision(19, 4);

            Property(t => t.Gg_ty_le)
                .HasPrecision(19, 4);

            Property(t => t.Gg_tien)
                .HasPrecision(19, 4);

            Property(t => t.Gg_tien_nt)
                .HasPrecision(19, 4);

            Property(t => t.Tien_ban)
                .HasPrecision(19, 4);

            Property(t => t.Tien_ban_nt)
                .HasPrecision(19, 4);

            Property(t => t.Gg_ly_do)
                .HasMaxLength(50);

            Property(t => t.So_to_khai)
                .HasMaxLength(20);

            // Relationships
            HasRequired(x => x.XPH5)
           .WithMany(c => c.XCT5s)
           .HasForeignKey(x => x.Ma_phieu);

            HasRequired(x => x.DMHH)
           .WithMany(c => c.XCT5s)
           .HasForeignKey(x => x.Ma_hh);
        }
    }
}
