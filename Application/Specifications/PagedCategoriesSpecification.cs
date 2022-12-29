using Ardalis.Specification;
using Domain.Models;

namespace POS.Application.Specifications
{
    public class PagedCategoriesSpecification : Specification<Category>
    {
        public PagedCategoriesSpecification(int pageSize, int pageNumber, string name)
        {            
            Query.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

            if (!string.IsNullOrEmpty(name))
                Query.Search(x => x.Name, "%" + name + "%");                            
        }
    }
}
