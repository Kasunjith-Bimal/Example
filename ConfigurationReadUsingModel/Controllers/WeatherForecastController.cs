using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationReadUsingModel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase


    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        // we can Use IOptions or IOptionSnapshort 
        private readonly IOptionsSnapshot<MySettings> _mysettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsSnapshot<MySettings> mysettings)
        {
            _logger = logger;
            _mysettings = mysettings;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Name = _mysettings.Value.Name
            })
            .ToArray();
        }
    }
}