using Gym.Business.Services.UserService;
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


        // (GET) - Calls the UserService to get a user by id.
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


        // (POST) - Calls the UserService to authenticate a user with username and password.
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.LoginUser(request.Username, request.Password);
            return user != null ? Ok(user) : Unauthorized("Invalid credentials");
        }


        // (POST) - Calls the UserService to register a new user.
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


        // (PUT) - Calls the UserService to update user data.
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserUpdateDto updateData)
        {
            try
            {
                var updated = _userService.UpdateUser(updateData.Id, updateData.Username, updateData.Password, updateData.Weight);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

public record LoginRequest(string Username, string Password);
public record UserUpdateDto(int Id, string? Username, string? Password, double? Weight);
public record UserRegisterDto(string Username, string Password, double Weight);