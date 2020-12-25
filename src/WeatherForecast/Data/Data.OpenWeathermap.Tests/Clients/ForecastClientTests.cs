using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherForecast.Data.OpenWeather.Clients;

namespace WeatherForecast.Data.OpenWeather.Tests.Clients
{
    public class ForecastClientTests
    {
        private IForecastClient InitClient()
            => new ForecastClient(new HttpClient(), Constants.ApiKey);
        
        [Test]
        public async Task GetForecastWeatherByCityName()
        {
            var client = InitClient();
            var response = await client.GetByCityNameAsync("Berlin");
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
        public async Task GetForecastWeatherByCityName_ExpectedNull()
        {
            var client = InitClient();
            var response = await client.GetByCityNameAsync("Berl132in");
            Assert.IsNull(response);
        }
        
        [Test]
        public async Task GetForecastWeatherByCityId()
        {
            var client = InitClient();
            var response = await client.GetByIdAsync(2950159);
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
        public async Task GetForecastWeatherByCityId_ExpectedNull()
        {
            var client = InitClient();
            var response = await client.GetByIdAsync(1154);
            Assert.IsNull(response);
        }
    }
}