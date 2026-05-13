using Gym.Business.Services.TrainingTypeService;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingTypeController : ControllerBase
    {
        private readonly ITrainingTypeService _trainingTypeService;

        public TrainingTypeController(ITrainingTypeService trainingTypeService)
        {
            _trainingTypeService = trainingTypeService;
        }


        // (GET) - Calls the TrainingTypeService to get all training types from the database.
        [HttpGet]
        public IActionResult GetAllTrainingTypes()
        {
            var trainingTypes = _trainingTypeService.GetAllTrainingTypes();
            return Ok(trainingTypes);
        }


        // (GET) - Calls the TrainingTypeService to get a training type by id from the database.
        [HttpGet("{id}")]
        public IActionResult GetTrainingTypeById(int id)
        {
            try
            {
                var trainingType = _trainingTypeService.GetTrainingTypeById(id);
                if (trainingType == null)
                {
                    return NotFound();
                }

                return Ok(trainingType);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}