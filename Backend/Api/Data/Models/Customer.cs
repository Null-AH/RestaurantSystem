using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public decimal Debt { get; set; }
        public decimal Balance { get; set; }

        // Navigation Properties
        public List<Invoice> Invoices { get; set; } = new(); 

    }
}