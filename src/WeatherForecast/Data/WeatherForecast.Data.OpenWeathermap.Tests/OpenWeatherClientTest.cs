using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WeatherForecast.Data.OpenWeather.Tests
{
    public class OpenWeatherClientTest
    {
        private const string ApiKey = "fcadd28326c90c3262054e0e6ca599cd";

        [Test]
        public async Task GetCurrentWeatherByCityName()
        {
            var client = new OpenWeatherClient(new HttpClient(), ApiKey);
            var response = await client.GetCurrentWeatherByCityName("Berlin");
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.AreEqual("Berlin", response.CityName);
            Assert.AreEqual(2950159, response.CityId);
            Assert.IsNotNull(response.Weather);
            Assert.Greater(response.Weather.Temperature, 0);
            Assert.Greater(response.Weather.Pressure, 0);
            Assert.Greater(response.Weather.Humidity, 0);
            Assert.IsNotNull(response.Wind);
            Assert.Greater(response.Wind.Speed, 0);
        }
    }
}