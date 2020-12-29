using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    /// <summary>
    /// Forecast service client
    /// </summary>
    public class ForecastClient : ClientBase<ForecastResponse>, IForecastClient
    {
        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="client">Http client</param>
        /// <param name="apiKey">API key</param>
        public ForecastClient(HttpClient client, string apiKey) : base(client, apiKey)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get URI builder
        /// </summary>
        /// <returns>OpenWeatherUriBuilder</returns>
        protected override OpenWeatherUriBuilder UriBuilder() 
            => base.UriBuilder().Forecast();

        /// <summary>
        /// Get forecast by name
        /// </summary>
        /// <param name="name">City name</param>
        /// <returns>Forecast</returns>
        public async Task<ForecastResponse> GetByCityNameAsync(string name)
            => await Run(UriBuilder().CityName(name));

        /// <summary>
        /// Get forecast by id
        /// </summary>
        /// <param name="id">City id</param>
        /// <returns>Forecast</returns>
        public async Task<ForecastResponse> GetByIdAsync(int id)
            =>  await Run(UriBuilder().Id(id));

        #endregion
    }
}