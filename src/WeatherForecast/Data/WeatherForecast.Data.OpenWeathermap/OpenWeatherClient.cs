using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Data.OpenWeather.Dto.Weather;

namespace WeatherForecast.Data.OpenWeather
{
    public class OpenWeatherClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public OpenWeatherClient(HttpClient client, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            }
            
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _apiKey = apiKey;
        }

        private OpenWeatherUriBuilder UriBuilder() => new OpenWeatherUriBuilder(_apiKey);

        private async Task<string> Run(string uri)
        {
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        
        public async Task<Response> GetCurrentWeatherByCityName(string name)
        {
            var body = await Run(UriBuilder().Weather().CityName(name).ToString());
            var response = JsonConvert.DeserializeObject<Response>(body);
            return response;
        }
    }
}