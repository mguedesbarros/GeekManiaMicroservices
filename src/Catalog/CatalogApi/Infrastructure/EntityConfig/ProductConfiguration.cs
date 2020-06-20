using CatalogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasMany(c => c.Images)
                   .WithOne(e => e.Product)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(b => b.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).HasColumnName("name").IsRequired();
            builder.Property(p => p.Description).HasMaxLength(300).HasColumnName("description").IsRequired();            
            builder.Property(p => p.UnityPrice).HasColumnName("unity_price").IsRequired();            
            builder.Property(p => p.QuantityInStock).HasColumnName("quantity_stock").IsRequired();
            builder.Property(p => p.Image).HasMaxLength(2000).HasColumnName("image").IsRequired();
            builder.Property(p => p.CategoryId).HasColumnName("category_id").IsRequired();            
            builder.Property(p => p.SubCategoryId).HasColumnName("subcategory_id").IsRequired(false);
            builder.Property(p => p.NoveltyId).HasColumnName("novelty_id").IsRequired(false);
            builder.Property(p => p.Status).HasMaxLength(1).HasColumnName("status").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnName("updatedAt").IsRequired();

            builder.Ignore(p => p.Events);
        }
    }
}