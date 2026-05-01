using Gym.Business.Interfaces;
using Microsoft.AspNetCore.Http;
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
