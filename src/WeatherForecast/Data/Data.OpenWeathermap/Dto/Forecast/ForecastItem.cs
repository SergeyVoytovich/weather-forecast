using System;
using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Forecast
{
    public class ForecastItem
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date { get; set; }
        
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        
        [JsonProperty("main")]
        public Main Main { get; set; }
    }
}