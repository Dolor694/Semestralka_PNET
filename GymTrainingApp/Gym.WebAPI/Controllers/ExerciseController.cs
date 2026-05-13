using Gym.Business.Services.ExerciseService;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }


        // (GET) - Calls the ExerciseService to get an exercise by id.
        [HttpGet("detail/{id}")]
        public IActionResult GetExerciseById(int id)
        {
            try
            {
                var exercise = _exerciseService.GetExerciseById(id);
                if (exercise == null)
                {
                    return NotFound();
                }

                return Ok(exercise);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // (GET) - Calls the ExerciseService to get all exercises by muscle group id.
        [HttpGet("{idMuscleGroup}")]
        public IActionResult GetExercisesByMuscleGroup(int idMuscleGroup)
        {
            try
            {
                var exercises = _exerciseService.GetExercisesByMuscleGroup(idMuscleGroup);
                return Ok(exercises);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
