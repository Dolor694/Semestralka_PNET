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
    public class TrainingService : ITrainingService
    {
        protected readonly ITrainingRepository _trainingRepository;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public Training CreateTraining(int id, DateOnly date, int idTrainingPlan, int idTrainingTypeSequence)
        {
            Training newTraining = new Training
            {
                Id = id,
                Date = date,
                IdTrainingPlan = idTrainingPlan,
                IdTrainingTypeSequence = idTrainingTypeSequence
            };

            _trainingRepository.Add(newTraining);

            return newTraining;
        }

        public TrainingDTO? GetTrainingById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            Training? training = _trainingRepository.GetById(id);

            if (training == null)
            {
                return null;
            }

            return MapToTrainingDTO(training);
        }

        public TrainingDTO UpdateTraining(int id, DateOnly? date, int? idTrainingTypeSequence)
        {
            Training? training = _trainingRepository.GetById(id);

            if (training == null)
            {
                throw new Exception($"Training with id '{id}' not found.");
            }

            if (date.HasValue)
            {
                training.Date = date.Value;
            }

            if (idTrainingTypeSequence.HasValue)
            {
                training.IdTrainingTypeSequence = idTrainingTypeSequence.Value;
            }

            _trainingRepository.Update(training);

            return MapToTrainingDTO(training);
        }

        public bool DeleteTraining(int id)
        {
            Training? training = _trainingRepository.GetById(id);

            if (training == null)
            {
                return false;
            }

            _trainingRepository.Delete(training);
            return true;
        }

        public IEnumerable<TrainingDTO> GetTrainingsByPlan(int idPlan)
        {
            if (idPlan <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(idPlan));
            }

            IEnumerable<Training> trainings = _trainingRepository.GetTrainingsByPlan(idPlan);
            return trainings.Select(MapToTrainingDTO);
        }

        public Training? GetLastTrainingInPlan(int idPlan)
        {
            if (idPlan <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(idPlan));
            }
            
            IEnumerable<Training> trainings = _trainingRepository.GetTrainingsByPlan(idPlan);

            return trainings.OrderByDescending(t => t.Date).FirstOrDefault();
        }

        /*
         * This method maps a Training entity to a TrainingDTO object.
         * 
         * @param training The Training entity to be mapped.
         * @return A TrainingDTO object containing the mapped information from the Training entity.
         */
        private TrainingDTO MapToTrainingDTO(Training training)
        {
            return new TrainingDTO(
                training.Id,
                training.Date,
                training.IdTrainingPlan,
                training.IdTrainingTypeSequence);
        }
    }
}