using CatalogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "geekmania");
            builder.HasMany(c => c.Images)
                   .WithOne(e => e.Product)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(b => b.Id);
            
            builder.Property(p => p.Key).IsUnicode(false).HasColumnType("UniqueIdentifier");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Description).HasColumnName("description");            
            builder.Property(p => p.UnityPrice).HasColumnName("unity_price");            
            builder.Property(p => p.QuantityInStock).HasColumnName("quantity_stock");
            builder.Property(p => p.Image).HasColumnName("image");
            builder.Property(p => p.CategoryId).HasColumnName("category_id");            
            builder.Property(p => p.SubCategoryId).HasColumnName("subcategory_id");       
            builder.Property(p => p.NoveltyId).HasColumnName("novelty_id");
            builder.Property(p => p.Status).HasColumnName("status").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnName("updatedAt").IsRequired();

            builder.Ignore(p => p.Events);
        }
    }
}