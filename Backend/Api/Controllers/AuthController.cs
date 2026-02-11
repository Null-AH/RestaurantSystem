using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Api.DTOs;
using Api.Data.Models;
using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthRepository authRepo, ITokenService tokenService)
        {
            _authRepo = authRepo;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {

            if (await _authRepo.UserExists(dto.Username))
                return BadRequest("Username already taken");

            var userToCreate = new User
            {
                Username = dto.Username,
                Role = dto.Role 
            };

            var createdUser = await _authRepo.Register(userToCreate, dto.Password);

            var token = _tokenService.CreateToken(createdUser);

            return Ok(new { token, user = createdUser.Username, role = createdUser.Role.ToString() });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {

            var user = await _authRepo.Login(dto.Username, dto.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            // Generate Token
            var token = _tokenService.CreateToken(user);

            return Ok(new { token, user = user.Username, role = user.Role.ToString() });
        }
    }
}