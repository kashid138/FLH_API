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
    public class UserRepository : IRegistrationRepository
    {
        private readonly LFHDBContext _context;

        public UserRepository(LFHDBContext context)
        {
            _context = context;
        }

        //public async Task<UserRegistration> CreateUser(UserRegistration toCreate)
        //{
        //    toCreate.DateCreated = DateTime.Now;
        //    toCreate.LastModified = DateTime.Now;
        //    _context.Users.Add(toCreate);
        //    await _context.SaveChangesAsync();
        //    return toCreate;
        //}

        public async Task<UserRegistration> CreateUser(UserRegistration toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;


        // Check if user already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.email == toCreate.email);
            if (existingUser != null)
            {
                // User already exists, return a specific response
                return new UserRegistration
                {
                    userid = existingUser.userid,
                    firstName = existingUser.firstName,
                    lastName = existingUser.lastName,
                    contact = existingUser.contact,
                    email = existingUser.email,
                    usertype = existingUser.usertype,
                    password =existingUser.password,
                    DateCreated = existingUser.DateCreated,
                    LastModified = existingUser.LastModified,
                    Message = "User already exists"
                };
            }

            _context.Users.Add(toCreate);
            await _context.SaveChangesAsync();
            return new UserRegistration
            {
                Message = "User Created Successfully!!"
            };
        }


        public async Task DeleteUser(int UserId)
        {
            var User = await _context.Users.FirstOrDefaultAsync(p => p.userid == UserId);
            if (User == null) return;

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserRegistration>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> GetAllUsersCount()
        {
            return await _context.Users.CountAsync();
        }
        public async Task<UserRegistration> GetUserWithId(int userId)
        {
            return await _context.Users.LastOrDefaultAsync(p => p.userid == userId);
        }

     

    }
}
