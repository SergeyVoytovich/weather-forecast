using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Weather;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    public class WeatherClient : ClientBase<WeatherResponse>, IWeatherClient
    {
        public WeatherClient(HttpClient client, string apiKey) : base(client, apiKey)
        {
        }

        protected override OpenWeatherUriBuilder UriBuilder() 
            => base.UriBuilder().Weather();

        public async Task<WeatherResponse> GetByCityName(string name) 
            => await Run(UriBuilder().CityName(name));

        public async Task<WeatherResponse> GetByZipCode(int code)
            => await Run(UriBuilder().ZipCode(code));
    }
}