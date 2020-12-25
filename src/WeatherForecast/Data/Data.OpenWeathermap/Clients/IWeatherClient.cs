using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Weather;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    public interface IWeatherClient
    {
        Task<WeatherResponse> GetByCityName(string name);
        Task<WeatherResponse> GetByZipCode(int code);
    }
}