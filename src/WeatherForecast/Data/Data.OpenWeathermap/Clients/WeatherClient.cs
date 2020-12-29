using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Weather;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    /// <summary>
    /// Weather service client
    /// </summary>
    public class WeatherClient : ClientBase<WeatherResponse>, IWeatherClient
    {
        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="client">Http client</param>
        /// <param name="apiKey">API key</param>
        public WeatherClient(HttpClient client, string apiKey) : base(client, apiKey)
        {
        }

        #endregion

        
        #region Methods

        /// <summary>
        /// Get URI builder
        /// </summary>
        /// <returns>OpenWeatherUriBuilder</returns>
        protected override OpenWeatherUriBuilder UriBuilder() 
            => base.UriBuilder().Weather();

        /// <summary>
        /// Get weather by city name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Weather</returns>
        public async Task<WeatherResponse> GetByCityNameAsync(string name) 
            => await Run(UriBuilder().CityName(name));

        /// <summary>
        /// Get weather by zip code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Weather</returns>
        public async Task<WeatherResponse> GetByZipCodeAsync(int code)
            => await Run(UriBuilder().ZipCode(code));

        #endregion
    }
}