using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Category : BaseModel
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        

        public virtual ICollection<Product> Products { get; set; }
    }
}
