using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    public class WeatherResponse : ResponseBase
    {
        [JsonProperty("id")]
        public int CityId { get; set; }
        
        [JsonProperty("name")]
        public string CityName { get; set; }
        
        [JsonProperty("main")]
        public Main Main { get; set; }
        
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
}