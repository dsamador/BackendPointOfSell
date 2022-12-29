using Ardalis.Specification;
using Domain.Models;

namespace POS.Application.Specifications
{
    public class PagedCustomersSpecification : Specification<Customer>
    {
        public PagedCustomersSpecification(
            int pageSize, int pageNumber, string firstName, string middleName,
            string firstLastName, string secondLastName, string address,
            string phoneNumber, string email
            )
        {
            Query.Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize);

            if(!string.IsNullOrEmpty(firstName) )            
                Query.Search(x => x.FirstName, "%" + firstName + "%");
            
            if (!string.IsNullOrEmpty(middleName))
                Query.Search(x => x.MiddleName, "%" + middleName + "%");

            if (!string.IsNullOrEmpty(firstLastName))
                Query.Search(x => x.FirstLastName, "%" + firstLastName + "%");

            if (!string.IsNullOrEmpty(secondLastName))
                Query.Search(x => x.SecondLastName, "%" + secondLastName + "%");

            if (!string.IsNullOrEmpty(address))
                Query.Search(x => x.Address, "%" + address + "%");
            
            if (!string.IsNullOrEmpty(phoneNumber))
                Query.Search(x => x.PhoneNumber, "%" + phoneNumber + "%");
            
            if (!string.IsNullOrEmpty(email))
                Query.Search(x => x.Email, "%" + phoneNumber + "%");
        }
    }
}
