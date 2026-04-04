using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class TrainingTypeSequence
    {
        private int Id { get; set; }
        private int OrderInCycle { get; set; }
        private int IdTrainingType { get; set; }
        private int IdMuscleGroup { get; set; }

        // Navigation
        public TrainingType TrainingType { get; set; } = null!;
        public MuscleGroup MuscleGroup { get; set; } = null!;
        public ICollection<Training> Trainings { get; set; } = [];
    }
}
