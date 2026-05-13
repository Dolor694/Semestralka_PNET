using System.ComponentModel.DataAnnotations.Schema;
using Gym.Models.MuscleGroupEntity;
using Gym.Models.MuscleEntity;

namespace Gym.Models.MuscleGroupMuscleEntity
{
    public class MuscleGroupMuscle
    {
        [ForeignKey(nameof(MuscleGroup))]
        public int IdMuscleGroup { get; set; }

        [ForeignKey(nameof(Muscle))]
        public int IdMuscle { get; set; }

        // Navigation
        public MuscleGroup MuscleGroup { get; set; } = null!;
        public Muscle Muscle { get; set; } = null!;
    }
}