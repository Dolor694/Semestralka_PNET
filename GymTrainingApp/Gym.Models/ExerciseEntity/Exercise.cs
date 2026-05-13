using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gym.Models.MuscleEntity;
using Gym.Models.ExerciseInTrainingEntity;

namespace Gym.Models.ExerciseEntity
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public bool Complex { get; set; } = false;



        [ForeignKey(nameof(Muscle))]
        public int IdMuscle { get; set; }

        // Navigation
        public Muscle Muscle { get; set; } = null!;
        public ICollection<ExerciseInTraining> ExercisesInTraining { get; set; } = [];
    }
}
