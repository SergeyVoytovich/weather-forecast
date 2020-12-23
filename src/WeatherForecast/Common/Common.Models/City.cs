using System.Collections.Generic;

namespace WeatherForecast.Common.Models
{
    public class City : ICity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public IList<IWeather> Weather { get; set; }
    }
}