using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace POS.Persistence.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
            builder.HasKey(p => p.CustomerId);
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.MiddleName).HasMaxLength(50);
            builder.Property(p => p.FirstLastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.SecondLastName).HasMaxLength(50);            
            builder.Property(p => p.Address).HasMaxLength(200);
            builder.Property(p => p.DateOfBirth).HasColumnType("datetime");
            builder.Property(p => p.PhoneNumber).HasMaxLength(15);
            builder.Property(p => p.Email).HasMaxLength(200);
            builder.Property(p => p.Created).HasColumnType("datetime");
            builder.Property(p => p.LastModified).HasColumnType("datetime");
            builder.Property(p => p.IsDeleted).HasColumnType("bit");
            builder.Property(p => p.IsModified).HasColumnType("bit");
        }
    }
}
