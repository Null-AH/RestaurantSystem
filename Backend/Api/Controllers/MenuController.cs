using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Data.DTOs.Menu;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuController : ControllerBase
    {
        private IMenuRepository _menuRepo;
        public MenuController(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetMenu()
        {
            var menu = await _menuRepo.GetFullMenuAsync();
            
            return Ok(menu);
        }

        
    }
}