using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WeatherForecast.Common.Models;

namespace WeatherForecast.ApplicationLayer.Tests
{
    public class ApplicationTests
    {
        [Test]
        public async Task Get_ByCityName_EmptyString()
        {
            var database = new MockDatabase();
            var application = new Application(database.Object);

            var result = await application.GetAsync(string.Empty);
            
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task Get_ByCityName_Exists()
        {
            var database = new MockDatabase();
            database.Weather
                .Setup(i => i.GetAsync("Berlin"))
                .ReturnsAsync(new City());
            database.Forecast
                .Setup(i => i.LoadAsync(It.IsAny<ICity>()))
                .Callback(() => { });
            var application = new Application(database.Object);

            var result = await application.GetAsync("Berlin");
            
            Assert.IsNotNull(result);
        }
        
        [Test]
        public async Task Get_ByCityName_NotExists()
        {
            var database = new MockDatabase();
            database.Weather
                .Setup(i => i.GetAsync("Berlin"))
                .ReturnsAsync(new City());
            database.Forecast
                .Setup(i => i.LoadAsync(It.IsAny<ICity>()))
                .Callback(() => { });
            var application = new Application(database.Object);

            var result = await application.GetAsync("08Berlin");
            
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task Get_BZip_Exists()
        {
            var database = new MockDatabase();
            database.Weather
                .Setup(i => i.GetAsync(123))
                .ReturnsAsync(new City());
            database.Forecast
                .Setup(i => i.LoadAsync(It.IsAny<ICity>()))
                .Callback(() => { });
            var application = new Application(database.Object);

            var result = await application.GetAsync(123.ToString());
            
            Assert.IsNotNull(result);
        }
        
        [Test]
        public async Task Get_BZip_NotExists()
        {
            var database = new MockDatabase();
            database.Weather
                .Setup(i => i.GetAsync(123))
                .ReturnsAsync(new City());
            database.Forecast
                .Setup(i => i.LoadAsync(It.IsAny<ICity>()))
                .Callback(() => { });
            var application = new Application(database.Object);

            var result = await application.GetAsync(487.ToString());
            
            Assert.IsNull(result);
        }
    }
}