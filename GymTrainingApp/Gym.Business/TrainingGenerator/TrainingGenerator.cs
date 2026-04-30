using Gym.Models.Interfaces;
using Gym.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Models.Database;
using Gym.Business.Factories;
using Gym.Business.AOPStrategies;
using Gym.Business.Interfaces;

namespace Gym.Business.TrainingGenerator
{
    public class TrainingGenerator : ITrainingGenerator
    {
        private readonly AimOfPlanFactory _aimOfPlanFactory;
        private readonly IExerciseGetter _exerciseGetter;
        private readonly IExerciseSelector _exerciseSelector;
        private readonly ITrainingTypeSequenceRepository _trainingTypeSequenceRepository;
        private readonly IExerciseInTrainingService _exerciseInTrainingService;

        public TrainingGenerator(AimOfPlanFactory aimOfPlanFactory, IExerciseGetter exerciseGetter,
                                IExerciseSelector exerciseSelector, ITrainingTypeSequenceRepository trainingTypeSequenceRepository,
                                IExerciseInTrainingService exerciseInTrainingService)
        {
            _aimOfPlanFactory = aimOfPlanFactory;
            _exerciseGetter = exerciseGetter;
            _exerciseSelector = exerciseSelector;
            _trainingTypeSequenceRepository = trainingTypeSequenceRepository;
            _exerciseInTrainingService = exerciseInTrainingService;
        }

        public void GenerateTraining(int idAimOfTraining, int idTrainingTypeSequence, int idTraining)
        {
            int recomendedNumberOfExercises = 7;

            // Create strategy based on the aim of training
            IAimOfPlanStrategy aimOfPlanStrategy = _aimOfPlanFactory.Create(idAimOfTraining);

            // Resolve muscle group directly from the selected sequence item for this training
            var trainingTypeSequence = _trainingTypeSequenceRepository.GetById(idTrainingTypeSequence)
                ?? throw new Exception($"TrainingTypeSequence with id '{idTrainingTypeSequence}' not found.");

            int idNextMuscleGroup = trainingTypeSequence.IdMuscleGroup;

            // Get all exercises for the next muscle group
            IEnumerable<Exercise> exercises = _exerciseGetter.GetExercisesByMuscleGroup(idNextMuscleGroup);

            // Select exercises based on the strategy and the recommended number of exercises
            List<Exercise> selectedExercises = _exerciseSelector.SelectExercises(exercises, recomendedNumberOfExercises, idNextMuscleGroup).ToList();

            // Map selected exercises to ExerciseInTraining and set parameters based on the strategy
            List<ExerciseInTraining> exercisesInTraining = aimOfPlanStrategy.SetParametersOfExercises(selectedExercises, idTraining);


            for (int i = 0; i < exercisesInTraining.Count; i++)
            {
                _exerciseInTrainingService.AddExerciseInTraining(exercisesInTraining[i]);
            }
        }
    }
}
