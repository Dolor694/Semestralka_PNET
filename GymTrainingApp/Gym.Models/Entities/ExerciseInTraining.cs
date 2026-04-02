using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class ExerciseInTraining
    {
        private int PlanExerciseId { get; set; }

        private int ExerciseId { get; set; }

        public int sets { get; set; }

        public int reps { get; set; }

        public int order { get; set; }

    }
}
