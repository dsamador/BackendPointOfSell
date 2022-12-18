using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
