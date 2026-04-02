using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class Training
    {
        private int Id { get; set; }

        private int TrainingPlanId { get; set; }

        private DateOnly date { get; set; }

        public TrainingPlan TrainingPlan { get; set; }
        public ICollection<ExerciseInTraining> ExercisesInTraining { get; set; } = [];

    }
}
