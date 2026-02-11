using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class InvoiceItemOption
    {
        public int Id { get; set; }
        public int InvoiceItemId { get; set; }
        public InvoiceItem InvoiceItem { get; set; }

        public int MenuOptionID { get; set; }
        public MenuOption MenuOption { get; set; }

        public decimal Price { get; set; }
    }
}