using Domain.Common;

namespace Domain.Models
{
    public class Category : AuditableBaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        

        public virtual ICollection<Product> Products { get; private set; }
    }
}
