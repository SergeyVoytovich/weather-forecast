using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    public class ForecastClient : ClientBase<ForecastResponse>, IForecastClient
    {
        public ForecastClient(HttpClient client, string apiKey) : base(client, apiKey)
        {
        }

        protected override OpenWeatherUriBuilder UriBuilder() 
            => base.UriBuilder().Forecast();

        public async Task<ForecastResponse> GetByCityName(string name)
            => await Run(UriBuilder().CityName(name));

        public async Task<ForecastResponse> GetById(int id)
            =>  await Run(UriBuilder().Id(id));
    }
}