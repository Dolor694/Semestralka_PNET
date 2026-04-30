using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Models.Data;

namespace Gym.Models.Database
{
    public class DatabaseMuscleRepo : DatabaseRepository<Muscle>, IMuscleRepository
    {
        public DatabaseMuscleRepo(GymDbContext context) : base(context)
        {
        }

        public IEnumerable<Muscle> GetMusclesByGroup(int idMuscleGroup)
        {
            return _context.MuscleGroupMuscles
                .Where(mgm => mgm.IdMuscleGroup == idMuscleGroup)
                .Select(mgm => mgm.Muscle)
                .Distinct()
                .ToList();
        }
    }
}
