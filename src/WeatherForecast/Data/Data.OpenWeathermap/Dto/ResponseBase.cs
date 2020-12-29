using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto
{
    /// <summary>
    /// Base data transfer object for response
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Response code
        /// </summary>
        [JsonProperty("cod")]
        public int Code { get; set; }
    }
}