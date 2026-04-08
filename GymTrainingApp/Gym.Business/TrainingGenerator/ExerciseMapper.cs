using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Business.TrainingGenerator
{
    public class ExerciseMapper : IExerciseMapper
    {
        public ExerciseInTraining MapExercise(Exercise exercise, int numberOfSeries, int numberOfRepetitions, int order)
        {
            return new ExerciseInTraining
            {
                IdExercise = exercise.Id,
                Sets = numberOfSeries,
                Reps = numberOfRepetitions,
                Order = order
            };
        }
    }
}
