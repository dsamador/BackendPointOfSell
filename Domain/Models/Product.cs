using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product : AuditableBaseEntity
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
