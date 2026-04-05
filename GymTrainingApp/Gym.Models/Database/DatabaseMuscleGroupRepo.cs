using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Database
{
    public class DatabaseMuscleGroupRepo : DatabaseRepository<MuscleGroup>, IMuscleGroupRepository
    {
        public DatabaseMuscleGroupRepo(GymDbContext context) : base(context)
        {
        }
    }
}
