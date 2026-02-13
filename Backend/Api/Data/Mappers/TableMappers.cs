using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTOs.TableDtos;
using Api.Data.Models;

namespace Api.Data.Mappers
{
    public static class TableMappers
    {
        public static TableDto ToTableDto(this Table table)
        {
            return new TableDto
            {
                Id = table.Id,
                Number = table.Number,
                Capacity = table.Capacity,
                Status = table.Status,
                FloorId = table.FloorId
            };
        }
        
    }
}