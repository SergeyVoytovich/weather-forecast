using System.Threading.Tasks;
using WeatherForecast.Common.Models;

namespace WeatherForecast.Common.Data
{
    /// <summary>
    /// Interface for repository 
    /// </summary>
    public interface IWeatherRepository
    {
        /// <summary>
        /// Get city weather by city name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ICity> GetAsync(string name);

        /// <summary>
        /// Get city weather by city yip code
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<ICity> GetAsync(int zipCode);
    }
}