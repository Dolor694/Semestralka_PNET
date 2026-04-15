using Gym.Business.Interfaces;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Services
{
    public class TrainingTypeSequenceService : ITrainingTypeSequenceService
    {
        protected readonly ITrainingTypeSequenceRepository _trainingTypeSequenceRepository;

        public TrainingTypeSequenceService(ITrainingTypeSequenceRepository trainingTypeSequenceRepository)
        {
            _trainingTypeSequenceRepository = trainingTypeSequenceRepository;
        }

        public TrainingTypeSequence CreateTrainingTypeSequence(int orderInCycle, int idTrainingType, int idMuscleGroup)
        {
            TrainingTypeSequence newTrainingTypeSequence = new TrainingTypeSequence
            {
                OrderInCycle = orderInCycle,
                IdTrainingType = idTrainingType,
                IdMuscleGroup = idMuscleGroup
            };

            _trainingTypeSequenceRepository.Add(newTrainingTypeSequence);

            return newTrainingTypeSequence;
        }

        public TrainingTypeSequence? GetTrainingTypeSequenceById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            return _trainingTypeSequenceRepository.GetById(id);
        }

        public TrainingTypeSequence UpdateTrainingTypeSequence(int id, int? orderInCycle, int? idTrainingType, int? idMuscleGroup)
        {
            TrainingTypeSequence? sequence = _trainingTypeSequenceRepository.GetById(id);

            if (sequence == null)
            {
                throw new Exception($"TrainingTypeSequence with id '{id}' not found.");
            }

            if (orderInCycle.HasValue)
            {
                sequence.OrderInCycle = orderInCycle.Value;
            }

            if (idTrainingType.HasValue)
            {
                sequence.IdTrainingType = idTrainingType.Value;
            }

            if (idMuscleGroup.HasValue)
            {
                sequence.IdMuscleGroup = idMuscleGroup.Value;
            }

            _trainingTypeSequenceRepository.Update(sequence);

            return sequence;
        }

        public bool DeleteTrainingTypeSequence(int id)
        {
            TrainingTypeSequence? sequence = _trainingTypeSequenceRepository.GetById(id);

            if (sequence == null)
            {
                return false;
            }

            _trainingTypeSequenceRepository.Delete(sequence);
            return true;
        }
    }
}