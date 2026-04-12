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
         * @return A Training object representing the most recent training associated with the specified training plan, or null if no trainings are found.
         */
        public Training? GetLastTrainingByPlan(int idPlan);

        /*
         * This method retrieves the ID of the training aim associated with a specific training plan, identified by its ID.
         * 
         * @param idPlan The ID of the training plan for which to retrieve the training aim ID.
         * @return The ID of the training aim associated with the specified training plan.
         */
        public int GetTrainingAimOfPlanId(int idPlan);

        /*
         * This method gets the ID of the last trining in a training plan.
         * 
         * @param idPlan The ID of the training plan for which to retrieve the last training ID.
         * @return The ID of the last training in the specified training plan, or 0 if no trainings are found.
         */
        public int GetLastTrainingIdInPlan(int idPlan);

        /*
         * This method retrieves the ID of the training type associated with a specific training plan, identified by its ID.
         * 
         * @param idPlan The ID of the training plan for which to retrieve the training type ID.
         * @return The ID of the training type associated with the specified training plan.
         */
        public int GetTrainingTypeId(int idPlan);
    }
}
