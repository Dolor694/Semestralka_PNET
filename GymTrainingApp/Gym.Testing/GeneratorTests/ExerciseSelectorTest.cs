using Gym.Business.TrainingGenerator;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.GeneratorTests
{
    [TestClass]
    public class ExerciseSelectorTest
    {
        private static List<Exercise> _baseExercises = null!;
        private static List<Exercise> _singleExercises = null!;
        private static ExerciseSelector _selectorWithNuscles = null!;
        private static ExerciseSelector _selectorWithoutMuscles = null!;

        private const int GroupId = 10;
        private const int RequestedCount = 3;
        private const int FallbackGroupId = 999;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _baseExercises =
            [
                new Exercise { Id = 1, Name = "Bench Press", Complex = true, IdMuscle = 1 },
                new Exercise { Id = 2, Name = "Fly", Complex = false, IdMuscle = 1 },
                new Exercise { Id = 3, Name = "Row", Complex = false, IdMuscle = 2 },
                new Exercise { Id = 4, Name = "Pullover", Complex = false, IdMuscle = 2 }
            ];

            _singleExercises =
            [
                new Exercise { Id = 1, Name = "Squat", Complex = true, IdMuscle = 1 },
                new Exercise { Id = 2, Name = "Leg Extension", Complex = false, IdMuscle = 1 }
            ];

            var muscleRepositoryMock = new Mock<IMuscleRepository>();
            muscleRepositoryMock
                .Setup(r => r.GetMusclesByGroup(GroupId))
                .Returns(
                [
                    new Muscle { Id = 1, Name = "Chest" },
                    new Muscle { Id = 2, Name = "Back" }
                ]);

            _selectorWithNuscles =  new ExerciseSelector(muscleRepositoryMock.Object);

            var withoutMuscleRepositoryMock = new Mock<IMuscleRepository>();
            withoutMuscleRepositoryMock
                .Setup(r => r.GetMusclesByGroup(It.IsAny<int>()))
                .Returns(new List<Muscle>());

            _selectorWithoutMuscles = new ExerciseSelector(withoutMuscleRepositoryMock.Object);
        }

        [TestMethod]
        public void SelectExercises_ShouldReturnRequestedCount_WhenMusclesExist()
        {
            List<Exercise> result = _selectorWithNuscles.SelectExercises(_baseExercises, RequestedCount, GroupId).ToList();

            Assert.AreEqual(RequestedCount, result.Count);
        }

        [TestMethod]
        public void SelectExercises_ShouldContainComplexExercise_WhenComplexExists()
        {
            List<Exercise> result = _selectorWithNuscles.SelectExercises(_baseExercises, RequestedCount, GroupId).ToList();

            Assert.IsTrue(result.Any(e => e.Complex));
        }

        [TestMethod]
        public void SelectExercises_ShouldReturnUniqueExercises_WhenFallbackIsUsed()
        {
            List<Exercise> result = _selectorWithoutMuscles.SelectExercises(_baseExercises, RequestedCount, FallbackGroupId).ToList();

            Assert.AreEqual(result.Count, result.Select(e => e.Id).Distinct().Count());
        }

        [TestMethod]
        public void SelectExercises_ShouldReturnOneExercise_WhenOneIsRequested()
        {
            List<Exercise> result = _selectorWithoutMuscles.SelectExercises(_singleExercises, 1, 1).ToList();

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void SelectExercises_ShouldReturnComplexExercise_WhenOneIsRequestedAndComplexExists()
        {
            List<Exercise> result = _selectorWithNuscles.SelectExercises(_singleExercises, 1, 1).ToList();

            Assert.IsTrue(result[0].Complex);
        }
    }
}