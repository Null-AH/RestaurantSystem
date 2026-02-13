using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;

namespace Api.Data.DTOs.Menu
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int PrinterId { get; set; }
        public List<MenuItemDto> MenuItems { get; set; } =new();
        public List<MenuOption> MenuOptions { get; set; } = new();
    }
}