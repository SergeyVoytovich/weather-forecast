using System.Collections.Generic;

namespace WeatherForecast.Common.Models
{
    /// <summary>
    /// Model to store data of city
    /// </summary>
    public interface ICity
    {
        /// <summary>
        /// City ID
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// City zip code
        /// </summary>
        int ZipCode { get; set; }
        /// <summary>
        /// Weather list
        /// </summary>
        IList<IWeather> Weather { get; set; }
    }
}