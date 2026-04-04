using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Strategies
{
    internal interface IAimOfPlanStrategy
    {
        public IReadOnlyList<ExerciseDTO> GenerateTrainingForPlan();
    }
}
