using System.Data.Entity.ModelConfiguration;
using GPBH.Data.Entities;

namespace GPBH.Data.Configurations
{
    /// <summary>
    /// Cấu hình mapping cho bảng SysDinh_dang_form (EF6).
    /// </summary>
    public class SysDinh_dang_formConfiguration : EntityTypeConfiguration<SysDinh_dang_form>
    {
        public SysDinh_dang_formConfiguration()
        {
            ToTable("SysDinh_dang_form");

            HasKey(x => new { x.Ma_cua_hang, x.Code_name, x.MenuId, x.Field_name });

            Property(x => x.Ma_cua_hang)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Code_name)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.MenuId)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Field_name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Field_type)
                .HasMaxLength(50);

            Property(x => x.Field_title)
                .HasMaxLength(255);

            Property(x => x.Field_order);

            Property(x => x.Field_hide);

            Property(x => x.Field_format)
                .HasMaxLength(20);

            Property(x => x.Default_sort);
        }
    }
}