using Gym.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Gym.Models.ExerciseEntity
{
    public class DatabaseExerciseRepo : DatabaseRepository<Exercise>, IExerciseRepository
    {
        public DatabaseExerciseRepo(GymDbContext context) : base(context)
        {
        }

        public IEnumerable<Exercise> GetExercisesByMuscleGroup(int idMuscleGroup)
        {
            return _context.Exercises
                .Include(e => e.Muscle)
                .ThenInclude(m => m.MuscleGroupMuscles)
                .Where(e => e.Muscle.MuscleGroupMuscles.Any(mgm => mgm.IdMuscleGroup == idMuscleGroup))
                .ToList();
        }
    }
}
