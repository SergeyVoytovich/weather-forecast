using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto.Forecast
{
    public class ForecastMain : Main
    {
        [JsonProperty("temp_min")]
        public decimal TemperatureMinimal { get; set; }
        
        [JsonProperty("temp_max")]
        public decimal TemperatureMaximal { get; set; }
    }
}