using Microsoft.AspNetCore.Mvc;

namespace Gym.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public ActionResult<IEnumerable<WeatherForecastDto>> Get()
    {
        var startDate = DateOnly.FromDateTime(DateTime.Now);

        var result = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecastDto(
                startDate.AddDays(index),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]))
            .ToArray();

        return Ok(result);
    }

    public sealed record WeatherForecastDto(DateOnly Date, int TemperatureC, string Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}