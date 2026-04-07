using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Interfaces
{
    /*
     * This interface defines the contract for the AimOfPlan service, 
     * which is responsible for managing AimOfPlan entities in the application.
     */
    internal interface IAimOfPlanService
    {
        /*
         * This method creates a new aim of plan.
         * 
         * @param id The unique identifier for the aim of plan.
         * @param description The description of the aim.
         * @return The created aim of plan object.
         */
        AimOfPlan CreateAimOfPlan(int id, string description);

        /*
         * This method retrieves an aim of plan by its unique identifier.
         * 
         * @param id The unique identifier of the aim of plan to be retrieved.
         * @return An AimOfPlanDTO object containing the aim's information if found, or null if the aim does not exist.
         */
        AimOfPlanDTO? GetAimOfPlanById(int id);

        /*
         * This method updates the information of an existing aim of plan.
         * 
         * @param id The unique identifier of the aim of plan to be updated.
         * @param description The new description for the aim (optional).
         * @return An AimOfPlanDTO object containing the updated aim's information.
         */
        AimOfPlanDTO UpdateAimOfPlan(int id, string? description);

        /*
         * This method deletes an aim of plan by its unique identifier.
         * 
         * @param id The unique identifier of the aim of plan to be deleted.
         * @return A boolean value indicating whether the aim of plan was successfully deleted (true) or not found (false).
         */
        bool DeleteAimOfPlan(int id);
    }
}
