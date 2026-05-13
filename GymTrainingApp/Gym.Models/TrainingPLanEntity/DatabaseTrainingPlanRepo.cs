using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.TrainingPlanEntity
{
    public class DatabaseTrainingPlanRepo : DatabaseRepository<TrainingPlan>, ITrainingPlanRepository
    {
        public DatabaseTrainingPlanRepo(GymDbContext context) : base(context)
        {
        }

        public List<TrainingPlan> GetPlansByUserId(int idUser)
        {
            return _context.TrainingPlans
                .Where(tp => tp.IdUser == idUser)
                .ToList();
        }
    }
}
