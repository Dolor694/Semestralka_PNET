using Gym.Models.Entities;
using System.Collections.Generic;

namespace Gym.Business.Interfaces
{
    public interface IMuscleService
    {
        /*
         * This method creates a new muscle.
         * 
         * @param name The name of the muscle.
         * @param idMuscleGroups The identifiers of the muscle groups.
         * @return The created muscle object.
         */
        Muscle CreateMuscle(string name, IEnumerable<int> idMuscleGroups);

        MuscleDTO? GetMuscleById(int id);
        MuscleDTO UpdateMuscle(int id, string? name, IEnumerable<int>? idMuscleGroups);
        bool DeleteMuscle(int id);
    }
}