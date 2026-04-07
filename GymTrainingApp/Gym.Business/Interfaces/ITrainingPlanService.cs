using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    internal interface ITrainingPlanService
    {
        /*
         * This method creates a new training plan.
         * 
         * @param id The unique identifier for the training plan.
         * @param planName The name of the training plan.
         * @param trainingFrequency The frequency of training per week.
         * @param idUser The identifier of the user who owns the plan.
         * @param idTrainingType The identifier of the training type.
         * @param idAimOfTraining The identifier of the aim of the training.
         * @return The created training plan object.
         */
        TrainingPlan CreateTrainingPlan(int id, string planName, int trainingFrequency, int idUser, int idTrainingType, int idAimOfTraining);

        /*
         * This method retrieves a training plan by its unique identifier.
         * 
         * @param id The unique identifier of the training plan to be retrieved.
         * @return A TrainingPlanDTO object containing the training plan's information if found, or null if the training plan does not exist.
         */
        TrainingPlanDTO? GetTrainingPlanById(int id);

        /*
         * This method updates the information of an existing training plan.
         * 
         * @param id The unique identifier of the training plan to be updated.
         * @param planName The new name for the training plan (optional).
         * @param trainingFrequency The new training frequency (optional).
         * @param idTrainingType The new training type identifier (optional).
         * @param idAimOfTraining The new aim of training identifier (optional).
         * @return A TrainingPlanDTO object containing the updated training plan's information.
         */
        TrainingPlanDTO UpdateTrainingPlan(int id, string? planName, int? trainingFrequency, int? idTrainingType, int? idAimOfTraining);

        /*
         * This method deletes a training plan by its unique identifier.
         * 
         * @param id The unique identifier of the training plan to be deleted.
         * @return A boolean value indicating whether the training plan was successfully deleted (true) or not found (false).
         */
        bool DeleteTrainingPlan(int id);
    }
}
