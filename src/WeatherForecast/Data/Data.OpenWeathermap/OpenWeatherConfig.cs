using System;

namespace WeatherForecast.Data.OpenWeather
{
    /// <summary>
    /// Configuration for open weather map 
    /// </summary>
    public class OpenWeatherConfig : IOpenWeatherConfig
    {

        #region Properties

        /// <summary>
        /// API key
        /// </summary>
        public string ApiKey { get; }

        #endregion
        
        
        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="apiKey">API key</param>
        /// <exception cref="ArgumentException">Throw exception if API key is null or empty</exception>
        public OpenWeatherConfig(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(apiKey));
            }
            
            ApiKey = apiKey;
        }

        #endregion

        
    }
}