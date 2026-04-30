using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class TrainingTypeSequenceServiceTest
    {
        private static TrainingTypeSequenceService _service = null!;
        private static List<TrainingTypeSequence> _sequences = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _sequences =
            [
                new TrainingTypeSequence { Id = 1, OrderInCycle = 1, IdTrainingType = 1, IdMuscleGroup = 1 },
                new TrainingTypeSequence { Id = 2, OrderInCycle = 2, IdTrainingType = 1, IdMuscleGroup = 2 }
            ];

            var repoMock = new Mock<ITrainingTypeSequenceRepository>();
            repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _sequences.FirstOrDefault(x => x.Id == id));

            _service = new TrainingTypeSequenceService(repoMock.Object);
        }

        [TestMethod]
        public void GetTrainingTypeSequenceById_ShouldReturnTrainingTypeSequence_WhenValidId()
        {
            var result = _service.GetTrainingTypeSequenceById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TrainingTypeSequence));
        }

        [TestMethod]
        public void GetTrainingTypeSequenceById_ShouldReturnNull_WhenNonExistingId()
        {
            var result = _service.GetTrainingTypeSequenceById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTrainingTypeSequenceById_ShouldThrowArgumentException_WhenInvalidId()
        {
            Assert.Throws<ArgumentException>(() => _service.GetTrainingTypeSequenceById(0));
        }
    }
}