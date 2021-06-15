using PwiAPI.Data;
using PwiAPI.Helpers;
using PwiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PwiAPI.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public User GetUserByEmail(string emailAddress)
        {
            return _context.Users.FirstOrDefault(user => user.Email == emailAddress);
        }

        public void Add(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
