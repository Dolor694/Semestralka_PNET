using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public interface IExerciseMapper
    {
        /*
         * This method will map an exercise to an ExerciseInTraining object with the specified parameters.
         * 
         * @param exercise - the exercise to be mapped.
         * @param numberOfSeries - the number of series for the exercise.
         * @param numberOfRepetitions - the number of repetitions for the exercise.
         * @param order - the order of the exercise in the training.
         * @return an ExerciseInTraining object with the specified parameters.
         */
        public ExerciseInTraining MapExercise(Exercise exercise, int numberOfSeries, int numberOfRepetitions, int order);
    }
}
