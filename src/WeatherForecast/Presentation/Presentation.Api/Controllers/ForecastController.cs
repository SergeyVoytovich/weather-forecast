using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<int> Get()
        {
            return 200;
        }
    }
}