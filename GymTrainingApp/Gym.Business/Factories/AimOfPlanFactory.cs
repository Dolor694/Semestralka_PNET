using Gym.Business.AOPStrategies;
using Gym.Business.TrainingGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Factories
{
    public class AimOfPlanFactory
    {
        private readonly IExerciseMapper _exerciseMapper;

        public AimOfPlanFactory(IExerciseMapper exerciseMapper)
        {
            _exerciseMapper = exerciseMapper;
        }

        public IAimOfPlanStrategy Create(int idAimOfPlan)
        {
            switch (idAimOfPlan)
            {
                case 1:
                    return new AOPBuildMuscle(_exerciseMapper);
                case 2:
                    return new AOPBuildStrength(_exerciseMapper);
                case 3:
                    return new AOPLoseWeight(_exerciseMapper);
                default:
                    throw new ArgumentException($"Invalid idAimOfPlan: {idAimOfPlan}");
            }
        }
    }
}
