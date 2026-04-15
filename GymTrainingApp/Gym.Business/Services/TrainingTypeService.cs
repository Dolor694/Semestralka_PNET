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

        public TrainingType CreateTrainingType(string name)
        {
            TrainingType newTrainingType = new TrainingType
            {
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

        public List<TrainingTypeDTO> GetAllTrainingTypes()
        {
            return _trainingTypeRepository.GetAll()
                .Select(MapToTrainingTypeDTO)
                .ToList();
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

        private TrainingTypeDTO MapToTrainingTypeDTO(TrainingType trainingType)
        {
            return new TrainingTypeDTO(trainingType.Id, trainingType.Name);
        }
    }
}
