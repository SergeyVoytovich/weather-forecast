using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Forecast
{
    /// <summary>
    /// Data transfer object for forecast service response
    /// </summary>
    public class ForecastResponse : ResponseBase
    {
        /// <summary>
        /// City data
        /// </summary>
        [JsonProperty("city")]
        public City City { get; set; }
        
        /// <summary>
        /// Forecast items
        /// </summary>
        [JsonProperty("list")]
        public IList<ForecastItem> Items { get; set; }
    }
}