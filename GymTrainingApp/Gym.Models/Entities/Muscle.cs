using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class Muscle
    {
        private int Id { get; set; }
        private string Name { get; set; } = string.Empty;
        private int IdMuscleGroup { get; set; }

        public MuscleGroup MuscleGroup { get; set; } = null!;
        public ICollection<Exercise> Exercises { get; set; } = [];
    }
}
