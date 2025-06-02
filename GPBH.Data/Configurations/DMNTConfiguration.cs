using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class DMNTConfiguration : EntityTypeConfiguration<DMNT>
    {
        public DMNTConfiguration()
        {
            // Table name
            ToTable("DMNT");

            // Primary Key
            HasKey(t => t.Ma_nt);

            // Properties
            Property(t => t.Ma_nt)
                .IsRequired()
                .HasMaxLength(3);

            Property(t => t.Ksd)
                .IsRequired();

            Property(t => t.Nguoi_tao)
                .HasMaxLength(20);

            Property(t => t.Ngay_tao);

            Property(t => t.Nguoi_sua)
                .HasMaxLength(20);

            Property(t => t.Ngay_sua);
        }
    }
}
