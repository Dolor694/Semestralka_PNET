using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class TrainingTypeSequence
    {
        [Key]
        public int Id { get; set; }

        public int OrderInCycle { get; set; }

        [ForeignKey(nameof(TrainingType))]
        public int IdTrainingType { get; set; }

        [ForeignKey(nameof(MuscleGroup))]
        public int IdMuscleGroup { get; set; }

        // Navigation
        public TrainingType TrainingType { get; set; } = null!;
        public MuscleGroup MuscleGroup { get; set; } = null!;
        public ICollection<Training> Trainings { get; set; } = [];
    }
}
