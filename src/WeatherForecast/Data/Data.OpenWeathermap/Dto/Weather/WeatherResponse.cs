using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Weather
{
    /// <summary>
    /// Data transfer object for weather response
    /// </summary>
    public class WeatherResponse : ResponseBase
    {
        /// <summary>
        /// city identifier
        /// </summary>
        [JsonProperty("id")]
        public int CityId { get; set; }
        
        /// <summary>
        /// City name
        /// </summary>
        [JsonProperty("name")]
        public string CityName { get; set; }
        
        /// <summary>
        /// Main weather data
        /// </summary>
        [JsonProperty("main")]
        public Main Main { get; set; }
        
        /// <summary>
        /// Wind data
        /// </summary>
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
}