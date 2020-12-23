using System;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Forecast
{
    public class ForecastItem
    {
        [JsonProperty("dt")]
        public DateTime Date { get; set; }
        
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        
        [JsonProperty("main")]
        public ForecastMain Main { get; set; }
    }
}