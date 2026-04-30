using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class ExerciseServiceTest
    {
        private static ExerciseService _service = null!;
        private static List<Exercise> _exercises = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _exercises =
            [
                new Exercise { Id = 1, Name = "Bench Press", Complex = true, IdMuscle = 1 },
                new Exercise { Id = 2, Name = "Biceps Curl", Complex = false, IdMuscle = 2 }
            ];

            var repoMock = new Mock<IExerciseRepository>();
            repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _exercises.FirstOrDefault(x => x.Id == id));
            repoMock.Setup(r => r.GetExercisesByMuscleGroup(It.IsAny<int>()))
                .Returns((int idMuscleGroup) => _exercises.Where(x => x.IdMuscle == idMuscleGroup));
            repoMock.Setup(r => r.Delete(It.IsAny<Exercise>())).Callback((Exercise e) => _exercises.Remove(e));

            _service = new ExerciseService(repoMock.Object);
        }

        [TestMethod]
        public void GetExerciseById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetExerciseById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ExerciseDTO));
        }

        [TestMethod]
        public void GetExerciseById_ShouldReturnNull_WhenInvalidId()
        {
            var result = _service.GetExerciseById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetExerciseById_ShouldThrowArgumentException_WhenIdIsZeroOrNegative()
        {
            int invalidId = 0;

            Assert.Throws<ArgumentException>(() => _service.GetExerciseById(invalidId));
        }

        [TestMethod]
        public void GetExercisesByMuscleGroup_ShouldReturnList_WhenValidGroupId()
        {
            var result = _service.GetExercisesByMuscleGroup(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<ExerciseDTO>)); 
        }

        [TestMethod]
        public void GetExercisesByMuscleGroup_ShouldReturnCorrectNumberOfDtos()
        {
            var result = _service.GetExercisesByMuscleGroup(1);
            var numOfExercises = _exercises.Count(e => e.IdMuscle == 1);

            Assert.IsNotNull(result);
            Assert.HasCount(numOfExercises, result);
        }
    }
}