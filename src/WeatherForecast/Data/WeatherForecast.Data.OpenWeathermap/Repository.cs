using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherForecast.Common.Data;
using WeatherForecast.Common.Models;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;
using WeatherForecast.Data.OpenWeather.Dto.Weather;
using City = WeatherForecast.Common.Models.City;

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

        private ICity ConvertWeatherResponse(WeatherResponse dto)
        {
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

            var result = ConvertWeatherResponse(dto);
            return result;
        }

        public async Task<ICity> GetWeatherAsync(int zipCode)
        {
            var dto = await _client.GetCurrentWeatherByZipCode(zipCode);
            if (dto is null)
            {
                return null;
            }

            var result = ConvertWeatherResponse(dto);
            return result;
        }

        public async Task LoadForecast(ICity city)
        {
            if (city is null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            ForecastResponse dto;
            if (city.Id > 0)
            {
                dto = await _client.GetForecastWeatherByCityId(city.Id);
            }
            else if(!string.IsNullOrWhiteSpace(city.Name))
            {
                dto = await _client.GetForecastWeatherByCityName(city.Name);
            }
            else
            {
                throw new InvalidOperationException("Unable to load forecast for city");
            }

            if (dto?.Items?.Any() != true)
            {
                return;
            }
            
            city.Weather ??= new List<IWeather>();
            foreach (var item in dto.Items.GroupBy(i => i.Date))
            {
                city.Weather.Add(new Weather
                {
                    Date = item.Key,
                    Temperature = item.Average(i => i.Main?.Temperature ?? 0),
                    Pressure = item.Average(i => i.Main?.Pressure ?? 0),
                    Humidity = item.Average(i => i.Main?.Humidity ?? 0),
                    WindSpeed = item.Average(i => i.Wind?.Speed ?? 0),
                });
            }
        }

        #endregion
    }
}