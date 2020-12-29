using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto
{
    /// <summary>
    /// Data transfer object for main weather data
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Temperature
        /// </summary>
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }
        
        /// <summary>
        /// Pressure
        /// </summary>
        [JsonProperty("pressure")]
        public decimal Pressure { get; set; }
        
        /// <summary>
        /// Humidity
        /// </summary>
        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }
    }
}