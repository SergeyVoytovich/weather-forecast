using System.Collections.Generic;

namespace WeatherForecast.Common.Models
{
    /// <summary>
    /// Model to store data of city
    /// </summary>
    public class City : ICity
    {
        /// <summary>
        /// City ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Weather list
        /// </summary>
        public IList<IWeather> Weather { get; set; }
    }
}