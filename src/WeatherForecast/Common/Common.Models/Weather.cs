using System;

namespace WeatherForecast.Common.Models
{
    public class Weather : IWeather
    {
        public DateTime DateTime { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
    }
}