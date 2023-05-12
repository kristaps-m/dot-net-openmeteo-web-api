# Weather-Api

- An simple ASP.NET Core Web API .NET 6 application.
- The API service is using a https://open-meteo.com/ API to gather the data for each specific location.
- You will be able to query a service with a name of known locations (Liepaja, Riga) and get a hourly forecast of the temperature for a whole day in this location.
- Send a GET request to a following URI:
  - https://localhost:8080/weather-api/locations/riga/temperature
  - https://localhost:8080/weather-api/locations/liepaja/temperature
- And as a response from this endpoint, will return following data:
```
{
	"alias": "riga",
	"latitude": 56.95,
	"longitude": 24.11,
	"hourly_temperature": {
	{
		"00:00": 5,
		"01:00": 4.5,
		"02:00": 4,
		...
		"18:00": 15,
		...
		"23:00": 8
	}
}
```