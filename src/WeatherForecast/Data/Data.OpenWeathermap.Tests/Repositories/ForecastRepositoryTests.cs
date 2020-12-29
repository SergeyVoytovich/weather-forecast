using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherForecast.Common.Data;
using WeatherForecast.Common.Models;
using WeatherForecast.Data.OpenWeather.Clients;
using WeatherForecast.Data.OpenWeather.Repositories;

namespace WeatherForecast.Data.OpenWeather.Tests.Repositories
{
    public class ForecastRepositoryTests
    {
        private IForecastRepository InitRepository() => new ForecastRepository(new ForecastClient(new HttpClient(), Constants.ApiKey));

        [Test]
        public async Task LoadForecast()
        {
            void AssertIsLoaded(ICity actual)
            {
                Assert.IsNotNull(actual);
                Assert.IsNotNull(actual.Weather);
                Assert.IsNotEmpty(actual.Weather);
                Assert.Greater(actual.Weather.Count, 1);
            
                foreach (var item in actual.Weather)
                {
                    Assert.Greater(item.Date, DateTime.MinValue);
                    Assert.Greater(item.Temperature, 0);
                    Assert.Greater(item.Pressure, 0);
                    Assert.Greater(item.Humidity, 0);
                    Assert.IsNotNull(item.WindSpeed);
                }
            }
            
            var repository = InitRepository();
            foreach (var city in new[] {new City{Id = 2950159}, new City{Name = "Berlin"}})
            {
                await repository.LoadAsync(city);
                AssertIsLoaded(city);
            }
        }
    }
}