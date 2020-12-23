using Newtonsoft.Json;

namespace WeatherForecast.Data.OpenWeather.Dto
{
    public class ResponseBase
    {
        [JsonProperty("cod")]
        public int Code { get; set; }
    }
}