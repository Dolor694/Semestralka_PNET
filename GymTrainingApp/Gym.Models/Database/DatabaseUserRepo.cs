using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Database
{
    public class DatabaseUserRepo : DatabaseRepository<User>, IUserRepository
    {
        public DatabaseUserRepo(GymDbContext context) : base(context)
        {
        }

        /*
         * This method retrieves a user from the database based on their username.
         * 
         * @param username The username of the user to retrieve.
         * @return The user with the specified username, or null if no such user exists.
         */
        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
