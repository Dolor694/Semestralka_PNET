using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class ExerciseInTraining
    {
        private int Sets { get; set; }
        private int Reps { get; set; }
        private int Order { get; set; }
        private int IdExercise { get; set; }
        private int IdTraining { get; set; }

        public Exercise Exercise { get; set; } = null!;
        public Training Training { get; set; } = null!;

    }
}
