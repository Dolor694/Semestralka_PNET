using Gym.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseInTrainingController : ControllerBase
    {

        private readonly IExerciseInTrainingService _exerciseInTrainingService;

        public ExerciseInTrainingController(IExerciseInTrainingService exerciseInTrainingService)
        {
            _exerciseInTrainingService = exerciseInTrainingService;
        }

        [HttpGet("{id}")]
        public IActionResult GetExerciseInTraining(int id)
        {
            var exerciseInTraining = _exerciseInTrainingService.GetExerciseInTrainingById(id);
            if (exerciseInTraining == null)
            {
                return NotFound();
            }
            return Ok(exerciseInTraining);
        }

        [HttpGet("training/{idTraining}")]
        public IActionResult GetExercisesByTrainingId(int idTraining)
        {
            var exercisesInTraining = _exerciseInTrainingService.GetExercisesByTrainingId(idTraining);
            if (exercisesInTraining == null || exercisesInTraining.Count == 0)
            {
                return NotFound();
            }
            return Ok(exercisesInTraining);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExerciseInTraining(int id, [FromBody] UpdateExerciseInTrainingDto request)
        {
            var updatedExerciseInTraining = _exerciseInTrainingService.UpdateExerciseInTraining(id, request.Sets, request.Reps, request.Order);
            if (updatedExerciseInTraining == null)
            {
                return NotFound();
            }
            return Ok(updatedExerciseInTraining);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExerciseInTraining(int id)
        {
            var deleted = _exerciseInTrainingService.DeleteExerciseInTraining(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateExerciseInTraining([FromBody] CreateExerciseInTrainingDto request)
        {
            var createdExerciseInTraining = _exerciseInTrainingService.CreateExerciseInTraining(request.Sets, 
                                                                                                request.Reps, 
                                                                                                request.Order, 
                                                                                                request.IdExercise, 
                                                                                                request.IdTraining);
            return CreatedAtAction(nameof(GetExerciseInTraining), new { id = createdExerciseInTraining.Id }, createdExerciseInTraining);
        }
    }
}

public record UpdateExerciseInTrainingDto(int? Sets, int? Reps, int? Order);
public record CreateExerciseInTrainingDto(int Sets, int Reps, int Order, int IdExercise, int IdTraining);
