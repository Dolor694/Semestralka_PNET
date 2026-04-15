using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Interfaces
{
    public interface ITrainingRepository : IRepository<Training>
    {
        /*
         * This method retrieves all the trainings associated with a specific training plan, identified by its ID.
         * 
         * @param idPlan The ID of the training plan for which to retrieve the trainings.
         * @return An enumerable collection of Training objects that are associated with the specified training plan.
         */
        public IEnumerable<Training> GetTrainingsByPlan(int idPlan);

        /*
         * This method retrieves the most recent training associated with a specific training plan, identified by its ID.
         * 
         * @param idPlan The ID of the training plan for which to retrieve the last training.
         * @return A Training object representing the most recent training, or null if no trainings are found.
         */
        public Training? GetLastTrainingByPlan(int idPlan);

        /*
         * This method retrieves the ID of the training aim associated with a specific training plan.
         * 
         * @param idPlan The ID of the training plan.
         * @return The ID of the training aim.
         */
        public int GetTrainingAimOfPlanId(int idPlan);

        /*
         * This method retrieves the ID of the training type associated with a specific training plan.
         * 
         * @param idPlan The ID of the training plan.
         * @return The ID of the training type.
         */
        public int GetTrainingTypeId(int idPlan);
    }
}
