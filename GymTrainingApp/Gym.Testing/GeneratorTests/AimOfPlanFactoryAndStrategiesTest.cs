using Gym.Business.AOPStrategies;
using Gym.Business.Factories;
using Gym.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym.Tests.GeneratorTests
{
    [TestClass]
    public class AimOfPlanFactoryAndStrategiesTest
    {
        private static AimOfPlanFactory _factory = null!;
        private static List<Exercise> _testExercises = null!;

        private const int BuildMuscleId = 1;
        private const int BuildStrengthId = 2;
        private const int InvalidId = 0;
        private const int TestTrainingId = 50;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _factory = new AimOfPlanFactory();
            _testExercises =
            [
                new Exercise { Id = 1, Name = "Compound", Complex = true, IdMuscle = 1 },
                new Exercise { Id = 2, Name = "Isolation", Complex = false, IdMuscle = 2 }
            ];
        }

        [TestMethod]
        public void Create_ShouldReturnBuildMuscleStrategy_WhenIdIs1()
        {
            IAimOfPlanStrategy strategy = _factory.Create(BuildMuscleId);

            Assert.IsInstanceOfType(strategy, typeof(AOPBuildMuscle));
        }

        [TestMethod]
        public void Create_ShouldReturnBuildStrengthStrategy_WhenIdIs2()
        {
            IAimOfPlanStrategy strategy = _factory.Create(BuildStrengthId);

            Assert.IsInstanceOfType(strategy, typeof(AOPBuildStrength));
        }

        [TestMethod]
        public void Create_ShouldThrowArgumentException_WhenIdIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => _factory.Create(InvalidId));
        }

        [TestMethod]
        public void AOPBuildMuscle_ShouldContainComplexExercise()
        {
            var strategy = new AOPBuildMuscle();
            List<ExerciseInTraining> result = strategy.SetParametersOfExercises(_testExercises, TestTrainingId);

            Assert.Contains(x => x.IdExercise == 1, result);
        }

        [TestMethod]
        public void AOPBuildMuscle_ShouldContainNonComplexExercise()
        {
            var strategy = new AOPBuildMuscle();
            List<ExerciseInTraining> result = strategy.SetParametersOfExercises(_testExercises, TestTrainingId);

            Assert.Contains(x => x.IdExercise == 2, result);
        }

        [TestMethod]
        public void AOPBuildMuscle_HasExpectedOrder()
        {
            var strategy = new AOPBuildMuscle();
            List<ExerciseInTraining> result = strategy.SetParametersOfExercises(_testExercises, TestTrainingId);

            ExerciseInTraining complex = result.Single(x => x.IdExercise == 1);
            ExerciseInTraining isolation = result.Single(x => x.IdExercise == 2);

            Assert.IsTrue(complex.Order == 1 && isolation.Order == 2);
        }

        [TestMethod]
        public void AOPBuildMuscle_HasExpectedTrainingId()
        {
            var strategy = new AOPBuildMuscle();

            List<ExerciseInTraining> result = strategy.SetParametersOfExercises(_testExercises, TestTrainingId);

            Assert.IsTrue(result.All(x => x.IdTraining == TestTrainingId));
        }

        [TestMethod]
        public void AOPBulidMuscle_HasComplexRange()
        {
            var strategy = new AOPBuildMuscle();
            List<ExerciseInTraining> result = strategy.SetParametersOfExercises(_testExercises, TestTrainingId);
            ExerciseInTraining complex = result.Single(x => x.IdExercise == 1);

            Assert.IsTrue(complex.Sets >= 4 && complex.Sets <= 5 && complex.Reps >= 4 && complex.Reps <= 7);
        }

        [TestMethod]
        public void AOPBulidMuscle_HasNonComplexRange()
        {
            var strategy = new AOPBuildMuscle();
            List<ExerciseInTraining> result = strategy.SetParametersOfExercises(_testExercises, TestTrainingId);
            ExerciseInTraining isolation = result.Single(x => x.IdExercise == 2);

            Assert.IsTrue(isolation.Sets >= 3 && isolation.Sets <= 4 && isolation.Reps >= 10 && isolation.Reps <= 15);
        }
    }
}