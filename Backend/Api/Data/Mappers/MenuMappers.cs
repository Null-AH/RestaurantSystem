using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTOs.Menu;
using Api.Data.Models;

namespace Api.Data.Mappers
{
    public static class MenuMappers
    {
        
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Name = category.Name,
                Image = category.Image,
                IsActive = category.IsActive,
                PrinterId = category.PrinterId,
                MenuItems = category.MenuItems.Select(mi => mi.ToMenuItemDto()).ToList(),
            };
        }

        public static MenuItemDto ToMenuItemDto(this MenuItem item)
        {
            return new MenuItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Cost = item.Cost,
                IsAvailable = item.IsAvailable,
                Image = item.Image,
                MenuOptions = item.MenuItemOptions.Select(mo => mo.MenuOption.ToMenuOptionDto()).ToList()
            };
        }
        public static MenuOptionDto ToMenuOptionDto(this MenuOption menuOption)
        {
            return new MenuOptionDto
            {
                Id = menuOption.Id,
                Name = menuOption.Name,
                Price = menuOption.Price
            };
        }
    }
}