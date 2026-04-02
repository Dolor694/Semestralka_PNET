using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class TrainingType
    {
        public int IdTrainingType { get; set; }
        public string TypeName { get; set; } = string.Empty;

        // Navigation
        public ICollection<TrainingPlan> TrainingPlans { get; set; } = [];
        public ICollection<TrainingTypeSequence> TrainingTypeSequences { get; set; } = [];

    }
}
