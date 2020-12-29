using System;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Common.ApplicationLayer;

namespace Presentation.Api.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class ApiControllerBase : ControllerBase
    {
        #region Properties

        /// <summary>
        /// Application
        /// </summary>
        protected IApplication Application { get; }

        #endregion
        
        
        #region Contructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="application"></param>
        protected ApiControllerBase(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        #endregion

        
    }
}