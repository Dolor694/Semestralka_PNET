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
    public class MuscleGroupService : IMuscleGroupService
    {
        protected readonly IMuscleGroupRepository _muscleGroupRepository;

        public MuscleGroupService(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }

        public MuscleGroup CreateMuscleGroup(string name)
        {
            MuscleGroup newMuscleGroup = new MuscleGroup
            {
                Name = name
            };

            _muscleGroupRepository.Add(newMuscleGroup);

            return newMuscleGroup;
        }

        public MuscleGroupDTO? GetMuscleGroupById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }

            MuscleGroup? muscleGroup = _muscleGroupRepository.GetById(id);

            if (muscleGroup == null)
            {
                return null;
            }

            return MapToMuscleGroupDTO(muscleGroup);
        }

        public List<MuscleGroupDTO> GetAllMuscleGroups()
        {
            return _muscleGroupRepository.GetAll()
                .Select(MapToMuscleGroupDTO)
                .ToList();
        }

        public MuscleGroupDTO UpdateMuscleGroup(int id, string? name)
        {
            MuscleGroup? muscleGroup = _muscleGroupRepository.GetById(id);

            if (muscleGroup == null)
            {
                throw new Exception($"MuscleGroup with id '{id}' not found.");
            }

            if (!string.IsNullOrEmpty(name))
            {
                muscleGroup.Name = name;
            }

            _muscleGroupRepository.Update(muscleGroup);

            return MapToMuscleGroupDTO(muscleGroup);
        }

        public bool DeleteMuscleGroup(int id)
        {
            MuscleGroup? muscleGroup = _muscleGroupRepository.GetById(id);

            if (muscleGroup == null)
            {
                return false;
            }

            _muscleGroupRepository.Delete(muscleGroup);
            return true;
        }

        private MuscleGroupDTO MapToMuscleGroupDTO(MuscleGroup muscleGroup)
        {
            return new MuscleGroupDTO(muscleGroup.Id, muscleGroup.Name);
        }
    }
}