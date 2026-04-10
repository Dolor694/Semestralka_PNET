using Gym.Models.Interfaces;
using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Models.Database;
using Gym.Business.Factories;

namespace Gym.Business.TrainingGenerator
{
    public class TrainingGenerator : ITrainingGenerator
    {
        private readonly AimOfPlanFactory _aimOfPlanFactory;
        private readonly IExerciseGetter _exerciseGetter;
        private readonly IExerciseSelector _exerciseSelector;
        private readonly IExerciseMapper _exerciseMapper;
        private readonly INextMuscleGroupResolver _nextMuscleGroupResolver;

        public TrainingGenerator(AimOfPlanFactory aimOfPlanFactory, IExerciseGetter exerciseGetter,
                                IExerciseSelector exerciseSelector, IExerciseMapper exerciseMapper,
                                INextMuscleGroupResolver nextMuscleGroupResolver)
        {
            _aimOfPlanFactory = aimOfPlanFactory;
            _exerciseGetter = exerciseGetter;
            _exerciseSelector = exerciseSelector;
            _exerciseMapper = exerciseMapper;
            _nextMuscleGroupResolver = nextMuscleGroupResolver;
        }

        public Training GenerateTraining()
        {
            throw new NotImplementedException();
        }
    }
}
