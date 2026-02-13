using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Api.Data.DTOs.Order;
using Api.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ITableRepository _tabelRepo;
        private readonly IOrderService _orderService;
        public OrderController(IOrderRepository orderRepo, ITableRepository tableRepo)
        {
            _orderRepo = orderRepo;
            _tabelRepo = tableRepo;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrderByTableId(int id)
        {
            var order = await _orderRepo.GetInvoiceByTableIdAsync(id);
            
            return Ok(order);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> OpenOrder([FromBody] CreateOrderRequestDto invoiceDto)
        {
            var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdString == null) return Unauthorized();

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Invalid User ID in Token");
            }

            if(invoiceDto == null)
            {
                return BadRequest();
            }

            await _orderService.CreateOrderAsync(invoiceDto,userId);

            return Ok();
        }
        
    }
}