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

        public AimOfPlan CreateAimOfPlan(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            AimOfPlan aim = new AimOfPlan{Id = id, Description = name};

            _aimOfPlanRepository.Add(aim);

            return aim;
        }

        public bool DeleteAimOfPlan(int id)
        {
            AimOfPlan? aim = _aimOfPlanRepository.GetById(id);

            if (aim == null)
            {
                return false;
            }

            _aimOfPlanRepository.Delete(aim);

            return true;
        }

        public AimOfPlanDTO? GetAimOfPlanById(int id)
        {
            AimOfPlan? aim = _aimOfPlanRepository.GetById(id);

            if (aim == null)
            {
                return null;
            }

            return MapAimOfPlanToDTO(aim);
        }

        public AimOfPlanDTO MapAimOfPlanToDTO(AimOfPlan aimOfPlan)
        {
            return new AimOfPlanDTO(aimOfPlan.Id, aimOfPlan.Description);
        }

        public AimOfPlan UpdateAimOfPlan(int id, string? name)
        {
            AimOfPlan aim = new AimOfPlan { Id = id, Description = name ?? string.Empty };

            _aimOfPlanRepository.Update(aim);

            return aim;
        }
    }
}
