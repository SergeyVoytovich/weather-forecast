using System;
using System.Net.Http;
using WeatherForecast.Common.Data;
using WeatherForecast.Data.OpenWeather.Clients;
using WeatherForecast.Data.OpenWeather.Repositories;

namespace WeatherForecast.Data.OpenWeather
{
    public class Database : IDatabase
    {
        public Database(HttpClient client, IOpenWeatherConfig config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            
            Weather = new WeatherRepository(new WeatherClient(client, config.ApiKey));
            Forecast = new ForecastRepository(new ForecastClient(client, config.ApiKey));
        }

        public IWeatherRepository Weather { get; }
        public IForecastRepository Forecast { get; }
    }
}