using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Api.Data;
using Api.Data.DTOs.TableDtos;
using Api.Data.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext _context;
        public TableRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TableDto>> GetAllTablesAsync()
        {            
            var tables = await _context.Tables.Select(t => t.ToTableDto()).ToListAsync();
        
            return tables;
        }

        public async Task<bool> UpdateTableAsync(int id, TableDto table)
        {
            var existingTable = await _context.Tables.FindAsync(id);
            if (existingTable == null)
            {
                return false;
            }

            existingTable.Number = table.Number;
            existingTable.Capacity = table.Capacity;
            existingTable.Status = table.Status;

            _context.Tables.Update(existingTable);
            await _context.SaveChangesAsync();

            return true;
        }
        // public Task<TableDto> CreateTableAsync(TableDto table)
        // {
        //     throw new NotImplementedException();
        // }


        public async Task<TableDto> GetTableByIdAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);            
            
            return table.ToTableDto();
        }

    }
}