using System;

namespace WeatherForecast.Data.OpenWeather.Repositories
{
    public class OpenWeatherConfig : IOpenWeatherConfig
    {
        public OpenWeatherConfig(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            }
            
            ApiKey = apiKey;
        }

        public string ApiKey { get; }
    }
}