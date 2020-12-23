﻿using System;
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
            var client = new OpenWeatherClient(new HttpClient(), ApiKey);
            var response = await client.GetCurrentWeatherByZipCode(10117); // Berlin zip code
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
        
        [Test]
        public async Task GetForecastWeatherByCityName()
        {
            var client = new OpenWeatherClient(new HttpClient(), ApiKey);
            var response = await client.GetForecastWeatherByCityName("Berlin");
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
            var client = new OpenWeatherClient(new HttpClient(), ApiKey);
            var response = await client.GetForecastWeatherByCityId(2950159);
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