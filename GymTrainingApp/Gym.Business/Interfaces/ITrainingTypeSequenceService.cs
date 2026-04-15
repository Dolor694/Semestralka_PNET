using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    public interface ITrainingTypeSequenceService
    {
        /*
         * This method creates a new training type sequence.
         * 
         * @param orderInCycle The order of this sequence in the training cycle.
         * @param idTrainingType The identifier of the training type.
         * @param idMuscleGroup The identifier of the muscle group.
         * @return The created training type sequence object.
         */
        TrainingTypeSequence CreateTrainingTypeSequence(int orderInCycle, int idTrainingType, int idMuscleGroup);

        /*
         * This method retrieves a training type sequence by its unique identifier.
         * 
         * @param id The unique identifier of the training type sequence to be retrieved.
         * @return A TrainingTypeSequence object if found, or null if it does not exist.
         */
        TrainingTypeSequence? GetTrainingTypeSequenceById(int id);

        /*
         * This method updates the information of an existing training type sequence.
         * 
         * @param id The unique identifier of the training type sequence to be updated.
         * @param orderInCycle The new order in the cycle (optional).
         * @param idTrainingType The new training type identifier (optional).
         * @param idMuscleGroup The new muscle group identifier (optional).
         * @return The updated training type sequence object.
         */
        TrainingTypeSequence UpdateTrainingTypeSequence(int id, int? orderInCycle, int? idTrainingType, int? idMuscleGroup);

        /*
         * This method deletes a training type sequence by its unique identifier.
         * 
         * @param id The unique identifier of the training type sequence to be deleted.
         * @return A boolean value indicating whether the training type sequence was successfully deleted (true) or not found (false).
         */
        bool DeleteTrainingTypeSequence(int id);
    }
}