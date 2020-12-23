using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Common.Data;
using WeatherForecast.Common.Models;

namespace WeatherForecast.Data.OpenWeather
{
    /// <summary>
    /// Open weather map repository
    /// </summary>
    public class Repository : IRepository
    {
        #region Private members

        private readonly OpenWeatherClient _client;

        #endregion


        #region Constructors

        /// <summary>
        /// Initialize new instance
        /// </summary>
        /// <param name="client">Http client</param>
        /// <param name="config">Configuration</param>
        public Repository(HttpClient client, IOpenWeatherConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            _client = new OpenWeatherClient(client, config.ApiKey);
        }

        #endregion


        #region Methods

        public async Task<ICity> GetWeatherAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var dto = await _client.GetCurrentWeatherByCityName(name);
            if (dto is null)
            {
                return null;
            }

            var result = new City
            {
                Id = dto.CityId,
                Name = dto.CityName,
                Weather = new List<IWeather>
                {
                    new Weather
                    {
                        Date = DateTime.Now,
                        Temperature = dto.Main?.Temperature ?? 0,
                        Humidity = dto.Main?.Humidity ?? 0,
                        WindSpeed = dto.Wind?.Speed ?? 0,
                        Pressure = dto.Main?.Pressure ?? 0
                    }
                }
            };
            return result;
        }

        public Task<ICity> GetWeatherAsync(int zipCode)
        {
            throw new NotImplementedException();
        }

        public Task LoadForecast(ICity city)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}