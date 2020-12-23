using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Data.OpenWeather.Dto.Forecast;
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
        
        public async Task<WeatherResponse> GetCurrentWeatherByCityName(string name)
        {
            var body = await Run(UriBuilder().Weather().CityName(name).ToString());
            var response = JsonConvert.DeserializeObject<WeatherResponse>(body);
            return response;
        }
        
        public async Task<WeatherResponse> GetCurrentWeatherByZipCode(int code)
        {
            var body = await Run(UriBuilder().Weather().ZipCode(code).ToString());
            var response = JsonConvert.DeserializeObject<WeatherResponse>(body);
            return response;
        }
        
        public async Task<ForecastResponse> GetForecastWeatherByCityName(string name)
        {
            var body = await Run(UriBuilder().Forecast().CityName(name).ToString());
            var response = JsonConvert.DeserializeObject<ForecastResponse>(body);
            return response;
        }
        
        public async Task<ForecastResponse> GetForecastWeatherByCityId(int id)
        {
            var body = await Run(UriBuilder().Forecast().Id(id).ToString());
            var response = JsonConvert.DeserializeObject<ForecastResponse>(body);
            return response;
        }
    }
}