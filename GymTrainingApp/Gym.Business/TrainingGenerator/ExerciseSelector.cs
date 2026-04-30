using Gym.Models.Entities;
using Gym.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public class ExerciseSelector : IExerciseSelector
    {
        protected readonly IMuscleRepository _muscleRepository;

        public ExerciseSelector(IMuscleRepository muscleRepository)
        {
            _muscleRepository = muscleRepository;
        }

        public IEnumerable<Exercise> SelectExercises(IEnumerable<Exercise> exercises, int numberOfExercises, int idMuscleGroup)
        {
            List<Exercise> selectedExercises = new List<Exercise>();

            // Ensure at least one complex (compound) exercise is selected when available
            var complexExercises = exercises.Where(e => e.Complex).ToList();
            if (complexExercises.Count > 0)
            {
                Exercise selectedComplex = complexExercises[Random.Shared.Next(complexExercises.Count)];
                selectedExercises.Add(selectedComplex);
            }

            int remainingSlots = numberOfExercises - selectedExercises.Count;

            if (remainingSlots <= 0)
            {
                return selectedExercises.Take(numberOfExercises);
            }

            // Get all muscles in the group to distribute exercises evenly
            var muscles = GetMusclesByGroup(idMuscleGroup).ToList();
            int numberOfMuscles = muscles.Count;

            if (numberOfMuscles == 0)
            {
                var fallbackCandidates = exercises
                    .Where(e => selectedExercises.All(se => se.Id != e.Id))
                    .OrderBy(_ => Random.Shared.Next())
                    .Take(remainingSlots)
                    .ToList();

                selectedExercises.AddRange(fallbackCandidates);
                return selectedExercises;
            }

            // Group remaining exercises by muscle
            var alreadySelectedIds = new HashSet<int>(selectedExercises.Select(e => e.Id));
            var exercisesByMuscle = exercises
                .Where(e => !alreadySelectedIds.Contains(e.Id))
                .GroupBy(e => e.IdMuscle)
                .ToDictionary(g => g.Key, g => g.OrderBy(_ => Random.Shared.Next()).ToList());

            // Calculate how many exercises per muscle (base + remainder)
            int basePerMuscle = remainingSlots / numberOfMuscles;
            int remainder = remainingSlots % numberOfMuscles;

            // Distribute exercises across muscles as evenly as possible
            foreach (var muscle in muscles.OrderBy(_ => Random.Shared.Next()))
            {
                int countForThisMuscle = basePerMuscle + (remainder > 0 ? 1 : 0);
                if (remainder > 0)
                {
                    remainder--;
                }

                if (exercisesByMuscle.TryGetValue(muscle.Id, out var available))
                {
                    selectedExercises.AddRange(available.Take(countForThisMuscle));
                }
            }

            // If some slots are still empty, fill them randomly from all remaining exercises
            int missing = numberOfExercises - selectedExercises.Count;
            if (missing > 0)
            {
                var selectedIds = new HashSet<int>(selectedExercises.Select(e => e.Id));
                var remaining = exercises
                    .Where(e => !selectedIds.Contains(e.Id))
                    .OrderBy(_ => Random.Shared.Next())
                    .Take(missing)
                    .ToList();

                selectedExercises.AddRange(remaining);
            }

            return selectedExercises;
        }

        private IEnumerable<Muscle> GetMusclesByGroup(int idMuscleGroup)
        {
            return _muscleRepository.GetMusclesByGroup(idMuscleGroup);
        }
    }
}