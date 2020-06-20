using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CatalogApi.Domain.Entities;

namespace CatalogApi.Infrastructure.EntityConfig
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategory");
            builder.HasOne(c => c.Category)
                   .WithMany(e => e.SubCategories)
                   .HasForeignKey(p => p.CategoryId);

            builder.HasKey(p => p.Id);
                
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).HasColumnName("name").IsRequired();
            builder.Property(p => p.CategoryId).HasColumnName("category_id").IsRequired();
        }
    }
}