using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Presentation.Api.Models
{
    public class CityModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weather")] 
        public IList<WeatherModel> Weather { get; set; } = new List<WeatherModel>();
    }
}