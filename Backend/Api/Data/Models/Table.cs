using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    [Table("Tables")]
    public class Table
    {
        public enum TableStatus
        {
            Available,
            Occupied,
            Reserved
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public TableStatus Status { get; set; }
        public int FloorId { get; set; }

        
    }
}