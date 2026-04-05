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
        private DateOnly Date { get; set; }
        private int IdTrainingPlan { get; set; }
        private int IdTrainingTypeSequence { get; set; }

        public TrainingPlan TrainingPlan { get; set; } = null!;
        public TrainingTypeSequence TrainingTypeSequence { get; set; } = null!;
        public ICollection<ExerciseInTraining> ExercisesInTraining { get; set; } = [];

    }
}
