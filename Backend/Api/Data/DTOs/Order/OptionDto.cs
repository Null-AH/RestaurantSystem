using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;

namespace Api.Data.DTOs.Order
{
    public class OptionDto
    {
        public int Id { get; set; }
        public int InvoiceItemId { get; set; }
        public int MenuOptionID { get; set; }
        public decimal Price { get; set; }
    }
}