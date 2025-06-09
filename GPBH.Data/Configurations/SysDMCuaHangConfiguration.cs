using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class SysDMCuaHangConfiguration : EntityTypeConfiguration<SysDMCuaHang>
    {
        public SysDMCuaHangConfiguration()
        {
            // Table name
            ToTable("SysDMCuaHang");

            // Primary Key (giả sử Ma_cua_hang là khóa chính, điều chỉnh lại nếu cần)
            HasKey(t => t.Ma_cua_hang);

            // Properties
            Property(t => t.Ma_dv)
                .IsRequired()
                .HasMaxLength(3);

            Property(t => t.Ma_cua_hang)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ten_cua_hang)
                .HasMaxLength(200);

            Property(t => t.Dia_chi)
                .HasMaxLength(200);

            Property(t => t.Ma_nhom_kh)
                .HasMaxLength(20);

            Property(t => t.Ma_loai_hinh)
                .HasMaxLength(20);

            Property(t => t.Ma_doi_tuong)
                .HasMaxLength(20);

            Property(t => t.Ma_nt)
                .HasMaxLength(3);

            Property(t => t.Han_muc_tm)
                .HasPrecision(19, 4);

            Property(t => t.Ma_cqt)
                .HasMaxLength(50);

            Property(t => t.Nhap_ttxnc)
                .IsRequired();

            // Relationships
            HasRequired(x => x.SysDMDV)
           .WithMany(c => c.SysDMCuaHangs)
           .HasForeignKey(x => x.Ma_dv);
        }
    }
}
