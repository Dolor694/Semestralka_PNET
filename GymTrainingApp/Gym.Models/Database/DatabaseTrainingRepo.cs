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
    public class DatabaseTrainingRepo : DatabaseRepository<Training>, ITrainingRepository
    {
        public DatabaseTrainingRepo(GymDbContext context) : base(context)
        {
        }

        public IEnumerable<Training> GetTrainingsByPlan(int idPlan)
        {
            return _context.Trainings.Where(t => t.IdTrainingPlan == idPlan).OrderBy(t => t.Date).ToList();
        }

        public Training? GetLastTrainingByPlan(int idPlan)
        {
            return _context.Trainings.Where(t => t.IdTrainingPlan == idPlan).
                OrderByDescending(t => t.Date).
                FirstOrDefault();
        }
    }
}
