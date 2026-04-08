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
                
            // Always select all complex (compound) exercises first
            var complexExercises = exercises.Where(e => e.Complex).ToList();
            selectedExercises.AddRange(complexExercises);

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
                return selectedExercises;
            }

            // Group the non-complex exercises by muscle
            var alreadySelectedIds = new HashSet<int>(selectedExercises.Select(e => e.Id));
            var nonComplexByMuscle = exercises
                .Where(e => !e.Complex && !alreadySelectedIds.Contains(e.Id))
                .GroupBy(e => e.IdMuscle)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Calculate how many exercises per muscle (base + remainder)
            int basePerMuscle = remainingSlots / numberOfMuscles;
            int remainder = remainingSlots % numberOfMuscles;

            // Distribute exercises across muscles as evenly as possible
            foreach (var muscle in muscles)
            {
                int countForThisMuscle = basePerMuscle + (remainder > 0 ? 1 : 0);
                if (remainder > 0)
                {
                    remainder--;
                }

                if (nonComplexByMuscle.TryGetValue(muscle.Id, out var available))
                {
                    selectedExercises.AddRange(available.Take(countForThisMuscle));
                }
            }

            return selectedExercises;
        }

        private IEnumerable<Muscle> GetMusclesByGroup(int idMuscleGroup)
        {
            return _muscleRepository.GetMusclesByGroup(idMuscleGroup);
        }
    }
}