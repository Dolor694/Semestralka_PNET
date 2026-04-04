using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    internal interface IUserService
    {
        IReadOnlyList<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
        UserDTO GetUserByUsername(string username);
        UserWithPasswordDTO GetUserByNameForValidation(string username);
        UserDTO CreateUser(int id, string username, string password, double weight);
        UserDTO UpdateUser(int id, string? username, string? password, double? weight);
        bool ValidateUser(string username, string password);
        bool DeleteUser(int id);
    }
}
