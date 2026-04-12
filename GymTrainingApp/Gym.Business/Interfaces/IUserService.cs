using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    internal interface IUserService
    {
        /*
         * This method retrieves a user by their unique identifier.
         * 
         * @param id The unique identifier of the user to be retrieved.
         * @return A UserDTO object containing the user's information if found, or null if the user does not exist.
         */
        UserDTO? GetUserById(int id);

        /*
         * This method retrieves a user by their username.
         * 
         * @param username The username of the user to be retrieved.
         * @return A UserDTO object containing the user's information if found
         */
        UserDTO GetUserByUsername(string username);

        /*
         * This method retrieves a user for validation purposes based on their username.
         * 
         * @param username The username of the user to be retrieved for validation.
         * @return A User object containing the user's information if found, or throws an exception if not.
         */
        User GetUserForValidation(string username);

        /*
         * This method creates a new user.
         * 
         * @param id The unique identifier for the user.
         * @param username The username of the user.
         * @param password The password of the user.
         * @param weight The weight of the user.
         * @return The created user object.
        */
        User CreateUser(int id, string username, string password, double weight);

        /*
         * This method updates the information of an existing user.
         * 
         * @param id The unique identifier of the user to be updated.
         * @param username The new username for the user (optional).
         * @param password The new password for the user (optional).
         * @param weight The new weight for the user (optional).
         * @return A UserDTO object containing the updated user's information.
         */
        UserDTO UpdateUser(int id, string? username, string? password, double? weight);

        /*
         * This method validates a user's password by comparing the provided password with the stored hashed password.
         * 
         * @param username The username of the user whose password is to be validated.
         * @param password The password to be validated against the stored hashed password.
         * @return A boolean value indicating whether the provided password is valid (true) or not (false).
         */
        bool ValidatePassword(string username, string password);

        /*
         * This method deletes a user by their unique identifier.
         * 
         * @param id The unique identifier of the user to be deleted.
         * @return A boolean value indicating whether the user was successfully deleted (true) or not found (false).
         */
        bool DeleteUser(int id);

        /*
         * This method logs in an user who is already registered.
         * 
         * @param username The username of the user.
         * @param password The password of the user
         * @return An UserDTO representing the user.
         */
        UserDTO? LoginUser(string username, string password);
    }
}
