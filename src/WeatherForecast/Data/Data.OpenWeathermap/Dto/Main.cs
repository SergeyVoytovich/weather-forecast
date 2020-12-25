using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto
{
    public class Main
    {
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }
        
        [JsonProperty("pressure")]
        public decimal Pressure { get; set; }
        
        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }
    }
}