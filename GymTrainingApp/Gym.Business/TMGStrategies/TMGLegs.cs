using Gym.Business.Strategies;
using Gym.Business.TMGStrategies;
using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TMGStrategies
{
    internal class TMGLegs : ITrainingMuscleGroupStrategy
    {
        public IReadOnlyList<Exercise> GenerateTrainingForPlan()
        {
            throw new NotImplementedException();
        }
    }
}
