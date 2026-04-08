using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public interface IExerciseSelector
    {
        /*
         * This method selects a specific number of exercises from a list of exercises.
         * 
         * @param exercises list of exercises to select from
         * @param numberOfExercises number of exercises to select
         * @param idMuscleGroup id of the muscle group to select exercises for
         * @return list of selected exercises
         */
        public IEnumerable<Exercise> SelectExercises(IEnumerable<Exercise> exercises, int numberOfExercises, int idMuscleGroup);
    }
}
