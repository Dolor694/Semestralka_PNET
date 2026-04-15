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

        public AimOfPlan CreateAimOfPlan(string description)
        {
            AimOfPlan newAimOfPlan = new AimOfPlan
            {
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

        public List<AimOfPlanDTO> GetAllAimsOfPlan()
        {
            return _aimOfPlanRepository.GetAll()
                .Select(MapToAimOfPlanDTO)
                .ToList();
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

        private AimOfPlanDTO MapToAimOfPlanDTO(AimOfPlan aimOfPlan)
        {
            return new AimOfPlanDTO(aimOfPlan.Id, aimOfPlan.Description);
        }
    }
}
