using Gym.Business.Interfaces;
using Gym.Business.Services;
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

        [HttpPost]
        public IActionResult CreateTraining(int idPlan)
        {
            if (idPlan <= 0)
            {
                return BadRequest();
            }
            var createdTraining = _trainingService.CreateTraining(idPlan);
            return CreatedAtAction(nameof(GetTrainingById), new { id = createdTraining.Id }, createdTraining);
        }

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