using Gym.Business.Interfaces;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : ControllerBase
    {

        private readonly ITrainingPlanService _trainingPlanService;

        public TrainingPlanController(ITrainingPlanService trainingPlanService)
        {
            _trainingPlanService = trainingPlanService;
        }

        // GET: api/TrainingPlan/5
        [HttpGet("{id}")]
        public IActionResult GetTrainingPlanById(int id)
        {
            var trainingPlan = _trainingPlanService.GetTrainingPlanById(id);
            if (trainingPlan == null)
            {
                return NotFound();
            }
            return Ok(trainingPlan);
        }

        // GET: api/TrainingPlan/user/5
        [HttpGet("user/{userId}")]
        public IActionResult GetTrainingPlansByUserId(int userId)
        {
            var trainingPlans = _trainingPlanService.GetPlansByUserId(userId);
            return Ok(trainingPlans);
        }

        // POST: api/TrainingPlan
        [HttpPost("create")]
        public IActionResult CreateTrainingPlan([FromBody] TrainingPlanDto request)
        {
            try
            {
                var trainingPlan = _trainingPlanService.CreateTrainingPlan(request.PlanName,
                                                                           request.TrainingFrequency,
                                                                           request.UserId,
                                                                           request.IdTrainingType,
                                                                           request.IdAimOfTraining);
                return Ok(trainingPlan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/TrainingPlan/5
        [HttpPut("{id}")]
        public IActionResult UpdateTrainingPlan(int id, [FromBody] TrainingPlanDto request)
        {
            try
            {
                var updatedPlan = _trainingPlanService.UpdateTrainingPlan(id,
                                                                           request.PlanName,
                                                                           request.TrainingFrequency,
                                                                           request.IdTrainingType,
                                                                           request.IdAimOfTraining);
                return Ok(updatedPlan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/TrainingPlan/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTrainingPlan(int id)
        {
            bool isDeleted = _trainingPlanService.DeleteTrainingPlan(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

public record TrainingPlanDto(string PlanName, int TrainingFrequency, int UserId, int IdTrainingType, int IdAimOfTraining);