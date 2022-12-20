using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer : AuditableBaseEntity
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }
        private int _age;

        public int CostumerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string FirstLastName { get; set; } = null!;
        public string SecondLastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        
        public virtual ICollection<Invoice> Invoices { get; set; }

        public int Age
        {
            get
            {
                if (this._age <= 0)
                    this._age = new DateTime(DateTime.Now.Subtract(this.DateOfBirth).Ticks).Year - 1;
                return this._age;                
            } 
        }
    }
}
