using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Weather_Api.Classes;
using Weather_Api.Services;

namespace Weather_Api.Controllers
{
    [Route("weather-api")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWeatherApiFilter _weatherApiFilter;
        private readonly IWeatherService _weatherService;

        public WeatherController(IConfiguration configuration,
            IWeatherApiFilter weatherApiFilter, IWeatherService weatherService)
        {
            _configuration = configuration;
            _weatherApiFilter = weatherApiFilter;
            _weatherService = weatherService;
        }

        [HttpGet("locations/{alias}/temperature")]
        public async Task<IActionResult> GetTemperature(string alias)
        {
            var locations = _configuration.GetSection("Locations").Get<List<Location>>();
            var location = locations.Find(l => l.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase));

            if (location == null)
            {
                return NotFound($"Location with alias '{alias}' not found.");
            }

            var weatherData = await _weatherService.GetWeatherData(alias, location);
            var modifiedResponse = _weatherApiFilter.FilterWeatherApiResponseToModifiedResponse(weatherData, alias);

            return Ok(modifiedResponse);
        }
    }
}

