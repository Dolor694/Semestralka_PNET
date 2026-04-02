using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class TrainingPlan
    {
        public int IdTrainingPlan { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public int UserIdUser { get; set; }
        public int TrainingTypeIdTrainingType { get; set; }
        public int AimOfTrainingIdAimOfTraining { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public int TrainingFrequency { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public TrainingType TrainingType { get; set; } = null!;
        public AimOfTraining AimOfTraining { get; set; } = null!;
        public ICollection<Training> Trainings { get; set; } = [];

    }
}
