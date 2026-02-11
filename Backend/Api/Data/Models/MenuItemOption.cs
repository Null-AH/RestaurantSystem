using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class MenuItemOption
    {
        public int MenuItemId { get; set; }
        public int MenuOptionId { get; set; }
        public MenuItem? MenuItem { get; set; }
        public MenuOption? MenuOption { get; set; }
    }
}