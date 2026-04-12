using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    public interface IExerciseInTrainingService
    {
        /*
         * This method creates a new exercise in training.
         * 
         * @param id The unique identifier for the exercise in training.
         * @param sets The number of sets.
         * @param reps The number of repetitions.
         * @param order The order of the exercise in the training.
         * @param idExercise The identifier of the exercise.
         * @param idTraining The identifier of the training.
         * @return The created exercise in training object.
         */
        ExerciseInTraining CreateExerciseInTraining(int id, int sets, int reps, int order, int idExercise, int idTraining);

        /*
         * This method retrieves an exercise in training by its unique identifier.
         * 
         * @param id The unique identifier of the exercise in training to be retrieved.
         * @return An ExerciseInTrainingDTO object containing the information if found, or null if it does not exist.
         */
        ExerciseInTrainingDTO? GetExerciseInTrainingById(int id);

        /*
         * This method updates the information of an existing exercise in training.
         * 
         * @param id The unique identifier of the exercise in training to be updated.
         * @param sets The new number of sets (optional).
         * @param reps The new number of repetitions (optional).
         * @param order The new order (optional).
         * @return An ExerciseInTrainingDTO object containing the updated information.
         */
        ExerciseInTrainingDTO UpdateExerciseInTraining(int id, int? sets, int? reps, int? order);

        /*
         * This method deletes an exercise in training by its unique identifier.
         * 
         * @param id The unique identifier of the exercise in training to be deleted.
         * @return A boolean value indicating whether the exercise in training was successfully deleted (true) or not found (false).
         */
        bool DeleteExerciseInTraining(int id);

        /*
         * This method adds an exercise to a reportory of exercises in training.
         * 
         * @param exerciseInTraining The exercise in training object to be added.
         * @return The added exercise in training object.
         */
        ExerciseInTraining AddExerciseInTraining(ExerciseInTraining exerciseInTraining);
    }
}