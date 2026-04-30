using Gym.Business.TrainingGenerator;
using Gym.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym.Tests.GeneratorTests
{
    [TestClass]
    public class ExerciseMapperTest
    {
        private static ExerciseMapper _mapper = null!;
        private static Exercise _exercise = null!;

        private const int ExpectedExerciseId = 15;
        private const int ExpectedSets = 4;
        private const int ExpectedReps = 8;
        private const int ExpectedOrder = 2;
        private const int ExpectedTrainingId = 99;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _mapper = new ExerciseMapper();
            _exercise = new Exercise
            {
                Id = ExpectedExerciseId,
                Name = "Bench Press",
                Complex = true,
                IdMuscle = 1
            };
        }

        [TestMethod]
        public void MapExercise_ShouldMapExerciseId()
        {
            ExerciseInTraining result = CreateMappedExercise();

            Assert.AreEqual(ExpectedExerciseId, result.IdExercise);
        }

        [TestMethod]
        public void MapExercise_ShouldMapSets()
        {
            ExerciseInTraining result = CreateMappedExercise();

            Assert.AreEqual(ExpectedSets, result.Sets);
        }

        [TestMethod]
        public void MapExercise_ShouldMapReps()
        {
            ExerciseInTraining result = CreateMappedExercise();

            Assert.AreEqual(ExpectedReps, result.Reps);
        }

        [TestMethod]
        public void MapExercise_ShouldMapOrder()
        {
            ExerciseInTraining result = CreateMappedExercise();

            Assert.AreEqual(ExpectedOrder, result.Order);
        }

        [TestMethod]
        public void MapExercise_ShouldMapTrainingId()
        {
            ExerciseInTraining result = CreateMappedExercise();

            Assert.AreEqual(ExpectedTrainingId, result.IdTraining);
        }

        private static ExerciseInTraining CreateMappedExercise()
        {
            return _mapper.MapExercise(
                _exercise,
                ExpectedSets,
                ExpectedReps,
                ExpectedOrder,
                ExpectedTrainingId);
        }
    }
}