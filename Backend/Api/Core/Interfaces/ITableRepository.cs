using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTOs.TableDtos;

namespace Api.Core.Interfaces
{
    public interface ITableRepository
    {
        public Task<List<TableDto>> GetAllTablesAsync();
        public Task<TableDto> GetTableByIdAsync(int id);
        // public Task<TableDto> CreateTableAsync(TableDto table);
        public Task<bool> UpdateTableAsync(int id, TableDto table);
    }
}