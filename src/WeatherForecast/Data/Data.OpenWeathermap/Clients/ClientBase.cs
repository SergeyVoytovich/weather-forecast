using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Data.OpenWeather.Dto;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    public abstract class ClientBase<T> where T : ResponseBase
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        protected ClientBase(HttpClient client, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            }
            
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _apiKey = apiKey;
        }

        protected virtual OpenWeatherUriBuilder UriBuilder() 
            => new OpenWeatherUriBuilder(_apiKey);

        protected async Task<T> Run(UriBuilder builder)
        {
            var uri = (builder ?? UriBuilder()).ToString();
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseBody);
            return result;

        }
    }
}