using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    public class Response
    {
        [JsonProperty("cod")]
        public int Code { get; set; }
        
        [JsonProperty("id")]
        public int CityId { get; set; }
        
        [JsonProperty("name")]
        public string CityName { get; set; }
        
        [JsonProperty("main")]
        public Weather Weather { get; set; }
        
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
}