using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Common.Data;
using WeatherForecast.Common.Models;
using WeatherForecast.Data.OpenWeather.Clients;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;

namespace WeatherForecast.Data.OpenWeather.Repositories
{
    /// <summary>
    /// Open weather map repository
    /// </summary>
    public class ForecastRepository : IForecastRepository
    {
        #region Private members

        private readonly IForecastClient _client;

        #endregion


        #region Constructors

        /// <summary>
        /// Initialize new instance
        /// </summary>
        /// <param name="client">Http client</param>
        public ForecastRepository(IForecastClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        #endregion


        #region Methods

        public async Task LoadAsync(ICity city)
        {
            if (city is null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            ForecastResponse dto;
            if (city.Id > 0)
            {
                dto = await _client.GetByIdAsync(city.Id);
            }
            else if(!string.IsNullOrWhiteSpace(city.Name))
            {
                dto = await _client.GetByCityNameAsync(city.Name);
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
            foreach (var item in dto.Items)
            {
                city.Weather.Add(new Weather
                {
                    Date = item.Date,
                    Temperature = item.Main?.Temperature ?? 0,
                    Pressure = item.Main?.Pressure ?? 0,
                    Humidity = item.Main?.Humidity ?? 0,
                    WindSpeed = item.Wind?.Speed ?? 0,
                });
            }
        }

        #endregion
        
    }
}