using System;
using System.Net.Http;
using WeatherForecast.Common.Data;
using WeatherForecast.Data.OpenWeather.Clients;
using WeatherForecast.Data.OpenWeather.Repositories;

namespace WeatherForecast.Data.OpenWeather
{
    /// <summary>
    /// Database
    /// </summary>
    public class OpenWeatherDatabase : IDatabase
    {

        #region Properties

        /// <summary>
        /// Weather repository
        /// </summary>
        public IWeatherRepository Weather { get; }
        
        /// <summary>
        /// Forecast repository
        /// </summary>
        public IForecastRepository Forecast { get; }

        #endregion
        
        
        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="client">Http client</param>
        /// <param name="config">Configuration</param>
        /// <exception cref="ArgumentNullException">Throws exception if config is null</exception>
        public OpenWeatherDatabase(HttpClient client, IOpenWeatherConfig config)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            
            Weather = new WeatherRepository(new WeatherClient(client, config.ApiKey));
            Forecast = new ForecastRepository(new ForecastClient(client, config.ApiKey));
        }

        #endregion

        
    }
}