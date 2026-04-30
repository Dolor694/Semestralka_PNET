using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class TrainingTypeServiceTest
    {
        private static TrainingTypeService _service = null!;
        private static List<TrainingType> _types = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _types =
            [
                new TrainingType { Id = 1, Name = "Push/Pull/Legs" },
                new TrainingType { Id = 2, Name = "Upper/Lower" }
            ];

            var repoMock = new Mock<ITrainingTypeRepository>();
            repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _types.FirstOrDefault(x => x.Id == id));
            repoMock.Setup(r => r.GetAll()).Returns(() => _types.ToList());
            repoMock.Setup(r => r.Delete(It.IsAny<TrainingType>())).Callback((TrainingType t) => _types.Remove(t));

            _service = new TrainingTypeService(repoMock.Object);
        }

        [TestMethod]
        public void GetTrainingTypeById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetTrainingTypeById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TrainingTypeDTO));
        }

        [TestMethod]
        public void GetTrainingTypeById_ShouldReturnNull_WhenInvalidId()
        {
            var result = _service.GetTrainingTypeById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTrainingTypeById_ShouldThrowException_WhenIdIsNegative()
        {
            Assert.Throws<ArgumentException>(() => _service.GetTrainingTypeById(0));
        }


        [TestMethod]
        public void GetAllTrainingTypes_ShouldReturnListOfDtos()
        {
            var result = _service.GetAllTrainingTypes();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<TrainingTypeDTO>));
        }

        [TestMethod]
        public void GetAllTrainingTypes_ShouldReturnCorrectCount()
        {
            var result = _service.GetAllTrainingTypes();
            Assert.AreEqual(_types.Count, result.Count);
        }
    }
}