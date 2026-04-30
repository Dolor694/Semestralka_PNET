using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entities
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
