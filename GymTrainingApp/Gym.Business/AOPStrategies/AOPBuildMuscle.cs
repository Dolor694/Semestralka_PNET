using Gym.Business.TrainingGenerator;
using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.AOPStrategies
{
    public class AOPBuildMuscle : IAimOfPlanStrategy
    {
        protected readonly IExerciseMapper _exerciseMapper;

        public AOPBuildMuscle()
        {
            _exerciseMapper = new ExerciseMapper();
        }
        public IReadOnlyList<ExerciseInTraining> SetParametersOfExercises(List<Exercise> exercises)
        {
            Random random = new Random();
            List<ExerciseInTraining> exercisesInTraining = new List<ExerciseInTraining>();

            int order = 2;

            foreach (var exercise in exercises)
            {
                if (exercise.Complex)
                {
                    int sets = random.Next(4, 6);
                    int reps = random.Next(4, 8);
                    exercisesInTraining.Add(_exerciseMapper.MapExercise(exercise, sets, reps, 1));
                }
                else
                {
                    int sets = random.Next(3, 5);
                    int reps = random.Next(10, 16);
                    exercisesInTraining.Add(_exerciseMapper.MapExercise(exercise, sets, reps, order));
                    order++;
                }
            }

            return exercisesInTraining;
        }
    }
}
