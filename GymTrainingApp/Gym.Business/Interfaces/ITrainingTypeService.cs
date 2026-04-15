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
         * @param name The name of the training type.
         * @return The created training type object.
         */
        TrainingType CreateTrainingType(string name);

        TrainingTypeDTO? GetTrainingTypeById(int id);
        List<TrainingTypeDTO> GetAllTrainingTypes();
        TrainingTypeDTO UpdateTrainingType(int id, string? name);
        bool DeleteTrainingType(int id);
    }
}
