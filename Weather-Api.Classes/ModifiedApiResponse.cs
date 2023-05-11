namespace Weather_Api.Classes
{
    public class ModifiedApiResponse
    {
		public string Alias { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public IDictionary<string,double> Hourly_temperature { get; set; }
	}
}
