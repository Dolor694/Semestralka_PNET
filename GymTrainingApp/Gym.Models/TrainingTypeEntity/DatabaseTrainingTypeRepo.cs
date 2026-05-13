using Gym.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.TrainingTypeEntity
{
    public class DatabaseTrainingTypeRepo : DatabaseRepository<TrainingType>, ITrainingTypeRepository
    {
        public DatabaseTrainingTypeRepo(GymDbContext context) : base(context)
        {
        }
    }
}
