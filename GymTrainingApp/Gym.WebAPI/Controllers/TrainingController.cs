using Gym.Business.Services;
using Gym.Business.Services.TrainingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }


        // (GET) - Calls the TrainingService to get a training by id.
        [HttpGet("{id}")]
        public IActionResult GetTrainingById(int id)
        {
            var training = _trainingService.GetTrainingById(id);
            if (training == null)
            {
                return NotFound();
            }
            return Ok(training);
        }


        // (GET) - Calls the TrainingService to get all trainings for a plan by plan id.
        [HttpGet("plan/{idPlan}")]
        public IActionResult GetAllTrainingsByPlanId(int idPlan)
        {
            var trainings = _trainingService.GetTrainingsByPlan(idPlan);
            if (trainings == null || trainings.Count == 0)
            {
                return NotFound();
            }
            return Ok(trainings);
        }


        // (POST) - Calls the TrainingService to create a new training for a plan id.
        [HttpPost]
        public IActionResult CreateTraining(int idPlan)
        {
            if (idPlan <= 0)
            {
                return BadRequest();
            }

            var createdTraining = _trainingService.CreateTraining(idPlan);
            var createdTrainingDto = _trainingService.GetTrainingById(createdTraining.Id);

            if (createdTrainingDto == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Training was created but could not be loaded.");
            }

            return CreatedAtAction(nameof(GetTrainingById), new { id = createdTraining.Id }, createdTrainingDto);
        }


        // (PUT) - Calls the TrainingService to update a training by id.
        [HttpPut("{id}")]
        public IActionResult UpdateTraining(int id, [FromBody] UpdateTrainingDto request)
        {
            var updatedTraining = _trainingService.UpdateTraining(id, request.Date, request.IdTrainingTypeSequence);
            if (updatedTraining == null)
            {
                return NotFound();
            }
            return Ok(updatedTraining);
        }


        // (DELETE) - Calls the TrainingService to delete a training by id.
        [HttpDelete("{id}")]
        public IActionResult DeleteTraining(int id)
        {
            var success = _trainingService.DeleteTraining(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

public record UpdateTrainingDto(DateOnly Date, int IdTrainingTypeSequence);