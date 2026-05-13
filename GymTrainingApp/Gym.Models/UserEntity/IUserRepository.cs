using Gym.Models._Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.UserEntity
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetByUsername(string username);
    }
}
