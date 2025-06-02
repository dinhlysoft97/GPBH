using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class DMHHConfiguration : EntityTypeConfiguration<DMHH>
    {
        public DMHHConfiguration()
        {
            // Table name
            ToTable("DMHH");

            // Primary Key
            HasKey(t => t.Ma_hh);

            // Properties
            Property(t => t.Ma_hh)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ten_hh)
                .HasMaxLength(50);

            Property(t => t.Dvt)
                .HasMaxLength(20);

            Property(t => t.Ma_nhom_hh)
                .HasMaxLength(20);

            Property(t => t.Thuong_hieu)
                .HasMaxLength(50);

            Property(t => t.Ma_nsx)
                .HasMaxLength(20);

            Property(t => t.Ten_nsx)
                .HasMaxLength(100);

            Property(t => t.Nuoc_sx)
                .HasMaxLength(20);

            Property(t => t.Chieu_dai)
                .HasPrecision(19, 4);

            Property(t => t.Trong_luong)
                .HasPrecision(19, 4);

            Property(t => t.Chieu_cao)
                .HasPrecision(19, 4);

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
