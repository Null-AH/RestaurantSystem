using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Enums;

namespace Api.Data.DTOs.Order
{
    public class CreateOrderRequestDto
    {
        public int TableId { get; set; }
        public int CustomerId { get; set; }
        public OrderTypes OrderType { get; set; }

    }
}