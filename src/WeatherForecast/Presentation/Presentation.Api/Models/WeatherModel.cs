using System;
using System.Text.Json.Serialization;

namespace Presentation.Api.Models
{
    /// <summary>
    /// View model for weather data
    /// </summary>
    public class WeatherModel
    {
        /// <summary>
        /// Date
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Temperature
        /// </summary>
        [JsonPropertyName("temp")]
        public int Temperature { get; set; }
        
        /// <summary>
        /// Pressure
        /// </summary>
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        
        /// <summary>
        /// Humidity
        /// </summary>
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        
        /// <summary>
        /// WindSpeed
        /// </summary>
        [JsonPropertyName("speed")]
        public decimal WindSpeed { get; set; }
    }
}