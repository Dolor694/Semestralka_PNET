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
        UserDTO? GetUserById(int id);
        UserDTO? GetUserByUsername(string username);
        User GetUserForValidation(string username);
        User CreateUser(int id, string username, string password, double weight);
        UserDTO UpdateUser(int id, string? username, string? password, double? weight);
        bool ValidatePassword(string username, string password);
        bool DeleteUser(int id);
    }
}
