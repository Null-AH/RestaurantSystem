using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.DTOs.Menu
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public bool IsAvailable { get; set; }
        public string Image { get; set; } = string.Empty;
        public List<MenuOptionDto> MenuOptions { get; set; } = new();
    }
}