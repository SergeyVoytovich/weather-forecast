using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Weather;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    /// <summary>
    /// Weather service client
    /// </summary>
    public interface IWeatherClient
    {
        /// <summary>
        /// Get weather by city name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Weather</returns>
        Task<WeatherResponse> GetByCityNameAsync(string name);
        
        /// <summary>
        /// Get weather by zip code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Weather</returns>
        Task<WeatherResponse> GetByZipCodeAsync(int code);
    }
}