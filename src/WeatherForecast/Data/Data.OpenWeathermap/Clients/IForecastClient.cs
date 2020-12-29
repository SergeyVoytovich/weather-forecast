using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    /// <summary>
    /// Forecast service client
    /// </summary>
    public interface IForecastClient
    {
        /// <summary>
        /// Get forecast by name
        /// </summary>
        /// <param name="name">City name</param>
        /// <returns>Forecast</returns>
        Task<ForecastResponse> GetByCityNameAsync(string name);
        
        /// <summary>
        /// Get forecast by id
        /// </summary>
        /// <param name="id">City id</param>
        /// <returns>Forecast</returns>
        Task<ForecastResponse> GetByIdAsync(int id);
    }
}