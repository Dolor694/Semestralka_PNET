using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class MuscleGroupServiceTest
    {
        private static MuscleGroupService _service = null!;
        private static List<MuscleGroup> _groups = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _groups =
            [
                new MuscleGroup { Id = 1, Name = "Chest" },
                new MuscleGroup { Id = 2, Name = "Back" }
            ];

            var repoMock = new Mock<IMuscleGroupRepository>();
            repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _groups.FirstOrDefault(x => x.Id == id));
            repoMock.Setup(r => r.GetAll()).Returns(() => _groups.ToList());
            repoMock.Setup(r => r.Delete(It.IsAny<MuscleGroup>())).Callback((MuscleGroup g) => _groups.Remove(g));

            _service = new MuscleGroupService(repoMock.Object);
        }

        [TestMethod]
        public void GetMuscleGroupById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetMuscleGroupById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(MuscleGroupDTO));
        }

        [TestMethod]
        public void GetMuscleGroupById_ShouldReturnNull_WhenInvalidId()
        {
            var result = _service.GetMuscleGroupById(999);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMuscleGroupById_ShouldThrowArgumentException_WhenIdIsZeroOrNegative()
        {
            int invalidId = 0;

            Assert.Throws<ArgumentException>(() => _service.GetMuscleGroupById(invalidId));
        }


        [TestMethod]
        public void GetAllMuscleGroups_ShouldReturnListOfMuscleGroupDTO()
        {
            var result = _service.GetAllMuscleGroups();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<MuscleGroupDTO>));
        }

        [TestMethod]
        public void GetAllMuscleGroups_ShouldReturnCorrectNumberOfMuscleGroupDTO_WhenNoMuscleGroups()
        {
            var result = _service.GetAllMuscleGroups();

            Assert.IsNotNull(result);
            Assert.HasCount(2, result);
        }
    }
}