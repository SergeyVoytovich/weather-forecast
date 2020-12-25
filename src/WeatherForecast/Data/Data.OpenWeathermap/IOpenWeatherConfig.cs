namespace WeatherForecast.Data.OpenWeather.Repositories
{
    /// <summary>
    /// Configuration for open weather map 
    /// </summary>
    public interface IOpenWeatherConfig
    {
        string ApiKey { get; }
    }
}