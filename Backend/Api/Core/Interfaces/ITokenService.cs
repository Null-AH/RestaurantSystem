using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;

namespace Api.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}