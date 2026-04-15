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
         * @param name The name of the muscle.
         * @param idMuscleGroup The identifier of the muscle group.
         * @return The created muscle object.
         */
        Muscle CreateMuscle(string name, int idMuscleGroup);

        MuscleDTO? GetMuscleById(int id);
        MuscleDTO UpdateMuscle(int id, string? name, int? idMuscleGroup);
        bool DeleteMuscle(int id);
    }
}