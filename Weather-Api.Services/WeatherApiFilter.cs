using Weather_Api.Classes;

namespace Weather_Api.Services
{
    public class WeatherApiFilter : IWeatherApiFilter
	{
		public ModifiedApiResponse FilterWeatherApiResponseToModifiedResponse(WeatherApiResponse countries, string theAlias)
		{
			IDictionary<string, double> hourlyDictionary = new Dictionary<string, double>();

			for (var i = 0; i < countries.hourly.time.Count; i++)
			{
                try
                {
					hourlyDictionary.Add(fromDateTimeToHours(countries.hourly.time[i]),
						countries.hourly.temperature_2m[i]);
                }
                catch
                {
					break;
                }
			}

			var emptyModifiedApiResponse = new ModifiedApiResponse()
			{
				Alias = theAlias,
				Latitude = countries.Latitude,
				Longitude = countries.Longitude,
				Hourly_temperature = hourlyDictionary,
			};

			return emptyModifiedApiResponse;
		}

		string fromDateTimeToHours(DateTime datetime)
        {
			// "2023-05-11 00:00:00" => "00:00"
			var date = datetime.ToString().Split(" ")[1];
			return date.Length == 7 ? "0"+date.Substring(0, 4) : date.Substring(0,5);
        }
	}
}
