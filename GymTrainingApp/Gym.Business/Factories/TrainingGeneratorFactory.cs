using Gym.Business.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Factories
{
    public class TrainingGeneratorFactory()
    {
        public ITrainingTypeStrategy Create(int idTrainingPlan);
    }
}
