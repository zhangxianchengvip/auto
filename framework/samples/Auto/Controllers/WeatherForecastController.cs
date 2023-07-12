using Auto.Core.Caching;
using Auto.Core.Caching.Abstractions;
using Auto.Options;
using Auto.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Auto.Controllers
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
        private readonly Redis _redis;
        private readonly IUser _user;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsSnapshot<Redis> options, IUser user)
        {
            _logger = logger;
            _redis = options.Value;
            _user = user;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        [AutoCache]
        public virtual async Task<IEnumerable<WeatherForecast>> Get(User user)
        {
            var ss = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

            return ss;
        }
    }

    public record User(string name, int age);
}