﻿using Domain.Common;

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
        public string? MiddleName { get; set; } = string.Empty;
        public string FirstLastName { get; set; } = null!;
        public string? SecondLastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {MiddleName} {FirstLastName} {SecondLastName}";
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;        
        
        public virtual ICollection<Invoice> Invoices { get; private set; }

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
