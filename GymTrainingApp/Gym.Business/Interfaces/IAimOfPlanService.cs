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
         * This method retrieves an AimOfPlan by its ID.
         * 
         * @param id The ID of the AimOfPlan to retrieve.
         * @return An AimOfPlanDTO representing the AimOfPlan with the specified ID, or null if not found.
         */
        AimOfPlanDTO? GetAimOfPlanById(int id);

        /*
        * This method creates a new AimOfPlan with the specified ID and name.
        * 
        * @param id The unique identifier for the new AimOfPlan.
        * @param name The name of the new AimOfPlan.
        * @return The created AimOfPlan object.
        */
        AimOfPlan CreateAimOfPlan(int id, string name);
        
        /*
         * This method updates an existing AimOfPlan with the specified ID and new name.
         * 
         * @param id The unique identifier of the AimOfPlan to update.
         * @param name The new name for the AimOfPlan. If null, the name will not be updated.
         * @return The updated AimOfPlan object, or null if the AimOfPlan with the specified ID does not exist.
         */
        AimOfPlan UpdateAimOfPlan(int id, string? name);
        
        /*
         * This method deletes an AimOfPlan with the specified ID.
         * 
         * @param id The unique identifier of the AimOfPlan to delete.
         * @return true if the AimOfPlan was successfully deleted, or false if the AimOfPlan with the specified ID does not exist.
         */
        bool DeleteAimOfPlan(int id);

        /*
         * This method maps an AimOfPlan entity to an AimOfPlanDTO.
         * 
         * @param aimOfPlan The AimOfPlan entity to map.
         * @return An AimOfPlanDTO representing the mapped AimOfPlan.
         */
        AimOfPlanDTO MapAimOfPlanToDTO(AimOfPlan aimOfPlan);
    }
}
