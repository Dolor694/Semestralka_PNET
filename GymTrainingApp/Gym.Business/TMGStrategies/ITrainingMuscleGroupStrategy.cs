using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Strategies
{
    public interface ITrainingMuscleGroupStrategy
    {
        public IReadOnlyList<Exercise> GenerateTrainingForPlan();
    }
}
