using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class DMKHConfiguration : EntityTypeConfiguration<DMKH>
    {
        public DMKHConfiguration()
        {
            // Table name
            ToTable("DMKH");

            // Primary Key
            HasKey(t => t.Passport);

            // Properties
            Property(t => t.Passport)
                .IsRequired()
                .HasMaxLength(8);

            Property(t => t.Ho)
                .HasMaxLength(20);

            Property(t => t.Ten_dem)
                .HasMaxLength(20);

            Property(t => t.Ten)
                .HasMaxLength(20);

            Property(t => t.Ngay_cap);

            Property(t => t.Ngay_hh);

            Property(t => t.Quoc_gia)
                .HasMaxLength(20);

            Property(t => t.Gioi_tinh)
                .HasMaxLength(1);

            Property(t => t.Ngay_sinh);

            Property(t => t.Dia_chi)
                .HasMaxLength(200);

            Property(t => t.Dien_thoai)
                .HasMaxLength(20);

            Property(t => t.Email)
                .HasMaxLength(100);

            Property(t => t.Nguoi_tao)
                .HasMaxLength(20);

            Property(t => t.Ngay_tao);

            Property(t => t.Nguoi_sua)
                .HasMaxLength(20);

            Property(t => t.Ngay_sua);

            // Relationships
            HasRequired(x => x.DMQG)
           .WithMany(c => c.DMKhs)
           .HasForeignKey(x => x.Quoc_gia);
        }
    }
}
