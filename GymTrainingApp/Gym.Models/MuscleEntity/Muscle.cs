using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gym.Models.ExerciseEntity;
using Gym.Models.MuscleGroupMuscleEntity;

namespace Gym.Models.MuscleEntity
{
    public class Muscle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;



        // Navigation
        public ICollection<Exercise> Exercises { get; set; } = [];
        public ICollection<MuscleGroupMuscle> MuscleGroupMuscles { get; set; } = [];
    }
}
