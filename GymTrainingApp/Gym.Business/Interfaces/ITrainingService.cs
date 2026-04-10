using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    internal interface ITrainingService
    {
        /*
         * This method creates a new training.
         * 
         */
        Training CreateTraining();

        /*
         * This method retrieves a training by its unique identifier.
         * 
         * @param id The unique identifier of the training to be retrieved.
         * @return A TrainingDTO object containing the training's information if found, or null if the training does not exist.
         */
        TrainingDTO? GetTrainingById(int id);

        /*
         * This method updates the information of an existing training.
         * 
         * @param id The unique identifier of the training to be updated.
         * @param date The new date for the training (optional).
         * @param idTrainingTypeSequence The new training type sequence identifier (optional).
         * @return A TrainingDTO object containing the updated training's information.
         */
        TrainingDTO UpdateTraining(int id, DateOnly? date, int? idTrainingTypeSequence);

        /*
         * This method deletes a training by its unique identifier.
         * 
         * @param id The unique identifier of the training to be deleted.
         * @return A boolean value indicating whether the training was successfully deleted (true) or not found (false).
         */
        bool DeleteTraining(int id);

        /*
         * This method retrieves all trainings associated with a specific training plan.
         * 
         * @param idPlan The ID of the training plan for which to retrieve the trainings.
         * @return An enumerable collection of TrainingDTO objects that are associated with the specified training plan.
         */
        IEnumerable<TrainingDTO> GetTrainingsByPlan(int idPlan);

        /*
         * This method retrieves the most recent training associated with a specific training plan.
         * 
         * @param idPlan The ID of the training plan for which to retrieve the most recent training.
         * @return A Training object representing the most recent training associated with the specified training plan, or null if no trainings are found for that plan.
         */
        Training? GetLastTrainingInPlan(int idPlan);
    }
}
