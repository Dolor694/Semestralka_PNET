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
    public class ExerciseService : IExerciseService
    {
        protected readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public Exercise CreateExercise(string name, bool complex, int idMuscle)
        {
            Exercise newExercise = new Exercise
            {
                Name = name,
                Complex = complex,
                IdMuscle = idMuscle
            };

            _exerciseRepository.Add(newExercise);

            return newExercise;
        }

        public ExerciseDTO? GetExerciseById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            Exercise? exercise = _exerciseRepository.GetById(id);

            if (exercise == null)
            {
                return null;
            }

            return MapToExerciseDTO(exercise);
        }

        public List<ExerciseDTO> GetExercisesByMuscleGroup(int idMuscleGroup)
        {
            if (idMuscleGroup <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(idMuscleGroup));
            }

            return _exerciseRepository.GetExercisesByMuscleGroup(idMuscleGroup)
                .Select(MapToExerciseDTO)
                .ToList();
        }

        public ExerciseDTO UpdateExercise(int id, string? name, bool? complex, int? idMuscle)
        {
            Exercise? exercise = _exerciseRepository.GetById(id);

            if (exercise == null)
            {
                throw new Exception($"Exercise with id '{id}' not found.");
            }

            if (!string.IsNullOrEmpty(name))
            {
                exercise.Name = name;
            }

            if (complex.HasValue)
            {
                exercise.Complex = complex.Value;
            }

            if (idMuscle.HasValue)
            {
                exercise.IdMuscle = idMuscle.Value;
            }

            _exerciseRepository.Update(exercise);

            return MapToExerciseDTO(exercise);
        }

        public bool DeleteExercise(int id)
        {
            Exercise? exercise = _exerciseRepository.GetById(id);

            if (exercise == null)
            {
                return false;
            }

            _exerciseRepository.Delete(exercise);
            return true;
        }

        private ExerciseDTO MapToExerciseDTO(Exercise exercise)
        {
            return new ExerciseDTO(exercise.Id, exercise.Name, exercise.Complex, exercise.IdMuscle);
        }
    }
}