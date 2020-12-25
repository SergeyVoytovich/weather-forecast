using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherForecast.Data.OpenWeather.Clients;

namespace WeatherForecast.Data.OpenWeather.Tests
{
    public class ForecastClientTests
    {
        private const string ApiKey = "fcadd28326c90c3262054e0e6ca599cd";

        private IForecastClient InitClient()
            => new ForecastClient(new HttpClient(), ApiKey);
        
        [Test]
        public async Task GetForecastWeatherByCityName()
        {
            var client = InitClient();
            var response = await client.GetByCityName("Berlin");
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            
            Assert.IsNotNull(response.City);
            Assert.AreEqual("Berlin", response.City.Name);
            Assert.AreEqual(2950159, response.City.Id);
            
            Assert.IsNotNull(response.Items);
            Assert.IsNotEmpty(response.Items);

            foreach (var item in response.Items)
            {
                Assert.Greater(item.Date, DateTime.MinValue);
                
                Assert.IsNotNull(item.Main);
                Assert.Greater(item.Main.Temperature, 0);
                Assert.Greater(item.Main.Pressure, 0);
                Assert.Greater(item.Main.Humidity, 0);
                
                Assert.IsNotNull(item.Wind);
                Assert.IsNotNull(item.Wind);
                Assert.Greater(item.Wind.Speed, 0);
            }
        }
        
        [Test]
        public async Task GetForecastWeatherByCityId()
        {
            var client = InitClient();
            var response = await client.GetById(2950159);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            
            Assert.IsNotNull(response.City);
            Assert.AreEqual("Berlin", response.City.Name);
            Assert.AreEqual(2950159, response.City.Id);
            
            Assert.IsNotNull(response.Items);
            Assert.IsNotEmpty(response.Items);

            foreach (var item in response.Items)
            {
                Assert.Greater(item.Date, DateTime.MinValue);
                
                Assert.IsNotNull(item.Main);
                Assert.Greater(item.Main.Temperature, 0);
                Assert.Greater(item.Main.Pressure, 0);
                Assert.Greater(item.Main.Humidity, 0);
                
                Assert.IsNotNull(item.Wind);
                Assert.IsNotNull(item.Wind);
                Assert.Greater(item.Wind.Speed, 0);
            }
        }
    }
}