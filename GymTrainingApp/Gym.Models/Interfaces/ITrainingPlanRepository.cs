using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Interfaces
{
    public interface ITrainingPlanRepository : IRepository<TrainingPlan>
    {
        /*
         * This method retrieves all training plans associated with a specific user, identified by their ID.
         * 
         * @param idUser The ID of the user for which to retrieve the training plans.
         * @return A list of TrainingPlan objects that are associated with the specified user.
         */
        List<TrainingPlan> GetPlansByUserId(int idUser);
    }
}
