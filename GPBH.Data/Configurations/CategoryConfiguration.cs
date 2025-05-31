using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
