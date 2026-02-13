using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Api.Data.DTOs.Order;
using Api.Data.Enums;
using Api.Data.Mappers;
using Api.Data.Models;
using Api.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ITableRepository _tableRepo;

        public OrderService(IOrderRepository orderRepository,ITableRepository tableRepository)
        {
            _orderRepo = orderRepository;
            _tableRepo = tableRepository;
        }
        public async Task<InvoiceDto> CreateOrderAsync(CreateOrderRequestDto orderDto, Guid UserId)
        {

            var table = await _tableRepo.GetTableByIdAsync(orderDto.TableId);

            if(orderDto.OrderType == OrderTypes.DineIn)
            {
                
                if(table.Status == TableStatus.Occupied || table.Status == TableStatus.Reserved)
                {
                    throw new Exception("This table is no currently available!");
                }

                table.Status = TableStatus.Occupied;                                                                                                           
            }
            else
            {
                table.Id = 0;
            }
        
            var invoice = new Invoice
                {
                    UserId = UserId,
                    TableId = table.Id,
                    CustomerId = orderDto.CustomerId,
                    OrderType = orderDto.OrderType,
                    InvoiceStatus = InvoiceStatus.Pending,
                    SubTotalPrice = 0
                };
            var savedInvoice = await _orderRepo.CreateInvoiceAsync(invoice);
            await _tableRepo.UpdateTableAsync(table.Id,table);
            
            return savedInvoice;
        }
    }
}