using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WeatherForecast.Data.OpenWeather.Clients;
using WeatherForecast.Data.OpenWeather.Dto;
using WeatherForecast.Data.OpenWeather.Dto.Weather;
using WeatherForecast.Data.OpenWeather.Repositories;

namespace WeatherForecast.Data.OpenWeather.Tests.Repositories
{
    public class WeatherRepositoryTests
    {
        private WeatherResponse SuccessResponse = new WeatherResponse
        {
            Code = 200,
            CityId = 2950159,
            CityName = "Berlin",
            Main = new Main
            {
                Humidity = 4984,
                Pressure = 45,
                Temperature = 154
            },
            Wind = new Wind
            {
                Speed = 545
            }
        };
        
        [Test]
        public async Task GetWeather_ByName()
        {
            var client = new Mock<IWeatherClient>();
            client
                .Setup(i => i.GetByCityNameAsync(It.IsAny<string>()))
                .ReturnsAsync(SuccessResponse);
            
            var repository = new WeatherRepository(client.Object);
            
            var result = await repository.GetAsync("Berlin");
            Assert.IsNotNull(result);
            Assert.AreEqual("Berlin", result.Name);
            Assert.AreEqual(2950159, result.Id);
            Assert.IsNotNull(result.Weather);
            Assert.IsNotEmpty(result.Weather);
            Assert.IsTrue(result.Weather.Any(i => i.Date.Date == DateTime.Now.Date));
            
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
        public async Task GetWeather_ByName_Null()
        {
            var client = new Mock<IWeatherClient>();
            client
                .Setup(i => i.GetByCityNameAsync(It.IsAny<string>()))
                .ReturnsAsync(null as WeatherResponse);
            
            var repository = new WeatherRepository(client.Object);
            
            var result = await repository.GetAsync("Berlin");
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task GetWeather_ByZip()
        {
            var client = new Mock<IWeatherClient>();
            client
                .Setup(i => i.GetByZipCodeAsync(It.IsAny<int>()))
                .ReturnsAsync(SuccessResponse);
            
            var repository = new WeatherRepository(client.Object);
            
            var result = await repository.GetAsync(10117);
            Assert.IsNotNull(result);
            Assert.AreEqual("Berlin", result.Name);
            Assert.AreEqual(2950159, result.Id);
            Assert.IsNotNull(result.Weather);
            Assert.IsNotEmpty(result.Weather);
            Assert.IsTrue(result.Weather.Any(i => i.Date.Date == DateTime.Now.Date));
            
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
        public async Task GetWeather_ByZip_Null()
        {
            var client = new Mock<IWeatherClient>();
            client
                .Setup(i => i.GetByZipCodeAsync(It.IsAny<int>()))
                .ReturnsAsync(SuccessResponse);
            
            var repository = new WeatherRepository(client.Object);
            
            var result = await repository.GetAsync(10117);
            Assert.IsNotNull(result);
        }
    }
}