using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.DTOs.Order
{
    public class InvoiceItemDto
    {
        public int Id { get; set; }
        public string MenuItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OptionDto> SelectedOptionsDto {get;set;} = new();
    }
}