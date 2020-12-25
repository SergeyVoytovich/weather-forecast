using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Forecast
{
    public class ForecastResponse : ResponseBase
    {
        [JsonProperty("city")]
        public City City { get; set; }
        
        [JsonProperty("list")]
        public IList<ForecastItem> Items { get; set; }
    }
}