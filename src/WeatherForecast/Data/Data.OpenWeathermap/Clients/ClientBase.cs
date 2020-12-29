using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Data.OpenWeather.Dto;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    /// <summary>
    /// Base open weather client
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ClientBase<T> where T : ResponseBase
    {
        #region Private members

        private readonly HttpClient _client;
        private readonly string _apiKey;

        #endregion

        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="client">Http client</param>
        /// <param name="apiKey">API key</param>
        /// <exception cref="ArgumentException">Throw if API key is null or empty</exception>
        protected ClientBase(HttpClient client, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            }
            
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _apiKey = apiKey;
        }

        #endregion

        
        #region Methods

        /// <summary>
        /// Get URI builder
        /// </summary>
        /// <returns>OpenWeatherUriBuilder</returns>
        protected virtual OpenWeatherUriBuilder UriBuilder() 
            => new OpenWeatherUriBuilder(_apiKey).MetricUnits();

        /// <summary>
        /// Run request
        /// </summary>
        /// <param name="builder">URI builder</param>
        /// <returns>Response</returns>
        protected async Task<T> Run(UriBuilder builder)
        {
            var uri = (builder ?? UriBuilder()).ToString();
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseBody);
            return result;
        }

        #endregion
    }
}