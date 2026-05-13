using Gym.Models.TrainingPlanEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.Services.TrainingPlanService
{
    public class TrainingPlanService : ITrainingPlanService
    {
        protected readonly ITrainingPlanRepository _trainingPlanRepository;

        public TrainingPlanService(ITrainingPlanRepository trainingPlanRepository)
        {
            _trainingPlanRepository = trainingPlanRepository;
        }

        public TrainingPlan CreateTrainingPlan(string planName, int trainingFrequency, int idUser, int idTrainingType, int idAimOfTraining)
        {
            TrainingPlan newTrainingPlan = new TrainingPlan
            {
                DateOfCreation = DateOnly.FromDateTime(DateTime.Now),
                Name = planName,
                TrainingFrequency = trainingFrequency,
                IdUser = idUser,
                IdTrainingType = idTrainingType,
                IdAimOfTraining = idAimOfTraining
            };

            _trainingPlanRepository.Add(newTrainingPlan);

            return newTrainingPlan;
        }

        public TrainingPlanDTO? GetTrainingPlanById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            TrainingPlan? trainingPlan = _trainingPlanRepository.GetById(id);

            if (trainingPlan == null)
            {
                return null;
            }

            return MapToTrainingPlanDTO(trainingPlan);
        }

        public TrainingPlanDTO UpdateTrainingPlan(int id, string? planName, int? trainingFrequency, int? idTrainingType, int? idAimOfTraining)
        {
            TrainingPlan? trainingPlan = _trainingPlanRepository.GetById(id);

            if (trainingPlan == null)
            {
                throw new Exception($"TrainingPlan with id '{id}' not found.");
            }

            if (!string.IsNullOrEmpty(planName))
            {
                trainingPlan.Name = planName;
            }

            if (trainingFrequency.HasValue)
            {
                trainingPlan.TrainingFrequency = trainingFrequency.Value;
            }

            if (idTrainingType.HasValue)
            {
                trainingPlan.IdTrainingType = idTrainingType.Value;
            }

            if (idAimOfTraining.HasValue)
            {
                trainingPlan.IdAimOfTraining = idAimOfTraining.Value;
            }

            _trainingPlanRepository.Update(trainingPlan);

            return MapToTrainingPlanDTO(trainingPlan);
        }

        public bool DeleteTrainingPlan(int id)
        {
            TrainingPlan? trainingPlan = _trainingPlanRepository.GetById(id);

            if (trainingPlan == null)
            {
                return false;
            }

            _trainingPlanRepository.Delete(trainingPlan);
            return true;
        }

        public List<TrainingPlanDTO> GetPlansByUserId(int idUser)
        {
            if (idUser <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(idUser));
            }

            List<TrainingPlan> plans = _trainingPlanRepository.GetPlansByUserId(idUser);

            return plans.Select(MapToTrainingPlanDTO).ToList();
        }

        private TrainingPlanDTO MapToTrainingPlanDTO(TrainingPlan trainingPlan)
        {
            return new TrainingPlanDTO(
                trainingPlan.Id,
                trainingPlan.Name,
                trainingPlan.TrainingFrequency,
                trainingPlan.IdUser,
                trainingPlan.IdTrainingType,
                trainingPlan.IdAimOfTraining);
        }
    }
}