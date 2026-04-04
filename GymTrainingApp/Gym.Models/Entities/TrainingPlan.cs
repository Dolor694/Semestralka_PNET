using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class TrainingPlan
    {
        private int IdTrainingPlan { get; set; }
        private DateOnly DateOfCreation { get; set; }
        private string PlanName { get; set; } = string.Empty;
        private int TrainingFrequency { get; set; }
        private int IdUser { get; set; }
        private int IdTrainingType { get; set; }
        private int IdAimOfTraining { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public TrainingType TrainingType { get; set; } = null!;
        public AimOfPlan AimOfTraining { get; set; } = null!;
        public ICollection<Training> Trainings { get; set; } = [];

    }
}
