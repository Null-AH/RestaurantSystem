using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Api.Data.Models.Table;

namespace Api.Data.DTOs.Table
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public TableStatus Status { get; set; }
        public int FloorId { get; set; }
    }
}