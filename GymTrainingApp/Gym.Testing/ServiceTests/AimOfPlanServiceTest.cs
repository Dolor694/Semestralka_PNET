using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class AimOfPlanServiceTest
    {
        private static AimOfPlanService _service = null!;
        private static List<AimOfPlan> _aims = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _aims =
            [
                new AimOfPlan { Id = 1, Description = "Strength" },
                new AimOfPlan { Id = 2, Description = "Hypertrophy" }
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