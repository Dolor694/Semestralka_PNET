using Gym.Business.Interfaces;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string username, string password, double weight)
        {
            User newUser = new User
            {
                Username = username,
                Password = HashPassword(password),
                Weight = weight
            };

            _userRepository.Add(newUser);

            return newUser;
        }

        public bool DeleteUser(int id)
        {
            User? user = _userRepository.GetById(id);

            if (user == null)
            {
                return false;
            }

            _userRepository.Delete(user);   
            return true;
        }

        public UserDTO? GetUserById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            User? user = _userRepository.GetById(id);

            if (user == null)
            {
                return null;
            }

            return MapToUserDTO(user);
        }

        public UserDTO GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            User? user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                throw new Exception($"User with username '{username}' not found.");
            }

            return MapToUserDTO(user);
        }

        public UserDTO UpdateUser(int id, string? username, string? password, double? weight)
        {
            User? user = _userRepository.GetById(id);

            if (user == null)
            {
                throw new Exception($"User with id '{id}' not found.");
            }

            if (!string.IsNullOrEmpty(username))
            {
                user.Username = username;
            }

            if (!string.IsNullOrEmpty(password))
            {
                user.Password = HashPassword(password);
            }

            if (weight.HasValue)
            {
                user.Weight = weight.Value;
            }

            _userRepository.Update(user);

            return MapToUserDTO(user);
        }

        public User GetUserForValidation(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            User? user = _userRepository.GetByUsername(username);

            if (user == null) {
                throw new Exception($"User with username '{username}' not found.");
            }

            return user;
        }

        public UserDTO? LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }

            User? user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return MapToUserDTO(user);
            }

            return null;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private UserDTO MapToUserDTO(User user)
        {
            return new UserDTO(user.Id, user.Username, user.Weight);
        }
    }
}
