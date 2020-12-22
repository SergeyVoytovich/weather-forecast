using System;
using System.Linq;

namespace WeatherForecast.Data.OpenWeather
{
    public class OpenWeatherUriBuilder : UriBuilder
    {
        public OpenWeatherUriBuilder(string apiKey)
        {
            Host = Constants.Host;
            Path = Constants.Path;
            Scheme = Constants.Scheme;
            AddQuery(Constants.ApiKey, apiKey);
        }

        private void AddQuery(string key, string value)
        {
            Query = string.Join("&", new[]{Query, $"{key}={value}"}.Where(i => !string.IsNullOrWhiteSpace(i)));
        }

        private void AddPath(string path)
        {
            Path = System.IO.Path.Combine(Path, path);
        }
        
        public OpenWeatherUriBuilder Weather()
        {
            AddPath(Constants.Weather);
            return this;
        }

        public OpenWeatherUriBuilder Forecast()
        {
            AddPath(Constants.Forecast);
            return this;
        }

        public OpenWeatherUriBuilder CityName(string name)
        {
            AddQuery(Constants.CityNameKey, name);
            return this;
        }

        public OpenWeatherUriBuilder ZipCode(int zip)
        {
            AddQuery(Constants.ZipCodeKey, $"{zip},{Constants.CountryCode}");
            return this;
        }

        public OpenWeatherUriBuilder Id(int id)
        {
            AddQuery(Constants.IdKey, id.ToString());
            return this;
        }
    }
}