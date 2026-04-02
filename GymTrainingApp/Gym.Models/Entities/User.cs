using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string Password { get; set; } = string.Empty; 

        // Navigation
        public ICollection<TrainingPlan> TrainingPlans { get; set; } = [];
    }
}
