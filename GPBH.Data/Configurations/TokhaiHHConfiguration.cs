using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class TokhaiHHConfiguration : EntityTypeConfiguration<TokhaiHH>
    {
        public TokhaiHHConfiguration()
        {
            // Table name
            ToTable("TokhaiHH");

            // Primary Key (Ma_cua_hang + Ma_kho + So_to_khai + Ma_hh)
            HasKey(t => new { t.Ma_cua_hang, t.Ma_kho, t.So_to_khai, t.Ma_hh });

            // Properties
            Property(t => t.Ma_cua_hang)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ma_kho)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.So_to_khai)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Ngay_nhap);

            Property(t => t.Ma_hh)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.So_luong)
                .HasPrecision(19, 4);

            Property(t => t.Da_xuat)
                .HasPrecision(19, 4);

            Property(t => t.Con_lai)
                .HasPrecision(19, 4);

            // Relationships
            HasRequired(x => x.DMHH)
           .WithMany(c => c.TokhaiHHs)
           .HasForeignKey(x => x.Ma_hh);

            HasRequired(x => x.SysDMCuaHang)
           .WithMany(c => c.TokhaiHHs)
           .HasForeignKey(x => x.Ma_cua_hang);
        }
    }
}
