using Gym.Models.Data;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Database
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
                .Where(e => e.Muscle.IdMuscleGroup == idMuscleGroup)
                .ToList();
        }
    }
}
