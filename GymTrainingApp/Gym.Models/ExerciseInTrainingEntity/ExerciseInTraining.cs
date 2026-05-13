using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gym.Models.ExerciseEntity;
using Gym.Models.TrainingEntity;

namespace Gym.Models.ExerciseInTrainingEntity
{
    public class ExerciseInTraining
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 10)]
        public int Sets { get; set; }

        [Range(1, 30)]
        public int Reps { get; set; }

        public int Order { get; set; }



        [ForeignKey(nameof(Exercise))]
        public int IdExercise { get; set; }

        [ForeignKey(nameof(Training))]
        public int IdTraining { get; set; }

        // Navigation
        public Exercise Exercise { get; set; } = null!;
        public Training Training { get; set; } = null!;
    }
}
