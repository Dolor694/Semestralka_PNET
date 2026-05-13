using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Business.Factories;
using Gym.Business.Services;
using Gym.Business.Services.AimOfPLanService;
using Gym.Business.Services.ExerciseService;
using Gym.Business.Services.ExerciseInTrainingService;
using Gym.Business.Services.MuscleService;
using Gym.Business.Services.MuscleGroupService;
using Gym.Business.Services.TrainingService;
using Gym.Business.Services.TrainingPlanService;
using Gym.Business.Services.TrainingTypeService;
using Gym.Business.Services.TrainingTypeSequenceService;
using Gym.Business.Services.UserService;
using Gym.Business.TrainingGenerator;
using Gym.Models.UserEntity;
using Gym.Models.MuscleGroupEntity;
using Gym.Models.MuscleEntity;
using Gym.Models.ExerciseEntity;
using Gym.Models.TrainingTypeEntity;
using Gym.Models.TrainingTypeSequenceEntity;
using Gym.Models.TrainingEntity;
using Gym.Models.ExerciseInTrainingEntity;
using Gym.Models.AimOfPlanEntity;
using Gym.Models.TrainingPlanEntity;
using Gym.Models.MuscleGroupMuscleEntity;
using Gym.Models._Database.Seed;
using Gym.Models.Data;
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

            // TEST ONLY: reset DB on every app start
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Seed baseline testing data
            DbSeeder.Seed(context);

            // 2. Create repositories
            var aimOfPlanRepo = new DatabaseAimOfPlanRepo(context);
            var exerciseInTrainingRepo = new DatabaseExerciseInTrainingRepo(context);
            var exerciseRepo = new DatabaseExerciseRepo(context);
            var muscleGroupRepo = new DatabaseMuscleGroupRepo(context);
            var muscleRepo = new DatabaseMuscleRepo(context);
            var muscleGroupMuscleRepo = new DatabaseRepository<MuscleGroupMuscle>(context);
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
            MuscleService = new MuscleService(muscleRepo, muscleGroupMuscleRepo);
            TrainingPlanService = new TrainingPlanService(trainingPlanRepo);
            TrainingTypeSequenceService = new TrainingTypeSequenceService(trainingTypeSequenceRepo);
            TrainingTypeService = new TrainingTypeService(trainingTypeRepo);
            UserService = new UserService(userRepo);

            // 4. Create TrainingGenerator components
            var aimOfPlanFactory = new AimOfPlanFactory();
            var exerciseGetter = new ExerciseGetter(exerciseRepo);
            var exerciseSelector = new ExerciseSelector(muscleRepo);
            var nextTrainingTypeSequenceResolver = new NextTrainingTypeSequenceResolver(trainingRepo, trainingTypeSequenceRepo);

            // 5. Create TrainingGenerator
            TrainingGenerator = new TrainingGenerator(
                aimOfPlanFactory,
                exerciseGetter,
                exerciseSelector,
                trainingTypeSequenceRepo,
                ExerciseInTrainingService);

            // 6. Create TrainingService (depends on TrainingGenerator)
            TrainingService = new TrainingService(trainingRepo, TrainingGenerator, nextTrainingTypeSequenceResolver);
        }
    }
}
