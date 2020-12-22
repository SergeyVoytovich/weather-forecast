using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WeatherForecast.Data.OpenWeathermap
{
    public class WeathermapUriBuilder : UriBuilder
    {
        public WeathermapUriBuilder(string apiKey)
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
        
        public WeathermapUriBuilder Weather()
        {
            AddPath(Constants.Weather);
            return this;
        }

        public WeathermapUriBuilder Forecast()
        {
            AddPath(Constants.Forecast);
            return this;
        }

        public WeathermapUriBuilder CityName(string name)
        {
            AddQuery(Constants.CityNameKey, name);
            return this;
        }

        public WeathermapUriBuilder ZipCode(int zip)
        {
            AddQuery(Constants.ZipCodeKey, $"{zip},{Constants.CountryCode}");
            return this;
        }

        public WeathermapUriBuilder Id(int id)
        {
            AddQuery(Constants.IdKey, id.ToString());
            return this;
        }
    }
}