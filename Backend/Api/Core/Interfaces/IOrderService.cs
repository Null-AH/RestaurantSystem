using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTOs.Order;

namespace Api.Core.Interfaces
{
    public interface IOrderService
    {
        public Task<InvoiceDto> CreateOrderAsync(CreateOrderRequestDto requestDto,Guid UserId);        
    }
}