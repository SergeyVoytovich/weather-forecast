using System.Threading.Tasks;
using WeatherForecast.Common.Models;

namespace WeatherForecast.Common.Data
{
    /// <summary>
    /// Interfaces for forecast repository
    /// </summary>
    public interface IForecastRepository
    {
        /// <summary>
        /// Load forecast for city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task LoadAsync(ICity city);
    }
}