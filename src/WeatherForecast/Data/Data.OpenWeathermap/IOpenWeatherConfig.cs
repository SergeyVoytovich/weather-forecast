namespace WeatherForecast.Data.OpenWeather
{
    /// <summary>
    /// Configuration for open weather map 
    /// </summary>
    public interface IOpenWeatherConfig
    {
        /// <summary>
        /// Api key
        /// </summary>
        string ApiKey { get; }
    }
}