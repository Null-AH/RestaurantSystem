using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTOs.Order;
using Api.Data.Models;

namespace Api.Data.Mappers
{
    public static class OrderMappers
    {
        public static InvoiceDto ToInvoiceDto(this Invoice invoice)
        {
            return new InvoiceDto
            {
                Id = invoice.Id,
                UserId = invoice.UserId,
                TableId = invoice.TableId,
                CustomerId = invoice.CustomerId,
                OrderType = invoice.OrderType,
                CreatedAt = invoice.CreatedAt,
                
                SubTotalPrice = invoice.SubTotalPrice,
                Discount = invoice.Discount,
                DiscountPrice = invoice.DiscountPrice,
                DiscountType = invoice.DiscountType,
                FinalPrice = invoice.FinalPrice,
                
                PaymentMethod = invoice.PaymentMethod,
                InvoiceStatus = invoice.InvoiceStatus,
                Notes = invoice.Notes,

                User = invoice.User, 
                Table = invoice.Table,
                Customer = invoice.Customer,

                InvoiceItemsDto = invoice.InvoiceItems.Select(i => i.ToInvoiceItemDto()).ToList()
            };

        }
        public static InvoiceItemDto ToInvoiceItemDto(this InvoiceItem invoiceItem)
        {
            return new InvoiceItemDto
            {
                Id = invoiceItem.Id,
                MenuItemName = invoiceItem.MenuItem.Name,
                Quantity = invoiceItem.Quantity,
                Price = invoiceItem.Price,
                TotalPrice = invoiceItem.TotalPrice,
                SelectedOptionsDto = invoiceItem.SelectedItemOptions.Select(sp => sp.ToOptionDto()).ToList()
            };               
        }
        public static OptionDto ToOptionDto(this InvoiceItemOption option)
        {
            return new OptionDto
            {
                Id = option.Id,
                InvoiceItemId = option.InvoiceItemId,
                MenuOptionID = option.MenuOptionID,
                Price = option.Price
            };
        }

            
        }
        
}
