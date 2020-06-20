using CatalogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImage");
            builder.HasOne(c => c.Product)
                   .WithMany(e => e.Images)
                   .HasForeignKey(p => p.ProductId);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(2000).HasColumnName("image").IsRequired();
            builder.Property(p => p.ProductId).HasColumnName("product_id").IsRequired();
        }
    }
}
