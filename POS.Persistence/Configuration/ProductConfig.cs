using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace POS.Persistence.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");            

            builder.Property(e => e.ProductId).HasColumnName("ProductID");
            builder.Property(e => e.Name).HasMaxLength(60).IsRequired();
            builder.Property(e => e.Color).HasMaxLength(50);
            builder.Property(e => e.SafetyStockLevel).HasColumnType("tinyint").IsRequired();
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.Property(e => e.Created).HasColumnType("datetime");
            builder.Property(e => e.LastModified).HasColumnType("datetime");
            builder.Property(p => p.IsDeleted).HasColumnType("bit");
            builder.Property(p => p.IsModified).HasColumnType("bit");
            builder.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
        }         
    }
}
