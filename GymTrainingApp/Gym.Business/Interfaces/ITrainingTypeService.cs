using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    public interface ITrainingTypeService
    {
        /*
         * This method creates a new training type.
         * 
         * @param id The unique identifier for the training type.
         * @param name The name of the training type.
         * @return The created training type object.
         */
        TrainingType CreateTrainingType(int id, string name);

        /*
         * This method retrieves a training type by its unique identifier.
         * 
         * @param id The unique identifier of the training type to be retrieved.
         * @return A TrainingTypeDTO object containing the training type's information if found, or null if the training type does not exist.
         */
        TrainingTypeDTO? GetTrainingTypeById(int id);

        /*
         * This method updates the information of an existing training type.
         * 
         * @param id The unique identifier of the training type to be updated.
         * @param name The new name for the training type (optional).
         * @return A TrainingTypeDTO object containing the updated training type's information.
         */
        TrainingTypeDTO UpdateTrainingType(int id, string? name);

        /*
         * This method deletes a training type by its unique identifier.
         * 
         * @param id The unique identifier of the training type to be deleted.
         * @return A boolean value indicating whether the training type was successfully deleted (true) or not found (false).
         */
        bool DeleteTrainingType(int id);
    }
}
