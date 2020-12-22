using NUnit.Framework;

namespace WeatherForecast.Data.OpenWeathermap.Tests
{
    public class WeathermapUriBuilderTests
    {
        [Test]
        public void Uri()
        {

            const string apiKey = "123456";
            const string cityName = "Berlin";
            const int id = 123;
            const int zip = 987;

            var uri = new WeathermapUriBuilder(apiKey).Weather().CityName(cityName).ToString();
            Assert.AreEqual($"https://api.openweathermap.org/data/2.5/weather?appid={apiKey}&q={cityName}", uri);
            
            uri = new WeathermapUriBuilder(apiKey).Forecast().CityName(cityName).ToString();
            Assert.AreEqual($"https://api.openweathermap.org/data/2.5/forecast?appid={apiKey}&q={cityName}", uri);
            
            uri = new WeathermapUriBuilder(apiKey).Forecast().Id(id).ToString();
            Assert.AreEqual($"https://api.openweathermap.org/data/2.5/forecast?appid={apiKey}&id={id}", uri);
            
            uri = new WeathermapUriBuilder(apiKey).Weather().ZipCode(zip).ToString();
            Assert.AreEqual($"https://api.openweathermap.org/data/2.5/weather?appid={apiKey}&zip={zip},de", uri);
        }
    }
}