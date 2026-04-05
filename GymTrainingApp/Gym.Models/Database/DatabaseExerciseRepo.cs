using Gym.Models.Data;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
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
    }
}
