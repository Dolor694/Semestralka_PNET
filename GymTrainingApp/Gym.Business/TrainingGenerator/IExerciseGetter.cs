using Gym.Models.Interfaces;
using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public interface IExerciseGetter
    {

        /*
         * This menthod gets all exercises, which train a specific muscle group.
         * 
         * @param IdMuscleGroup id of the muscle group
         * @return list of exercises, which train the muscle group
         */
        public IEnumerable<Exercise> GetExercisesByMuscleGroup(int IdMuscleGroup);
    }
}
