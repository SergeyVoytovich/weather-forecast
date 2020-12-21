using System;

namespace Common.Interfaces.Models
{
    public interface IWeather
    {
        DateTime DateTime { get; set; }
        bool IsCurrent => DateTime.Date == DateTime.Now.Date;
        decimal Temperature { get; set; }
        decimal Humidity { get; set; }
        decimal WindSpeed { get; set; }
    }
}