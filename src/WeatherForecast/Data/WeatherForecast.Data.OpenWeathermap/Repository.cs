using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Interfaces.Models;

namespace WeatherForecast.Data.OpenWeather
{
    /// <summary>
    /// Open weather map repository
    /// </summary>
    public class Repository : IRepository
    {
        #region Private members

        private readonly HttpClient _client;
        private readonly IOpenWeatherConfig _config;

        #endregion
        
        
        #region Constructors

        /// <summary>
        /// Initialize new instance
        /// </summary>
        /// <param name="client">Http client</param>
        /// <param name="config">Configuration</param>
        public Repository(HttpClient client, IOpenWeatherConfig config)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        #endregion
        
        
        #region Methods

        public Task<ICity> GetWeatherAsync(string name)
        {
            throw new NotImplementedException();
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