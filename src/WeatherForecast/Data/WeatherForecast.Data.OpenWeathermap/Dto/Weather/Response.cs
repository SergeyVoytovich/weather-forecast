using System.Text.Json.Serialization;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    public class Response
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        
        [JsonPropertyName("id")]
        public int CityId { get; set; }
        
        [JsonPropertyName("name")]
        public string CityName { get; set; }
        
        [JsonPropertyName("main")]
        public Weather Weather { get; set; }
        
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }
}