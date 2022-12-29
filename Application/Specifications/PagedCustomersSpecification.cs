using Ardalis.Specification;
using Domain.Models;

namespace POS.Application.Specifications
{
    public class PagedCustomersSpecification : Specification<Customer>
    {
        public PagedCustomersSpecification(int pageSize, int pageNumber, string firstName, string firstLastName)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize);

            if(!string.IsNullOrEmpty(firstName) )            
                Query.Search(x => x.FirstName, "%" + firstName + "%");

            if (!string.IsNullOrEmpty(firstLastName))
                Query.Search(x => x.FirstLastName, "%" + firstLastName + "%");
        }
    }
}
