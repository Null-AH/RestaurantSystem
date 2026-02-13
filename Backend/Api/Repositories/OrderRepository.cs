using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Api.Core.Interfaces;
using Api.Data;
using Api.Data.DTOs.Order;
using Api.Data.Enums;
using Api.Data.Mappers;
using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<InvoiceDto?> GetInvoiceByTableIdAsync(int tableId)
        {   
            var openInvoice = await _context.Invoices.Where(x => x.InvoiceStatus == InvoiceStatus.Pending && x.TableId == tableId)
                                .Include(x => x.InvoiceItems).ThenInclude(x => x.MenuItem)
                                .Include(x => x.InvoiceItems).ThenInclude(x => x.SelectedItemOptions)
                                .ThenInclude(x => x.MenuOption)
                                .FirstOrDefaultAsync();

            return openInvoice.ToInvoiceDto();
        }

        public async Task<InvoiceDto> CreateInvoiceAsync(Invoice invoice)
        {
            if(invoice == null)
            {
            }
            var addedInvoice = await _context.Invoices.AddAsync(invoice);                
            
            await _context.SaveChangesAsync();  
            return addedInvoice.Entity.ToInvoiceDto();
        }
        public async Task<InvoiceItemDto> AddInvoiceItemAsync(InvoiceItem invoiceItem)
        {
            if(invoiceItem == null)
            {
                
            }
            var addedInvoiceItem = await _context.InvoiceItems.AddAsync(invoiceItem);
            await _context.SaveChangesAsync();  

            return addedInvoiceItem.Entity.ToInvoiceItemDto();
        }


    }
}