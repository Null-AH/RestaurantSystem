using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int MenuItemId { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation Properties
        public Invoice? Invoice { get; set; }
        public MenuItem? MenuItem { get; set; }
        public List<InvoiceItemOption> SelectedItemOptions { get; set; } = new();
    }
}