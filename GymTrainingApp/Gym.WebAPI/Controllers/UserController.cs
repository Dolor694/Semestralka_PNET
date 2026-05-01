using Gym.Business.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        // POST: api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.LoginUser(request.Username, request.Password);
            return user != null ? Ok(user) : Unauthorized("Invalid credentials");
        }


        // POST: api/users/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto request)
        {
            try
            {
                var user = _userService.CreateUser(request.Username, request.Password, request.Weight);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT: api/users/update-weight
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserUpdateDto updateData)
        {
            try
            {
                var updated = _userService.UpdateUser(updateData.Id, updateData.Username, null, updateData.Weight);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


// Helper records for the UserController
public record LoginRequest(string Username, string Password);
public record UserUpdateDto(int Id, string? Username, double? Weight);
public record UserRegisterDto(string Username, string Password, double Weight);