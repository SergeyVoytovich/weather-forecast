using System;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<CityModel>> Get(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return BadRequest();
            }

            var city = await Application.GetAsync(q);
            return new CityModel
            {
                Name = city.Name,
                Weather = city.Weather.OrderBy(i => i.Date).Select(i => new WeatherModel
                {
                    Date = i.Date,
                    Humidity = (int)Math.Round(i.Humidity,0),
                    Pressure = (int)Math.Round(i.Pressure,0),
                    Temperature = (int)Math.Round(i.Temperature,0),
                    WindSpeed = Math.Round(i.WindSpeed,1),
                }).ToList()
            };
        }
    }
}