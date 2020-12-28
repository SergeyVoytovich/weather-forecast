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
    public class Application : IApplication
    {
        private readonly IDatabase _database;

        public Application(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

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

            await _database.Forecast.LoadAsync(city);
            city.Weather = GetAverageWeather(city.Weather);
            
            return city;
        }

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
        
        private enum GettingMode
        {
            ByCityName = 0,
            ByZipCode = 1,
            Unknown = int.MinValue
        }

        private GettingMode DetectGettingMode(string query) 
            => Regex.IsMatch(query, "^[0-9]*$") ? GettingMode.ByZipCode : GettingMode.ByCityName;
    }
}