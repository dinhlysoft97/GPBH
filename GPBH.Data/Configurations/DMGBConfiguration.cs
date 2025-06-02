using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class DMGBConfiguration : EntityTypeConfiguration<DMGB>
    {
        public DMGBConfiguration()
        {
            // Table name
            ToTable("DMGB");

            // Primary Key (Composite)
            HasKey(t => new { t.Ma_cua_hang, t.Ngay_ap_dung, t.Ma_hh });

            // Properties
            Property(t => t.Ma_cua_hang)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ngay_ap_dung)
                .IsRequired();

            Property(t => t.Ma_hh)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Gia_ban)
                .HasPrecision(19, 4)
                .IsRequired();


            // Relationships
            HasRequired(x => x.SysDMCuaHang)
           .WithMany(c => c.DMGBs)
           .HasForeignKey(x => x.Ma_cua_hang);

            // Relationships
            HasRequired(x => x.DMHH)
           .WithMany(c => c.DMGBs)
           .HasForeignKey(x => x.Ma_hh);
        }
    }
}
