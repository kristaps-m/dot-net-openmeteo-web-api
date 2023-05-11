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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IWeatherApiFilter _weatherApiFilter;

        public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IWeatherApiFilter weatherApiFilter)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _weatherApiFilter = weatherApiFilter;
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

            var latitude = location.Latitude;
            var longitude = location.Longitude;
            var apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m";

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                WeatherApiResponse myObject = JsonConvert.DeserializeObject<WeatherApiResponse>(content);
                var modifiedResponse = _weatherApiFilter.FilterWeatherApiResponseToModifiedResponse(myObject, alias);
                return Ok(modifiedResponse);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}

