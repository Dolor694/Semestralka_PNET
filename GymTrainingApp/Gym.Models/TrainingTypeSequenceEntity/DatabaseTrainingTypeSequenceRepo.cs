using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.TrainingTypeSequenceEntity
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
