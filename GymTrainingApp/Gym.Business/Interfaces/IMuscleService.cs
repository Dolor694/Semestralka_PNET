using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    public interface IMuscleService
    {
        /*
         * This method creates a new muscle.
         * 
         * @param id The unique identifier for the muscle.
         * @param name The name of the muscle.
         * @param idMuscleGroup The identifier of the muscle group this muscle belongs to.
         * @return The created muscle object.
         */
        Muscle CreateMuscle(int id, string name, int idMuscleGroup);

        /*
         * This method retrieves a muscle by its unique identifier.
         * 
         * @param id The unique identifier of the muscle to be retrieved.
         * @return A MuscleDTO object containing the muscle's information if found, or null if the muscle does not exist.
         */
        MuscleDTO? GetMuscleById(int id);

        /*
         * This method updates the information of an existing muscle.
         * 
         * @param id The unique identifier of the muscle to be updated.
         * @param name The new name for the muscle (optional).
         * @param idMuscleGroup The new muscle group identifier (optional).
         * @return A MuscleDTO object containing the updated muscle's information.
         */
        MuscleDTO UpdateMuscle(int id, string? name, int? idMuscleGroup);

        /*
         * This method deletes a muscle by its unique identifier.
         * 
         * @param id The unique identifier of the muscle to be deleted.
         * @return A boolean value indicating whether the muscle was successfully deleted (true) or not found (false).
         */
        bool DeleteMuscle(int id);
    }
}