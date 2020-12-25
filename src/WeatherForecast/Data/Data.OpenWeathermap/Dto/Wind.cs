using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto
{
    public class Wind
    {
        [JsonProperty("speed")]
        public decimal Speed { get; set; }
    }
}