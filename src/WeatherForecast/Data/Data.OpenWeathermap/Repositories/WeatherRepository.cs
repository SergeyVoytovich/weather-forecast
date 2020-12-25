using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Common.Data;
using WeatherForecast.Common.Models;
using WeatherForecast.Data.OpenWeather.Clients;
using WeatherForecast.Data.OpenWeather.Dto.Weather;
using City = WeatherForecast.Common.Models.City;

namespace WeatherForecast.Data.OpenWeather.Repositories
{
    /// <summary>
    /// Open weather map repository
    /// </summary>
    public class WeatherRepository : IWeatherRepository
    {
        #region Private members

        private readonly IWeatherClient _client;
        
        #endregion


        #region Constructors

        /// <summary>
        /// Initialize new instance
        /// </summary>
        /// <param name="client">Http client</param>
        public WeatherRepository(IWeatherClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        #endregion


        #region Methods

        private ICity ConvertWeatherResponse(WeatherResponse dto)
        {
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
        
        public async Task<ICity> GetAsync(string name)
        {
            var dto = await _client.GetByCityNameAsync(name);
            var result = ConvertWeatherResponse(dto);
            return result;
        }

        public async Task<ICity> GetAsync(int zipCode)
        {
            var dto = await _client.GetByZipCodeAsync(zipCode);
            var result = ConvertWeatherResponse(dto);
            return result;
        }

        #endregion

    }
}