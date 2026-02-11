using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;

namespace Api.Data.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int PrinterId { get; set; }

        public List<MenuItem> MenuItems { get; set; } = new();

    }
}