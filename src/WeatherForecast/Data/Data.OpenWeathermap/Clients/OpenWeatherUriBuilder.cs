using System;
using System.Linq;

namespace WeatherForecast.Data.OpenWeather.Clients
{
    /// <summary>
    /// URI builder for open weather service
    /// </summary>
    public class OpenWeatherUriBuilder : UriBuilder
    {
        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="apiKey">API key</param>
        public OpenWeatherUriBuilder(string apiKey)
        {
            Host = Constants.Host;
            Path = Constants.Path;
            Scheme = Constants.Scheme;
            AddQuery(Constants.ApiKey, apiKey);
        }

        #endregion

        #region Methods

        #region Private methods

        /// <summary>
        /// Add key value pair to query string
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        private void AddQuery(string key, string value)
        {
            Query = string.Join("&", new[]{Query, $"{key}={value}"}.Where(i => !string.IsNullOrWhiteSpace(i)));
        }

        /// <summary>
        /// Add string to path
        /// </summary>
        /// <param name="path"></param>
        private void AddPath(string path)
        {
            Path = System.IO.Path.Combine(Path, path);
        }

        #endregion
        
        /// <summary>
        /// set weather parameter
        /// </summary>
        /// <returns>OpenWeatherUriBuilder</returns>
        public OpenWeatherUriBuilder Weather()
        {
            AddPath(Constants.Weather);
            return this;
        }

        /// <summary>
        /// Set forecast parameter
        /// </summary>
        /// <returns>OpenWeatherUriBuilder</returns>
        public OpenWeatherUriBuilder Forecast()
        {
            AddPath(Constants.Forecast);
            return this;
        }

        /// <summary>
        /// Set city name parameter
        /// </summary>
        /// <param name="name">City name</param>
        /// <returns>OpenWeatherUriBuilder</returns>
        public OpenWeatherUriBuilder CityName(string name)
        {
            AddQuery(Constants.CityNameKey, name);
            return this;
        }

        /// <summary>
        /// Set zip code parameter
        /// </summary>
        /// <param name="zip">Zip code</param>
        /// <returns>OpenWeatherUriBuilder</returns>
        public OpenWeatherUriBuilder ZipCode(int zip)
        {
            AddQuery(Constants.ZipCodeKey, $"{zip},{Constants.CountryCode}");
            return this;
        }

        /// <summary>
        /// Set id parameter
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>OpenWeatherUriBuilder</returns>
        public OpenWeatherUriBuilder Id(int id)
        {
            AddQuery(Constants.IdKey, id.ToString());
            return this;
        }

        /// <summary>
        /// Set units parameter
        /// </summary>
        /// <param name="units">Units</param>
        /// <returns>OpenWeatherUriBuilder</returns>
        public OpenWeatherUriBuilder Units(string units)
        {
            AddQuery(Constants.UnitsKey, units);
            return this;
        }

        /// <summary>
        /// Set metric units parameter
        /// </summary>
        /// <returns>OpenWeatherUriBuilder</returns>
        public OpenWeatherUriBuilder MetricUnits()
            => Units(Constants.Metric);

        #endregion
    }
}