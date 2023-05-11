using Weather_Api.Classes;

namespace Weather_Api.Services
{
    public interface IWeatherApiFilter
    {
        ModifiedApiResponse FilterWeatherApiResponseToModifiedResponse(WeatherApiResponse countries, string theAlias);
    }
}
