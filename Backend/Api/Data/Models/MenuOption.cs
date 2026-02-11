using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    [Table("MenuOptions")]
    public class MenuOption
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<MenuItemOption> MenuItemOptions { get; set; } = new();

    }
}