using System.ComponentModel.DataAnnotations;
using Gym.Models.TrainingTypeSequenceEntity;
using Gym.Models.MuscleGroupMuscleEntity;

namespace Gym.Models.MuscleGroupEntity
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
