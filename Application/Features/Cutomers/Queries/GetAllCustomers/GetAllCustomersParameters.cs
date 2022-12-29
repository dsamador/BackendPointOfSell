using POS.Application.Parameters;

namespace POS.Application.Features.Cutomers.Queries.GetAllCustomers
{
    public class GetAllCustomersParameters : RequestParameter
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
