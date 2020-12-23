using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherForecast.Common.Data;

namespace WeatherForecast.Data.OpenWeather.Tests
{
    public class RepositoryTests
    {
        private const string ApiKey = "fcadd28326c90c3262054e0e6ca599cd";
        private IRepository InitRepository() => new Repository(new HttpClient(), new OpenWeatherConfig(ApiKey));

        [Test]
        public async Task GetWeather_ByName()
        {
            var repository = InitRepository();
            var result = await repository.GetWeatherAsync("Berlin");
            Assert.IsNotNull(result);
            Assert.AreEqual("Berlin", result.Name);
            Assert.AreEqual(2950159, result.Id);
            Assert.IsNotNull(result.Weather);
            Assert.IsNotEmpty(result.Weather);
            Assert.IsTrue(result.Weather.Any(i => i.IsCurrent));
            
            foreach (var item in result.Weather)
            {
                Assert.Greater(item.Date, DateTime.MinValue);
                Assert.Greater(item.Temperature, 0);
                Assert.Greater(item.Pressure, 0);
                Assert.Greater(item.Humidity, 0);
                Assert.IsNotNull(item.WindSpeed);
            }
        }
        
        [Test]
        public async Task GetWeather_ByZip()
        {
            var repository = InitRepository();
            var result = await repository.GetWeatherAsync(10117);
            Assert.IsNotNull(result);
            Assert.AreEqual("Berlin", result.Name);
            // Assert.AreEqual(2950159, result.Id);
            Assert.IsNotNull(result.Weather);
            Assert.IsNotEmpty(result.Weather);
            Assert.IsTrue(result.Weather.Any(i => i.IsCurrent));
            
            foreach (var item in result.Weather)
            {
                Assert.Greater(item.Date, DateTime.MinValue);
                Assert.Greater(item.Temperature, 0);
                Assert.Greater(item.Pressure, 0);
                Assert.Greater(item.Humidity, 0);
                Assert.IsNotNull(item.WindSpeed);
            }
        }
    }
}