using System.Threading.Tasks;
using WeatherForecast.Common.Models;

namespace WeatherForecast.Common.ApplicationLayer
{
    /// <summary>
    /// Interface for application
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Get city weather and forecast
        /// </summary>
        /// <param name="query">Query for search (city name or city zipcode)</param>
        /// <returns></returns>
        Task<ICity> GetAsync(string query);
    }
}