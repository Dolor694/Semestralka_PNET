using Gym.Models.Data;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Database
{
    public class DatabaseTrainingTypeSequenceRepo : DatabaseRepository<TrainingTypeSequence>, ITrainingTypeSequenceRepository
    {
        public DatabaseTrainingTypeSequenceRepo(GymDbContext context) : base(context)
        {
        }

        public IEnumerable<TrainingTypeSequence> GetSequencesByTrainingType(int idTrainingType)
        {
            return _context.TrainingTypeSequences
                .Where(s => s.IdTrainingType == idTrainingType)
                .OrderBy(s => s.OrderInCycle)
                .ToList();
        }
    }
}
