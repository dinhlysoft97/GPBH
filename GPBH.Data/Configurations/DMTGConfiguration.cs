using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class DMTGConfiguration : EntityTypeConfiguration<DMTG>
    {
        public DMTGConfiguration()
        {
            // Table name
            ToTable("DMTG");

            // Primary Key (giả định Ma_nt + Ngay_ap_dung là khóa chính)
            HasKey(t => new { t.Ma_nt, t.Ngay_ap_dung });

            // Properties
            Property(t => t.Ma_nt)
                .IsRequired()
                .HasMaxLength(3);

            Property(t => t.Ngay_ap_dung)
                .IsRequired();

            Property(t => t.Ty_gia)
                .HasPrecision(28, 8)
                .IsRequired();

            Property(t => t.Nguoi_tao)
                .HasMaxLength(20);

            Property(t => t.Ngay_tao);

            Property(t => t.Nguoi_sua)
                .HasMaxLength(20);

            Property(t => t.Ngay_sua);

            // Relationships
            HasRequired(x => x.DMNT)
           .WithMany(c => c.DMTGs)
           .HasForeignKey(x => x.Ma_nt);
        }
    }
}
