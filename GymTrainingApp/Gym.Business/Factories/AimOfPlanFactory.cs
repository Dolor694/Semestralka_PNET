using Gym.Business.AOPStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Factories
{
    public class AimOfPlanFactory
    {
        public IAimOfPlanStrategy Create(int idAimOfPlan)
        {
            switch (idAimOfPlan)
            {
                case 1:
                    return new AOPBuildMuscle();
                case 2:
                    return new AOPBuildStrength();
                case 3:
                    return new AOPLoseWeight();
                default:
                    throw new ArgumentException($"Invalid idAimOfPlan: {idAimOfPlan}");
            }
        }
    }
}
