using Gym.Models.Entities;
using Gym.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public class NextMuscleGroupResolver : INextMuscleGroupResolver
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly ITrainingTypeSequenceRepository _trainingTypeSequenceRepository;

        public NextMuscleGroupResolver(ITrainingRepository trainingRepository,
                                    ITrainingTypeSequenceRepository trainingTypeSequenceRepository)
        {
            _trainingRepository = trainingRepository;
            _trainingTypeSequenceRepository = trainingTypeSequenceRepository;
        }

        public int GetNextMuscleGroupId(int idTrainingPlan, int idTrainingType)
        {
            // Get the ordered sequence of muscle groups for this training type
            var sequence = _trainingTypeSequenceRepository.GetSequencesByTrainingType(idTrainingType)
                .ToList();

            if (sequence.Count == 0)
            {
                throw new Exception($"No training type sequence found for training type '{idTrainingType}'.");
            }

            // Find the last training in this plan
            var lastTraining = _trainingRepository.GetLastTrainingByPlan(idTrainingPlan);

            if (lastTraining == null)
            {
                // No previous training — start at the beginning of the cycle
                return sequence.First().IdMuscleGroup;
            }

            // Find where the last training sits in the sequence
            int lastIndex = sequence.FindIndex(s => s.Id == lastTraining.IdTrainingTypeSequence);

            if (lastIndex == -1)
            {
                // Last training's sequence entry not found -> return the first entry to start the cycle
                return sequence.First().IdMuscleGroup;
            }

            // Move to the next entry, wrapping around if at the end
            int nextIndex = (lastIndex + 1) % sequence.Count;

            return sequence[nextIndex].IdMuscleGroup;
        }
    }
}