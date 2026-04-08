using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Interfaces
{
    public interface IMuscleRepository : IRepository<Muscle>
    {
        public IEnumerable<Muscle> GetMusclesByGroup(int idMuscleGroup);
    }
}
