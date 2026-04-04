using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class AimOfPlan
    {
        private int Id { get; set; }
        private string Description { get; set; } = String.Empty; 


        public ICollection<TrainingPlan> TrainingPlans { get; set; } = [];
    }
}
