using Domain.Common;

namespace Domain.Models
{
    public class Invoice : AuditableBaseEntity
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; private set; }
    }
}
