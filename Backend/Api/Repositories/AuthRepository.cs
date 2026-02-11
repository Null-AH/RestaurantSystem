using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core.Interfaces;
using Api.Data;
using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        public AuthRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<User> Register(User user, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            
            user.PasswordHash = passwordHash;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User?> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
    
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }


        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower());
        }
    }
}