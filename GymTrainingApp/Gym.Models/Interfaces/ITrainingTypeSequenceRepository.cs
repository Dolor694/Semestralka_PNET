using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Interfaces
{
    public interface ITrainingTypeSequenceRepository : IRepository<TrainingTypeSequence>
    {
        /*
         * This method retrieves all training type sequences for a given training type, ordered by their cycle position.
         * 
         * @param idTrainingType The ID of the training type.
         * @return An ordered list of TrainingTypeSequence objects for the specified training type.
         */
        IEnumerable<TrainingTypeSequence> GetSequencesByTrainingType(int idTrainingType);
    }
}
