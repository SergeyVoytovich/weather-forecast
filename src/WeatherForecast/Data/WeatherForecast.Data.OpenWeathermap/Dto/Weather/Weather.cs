using System.Text.Json.Serialization;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    public class Weather
    {
        [JsonPropertyName("temp")]
        public decimal Temperature { get; set; }
        
        [JsonPropertyName("pressure")]
        public decimal Pressure { get; set; }
        
        [JsonPropertyName("humidity")]
        public decimal Humidity { get; set; }
    }
}