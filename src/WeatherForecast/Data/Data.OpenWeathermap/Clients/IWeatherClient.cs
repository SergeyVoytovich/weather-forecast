using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Weather;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    public interface IWeatherClient
    {
        Task<WeatherResponse> GetByCityNameAsync(string name);
        Task<WeatherResponse> GetByZipCodeAsync(int code);
    }
}