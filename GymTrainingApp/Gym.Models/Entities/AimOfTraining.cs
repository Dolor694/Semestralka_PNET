using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class AimOfTraining
    {
        private int Id { get; set; }
        private string description { get; set; }


        public ICollection<TrainingPlan> TrainingPlans { get; set; } = [];

        public AimOfTraining(string description)
        {
            this.description = description;
        }
    }
}
