using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalogApi.Domain.Entities;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategory", "geekmania");
            //builder.HasOne(c => c.Category)
            //       .WithMany(e => e.SubCategory);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                   .HasColumnName("name");

            builder.Property(p => p.Image)
                   .HasColumnName("url_image");

            builder.Property(p => p.CategoryId)
                   .HasColumnName("category_id");           

        }
    }
}