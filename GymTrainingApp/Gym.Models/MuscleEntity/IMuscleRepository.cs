using Gym.Models._Repo;
using Gym.Models.MuscleGroupEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.MuscleEntity
{
    public interface IMuscleRepository : IRepository<Muscle>
    {
        public IEnumerable<Muscle> GetMusclesByGroup(int idMuscleGroup);
    }
}
