using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class Training
    {
        [Key]
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        [ForeignKey(nameof(TrainingPlan))]
        public int IdTrainingPlan { get; set; }

        [ForeignKey(nameof(TrainingTypeSequence))]
        public int IdTrainingTypeSequence { get; set; }

        // Navigation
        public TrainingPlan TrainingPlan { get; set; } = null!;
        public TrainingTypeSequence TrainingTypeSequence { get; set; } = null!;
        public ICollection<ExerciseInTraining> ExercisesInTraining { get; set; } = [];
    }
}
