using Newtonsoft.Json;
using Weather_Api.Classes;

namespace Weather_Api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherApiResponse> GetWeatherData(string alias, Location location)
        {
            var latitude = location.Latitude;
            var longitude = location.Longitude;
            var apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m";

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                WeatherApiResponse weatherData = JsonConvert.DeserializeObject<WeatherApiResponse>(content);
                return weatherData;
            }

            return null;
        }
    }
}
