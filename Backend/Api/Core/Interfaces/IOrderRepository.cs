using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTOs.Order;
using Api.Data.Models;

namespace Api.Core.Interfaces
{
    public interface IOrderRepository
    {
        public Task<InvoiceDto?> GetInvoiceByTableIdAsync(int tableId);
        public Task<InvoiceDto> CreateInvoiceAsync(Invoice invoice);
        public Task<InvoiceItemDto> AddInvoiceItemAsync(InvoiceItem invoiceItem);
    }
}