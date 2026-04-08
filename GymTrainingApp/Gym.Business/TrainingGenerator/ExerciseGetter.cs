using Gym.Models.Entities;
using Gym.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public class ExerciseGetter : IExerciseGetter
    {
        protected readonly IExerciseRepository _exerciseRepository;

        public ExerciseGetter(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public IEnumerable<Exercise> GetExercisesByMuscleGroup(int idMuscleGroup)
        {
            return _exerciseRepository.GetExercisesByMuscleGroup(idMuscleGroup);
        }
    }
}
