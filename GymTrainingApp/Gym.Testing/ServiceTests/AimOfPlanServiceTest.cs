using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Gym.Models.AimOfPlanEntity;
using Gym.Business.Services.AimOfPLanService;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class AimOfPlanServiceTest
    {
        private static AimOfPlanService _service = null!;
        private static List<AimOfPlan> _aims = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            _aims =
            [
                new AimOfPlan { Id = 1, Name = "Strength" },
                new AimOfPlan { Id = 2, Name = "Hypertrophy" }
            ];

            // Fake repository
            var repoMock = new Mock<IAimOfPlanRepository>();
            repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _aims.FirstOrDefault(x => x.Id == id));
            repoMock.Setup(r => r.GetAll()).Returns(() => _aims.ToList());

            _service = new AimOfPlanService(repoMock.Object);
        }

        [TestMethod]
        public void GetAimOfPlanById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetAimOfPlanById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AimOfPlanDTO));
        }

        [TestMethod]
        public void GetAimOfPlanById_ShouldReturnNull_WhenIdNotFound()
        {
            var result = _service.GetAimOfPlanById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAimOfPlanById_ShouldThrowArgumentException_WhenIdIsInvalid()
        {
            var aimId = -1;

            Assert.Throws<ArgumentException>(() => _service.GetAimOfPlanById(aimId));
        }


        [TestMethod]
        public void GetAllAimOfPlans_ShouldReturnListOfDtos()
        {
            var result = _service.GetAllAimsOfPlan();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<AimOfPlanDTO>));
        }

        [TestMethod]
        public void GetAllAimOfPlans_ShouldReturnCorrectNumberOfDtos()
        {
            var result = _service.GetAllAimsOfPlan();
            var numOfAims = _aims.Count;

            Assert.IsNotNull(result);
            Assert.HasCount(numOfAims, result);
        }
    }
}