using System.ComponentModel.DataAnnotations;
using Gym.Models.TrainingPlanEntity;
using Gym.Models.TrainingTypeSequenceEntity;

namespace Gym.Models.TrainingTypeEntity
{
    public class TrainingType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;



        // Navigation
        public ICollection<TrainingPlan> TrainingPlans { get; set; } = [];
        public ICollection<TrainingTypeSequence> TrainingTypeSequences { get; set; } = [];
    }
}
