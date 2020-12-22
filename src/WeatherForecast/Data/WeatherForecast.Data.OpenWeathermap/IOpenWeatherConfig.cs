namespace WeatherForecast.Data.OpenWeather
{
    /// <summary>
    /// Configuration for open weather map 
    /// </summary>
    public interface IOpenWeatherConfig
    {
        string ApiKey { get; set; }
    }
}