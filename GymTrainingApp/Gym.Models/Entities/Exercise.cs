using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class Exercise
    {

        private int Id { get; set; }
        private string Name { get; set; } = string.Empty;
        private bool Complex { get; set; } = false;
        private int IdMuscle { get; set; }

        public Muscle Muscle { get; set; } = null!;
        public ICollection<ExerciseInTraining> ExercisesInTraining { get; set; } = [];
    }
}
