using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Enums;
using Humanizer;

namespace Api.Data.Models
{
    public class Invoice
    {

        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int TableId { get; set; }
        public int CustomerId { get; set; }
        public OrderTypes OrderType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public decimal SubTotalPrice { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal FinalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public User? User { get; set; }
        public Table? Table { get; set; }
        public Customer? Customer { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; } = new();

    }
}