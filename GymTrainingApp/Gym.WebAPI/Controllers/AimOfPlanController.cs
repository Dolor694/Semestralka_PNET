using Gym.Business.Services.AimOfPLanService;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AimOfPlanController : ControllerBase
    {
        private readonly IAimOfPlanService _aimOfPlanService;

        public AimOfPlanController(IAimOfPlanService aimOfPlanService)
        {
            _aimOfPlanService = aimOfPlanService;
        }


        // (GET) - Calls the AimOfPlanService to get all aims of training from the database.
        [HttpGet]
        public IActionResult GetAllAimsOfPlan()
        {
            var aims = _aimOfPlanService.GetAllAimsOfPlan();
            return Ok(aims);
        }


        // (GET) - Calls the AimOfPlanService to get an aim of training by id from the database.
        [HttpGet("{id}")]
        public IActionResult GetAimOfPlanById(int id)
        {
            try
            {
                var aim = _aimOfPlanService.GetAimOfPlanById(id);
                if (aim == null)
                {
                    return NotFound();
                }

                return Ok(aim);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}