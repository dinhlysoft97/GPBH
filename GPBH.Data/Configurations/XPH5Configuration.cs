namespace GPBH.Data.Configurations
{
    using GPBH.Data.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class XPH5Configuration : EntityTypeConfiguration<XPH5>
    {
        public XPH5Configuration()
        {
            // Table name
            ToTable("XPH5");

            // Primary Key
            HasKey(t => t.Ma_phieu);

            // Properties
            Property(t => t.Ma_cua_hang)
                .HasMaxLength(20);

            Property(t => t.Ma_phieu)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Ma_chung_tu)
                .HasMaxLength(3);

            Property(t => t.So_chung_tu)
                .HasMaxLength(50);

            Property(t => t.Ngay_chung_tu);

            Property(t => t.Ma_nt)
                .HasMaxLength(3);

            Property(t => t.Ty_gia)
                .HasPrecision(28, 8);

            Property(t => t.Ma_quay)
                .HasMaxLength(20);

            Property(t => t.Ma_cqt)
                .HasMaxLength(50);

            Property(t => t.Xuat_hddt)
                .IsRequired();

            Property(t => t.So_hddt)
                .HasMaxLength(20);

            Property(t => t.Xuat_hq)
                .IsRequired();

            Property(t => t.Ma_kho)
                .HasMaxLength(20);

            Property(t => t.Passport)
                .HasMaxLength(20);

            Property(t => t.Ten_khach)
                .HasMaxLength(100);

            Property(t => t.Nguoi_tao)
                .HasMaxLength(20);

            Property(t => t.Ngay_tao);

            Property(t => t.Nguoi_sua)
                .HasMaxLength(20);

            Property(t => t.Ngay_sua);

            Property(t => t.Tt1_loai)
                .HasMaxLength(10);

            Property(t => t.Tt1_ma_nt)
                .HasMaxLength(3);

            Property(t => t.Tt1_tien_tt)
                .HasPrecision(28, 8);

            Property(t => t.Tt1_tien_nt)
                .HasPrecision(28, 8);

            Property(t => t.Tt2_loai)
                .HasMaxLength(10);

            Property(t => t.Tt2_ma_nt)
                .HasMaxLength(3);

            Property(t => t.Tt2_tien_tt)
                .HasPrecision(28, 8);

            Property(t => t.Tt2_tien_nt)
                .HasPrecision(28, 8);

            Property(t => t.Tt3_loai)
                .HasMaxLength(10);

            Property(t => t.Tt3_ma_nt)
                .HasMaxLength(3);

            Property(t => t.Tt3_tien_tt)
                .HasPrecision(28, 8);

            Property(t => t.Tt3_tien_nt)
                .HasPrecision(28, 8);

            Property(t => t.Tt_tong)
                .HasPrecision(28, 8);

            Property(t => t.Tong_nhan)
                .HasPrecision(28, 8);

            Property(t => t.Tra_lai)
                .HasPrecision(28, 8);

            Property(t => t.Tra_lai_nt)
                .HasPrecision(28, 8);

            Property(t => t.Tong_tien_hang)
                .HasPrecision(28, 8);

            Property(t => t.Tong_tien_hang_nt)
                .HasPrecision(28, 8);

            Property(t => t.Tong_giam_gia)
                .HasPrecision(28, 8);

            Property(t => t.Tong_giam_gia_nt)
                .HasPrecision(28, 8);

            Property(t => t.Tong_thu)
                .HasPrecision(28, 8);

            Property(t => t.Tong_thu_nt)
                .HasPrecision(28, 8);

            Property(t => t.Tong_so_luong)
                .HasPrecision(28, 8);

            Property(t => t.Xnc_ngay_cap);

            Property(t => t.Xnc_ngay_hh);

            Property(t => t.So_hieu)
                .HasMaxLength(20);

            Property(t => t.Ten_tau_bay)
                .HasMaxLength(20);

            Property(t => t.Han_muc)
                .HasPrecision(28, 8);

            Property(t => t.Ma_nhom_kh)
                .HasMaxLength(20);

            Property(t => t.Ma_loai_hinh)
                .HasMaxLength(20);

            Property(t => t.Ma_doi_tuong)
                .HasMaxLength(20);
            
            Property(t => t.Ma_tra_lai)
                .HasMaxLength(3);

            // Relationships
            HasRequired(x => x.SysDMCuaHang)
           .WithMany(c => c.XPH5s)
           .HasForeignKey(x => x.Ma_cua_hang);

            HasRequired(x => x.DMNT)
           .WithMany(c => c.XPH5s)
           .HasForeignKey(x => x.Ma_nt);
        }
    }
}
