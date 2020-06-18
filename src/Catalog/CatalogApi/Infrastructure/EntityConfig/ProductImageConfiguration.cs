using CatalogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImage", "geekmania");
            builder.HasOne(c => c.Product)
                   .WithMany(e => e.Images);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Image)
                   .HasColumnName("image");

            builder.Property(p => p.ProductId)
                   .HasColumnName("product_id");

            builder.Ignore(p => p.Key);
            builder.Ignore(p => p.Events);

        }
    }
}
