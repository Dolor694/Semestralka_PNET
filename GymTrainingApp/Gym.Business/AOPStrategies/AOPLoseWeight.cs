using Gym.Business.TrainingGenerator;
using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.AOPStrategies
{
    internal class AOPLoseWeight : IAimOfPlanStrategy
    {
        protected readonly IExerciseMapper _exerciseMapper;

        public AOPLoseWeight()
        {
            _exerciseMapper = new ExerciseMapper();
        }
        public List<ExerciseInTraining> SetParametersOfExercises(List<Exercise> exercises, int idTraining)
        {
            Random random = new Random();
            List<ExerciseInTraining> exercisesInTraining = new List<ExerciseInTraining>();

            int order = 2;

            foreach (var exercise in exercises)
            {
                if (exercise.Complex)
                {
                    int sets = random.Next(5, 7);
                    int reps = random.Next(6, 11);
                    exercisesInTraining.Add(_exerciseMapper.MapExercise(exercise, sets, reps, 1, idTraining));
                }
                else
                {
                    int sets = random.Next(3, 5);
                    int reps = random.Next(15, 21);
                    exercisesInTraining.Add(_exerciseMapper.MapExercise(exercise, sets, reps, order, idTraining));
                    order++;
                }
            }

            return exercisesInTraining;
        }
    }
}
