using Gym.Business.Interfaces;
using Gym.Models.Entities;
using Gym.Models.Interfaces;

namespace Gym.Business.Services
{
    public class MuscleService : IMuscleService
    {
        protected readonly IMuscleRepository _muscleRepository;
        protected readonly IRepository<MuscleGroupMuscle> _muscleGroupMuscleRepository;

        public MuscleService(
            IMuscleRepository muscleRepository,
            IRepository<MuscleGroupMuscle> muscleGroupMuscleRepository)
        {
            _muscleRepository = muscleRepository;
            _muscleGroupMuscleRepository = muscleGroupMuscleRepository;
        }

        public Muscle CreateMuscle(string name, IEnumerable<int> idMuscleGroups)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Muscle name cannot be empty.", nameof(name));
            }

            List<int> groupIds = idMuscleGroups
                .Distinct()
                .Where(id => id > 0)
                .ToList();

            if (groupIds.Count == 0)
            {
                throw new ArgumentException("At least one muscle group must be assigned.", nameof(idMuscleGroups));
            }

            Muscle newMuscle = new Muscle
            {
                Name = name
            };

            _muscleRepository.Add(newMuscle);

            foreach (int groupId in groupIds)
            {
                _muscleGroupMuscleRepository.Add(new MuscleGroupMuscle
                {
                    IdMuscle = newMuscle.Id,
                    IdMuscleGroup = groupId
                });
            }

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

        public MuscleDTO UpdateMuscle(int id, string? name, IEnumerable<int>? idMuscleGroups)
        {
            Muscle? muscle = _muscleRepository.GetById(id);

            if (muscle == null)
            {
                throw new Exception($"Muscle with id '{id}' not found.");
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                muscle.Name = name;
                _muscleRepository.Update(muscle);
            }

            if (idMuscleGroups != null)
            {
                List<int> groupIds = idMuscleGroups
                    .Distinct()
                    .Where(groupId => groupId > 0)
                    .ToList();

                if (groupIds.Count == 0)
                {
                    throw new ArgumentException("At least one muscle group must be assigned.", nameof(idMuscleGroups));
                }

                List<MuscleGroupMuscle> existingMappings = _muscleGroupMuscleRepository.Query()
                    .Where(mgm => mgm.IdMuscle == id)
                    .ToList();

                foreach (MuscleGroupMuscle mapping in existingMappings)
                {
                    _muscleGroupMuscleRepository.Delete(mapping);
                }

                foreach (int groupId in groupIds)
                {
                    _muscleGroupMuscleRepository.Add(new MuscleGroupMuscle
                    {
                        IdMuscle = id,
                        IdMuscleGroup = groupId
                    });
                }
            }

            return MapToMuscleDTO(muscle);
        }

        public bool DeleteMuscle(int id)
        {
            Muscle? muscle = _muscleRepository.GetById(id);

            if (muscle == null)
            {
                return false;
            }

            List<MuscleGroupMuscle> existingMappings = _muscleGroupMuscleRepository.Query()
                .Where(mgm => mgm.IdMuscle == id)
                .ToList();

            foreach (MuscleGroupMuscle mapping in existingMappings)
            {
                _muscleGroupMuscleRepository.Delete(mapping);
            }

            _muscleRepository.Delete(muscle);
            return true;
        }

        private MuscleDTO MapToMuscleDTO(Muscle muscle)
        {
            List<int> groupIds = _muscleGroupMuscleRepository.Query()
                .Where(mgm => mgm.IdMuscle == muscle.Id)
                .Select(mgm => mgm.IdMuscleGroup)
                .OrderBy(groupId => groupId)
                .ToList();

            return new MuscleDTO(muscle.Id, muscle.Name, groupIds);
        }
    }
}