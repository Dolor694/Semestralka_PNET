using System.ComponentModel.DataAnnotations;

namespace Gym.Models.Entities
{
    public class AimOfPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        // Navigation
        public ICollection<TrainingPlan> TrainingPlans { get; set; } = [];
    }
}
