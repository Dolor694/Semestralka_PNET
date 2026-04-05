using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models.Entities
{
    public class Muscle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(MuscleGroup))]
        public int IdMuscleGroup { get; set; }

        // Navigation
        public MuscleGroup MuscleGroup { get; set; } = null!;
        public ICollection<Exercise> Exercises { get; set; } = [];
    }
}
