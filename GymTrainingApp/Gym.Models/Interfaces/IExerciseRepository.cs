using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Interfaces
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        /*
         * This method retrieves a list of exercises that target a specific muscle group.
         * 
         * @param idMuscleGroup The unique identifier of the muscle group for which exercises are to be retrieved.
         * @return An IEnumerable of Exercise objects that belong to the specified muscle group.
         */
        IEnumerable<Exercise> GetExercisesByMuscleGroup(int idMuscleGroup);
    }
}
