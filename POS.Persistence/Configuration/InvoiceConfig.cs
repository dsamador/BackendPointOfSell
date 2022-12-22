using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ardalis.Specification;

namespace POS.Persistence.Configuration
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            builder.HasKey(e => e.InvoiceId);
            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
            builder.Property(e => e.Created).HasColumnType("datetime");
            builder.Property(e => e.LastModified).HasColumnType("datetime");
            builder.Property(p => p.IsDeleted).HasColumnType("bit");
            builder.Property(p => p.IsModified).HasColumnType("bit");
            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Customer");

        }
    }
}
