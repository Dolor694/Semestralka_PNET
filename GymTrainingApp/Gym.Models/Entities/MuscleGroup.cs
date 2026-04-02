using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class MuscleGroup
    {
        private int Id { get; set; }
        private string name { get; set; } = string.Empty;


        public ICollection<Muscle> Muscles { get; set; } = [];
        public ICollection<TrainingType> TrainingTypes { get; set; } = [];

    }
}
