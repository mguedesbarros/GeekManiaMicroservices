using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalogApi.Domain.Entities;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "geekmania");
            builder.HasMany(c => c.SubCategory)
                   .WithOne(e => e.Category);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Key).IsUnicode(false).HasColumnType("UniqueIdentifier");

            builder.Property(p => p.Name)
                   .HasColumnName("name");
            
            builder.Property(p => p.Image)
                   .HasColumnName("url_image");

            builder.Property(p => p.CreatedAt)
                   .HasColumnName("createdAt")
                   .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .HasColumnName("updatedAt")
                   .IsRequired();

            builder.Ignore(p => p.SubCategory);
            builder.Ignore(p => p.Events);



        }
    }
}