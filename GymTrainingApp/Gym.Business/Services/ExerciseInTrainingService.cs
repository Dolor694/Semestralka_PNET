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
    public class ExerciseInTrainingService : IExerciseInTrainingService
    {
        protected readonly IExerciseInTrainingRepository _exerciseInTrainingRepository;

        public ExerciseInTrainingService(IExerciseInTrainingRepository exerciseInTrainingRepository)
        {
            _exerciseInTrainingRepository = exerciseInTrainingRepository;
        }

        public ExerciseInTraining CreateExerciseInTraining(int sets, int reps, int order, int idExercise, int idTraining)
        {
            ExerciseInTraining newExerciseInTraining = new ExerciseInTraining
            {
                Sets = sets,
                Reps = reps,
                Order = order,
                IdExercise = idExercise,
                IdTraining = idTraining
            };

            _exerciseInTrainingRepository.Add(newExerciseInTraining);

            return newExerciseInTraining;
        }

        public ExerciseInTrainingDTO? GetExerciseInTrainingById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            ExerciseInTraining? exerciseInTraining = _exerciseInTrainingRepository.GetById(id);

            if (exerciseInTraining == null)
            {
                return null;
            }

            return MapToExerciseInTrainingDTO(exerciseInTraining);
        }

        public List<ExerciseInTrainingDTO> GetExercisesByTrainingId(int idTraining)
        {
            if (idTraining <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(idTraining));
            }

            List<ExerciseInTraining> exercises = _exerciseInTrainingRepository.GetByTrainingId(idTraining);

            return exercises.Select(MapToExerciseInTrainingDTO).ToList();
        }

        public ExerciseInTrainingDTO UpdateExerciseInTraining(int id, int? sets, int? reps, int? order)
        {
            ExerciseInTraining? exerciseInTraining = _exerciseInTrainingRepository.GetById(id);

            if (exerciseInTraining == null)
            {
                throw new Exception($"ExerciseInTraining with id '{id}' not found.");
            }

            if (sets.HasValue)
            {
                exerciseInTraining.Sets = sets.Value;
            }

            if (reps.HasValue)
            {
                exerciseInTraining.Reps = reps.Value;
            }

            if (order.HasValue)
            {
                exerciseInTraining.Order = order.Value;
            }

            _exerciseInTrainingRepository.Update(exerciseInTraining);

            return MapToExerciseInTrainingDTO(exerciseInTraining);
        }

        public bool DeleteExerciseInTraining(int id)
        {
            ExerciseInTraining? exerciseInTraining = _exerciseInTrainingRepository.GetById(id);

            if (exerciseInTraining == null)
            {
                return false;
            }

            _exerciseInTrainingRepository.Delete(exerciseInTraining);
            return true;
        }

        public ExerciseInTraining AddExerciseInTraining(ExerciseInTraining exerciseInTraining)
        {
            if (exerciseInTraining == null)
            {
                throw new ArgumentNullException(nameof(exerciseInTraining), "ExerciseInTraining cannot be null.");
            }

            _exerciseInTrainingRepository.Add(exerciseInTraining);
            return exerciseInTraining;
        }

        private ExerciseInTrainingDTO MapToExerciseInTrainingDTO(ExerciseInTraining exerciseInTraining)
        {
            return new ExerciseInTrainingDTO(
                exerciseInTraining.Id,
                exerciseInTraining.Sets,
                exerciseInTraining.Reps,
                exerciseInTraining.Order,
                exerciseInTraining.IdExercise,
                exerciseInTraining.IdTraining);
        }
    }
}