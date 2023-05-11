namespace Weather_Api.Classes
{
    public class WeatherApiResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Decimal Generationtime_ms { get; set; }
        public int Utc_offset_seconds { get; set; }
        public string? Timezone { get; set; }
        public string? Timezone_abbreviation { get; set; }
        public double Elevation { get; set; }
        public HourlyUnits hourly_units { get; set; }
        public Hourly hourly { get; set; }
        public class HourlyUnits
        {
            public string time { get; set; }
            public string temperature_2m { get; set; }
        }
        public class Hourly
        {
            public List<DateTime> time { get; set; }
            public List<double> temperature_2m { get; set; }
        }

        //public Object? Hourly_units { get; set; }
        //public Object? Hourly { get; set; }
    }
}
