using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Presentation.Api.Models
{
    /// <summary>
    /// View model for city data
    /// </summary>
    public class CityModel
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Weather data
        /// </summary>
        [JsonPropertyName("weather")] 
        public IList<WeatherModel> Weather { get; set; } = new List<WeatherModel>();
    }
}