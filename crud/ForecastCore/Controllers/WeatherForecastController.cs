using System.Collections.Generic;
using System.Threading.Tasks;
using Forecast;
using ForecastCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ForecastCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IForecastRepo _forecastRepo;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IForecastRepo forecastRepo
            )
        {
            _logger = logger;
            _forecastRepo = forecastRepo;
        }


        /// <summary>
        /// Generate forecast
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return new List<WeatherForecast>();
        }

        /// <summary>
        /// Clear from cache
        /// </summary>
        /// <param name="id">index id of forecast (url encoded page title)</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> ClearCache([FromRoute()] string id)
        {
            await _forecastRepo.DeleteForecastById(id.ToLower());
            return Ok();
        }

        /// <summary>
        /// Get details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Forecast object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> Get([FromRoute()] string id)
        {
            var doc = await _forecastRepo.GetForecastById(id.ToLower());
            if (doc is null)
            {
                return NotFound();
            }
            return doc;
        }
    }
}
