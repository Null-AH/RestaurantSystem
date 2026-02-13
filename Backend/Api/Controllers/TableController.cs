using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Api.Data.DTOs.TableDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/tables")]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository _tableRepo;
        public TableController(ITableRepository tableRepo)
        {
            _tableRepo = tableRepo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableRepo.GetAllTablesAsync();

            return Ok(tables);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateTable(int id,[FromBody] TableDto table)
        {
            var result = await _tableRepo.UpdateTableAsync(id, table);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Table updated successfully");
        }
    }
}