using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.Api.Models;
using WeatherForecast.Common.ApplicationLayer;

namespace Presentation.Api.Controllers
{
    /// <summary>
    /// Forecast controller
    /// </summary>
    [ApiController]
    [Route("api/weather/[controller]")]
    public class ForecastController : ApiControllerBase
    {
        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="application"></param>
        public ForecastController(IApplication application) : base(application)
        {
        }

        #endregion

        
        #region Methods

        /// <summary>
        /// Get forecast for query
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CityModel>> Get(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return BadRequest();
            }

            var city = await Application.GetAsync(q);
            if (city is null)
            {
                return NotFound();
            }
            
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

        #endregion
    }
}