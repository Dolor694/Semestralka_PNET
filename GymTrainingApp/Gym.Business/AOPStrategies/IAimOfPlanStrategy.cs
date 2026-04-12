using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.AOPStrategies
{
    public interface IAimOfPlanStrategy
    {
        /*
         * This method will set the parameters of exercises in a training.
         * 
         * @param exercises - the list of exercises in a training.
         * @param idTraining - the id of the training for which the parameters will be set.
         * @return a list of exercises in a training with the parameters set.
         */
        public List<ExerciseInTraining> SetParametersOfExercises(List<Exercise> exercises, int idTraining);
    }
}
