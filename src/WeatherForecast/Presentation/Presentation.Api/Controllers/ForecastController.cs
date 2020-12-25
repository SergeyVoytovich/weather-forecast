using System;
using Microsoft.AspNetCore.Mvc;
using Presentation.Api.Models;
using WeatherForecast.Common.ApplicationLayer;

namespace Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/weather/[controller]")]
    public class ForecastController : ApiControllerBase
    {
        public ForecastController(IApplication application) : base(application)
        {
        }

        [HttpGet]
        public ActionResult<CityModel> Get()
        {
            return new CityModel
            {
                Name = "balblabla",
                Weather =
                {
                    new WeatherModel
                    {
                        Date = DateTime.Now,
                        Humidity = 6519814,
                        Pressure = 45498,
                        Temperature = 484984,
                        WindSpeed = 15451
                    }
                }
            };
        }
    }
}