namespace WeatherForecast.Data.OpenWeathermap
{
    /// <summary>
    /// Configuration for open wathermap 
    /// </summary>
    public interface IOpenWeathermapConfig
    {
        string ApiKey { get; set; }
    }
}