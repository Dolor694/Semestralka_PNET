using Gym.Business.Services;
using Gym.Business.TrainingGenerator;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class TrainingServiceTest
    {
        private static TrainingService _service = null!;
        private static List<Training> _trainings = null!;
        private static Mock<ITrainingGenerator> _generatorMock = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _trainings =
            [
                new Training { Id = 1, IdTrainingPlan = 1, IdTrainingTypeSequence = 10, Date = new DateOnly(2026, 1, 1) },
                new Training { Id = 2, IdTrainingPlan = 1, IdTrainingTypeSequence = 20, Date = new DateOnly(2026, 1, 8) },
                new Training { Id = 3, IdTrainingPlan = 2, IdTrainingTypeSequence = 30, Date = new DateOnly(2026, 1, 15) }
            ];

            var trainingRepoMock = new Mock<ITrainingRepository>();
            _generatorMock = new Mock<ITrainingGenerator>();
            var resolverMock = new Mock<INextTrainingTypeSequenceResolver>();

            trainingRepoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _trainings.FirstOrDefault(x => x.Id == id));
            trainingRepoMock.Setup(r => r.GetTrainingsByPlan(It.IsAny<int>())).Returns((int idPlan) => _trainings.Where(x => x.IdTrainingPlan == idPlan));
            trainingRepoMock.Setup(r => r.Add(It.IsAny<Training>())).Callback((Training t) =>
            {
                t.Id = _trainings.Max(x => x.Id) + 1;
                _trainings.Add(t);
            });
            trainingRepoMock.Setup(r => r.Delete(It.IsAny<Training>())).Callback((Training t) => _trainings.Remove(t));

            resolverMock.Setup(r => r.GetNextTrainingTypeSequenceId(It.IsAny<int>(), It.IsAny<int>())).Returns(10);

            _service = new TrainingService(trainingRepoMock.Object, _generatorMock.Object, resolverMock.Object);
        }

        [TestMethod]
        public void GetTrainingById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetTrainingById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TrainingDTO));
        }

        [TestMethod]
        public void GetTrainingById_ShouldReturnNull_WhenNonExistentId()
        {
            var result = _service.GetTrainingById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTrainingById_ShouldThrowArgumentException_WhenInvalidId()
        {
            Assert.Throws<ArgumentException>(() => _service.GetTrainingById(0));
        }


        [TestMethod]
        public void GetTrainingsByPlan_ShouldReturnDtos_WhenValidPlanId()
        {
            var result = _service.GetTrainingsByPlan(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<TrainingDTO>));
        }

        [TestMethod]
        public void GetTrainingsByPlan_ShouldReturnCorrectCount_WhenValidPlanId()
        {
            var result = _service.GetTrainingsByPlan(1);
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void GetTrainingsByPlan_ShouldReturnEmpty_WhenNoTrainingsForPlan()
        {
            var result = _service.GetTrainingsByPlan(999);
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [TestMethod]
        public void GetTrainingsByPlan_ShouldThrowArgumentException_WhenInvalidPlanId()
        {
            Assert.Throws<ArgumentException>(() => _service.GetTrainingsByPlan(0));
        }


        [TestMethod]
        public void GetLastTrainingInPlan_ShouldReturnTraining_WhenValidPlanId()
        {
            var result = _service.GetLastTrainingInPlan(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Training));
        }

        [TestMethod]
        public void GetLastTrainingInPlan_ShouldReturnMostRecentTraining_WhenValidPlanId()
        {
            var result = _service.GetLastTrainingInPlan(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
        }

        [TestMethod]
        public void GetLastTrainingInPlan_ShouldReturnNull_WhenNoTrainingsForPlan()
        {
            var result = _service.GetLastTrainingInPlan(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetLastTrainingInPlan_ShouldThrowArgumentException_WhenInvalidPlanId()
        {
            Assert.Throws<ArgumentException>(() => _service.GetLastTrainingInPlan(0));
        }
    }
}