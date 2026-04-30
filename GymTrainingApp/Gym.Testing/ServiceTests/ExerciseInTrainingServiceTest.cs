using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class ExerciseInTrainingServiceTest
    {
        private static ExerciseInTrainingService _exerciseInTrainingService = null!;
        private static List<ExerciseInTraining> _exercisesInTraining = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _exercisesInTraining =
            [
                new ExerciseInTraining
                {
                    Id = 1,
                    Sets = 3,
                    Reps = 10,
                    Order = 1,
                    IdExercise = 1,
                    IdTraining = 1
                },
                new ExerciseInTraining
                {
                    Id = 2,
                    Sets = 4,
                    Reps = 12,
                    Order = 2,
                    IdExercise = 2,
                    IdTraining = 1
                }
            ];

            var exerciseInTrainingRepositoryMock = new Mock<IExerciseInTrainingRepository>();
            exerciseInTrainingRepositoryMock
                .Setup(r => r.GetById(It.IsAny<int>()))
                .Returns((int id) => _exercisesInTraining.FirstOrDefault(x => x.Id == id));

            exerciseInTrainingRepositoryMock
                .Setup(r => r.GetAll())
                .Returns(() => _exercisesInTraining.ToList());

            exerciseInTrainingRepositoryMock
                .Setup(r => r.GetByTrainingId(It.IsAny<int>()))
                .Returns((int idTraining) => _exercisesInTraining.Where(e => e.IdTraining == idTraining).ToList());

            exerciseInTrainingRepositoryMock
                .Setup(r => r.Delete(It.IsAny<ExerciseInTraining>()))
                .Callback((ExerciseInTraining e) => _exercisesInTraining.Remove(e));

            _exerciseInTrainingService = new ExerciseInTrainingService(exerciseInTrainingRepositoryMock.Object);
        }

        [TestMethod]
        public void GetExerciseInTrainingById_ShouldReturnExerciseInTrainingDTO_WhenValidId()
        {
            int validId = 1;

            ExerciseInTrainingDTO? result = _exerciseInTrainingService.GetExerciseInTrainingById(validId);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ExerciseInTrainingDTO));
        }

        [TestMethod]
        public void GetExerciseInTrainingById_ShouldReturnNull_WhenInvalidId()
        {
            int invalidId = 999;

            ExerciseInTrainingDTO? result = _exerciseInTrainingService.GetExerciseInTrainingById(invalidId);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetExerciseInTrainingById_ShouldThrowArgumentException_WhenIdIsZeroOrNegative()
        {
            int invalidId = 0;

            Assert.Throws<ArgumentException>(() => _exerciseInTrainingService.GetExerciseInTrainingById(invalidId));
        }

        [TestMethod]
        public void GetExercisesByTrainingId_ShouldReturnListOfExerciseInTrainingDTO()
        {
            var result = _exerciseInTrainingService.GetExercisesByTrainingId(1);

            Assert.IsNotNull(result);
            Assert.IsExactInstanceOfType(result, typeof(List<ExerciseInTrainingDTO>));
        }

        [TestMethod]
        public void GetExercisesByTrainingId_ShouldReturnCorrectNumberOfExerciseInTrainingDTO()
        {
            var result = _exerciseInTrainingService.GetExercisesByTrainingId(1);
            var numOfExercises = _exercisesInTraining.Count(e => e.IdTraining == 1);

            Assert.IsNotNull(result);
            Assert.HasCount(numOfExercises, result);
        }

        [TestMethod]
        public void GetExercisesByTrainingId_ShouldThrowArgumentException_WhenIdIsZeroOrNegative()
        {
            int invalidId = -1;

            Assert.Throws<ArgumentException>(() => _exerciseInTrainingService.GetExercisesByTrainingId(invalidId));
        }
    }
}
