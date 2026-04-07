using Gym.Business.Interfaces;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Services
{
    public class AimOfPlanService : IAimOfPlanService
    {
        protected readonly IAimOfPlanRepository _aimOfPlanRepository;

        public AimOfPlanService(IAimOfPlanRepository aimOfPlanRepository)
        {
            _aimOfPlanRepository = aimOfPlanRepository;
        }

        public AimOfPlan CreateAimOfPlan(int id, string description)
        {
            AimOfPlan newAimOfPlan = new AimOfPlan
            {
                Id = id,
                Description = description
            };

            _aimOfPlanRepository.Add(newAimOfPlan);

            return newAimOfPlan;
        }

        public AimOfPlanDTO? GetAimOfPlanById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            AimOfPlan? aimOfPlan = _aimOfPlanRepository.GetById(id);

            if (aimOfPlan == null)
            {
                return null;
            }

            return MapToAimOfPlanDTO(aimOfPlan);
        }

        public AimOfPlanDTO UpdateAimOfPlan(int id, string? description)
        {
            AimOfPlan? aimOfPlan = _aimOfPlanRepository.GetById(id);

            if (aimOfPlan == null)
            {
                throw new Exception($"AimOfPlan with id '{id}' not found.");
            }

            if (!string.IsNullOrEmpty(description))
            {
                aimOfPlan.Description = description;
            }

            _aimOfPlanRepository.Update(aimOfPlan);

            return MapToAimOfPlanDTO(aimOfPlan);
        }

        public bool DeleteAimOfPlan(int id)
        {
            AimOfPlan? aimOfPlan = _aimOfPlanRepository.GetById(id);

            if (aimOfPlan == null)
            {
                return false;
            }

            _aimOfPlanRepository.Delete(aimOfPlan);
            return true;
        }

        /*
         * This method maps an AimOfPlan entity to an AimOfPlanDTO object.
         * 
         * @param aimOfPlan The AimOfPlan entity to be mapped.
         * @return An AimOfPlanDTO object containing the mapped information from the AimOfPlan entity.
         */
        private AimOfPlanDTO MapToAimOfPlanDTO(AimOfPlan aimOfPlan)
        {
            return new AimOfPlanDTO(aimOfPlan.Id, aimOfPlan.Description);
        }
    }
}
