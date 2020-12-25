namespace WeatherForecast.Common.Data
{
    public interface IDatabase
    {
        IWeatherRepository Weather { get; }
        IForecastRepository Forecast { get; }
    }
}