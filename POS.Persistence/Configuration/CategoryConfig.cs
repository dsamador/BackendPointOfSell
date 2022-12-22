using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace POS.Persistence.Configuration
{
    public class CategoryConfig :  IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.HasKey(p => p.CategoryId);
            builder.Property(p => p.Name).HasMaxLength(40).IsRequired();
            builder.Property(p => p.Created).HasColumnType("datetime");
            builder.Property(p => p.LastModified).HasColumnType("datetime");
            builder.Property(p => p.IsDeleted).HasColumnType("bit");
            builder.Property(p => p.IsModified).HasColumnType("bit");
        }        
    }
}
