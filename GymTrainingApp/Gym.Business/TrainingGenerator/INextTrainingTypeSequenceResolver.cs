using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public interface INextTrainingTypeSequenceResolver
    {
        /*
         * This method determines the ID of the next TrainingTypeSequence entry in the cycle.
         * It looks up the last training in the plan, finds its position in the sequence cycle,
         * and returns the Id of the next entry (wrapping around to the start if at the end).
         * If no previous training exists, it returns the first entry's Id.
         * 
         * @param idTrainingPlan The ID of the training plan.
         * @param idTrainingType The ID of the training type used to look up the sequence.
         * @return The Id of the next TrainingTypeSequence entry.
         */
        int GetNextTrainingTypeSequenceId(int idTrainingPlan, int idTrainingType);
    }
}