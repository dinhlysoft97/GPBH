namespace GPBH.Data.Configurations
{
    using GPBH.Data.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class SysConfigConfiguration : EntityTypeConfiguration<SysConfig>
    {
        public SysConfigConfiguration()
        {
            // Table name
            ToTable("SysConfig");

            // primary key
            HasKey(t => new { t.Id });

            Property(t => t.Han_muc_giao_dich_tien_mat)
                .HasPrecision(18, 8);

            Property(t => t.Loai_tien_ap_dung_khi_ban_hang)
                .HasMaxLength(10);

            Property(t => t.Ma_co_quan_thue)
                .HasMaxLength(50);
        }
    }
}
