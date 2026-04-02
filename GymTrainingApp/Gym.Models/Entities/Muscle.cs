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
        private int MuscleGroupId { get; set; }
        private string name { get; set; } = string.Empty;


        public ICollection<Exercise> Exercises { get; set; } = [];

        public Muscle() { }
    }
}
