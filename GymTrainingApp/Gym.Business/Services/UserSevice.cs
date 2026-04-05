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
    public class UserSevice : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserSevice(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /*
         * This method creates a new user.
         * 
         * @param id The unique identifier for the user.
         * @param username The username of the user.
         * @param password The password of the user.
         * @param weight The weight of the user.
         * @return The created user object.
        */
        public User CreateUser(int id, string username, string password, double weight)
        {
            User newUser = new User
            {
                Id = id,
                Username = username,
                Password = HashPassword(password),
                Weight = weight
            };

            _userRepository.Add(newUser);

            return newUser;
        }

        /*
         * This method deletes a user by their unique identifier.
         * 
         * @param id The unique identifier of the user to be deleted.
         * @return A boolean value indicating whether the user was successfully deleted (true) or not found (false).
         */
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

        /*
         * This method retrieves a user by their unique identifier.
         * 
         * @param id The unique identifier of the user to be retrieved.
         * @return A UserDTO object containing the user's information if found, or null if the user does not exist.
         */
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

        /*
         * This method retrieves a user by their username.
         * 
         * @param username The username of the user to be retrieved.
         * @return A UserDTO object containing the user's information if found
         */
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

        /*
         * This method updates the information of an existing user.
         * 
         * @param id The unique identifier of the user to be updated.
         * @param username The new username for the user (optional).
         * @param password The new password for the user (optional).
         * @param weight The new weight for the user (optional).
         * @return A UserDTO object containing the updated user's information.
         */
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

        /*
         * This method retrieves a user for validation purposes based on their username.
         * 
         * @param username The username of the user to be retrieved for validation.
         * @return A User object containing the user's information if found, or throws an exception if not.
         */
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

        /*
         * This method validates a user's password by comparing the provided password with the stored hashed password.
         * 
         * @param username The username of the user whose password is to be validated.
         * @param password The password to be validated against the stored hashed password.
         * @return A boolean value indicating whether the provided password is valid (true) or not (false).
         */
        public bool ValidatePassword(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrEmpty(password)) {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }

            User? user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                throw new Exception($"User with username '{username}' not found.");
            }

            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        /*
         * This method hashes a plain text password using the BCrypt algorithm.
         * 
         * @param password The plain text password to be hashed.
         * @return The hashed password as a string.
         */
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /*
         * This method maps a User entity to a UserDTO object.
         * 
         * @param user The User entity to be mapped.
         * @return A UserDTO object containing the mapped information from the User entity.
         */
        private UserDTO MapToUserDTO(User user)
        {
            return new UserDTO(user.Id, user.Username, user.Weight);
        }
    }
}
