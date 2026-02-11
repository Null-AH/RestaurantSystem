using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class User
    {
        public enum UserRole
        {
            Admin,
            Manager,
            Cashier,
            Cheff,
            Waiter
        }
        public Guid Id { get; set; }        
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; } = UserRole.Admin;
        public int SalaryId { get; set; }
    }
}