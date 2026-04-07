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
    public class TrainingTypeService : ITrainingTypeService
    {
        protected readonly ITrainingTypeRepository _trainingTypeRepository;

        public TrainingTypeService(ITrainingTypeRepository trainingTypeRepository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }

        public TrainingType CreateTrainingType(int id, string name)
        {
            TrainingType newTrainingType = new TrainingType
            {
                Id = id,
                Name = name
            };

            _trainingTypeRepository.Add(newTrainingType);

            return newTrainingType;
        }

        public TrainingTypeDTO? GetTrainingTypeById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            TrainingType? trainingType = _trainingTypeRepository.GetById(id);

            if (trainingType == null)
            {
                return null;
            }

            return MapToTrainingTypeDTO(trainingType);
        }

        public TrainingTypeDTO UpdateTrainingType(int id, string? name)
        {
            TrainingType? trainingType = _trainingTypeRepository.GetById(id);

            if (trainingType == null)
            {
                throw new Exception($"TrainingType with id '{id}' not found.");
            }

            if (!string.IsNullOrEmpty(name))
            {
                trainingType.Name = name;
            }

            _trainingTypeRepository.Update(trainingType);

            return MapToTrainingTypeDTO(trainingType);
        }

        public bool DeleteTrainingType(int id)
        {
            TrainingType? trainingType = _trainingTypeRepository.GetById(id);

            if (trainingType == null)
            {
                return false;
            }

            _trainingTypeRepository.Delete(trainingType);
            return true;
        }

        /*
         * This method maps a TrainingType entity to a TrainingTypeDTO object.
         * 
         * @param trainingType The TrainingType entity to be mapped.
         * @return A TrainingTypeDTO object containing the mapped information from the TrainingType entity.
         */
        private TrainingTypeDTO MapToTrainingTypeDTO(TrainingType trainingType)
        {
            return new TrainingTypeDTO(trainingType.Id, trainingType.Name);
        }
    }
}
