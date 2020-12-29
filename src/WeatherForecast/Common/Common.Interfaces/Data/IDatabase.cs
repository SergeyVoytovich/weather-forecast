namespace WeatherForecast.Common.Data
{
    /// <summary>
    /// Interface for Database
    /// </summary>
    /// <remarks>Database is like a repositories collection</remarks>
    public interface IDatabase
    {
        /// <summary>
        /// Weather repository
        /// </summary>
        IWeatherRepository Weather { get; }
        /// <summary>
        /// Forecast repository
        /// </summary>
        IForecastRepository Forecast { get; }
    }
}