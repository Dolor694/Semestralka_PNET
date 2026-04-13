using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Business.Interfaces;
using Gym.Business.Factories;
using Gym.Business.Services;
using Gym.Business.TrainingGenerator;
using Gym.Models.Data;
using Gym.Models.Database;
using Gym.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gym.UI.ConsoleUI
{
    public class AppService
    {
        public IAimOfPlanService AimOfPlanService { get; }
        public IExerciseInTrainingService ExerciseInTrainingService { get; }
        public IExerciseService ExerciseService { get; }
        public IMuscleGroupService MuscleGroupService { get; }
        public IMuscleService MuscleService { get; }
        public ITrainingPlanService TrainingPlanService { get; }
        public ITrainingService TrainingService { get; }
        public ITrainingTypeSequenceService TrainingTypeSequenceService { get; }
        public ITrainingTypeService TrainingTypeService { get; }
        public IUserService UserService { get; }

        public ITrainingGenerator TrainingGenerator { get; }

        public AppService()
        {
            // 1. Create the DbContext
            var optionsBuilder = new DbContextOptionsBuilder<GymDbContext>();
            optionsBuilder.UseSqlite("Data Source=gym.db");
            var context = new GymDbContext(optionsBuilder.Options);

            // 2. Create repositories
            var aimOfPlanRepo = new DatabaseAimOfPlanRepo(context);
            var exerciseInTrainingRepo = new DatabaseExerciseInTrainingRepo(context);
            var exerciseRepo = new DatabaseExerciseRepo(context);
            var muscleGroupRepo = new DatabaseMuscleGroupRepo(context);
            var muscleRepo = new DatabaseMuscleRepo(context);
            var trainingPlanRepo = new DatabaseTrainingPlanRepo(context);
            var trainingRepo = new DatabaseTrainingRepo(context);
            var trainingTypeSequenceRepo = new DatabaseTrainingTypeSequenceRepo(context);
            var trainingTypeRepo = new DatabaseTrainingTypeRepo(context);
            var userRepo = new DatabaseUserRepo(context);

            // 3. Create services
            AimOfPlanService = new AimOfPlanService(aimOfPlanRepo);
            ExerciseInTrainingService = new ExerciseInTrainingService(exerciseInTrainingRepo);
            ExerciseService = new ExerciseService(exerciseRepo);
            MuscleGroupService = new MuscleGroupService(muscleGroupRepo);
            MuscleService = new MuscleService(muscleRepo);
            TrainingPlanService = new TrainingPlanService(trainingPlanRepo);
            TrainingTypeSequenceService = new TrainingTypeSequenceService(trainingTypeSequenceRepo);
            TrainingTypeService = new TrainingTypeService(trainingTypeRepo);
            UserService = new UserSevice(userRepo);

            // 4. Create TrainingGenerator components
            var aimOfPlanFactory = new AimOfPlanFactory();
            var exerciseGetter = new ExerciseGetter(exerciseRepo);
            var exerciseSelector = new ExerciseSelector(muscleRepo);
            var nextMuscleGroupResolver = new NextMuscleGroupResolver(trainingRepo, trainingTypeSequenceRepo);
            var nextTrainingTypeSequenceResolver = new NextTrainingTypeSequenceResolver(trainingRepo, trainingTypeSequenceRepo);

            // 5. Create TrainingGenerator
            TrainingGenerator = new Business.TrainingGenerator.TrainingGenerator(
                aimOfPlanFactory,
                exerciseGetter,
                exerciseSelector,
                nextMuscleGroupResolver,
                ExerciseInTrainingService);

            // 6. Create TrainingService (depends on TrainingGenerator)
            TrainingService = new TrainingService(trainingRepo, TrainingGenerator, nextTrainingTypeSequenceResolver);
        }
    }
}
