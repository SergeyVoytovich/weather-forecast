using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherForecast.Common.ApplicationLayer;
using WeatherForecast.Common.Data;
using WeatherForecast.Common.Models;

namespace WeatherForecast.ApplicationLayer
{
    /// <summary>
    /// Application
    /// </summary>
    public class Application : IApplication
    {
        #region Private members

        private readonly IDatabase _database;

        #endregion

        
        #region Constuctors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="database">Database</param>
        public Application(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        #endregion

        
        #region Methods

        /// <summary>
        /// Get city current weather and forecast
        /// </summary>
        /// <param name="query">City name or zip code</param>
        /// <returns>City with current weather and forecast</returns>
        public async Task<ICity> GetAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }
            
            var city = DetectGettingMode(query) switch
            {
                GettingMode.ByCityName => await _database.Weather.GetAsync(query),
                GettingMode.ByZipCode => await _database.Weather.GetAsync(int.Parse(query)),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (city is null)
            {
                return null;
            }
            
            await _database.Forecast.LoadAsync(city);
            city.Weather = GetAverageWeather(city.Weather);
            
            return city;
        }

        /// <summary>
        /// Average data
        /// </summary>
        /// <param name="source">Source</param>
        /// <returns>Averaged data</returns>
        private IList<IWeather> GetAverageWeather(IList<IWeather> source)
            => source.GroupBy(i => i.Date.Date)
                .Select(grp => new Weather
                {
                    Date = grp.Key,
                    Temperature = grp.Average(i => i.Temperature),
                    Pressure = grp.Average(i => i.Pressure),
                    Humidity = grp.Average(i => i.Humidity),
                    WindSpeed = grp.Average(i => i.WindSpeed),
                }).ToList<IWeather>();
        
        /// <summary>
        /// Getting mode
        /// </summary>
        private enum GettingMode
        {
            // Get by city name
            ByCityName = 0,
            // Get by zip code
            ByZipCode = 1,
            // Unknown
            Unknown = int.MinValue
        }

        /// <summary>
        /// Detect getting mode
        /// </summary>
        /// <param name="query">City name or zip code</param>
        /// <returns>Getting mode</returns>
        private GettingMode DetectGettingMode(string query) 
            => Regex.IsMatch(query, "^[0-9]*$") ? GettingMode.ByZipCode : GettingMode.ByCityName;

        #endregion
    }
}