using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.AimOfPlanEntity
{
    public class DatabaseAimOfPlanRepo : DatabaseRepository<AimOfPlan>, IAimOfPlanRepository
    {
        public DatabaseAimOfPlanRepo(GymDbContext context) : base(context)
        {
        }
    }
}
