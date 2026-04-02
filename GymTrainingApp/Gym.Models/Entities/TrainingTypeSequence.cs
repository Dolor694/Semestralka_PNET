using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class TrainingTypeSequence
    {
        public int IdSequence { get; set; }
        public int TrainingTypeIdTrainingType { get; set; }
        public int MuscleGroupsIdMuscleGroup { get; set; }
        public int OrderInCycle { get; set; }

        // Navigation
        public TrainingType TrainingType { get; set; } = null!;
        public MuscleGroup MuscleGroup { get; set; } = null!;

    }
}
