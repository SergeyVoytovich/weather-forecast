using System.Threading.Tasks;
using WeatherForecast.Common.Models;

namespace WeatherForecast.Common.Data
{
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