using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public class ExerciseSelector : IExerciseSelector
    {
        public IEnumerable<Exercise> SelectExercises(IEnumerable<Exercise> exercises, int numberOfExercises)
        {
            // Implementation of exercise selection logic
            throw new NotImplementedException();
        }
    }
}
