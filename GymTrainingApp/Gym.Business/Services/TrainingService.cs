using Gym.Business.TrainingGenerator;
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
        protected readonly ITrainingGenerator _trainingGenerator;
        protected readonly INextTrainingTypeSequenceResolver _nextTrainingTypeSequenceResolver;

        public TrainingService(ITrainingRepository trainingRepository, ITrainingGenerator trainingGenerator,
                              INextTrainingTypeSequenceResolver nextTrainingTypeSequenceResolver)
        {
            _trainingRepository = trainingRepository;
            _trainingGenerator = trainingGenerator;
            _nextTrainingTypeSequenceResolver = nextTrainingTypeSequenceResolver;
        }

        public Training CreateTraining(int idPlan)
        {
            int idNextTraining = _trainingRepository.GetLastTrainingIdInPlan(idPlan) + 1;

            int aimOfTraining = _trainingRepository.GetTrainingAimOfPlanId(idPlan);

            int trainingType = _trainingRepository.GetTrainingTypeId(idPlan);

            // Generate exercises for the training (persists ExerciseInTraining records)
            _trainingGenerator.GenerateTraining(aimOfTraining, idPlan, trainingType, idNextTraining);

            // Resolve the next training type sequence entry in the cycle
            int idNextTrainingTypeSequence = _nextTrainingTypeSequenceResolver
                .GetNextTrainingTypeSequenceId(idPlan, trainingType);

            DateOnly dateOfCreation = DateOnly.FromDateTime(DateTime.Now);

            Training training = new Training
            {
                Id = idNextTraining,
                Date = dateOfCreation,
                IdTrainingPlan = idPlan,
                IdTrainingTypeSequence = idNextTrainingTypeSequence
            };

            _trainingRepository.Add(training);

            return training;
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