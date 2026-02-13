using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Api.Data;
using Api.Data.DTOs.Menu;
using Api.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> GetFullMenuAsync()
        {
            var menu = await _context.Categories.Where(c => c.IsActive)
                .Include(c => c.MenuItems.Where(mi => mi.IsAvailable))
                    .ThenInclude(mi => mi.MenuItemOptions)
                        .ThenInclude(mio => mio.MenuOption)
                .ToListAsync();
            var menuDto = menu.Select(c => c.ToCategoryDto()).ToList();

            return menuDto;
        }

        public async Task<MenuItemDto> GetItemByIdAsyn(int id)
        {
            var item = await _context.MenuItems.Include(i => i.MenuItemOptions)
                .ThenInclude(o => o.MenuOption)
                    .FirstOrDefaultAsync(i => i.Id == id);
            return item.ToMenuItemDto();
        }
    }
}