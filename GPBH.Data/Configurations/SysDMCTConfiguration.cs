using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class SysDMCTConfiguration : EntityTypeConfiguration<SysDMCT>
    {
        public SysDMCTConfiguration()
        {
            // Table name
            ToTable("SysDMCT");

            // Composite Key
            HasKey(t => new { t.Ma_cua_hang, t.Ma_chung_tu });

            // Properties
            Property(t => t.Ma_cua_hang)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ma_chung_tu)
                .IsRequired()
                .HasMaxLength(3);

            Property(t => t.Ma_nt)
                .HasMaxLength(3);

            Property(t => t.So_lien);

            Property(t => t.Sp_xu_ly)
                .HasMaxLength(50);

            Property(t => t.Ph)
                .HasMaxLength(50);

            Property(t => t.Ct)
                .HasMaxLength(50);

            Property(t => t.Dau_so)
                .HasMaxLength(50);

            Property(t => t.So_phieu);

            Property(t => t.Cuoi_so)
                .HasMaxLength(50);

            Property(t => t.Cach_danh_so)
                .HasMaxLength(1);

            Property(t => t.PhFieldlist2IN)
                .HasMaxLength(1000);

            Property(t => t.CtFieldlist2IN)
                .HasMaxLength(1000);
        }
    }
}
