using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherForecast.Data.OpenWeather.Clients;

namespace WeatherForecast.Data.OpenWeather.Tests.Clients
{
    public class WeatherClientTests
    {
        private IWeatherClient InitClient()
            => new WeatherClient(new HttpClient(), Constants.ApiKey);
        
        [Test]
        public async Task GetCurrentWeatherByCityName()
        {
            var client = InitClient();
            var response = await client.GetByCityNameAsync("Berlin");
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.AreEqual("Berlin", response.CityName);
            Assert.AreEqual(2950159, response.CityId);
            Assert.IsNotNull(response.Main);
            Assert.Greater(response.Main.Temperature, 0);
            Assert.Greater(response.Main.Pressure, 0);
            Assert.Greater(response.Main.Humidity, 0);
            Assert.IsNotNull(response.Wind);
            Assert.Greater(response.Wind.Speed, 0);
        }
        
        [Test]
        public async Task GetCurrentWeatherByZipCode()
        {
            var client = InitClient();
            var response = await client.GetByZipCodeAsync(10117); // Berlin zip code
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.AreEqual("Berlin", response.CityName);
            // Assert.AreEqual(2950159, response.CityId); // id in zip code responses is 0!!
            Assert.IsNotNull(response.Main);
            Assert.Greater(response.Main.Temperature, 0);
            Assert.Greater(response.Main.Pressure, 0);
            Assert.Greater(response.Main.Humidity, 0);
            Assert.IsNotNull(response.Wind);
            Assert.Greater(response.Wind.Speed, 0);
        }
    }
}