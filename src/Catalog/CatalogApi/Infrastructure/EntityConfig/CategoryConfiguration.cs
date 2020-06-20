using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalogApi.Domain.Entities;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasMany(c => c.SubCategories)
                   .WithOne(e => e.Category)
                   .HasForeignKey(p => p.CategoryId);

            builder.HasMany(c => c.Products)
                   .WithOne(e => e.Category)
                   .HasForeignKey(p => p.CategoryId);                   
            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(200).HasColumnName("name").IsRequired();            
            builder.Property(p => p.Image).HasMaxLength(2000).HasColumnName("image").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnName("updatedAt").IsRequired();
            builder.Property(p => p.Status).HasMaxLength(1).HasColumnName("status").IsRequired();

            builder.Ignore(p => p.Events);
        }
    }
}