using Gym.Business.Services.MuscleGroupService;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupController : ControllerBase
    {
        private readonly IMuscleGroupService _muscleGroupService;

        public MuscleGroupController(IMuscleGroupService muscleGroupService)
        {
            _muscleGroupService = muscleGroupService;
        }


        // (GET) - Calls the MuscleGroupService to get a muscle group by id.
        [HttpGet("{id}")]
        public IActionResult GetMuscleGroupById(int id)
        {
            try
            {
                var muscleGroup = _muscleGroupService.GetMuscleGroupById(id);
                if (muscleGroup == null)
                {
                    return NotFound();
                }

                return Ok(muscleGroup);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}