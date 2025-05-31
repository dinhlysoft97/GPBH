using GPBH.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GPBH.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            // Khóa chính
            HasKey(x => x.ProductId);

            // Thiết lập ProductId tự tăng
            Property(x => x.ProductId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Khóa ngoại
            //HasRequired(x => x.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(x => x.CategoryId);

            // Unique (cách tạo index unique)
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Nếu muốn unique index:
            HasIndex(x => x.Name).IsUnique(); // EF6.2+
        }
    }
}
