using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class SysDMDVConfiguration : EntityTypeConfiguration<SysDMDV>
    {
        public SysDMDVConfiguration()
        {
            // Table name
            ToTable("SysDMDV");

            // Primary Key
            HasKey(t => t.Ma_dv);

            // Properties
            Property(t => t.Ma_dv)
                .IsRequired()
                .HasMaxLength(3);

            Property(t => t.Ten_dv)
                .HasMaxLength(100);

            Property(t => t.Dia_chi)
                .HasMaxLength(100);

            Property(t => t.Ma_so_thue)
                .HasMaxLength(20);

            Property(t => t.Ma_hqcq)
                .HasMaxLength(20);

            Property(t => t.So_dien_thoai)
                .HasMaxLength(20);

            Property(t => t.So_fax)
                .HasMaxLength(20);

            Property(t => t.Email)
                .HasMaxLength(100);

            Property(t => t.Nlh_ho_ten)
                .HasMaxLength(50);

            Property(t => t.Nlh_chuc_vu)
                .HasMaxLength(50);

            Property(t => t.Nlh_Sdt)
                .HasMaxLength(20);
        }
    }
}
