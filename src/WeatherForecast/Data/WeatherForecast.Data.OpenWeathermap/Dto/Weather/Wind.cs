using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    public class Wind
    {
        [JsonProperty("speed")]
        public decimal Speed { get; set; }
    }
}