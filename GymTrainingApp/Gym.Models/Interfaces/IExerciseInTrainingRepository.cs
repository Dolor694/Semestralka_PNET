using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Interfaces
{
    public interface IExerciseInTrainingRepository : IRepository<ExerciseInTraining>
    {
        /*
         * This method retrieves all exercises in a specific training, ordered by their position.
         * 
         * @param idTraining The ID of the training.
         * @return A list of ExerciseInTraining objects for the specified training.
         */
        List<ExerciseInTraining> GetByTrainingId(int idTraining);
    }
}
