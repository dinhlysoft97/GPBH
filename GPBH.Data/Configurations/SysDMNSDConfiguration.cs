using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class SysDMNSDConfiguration : EntityTypeConfiguration<SysDMNSD>
    {
        public SysDMNSDConfiguration()
        {
            // Table name
            ToTable("SysDMNSD");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.TenDangNhap)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnAnnotation(
                "Index",
                new System.Data.Entity.Infrastructure.Annotations.IndexAnnotation(
                    new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("IX_TenDangNhap") { IsUnique = true }
                )
            );

            Property(t => t.TenDayDu)
                .HasMaxLength(50);

            Property(t => t.MatKhau)
                .HasMaxLength(500);

            Property(t => t.IsAdmin)
                .IsRequired();

            Property(t => t.Ksd)
                .IsRequired();

            Property(t => t.NguoiTao)
                .HasMaxLength(20);

            Property(t => t.NgayTao);

            Property(t => t.NguoiSua)
                .HasMaxLength(20);

            Property(t => t.NgaySua);
        }

    }
}
