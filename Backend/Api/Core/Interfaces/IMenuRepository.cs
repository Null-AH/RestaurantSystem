using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTOs;
using Api.Data.DTOs.Menu;

namespace Api.Core.Interfaces
{
    public interface IMenuRepository
    {
        public Task<List<CategoryDto>> GetFullMenuAsync();
        public Task<MenuItemDto> GetItemByIdAsyn(int id);
    }
}