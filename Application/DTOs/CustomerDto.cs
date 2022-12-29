

namespace POS.Application.DTOs
{
    public class CustomerDto
    {
       
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } = string.Empty;
        public string FirstLastName { get; set; } = null!;
        public string? SecondLastName { get; set; } = string.Empty;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
       
    }
}
