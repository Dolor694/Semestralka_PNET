using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class MuscleServiceTest
    {
        private static MuscleService _service = null!;
        private static List<Muscle> _muscles = null!;
        private static List<MuscleGroupMuscle> _mappings = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _muscles =
            [
                new Muscle { Id = 1, Name = "Triceps" },
                new Muscle { Id = 2, Name = "Biceps" }
            ];

            _mappings =
            [
                new MuscleGroupMuscle { IdMuscle = 1, IdMuscleGroup = 1 },
                new MuscleGroupMuscle { IdMuscle = 2, IdMuscleGroup = 2 }
            ];

            var muscleRepoMock = new Mock<IMuscleRepository>();
            muscleRepoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _muscles.FirstOrDefault(x => x.Id == id));
            muscleRepoMock.Setup(r => r.Add(It.IsAny<Muscle>())).Callback((Muscle m) =>
            {
                m.Id = _muscles.Max(x => x.Id) + 1;
                _muscles.Add(m);
            });
            muscleRepoMock.Setup(r => r.Delete(It.IsAny<Muscle>())).Callback((Muscle m) => _muscles.Remove(m));

            var mapRepoMock = new Mock<IRepository<MuscleGroupMuscle>>();
            mapRepoMock.Setup(r => r.Query()).Returns(() => _mappings.AsQueryable());
            mapRepoMock.Setup(r => r.Add(It.IsAny<MuscleGroupMuscle>())).Callback((MuscleGroupMuscle m) => _mappings.Add(m));
            mapRepoMock.Setup(r => r.Delete(It.IsAny<MuscleGroupMuscle>())).Callback((MuscleGroupMuscle m) => _mappings.Remove(m));

            _service = new MuscleService(muscleRepoMock.Object, mapRepoMock.Object);
        }

        [TestMethod]
        public void GetMuscleById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetMuscleById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(MuscleDTO));
        }

        [TestMethod]
        public void GetMuscleById_ShouldReturnNull_WhenIdInvalid()
        {
            var result = _service.GetMuscleById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMuscleById_ShouldThrowArgumentException_WhenIdIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => _service.GetMuscleById(0));
        }
    }
}