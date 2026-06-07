using Gym.Business.TrainingGenerator;
using Gym.Models.ExerciseEntity;
using Gym.Models.ExerciseInTrainingEntity;
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

        public AOPBuildMuscle(IExerciseMapper exerciseMapper)
        {
            _exerciseMapper = exerciseMapper;
        }
        public List<ExerciseInTraining> SetParametersOfExercises(List<Exercise> exercises, int idTraining)
        {
            List<ExerciseInTraining> exercisesInTraining = new List<ExerciseInTraining>();

            int order = 2;

            foreach (var exercise in exercises)
            {
                if (exercise.Complex)
                {
                    int sets = Random.Shared.Next(4, 6);
                    int reps = Random.Shared.Next(4, 8);
                    exercisesInTraining.Add(_exerciseMapper.MapExercise(exercise, sets, reps, 1, idTraining));
                }
                else
                {
                    int sets = Random.Shared.Next(3, 5);
                    int reps = Random.Shared.Next(10, 16);
                    exercisesInTraining.Add(_exerciseMapper.MapExercise(exercise, sets, reps, order, idTraining));
                    order++;
                }
            }

            return exercisesInTraining;
        }
    }
}
