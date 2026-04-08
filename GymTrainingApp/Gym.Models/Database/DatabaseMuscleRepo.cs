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
    public class DatabaseMuscleRepo : DatabaseRepository<Muscle>, IMuscleRepository
    {
        public DatabaseMuscleRepo(GymDbContext context) : base(context)
        {
        }

        public IEnumerable<Muscle> GetMusclesByGroup(int idMuscleGroup)
        {
            return _context.Muscles
                .Where(e => e.IdMuscleGroup == idMuscleGroup) .ToList();
        }
    }
}
