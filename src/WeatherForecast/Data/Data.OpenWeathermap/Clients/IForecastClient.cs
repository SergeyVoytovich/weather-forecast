using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    public interface IForecastClient
    {
        Task<ForecastResponse> GetByCityNameAsync(string name);
        Task<ForecastResponse> GetByIdAsync(int id);
    }
}