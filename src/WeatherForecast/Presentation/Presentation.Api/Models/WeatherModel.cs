using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Presentation.Api.Models
{
    public class WeatherModel
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("temp")]
        public int Temperature { get; set; }
        
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        
        [JsonPropertyName("speed")]
        public decimal WindSpeed { get; set; }
    }
}