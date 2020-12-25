using Moq;
using WeatherForecast.Common.Data;

namespace WeatherForecast.ApplicationLayer.Tests
{
    internal class MockDatabase
    {
        private IDatabase _database;

        public IDatabase Object
        {
            get => _database ?? Build();
            set => _database = value;
        }

        public Mock<IForecastRepository> Forecast { get; set; } = new Mock<IForecastRepository>();
        public Mock<IWeatherRepository> Weather { get; set; } = new Mock<IWeatherRepository>();

        protected virtual IDatabase Build()
        {
            var mock = new Mock<IDatabase>();
            mock.Setup(i => i.Forecast).Returns(Forecast.Object);
            mock.Setup(i => i.Weather).Returns(Weather.Object);
            return mock.Object;
        }
    }
}