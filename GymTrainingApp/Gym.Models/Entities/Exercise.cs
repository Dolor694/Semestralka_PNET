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

        private string name { get; set; } = string.Empty;

        private bool complex { get; set; } = false;

        private int MuscleId { get; set; }

        public ICollection<ExerciseInTraining> ExercisesInTraining { get; set; } = [];

        public Exercise() { }
    }
}
