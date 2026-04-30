using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models.Entities
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