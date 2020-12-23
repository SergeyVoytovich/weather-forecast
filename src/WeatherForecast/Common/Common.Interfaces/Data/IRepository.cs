using System.Threading.Tasks;
using WeatherForecast.Common.Models;

namespace WeatherForecast.Common.Data
{
    /// <summary>
    /// Interface for repository 
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Get city weather by city name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ICity> GetWeatherAsync(string name);

        /// <summary>
        /// Get city weather by city yip code
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<ICity> GetWeatherAsync(int zipCode);

        /// <summary>
        /// Load forecast for current city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task LoadForecast(ICity city);
    }
}