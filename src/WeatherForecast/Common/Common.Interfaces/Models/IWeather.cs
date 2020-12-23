using System;

namespace WeatherForecast.Common.Models
{
    /// <summary>
    /// Model to store weather data
    /// </summary>
    public interface IWeather
    {
        /// <summary>
        /// Date time of weather data
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// Is current weather
        /// </summary>
        bool IsCurrent => Date.Date == DateTime.Now.Date;
        /// <summary>
        /// Temperature
        /// </summary>
        decimal Temperature { get; set; }
        /// <summary>
        /// Humidity
        /// </summary>
        decimal Humidity { get; set; }
        /// <summary>
        /// WindSpeed
        /// </summary>
        decimal WindSpeed { get; set; }
        
        decimal Pressure { get; set; }
    }
}