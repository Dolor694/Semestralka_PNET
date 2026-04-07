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

        public Exercise CreateExercise(int id, string name, bool complex, int idMuscle)
        {
            Exercise newExercise = new Exercise
            {
                Id = id,
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

        /*
         * This method maps an Exercise entity to an ExerciseDTO object.
         * 
         * @param exercise The Exercise entity to be mapped.
         * @return An ExerciseDTO object containing the mapped information from the Exercise entity.
         */
        private ExerciseDTO MapToExerciseDTO(Exercise exercise)
        {
            return new ExerciseDTO(exercise.Id, exercise.Name, exercise.Complex, exercise.IdMuscle);
        }
    }
}