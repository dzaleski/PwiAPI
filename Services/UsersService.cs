using Microsoft.Extensions.Configuration;
using PwiAPI.Helpers;
using PwiAPI.Models;
using PwiAPI.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PwiAPI.Services
{
    public class UsersService
    {
        private readonly UserRepository _userRepository;
        public UsersService(UserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;

        }

        public User GetCurrentUser(string token)
        {
            string id = JwtTokenHelper.ExtractDataFromToken(token, ClaimTypes.NameIdentifier);
            var userFromRepo = _userRepository.GetUserById(int.Parse(id));

            return userFromRepo;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User Login(string email, string password)
        {
            return ValidateUser(email, password);
        }

        private User ValidateUser(string emailAddress, string password)
        {
            User userFromContext = _userRepository.GetUserByEmail(emailAddress.ToLower());

            if (userFromContext == null)
            {
                return null;
            }

            var result = PasswordHashHelper.VerifyHashedPassword(userFromContext.Password, password);

            if (result != PasswordVerificationResult.Success)
            {
                return null;
            }

            return userFromContext;
        }


        public void Register(string email, string password)
        {
            var hashedPassword = PasswordHashHelper.HashPassword(password);

            var newUser = new User()
            {
                Email = email.ToLower(),
                Password = hashedPassword,
                AccountBalance = 0
            };

            _userRepository.Add(newUser);
        }
    }

}
