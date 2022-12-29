using Domain.Common;

namespace Domain.Models
{
    public class Customer : AuditableBaseEntity
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }
        //private int _age;

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } = string.Empty;
        public string FirstLastName { get; set; } = null!;
        public string? SecondLastName { get; set; } = string.Empty;        
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;        
        
        public virtual ICollection<Invoice> Invoices { get; private set; }

        //public int Age
        //{
        //    get
        //    {
        //        if (_age <= 0)
        //            _age = new DateTime(DateTime.Now.Subtract(DateOfBirth).Ticks).Year - 1;
        //        return _age;                
        //    }
        //    set { _age = value; }
        //}
    }
}
