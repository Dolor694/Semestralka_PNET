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
    public interface IAimOfPlanService
    {
        /*
         * This method creates a new aim of plan.
         * 
         * @param description The description of the aim.
         * @return The created aim of plan object.
         */
        AimOfPlan CreateAimOfPlan(string description);

        AimOfPlanDTO? GetAimOfPlanById(int id);
        List<AimOfPlanDTO> GetAllAimsOfPlan();
        AimOfPlanDTO UpdateAimOfPlan(int id, string? description);
        bool DeleteAimOfPlan(int id);
    }
}
