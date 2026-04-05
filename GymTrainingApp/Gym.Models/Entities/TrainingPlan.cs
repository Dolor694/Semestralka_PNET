using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class TrainingPlan
    {
        [Key]
        public int Id { get; set; }

        public DateOnly DateOfCreation { get; set; }

        [Required]
        [MaxLength(100)]
        public string PlanName { get; set; } = string.Empty;

        [Range(1, 7)]
        public int TrainingFrequency { get; set; }

        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }

        [ForeignKey(nameof(TrainingType))]
        public int IdTrainingType { get; set; }

        [ForeignKey(nameof(AimOfTraining))]
        public int IdAimOfTraining { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public TrainingType TrainingType { get; set; } = null!;
        public AimOfPlan AimOfTraining { get; set; } = null!;
        public ICollection<Training> Trainings { get; set; } = [];
    }
}
