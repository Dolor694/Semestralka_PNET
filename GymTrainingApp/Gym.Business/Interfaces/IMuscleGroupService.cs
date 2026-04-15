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
         * @param name The name of the muscle group.
         * @return The created muscle group object.
         */
        MuscleGroup CreateMuscleGroup(string name);

        MuscleGroupDTO? GetMuscleGroupById(int id);
        List<MuscleGroupDTO> GetAllMuscleGroups();
        MuscleGroupDTO UpdateMuscleGroup(int id, string? name);
        bool DeleteMuscleGroup(int id);
    }
}