using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entities
{
    public class MuscleGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation
        public ICollection<MuscleGroupMuscle> MuscleGroupMuscles { get; set; } = [];
        public ICollection<TrainingTypeSequence> TrainingTypeSequences { get; set; } = [];
    }
}
