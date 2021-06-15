using Microsoft.Extensions.Configuration;
using PwiAPI.Helpers;
using PwiAPI.Models;
using PwiAPI.Repositories;
using System;
using System.Collections.Generic;
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
            string email = JwtTokenHelper.ExtractDataFromToken(token, ClaimTypes.Email);
            var userFromRepo = _userRepository.GetUserByEmail(email);

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
            if (!IsEmailValid(emailAddress) || !IsPasswordValid(password))
            {
                return null;
            }

            User userFromContext;
            try
            {
                userFromContext = _userRepository.GetUserByEmail(emailAddress.ToLower());
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            var result = PasswordHashHelper.VerifyHashedPassword(userFromContext.Password, password);

            if (result != PasswordVerificationResult.Success)
            {
                return null;
            }

            return userFromContext;
        }


        public bool Register(string email, string password)
        {
            if (!IsEmailValid(email) || !IsPasswordValid(password))
            {
                return false;
            }

            var hashedPassword = PasswordHashHelper.HashPassword(password);
            var newUser = new User()
            {
                Email = email.ToLower(),
                Password = hashedPassword,
                AccountBalance = 0
            };

            _userRepository.Add(newUser);
            return true;
        }

        private bool IsEmailValid(string emailAddress)
        {
            var regex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", RegexOptions.Compiled);
            return regex.IsMatch(emailAddress);
        }

        private bool IsPasswordValid(string emailAddress)
        {
            //At least 8 characters, one letter, one number, one special character
            var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", RegexOptions.Compiled);
            return regex.IsMatch(emailAddress);
        }
    }

}
