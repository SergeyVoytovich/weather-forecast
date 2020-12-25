using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Forecast
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}