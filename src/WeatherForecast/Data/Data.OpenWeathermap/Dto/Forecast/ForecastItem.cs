using System;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Forecast
{
    /// <summary>
    /// Data transfer object for forecast data
    /// </summary>
    public class ForecastItem
    {
        /// <summary>
        /// Date time
        /// </summary>
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Wind data
        /// </summary>
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        
        /// <summary>
        /// Weather data
        /// </summary>
        [JsonProperty("main")]
        public Main Main { get; set; }
    }
}