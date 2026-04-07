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
    public class MuscleService : IMuscleService
    {
        protected readonly IMuscleRepository _muscleRepository;

        public MuscleService(IMuscleRepository muscleRepository)
        {
            _muscleRepository = muscleRepository;
        }

        public Muscle CreateMuscle(int id, string name, int idMuscleGroup)
        {
            Muscle newMuscle = new Muscle
            {
                Id = id,
                Name = name,
                IdMuscleGroup = idMuscleGroup
            };

            _muscleRepository.Add(newMuscle);

            return newMuscle;
        }

        public MuscleDTO? GetMuscleById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            Muscle? muscle = _muscleRepository.GetById(id);

            if (muscle == null)
            {
                return null;
            }

            return MapToMuscleDTO(muscle);
        }

        public MuscleDTO UpdateMuscle(int id, string? name, int? idMuscleGroup)
        {
            Muscle? muscle = _muscleRepository.GetById(id);

            if (muscle == null)
            {
                throw new Exception($"Muscle with id '{id}' not found.");
            }

            if (!string.IsNullOrEmpty(name))
            {
                muscle.Name = name;
            }

            if (idMuscleGroup.HasValue)
            {
                muscle.IdMuscleGroup = idMuscleGroup.Value;
            }

            _muscleRepository.Update(muscle);

            return MapToMuscleDTO(muscle);
        }

        public bool DeleteMuscle(int id)
        {
            Muscle? muscle = _muscleRepository.GetById(id);

            if (muscle == null)
            {
                return false;
            }

            _muscleRepository.Delete(muscle);
            return true;
        }

        /*
         * This method maps a Muscle entity to a MuscleDTO object.
         * 
         * @param muscle The Muscle entity to be mapped.
         * @return A MuscleDTO object containing the mapped information from the Muscle entity.
         */
        private MuscleDTO MapToMuscleDTO(Muscle muscle)
        {
            return new MuscleDTO(muscle.Id, muscle.Name, muscle.IdMuscleGroup);
        }
    }
}