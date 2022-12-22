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
    public class InvoiceDetailConfig : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("InvoiceDetails");
            builder.Property(e => e.InvoiceDetailId).HasColumnName("InvoiceDetailID");
            builder.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            builder.Property(e => e.ProductId).HasColumnName("ProductID");
            builder.Property(e => e.Price).HasColumnType("numeric(16, 2)");
            builder.Property(e => e.Quantity).HasColumnType("int");
            builder.Property(e => e.Created).HasColumnType("datetime");
            builder.Property(e => e.LastModified).HasColumnType("datetime");
            builder.Property(p => p.IsDeleted).HasColumnType("bit");
            builder.Property(p => p.IsModified).HasColumnType("bit");
            
            builder.HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetail_Invoice");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetail_Product");
        }
    }
}
