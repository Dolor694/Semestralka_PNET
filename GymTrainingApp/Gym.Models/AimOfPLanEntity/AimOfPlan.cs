using Gym.Models.TrainingPlanEntity;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.AimOfPlanEntity
{
    public class AimOfPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation
        public ICollection<TrainingPlan> TrainingPlans { get; set; } = [];
    }
}
