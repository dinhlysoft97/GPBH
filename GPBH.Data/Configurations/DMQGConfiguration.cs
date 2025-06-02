using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class DMQGConfiguration : EntityTypeConfiguration<DMQG>
    {
        public DMQGConfiguration()
        {
            // Table name
            ToTable("DMQG");

            // Primary Key (giả sử Ma_cua_hang là khóa chính, điều chỉnh lại nếu cần)
            HasKey(t => t.Quoc_gia);

            // Properties
            Property(t => t.Quoc_gia)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
