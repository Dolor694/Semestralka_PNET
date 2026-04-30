using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class TrainingPlanServiceTest
    {
        private static TrainingPlanService _service = null!;
        private static List<TrainingPlan> _plans = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _plans =
            [
                new TrainingPlan { Id = 1, PlanName = "Plan A", TrainingFrequency = 3, IdUser = 1, IdTrainingType = 1, IdAimOfTraining = 1, DateOfCreation = DateOnly.FromDateTime(DateTime.Now) },
                new TrainingPlan { Id = 2, PlanName = "Plan B", TrainingFrequency = 4, IdUser = 1, IdTrainingType = 1, IdAimOfTraining = 2, DateOfCreation = DateOnly.FromDateTime(DateTime.Now) }
            ];

            var repoMock = new Mock<ITrainingPlanRepository>();
            repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _plans.FirstOrDefault(x => x.Id == id));
            repoMock.Setup(r => r.GetPlansByUserId(It.IsAny<int>())).Returns((int idUser) => _plans.Where(x => x.IdUser == idUser).ToList());
            repoMock.Setup(r => r.Delete(It.IsAny<TrainingPlan>())).Callback((TrainingPlan p) => _plans.Remove(p));

            _service = new TrainingPlanService(repoMock.Object);
        }

        [TestMethod]
        public void GetTrainingPlanById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetTrainingPlanById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Plan A", result.PlanName);
        }

        [TestMethod]
        public void GetTrainingPlanById_ShouldReturnNull_WhenInvalidId()
        {
            var result = _service.GetTrainingPlanById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTrainingPlanById_ShouldThrowException_WhenIdIsNegative()
        {
            Assert.Throws<ArgumentException>(() => _service.GetTrainingPlanById(0));
        }


        [TestMethod]
        public void GetPlansByUserId_ShouldReturnCorrectCount_WhenValidUserId()
        {
            var result = _service.GetPlansByUserId(1);
            Assert.IsNotNull(result);
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void GetPlansByUserId_ShouldReturnEmptyList_WhenNoPlansForUser()
        {
            var result = _service.GetPlansByUserId(999);
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [TestMethod]
        public void GetPlansByUserId_ShouldThrowException_WhenUserIdIsNegative()
        {
            Assert.Throws<ArgumentException>(() => _service.GetPlansByUserId(0));
        }
    }
}