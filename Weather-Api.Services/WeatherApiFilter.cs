using Weather_Api.Classes;

namespace Weather_Api.Services
{
    public class WeatherApiFilter : IWeatherApiFilter
	{
		public ModifiedApiResponse FilterWeatherApiResponseToModifiedResponse(WeatherApiResponse countries, string theAlias)
		{
			IDictionary<string, double> hourlyDictionary = new Dictionary<string, double>();

			for (var i = 0; i < countries.Hourly.Time.Count; i++)
			{
                try
                {
					hourlyDictionary.Add(countries.Hourly.Time[i].ToString("HH:mm"),
						countries.Hourly.Temperature_2m[i]);
                }
                catch
                {
					break;
                }
			}

			var emptyModifiedApiResponse = new ModifiedApiResponse()
			{
				Alias = theAlias.ToLower(),
				Latitude = countries.Latitude,
				Longitude = countries.Longitude,
				Hourly_temperature = hourlyDictionary,
			};

			return emptyModifiedApiResponse;
		}
	}
}
