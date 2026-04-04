using Gym.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Services
{
    internal class UserSevice : IUserService
    {
        
        public UserDTO CreateUser(int id, string username, string password, double weight)
        {
            throw new NotImplementedException();
        }
        
        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserWithPasswordDTO GetUserByNameForValidation(string username)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(int id, string? username, string? password, double? weight)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
