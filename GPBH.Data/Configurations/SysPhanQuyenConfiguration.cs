using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class SysPhanQuyenConfiguration : EntityTypeConfiguration<SysPhanQuyen>
    {
        public SysPhanQuyenConfiguration()
        {
            // Table name
            ToTable("SysPhanQuyen");

            // Composite Primary Key
            HasKey(t => new { t.Menuid, t.Ten_dang_nhap });

            // Properties
            Property(t => t.Menuid)
                .IsRequired()
                .HasMaxLength(8);

            Property(t => t.Ten_dang_nhap)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Xem);

            Property(t => t.Them);

            Property(t => t.Sua);

            Property(t => t.Xoa);

            Property(t => t.In);

            Property(t => t.Excel);

            Property(t => t.Nguoi_tao)
                .HasMaxLength(20);

            Property(t => t.Ngay_tao);

            Property(t => t.Nguoi_sua)
                .HasMaxLength(20);

            Property(t => t.Ngay_sua);

            // Relationships
            HasRequired(x => x.SysMenu)
           .WithMany(c => c.SysPhanQuyens)
           .HasForeignKey(x => x.Menuid);

            // Relationships
            HasRequired(x => x.SysDMNSD)
           .WithMany(c => c.SysPhanQuyens)
           .HasForeignKey(x => x.Ten_dang_nhap);
        }
    }
}
