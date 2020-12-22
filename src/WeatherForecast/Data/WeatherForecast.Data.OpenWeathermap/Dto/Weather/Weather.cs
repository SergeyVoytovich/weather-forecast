using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    public class Weather
    {
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }
        
        [JsonProperty("pressure")]
        public decimal Pressure { get; set; }
        
        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }
    }
}