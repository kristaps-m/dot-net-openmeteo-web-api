using Weather_Api.Classes;

namespace Weather_Api.Services
{
    public interface IWeatherService
    {
        Task<WeatherApiResponse> GetWeatherData(string alias, Location location);
    }
}