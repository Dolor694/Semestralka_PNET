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
    public class DatabaseExerciseInTrainingRepo : DatabaseRepository<ExerciseInTraining>, IExerciseInTrainingRepository
    {
        public DatabaseExerciseInTrainingRepo(GymDbContext context) : base(context)
        {
        }
    }
}
