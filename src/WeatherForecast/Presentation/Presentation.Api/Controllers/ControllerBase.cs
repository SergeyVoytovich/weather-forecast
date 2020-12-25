using System;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Common.ApplicationLayer;

namespace Presentation.Api.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ApiControllerBase(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        protected IApplication Application { get; }
    }
}