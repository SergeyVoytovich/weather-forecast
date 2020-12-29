using System;

namespace WeatherForecast.Common.Models
{
    /// <summary>
    /// Model to store weather data
    /// </summary>
    public class Weather : IWeather
    {
        /// <summary>
        /// Date time of weather data
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Temperature
        /// </summary>
        public decimal Temperature { get; set; }
        /// <summary>
        /// Humidity
        /// </summary>
        public decimal Humidity { get; set; }
        /// <summary>
        /// WindSpeed
        /// </summary>
        public decimal WindSpeed { get; set; }
        /// <summary>
        /// Pressure
        /// </summary>
        public decimal Pressure { get; set; }
    }
}