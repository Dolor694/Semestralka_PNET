using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    public interface IMuscleGroupService
    {
        /*
         * This method creates a new muscle group.
         * 
         * @param id The unique identifier for the muscle group.
         * @param name The name of the muscle group.
         * @return The created muscle group object.
         */
        MuscleGroup CreateMuscleGroup(int id, string name);

        /*
         * This method retrieves a muscle group by its unique identifier.
         * 
         * @param id The unique identifier of the muscle group to be retrieved.
         * @return A MuscleGroupDTO object containing the muscle group's information if found, or null if the muscle group does not exist.
         */
        MuscleGroupDTO? GetMuscleGroupById(int id);

        /*
         * This method updates the information of an existing muscle group.
         * 
         * @param id The unique identifier of the muscle group to be updated.
         * @param name The new name for the muscle group (optional).
         * @return A MuscleGroupDTO object containing the updated muscle group's information.
         */
        MuscleGroupDTO UpdateMuscleGroup(int id, string? name);

        /*
         * This method deletes a muscle group by its unique identifier.
         * 
         * @param id The unique identifier of the muscle group to be deleted.
         * @return A boolean value indicating whether the muscle group was successfully deleted (true) or not found (false).
         */
        bool DeleteMuscleGroup(int id);
    }
}