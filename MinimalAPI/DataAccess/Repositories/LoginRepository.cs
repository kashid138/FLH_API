using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LFHDBContext _context;

        public LoginRepository(LFHDBContext context)
        {
            _context = context;
        }
        #region Login
        public async Task<UserLogin> CheckLogin(string email, string pass)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.email == email && u.password == pass);
            if (existingUser != null)
            {
                return new UserLogin
                {
                    Password = existingUser.password,
                    Email = existingUser.email,
                    Message = "Login successful",
                    UserType=existingUser.usertype
                };
            }

            return new UserLogin
            {
                Password = pass, // You can set the contact and email to the values passed in if the user is not found
                Email = email,
                Message = "User not found"
            };
        }
        #endregion

    }
}
