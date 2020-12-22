using System.Text.Json.Serialization;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public decimal Speed { get; set; }
    }
}