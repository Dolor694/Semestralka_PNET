using Gym.Business.Services.TrainingTypeSequenceService;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingTypeSequenceController : ControllerBase
    {
        private readonly ITrainingTypeSequenceService _trainingTypeSequenceService;

        public TrainingTypeSequenceController(ITrainingTypeSequenceService trainingTypeSequenceService)
        {
            _trainingTypeSequenceService = trainingTypeSequenceService;
        }


        // (GET) - Calls the TrainingTypeSequenceService to get a training type sequence by id.
        [HttpGet("{id}")]
        public IActionResult GetTrainingTypeSequenceById(int id)
        {
            try
            {
                var sequence = _trainingTypeSequenceService.GetTrainingTypeSequenceById(id);
                if (sequence == null)
                {
                    return NotFound();
                }

                return Ok(new TrainingTypeSequenceDto(
                    sequence.Id,
                    sequence.OrderInCycle,
                    sequence.IdTrainingType,
                    sequence.IdMuscleGroup));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public record TrainingTypeSequenceDto(int Id, int OrderInCycle, int IdTrainingType, int IdMuscleGroup);
}