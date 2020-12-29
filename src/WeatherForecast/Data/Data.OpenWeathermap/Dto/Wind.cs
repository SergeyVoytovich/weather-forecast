using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto
{
    /// <summary>
    /// Data transfer object for wind data
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// Wind speed
        /// </summary>
        [JsonProperty("speed")]
        public decimal Speed { get; set; }
    }
}