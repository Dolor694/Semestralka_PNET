using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    public interface IExerciseService
    {
        /*
         * This method creates a new exercise.
         * 
         * @param name The name of the exercise.
         * @param complex Whether the exercise is a compound exercise.
         * @param idMuscle The identifier of the muscle targeted by the exercise.
         * @return The created exercise object.
         */
        Exercise CreateExercise(string name, bool complex, int idMuscle);

        /*
         * This method retrieves an exercise by its unique identifier.
         * 
         * @param id The unique identifier of the exercise to be retrieved.
         * @return An ExerciseDTO object containing the exercise's information if found, or null if the exercise does not exist.
         */
        ExerciseDTO? GetExerciseById(int id);

        /*
         * This method retrieves all exercises that target a specific muscle group.
         * 
         * @param idMuscleGroup The ID of the muscle group.
         * @return A list of ExerciseDTO objects for the specified muscle group.
         */
        List<ExerciseDTO> GetExercisesByMuscleGroup(int idMuscleGroup);

        /*
         * This method updates the information of an existing exercise.
         * 
         * @param id The unique identifier of the exercise to be updated.
         * @param name The new name for the exercise (optional).
         * @param complex The new complex flag for the exercise (optional).
         * @param idMuscle The new muscle identifier for the exercise (optional).
         * @return An ExerciseDTO object containing the updated exercise's information.
         */
        ExerciseDTO UpdateExercise(int id, string? name, bool? complex, int? idMuscle);

        /*
         * This method deletes an exercise by its unique identifier.
         * 
         * @param id The unique identifier of the exercise to be deleted.
         * @return A boolean value indicating whether the exercise was successfully deleted (true) or not found (false).
         */
        bool DeleteExercise(int id);
    }
}