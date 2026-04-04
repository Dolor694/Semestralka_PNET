using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class ExerciseInTraining
    {
        public int Sets { get; set; }

        public int Reps { get; set; }

        public int Order { get; set; }


        public Exercise Exercise { get; set; } = null!;
        public Training Training { get; set; } = null!;

    }
}
