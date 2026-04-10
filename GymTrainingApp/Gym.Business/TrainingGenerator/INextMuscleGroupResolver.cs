using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public interface INextMuscleGroupResolver
    {
        /*
         * This method determines the next muscle group to train based on the TrainingTypeSequence cycle.
         * It looks up the last training in the plan, finds its position in the sequence cycle,
         * and returns the IdMuscleGroup of the next entry (wrapping around to the start if at the end).
         * If no previous training exists, it returns the first muscle group in the sequence.
         * 
         * @param idTrainingPlan The ID of the training plan.
         * @param idTrainingType The ID of the training type used to look up the sequence.
         * @return The IdMuscleGroup of the next muscle group to train.
         */
        int GetNextMuscleGroupId(int idTrainingPlan, int idTrainingType);
    }
}