using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forecast;
using ForecastCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NodaTime;
using DateTime = Google.Type.DateTime;

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
        /// <param name="city">City of Forecast</param>
        /// <param name="startDatetime"></param>
        /// <param name="numOfDays"></param>
        /// <param name="averageTemp"></param>
        /// <returns></returns>
        [HttpGet("generate_forecasts")]
        public async Task<IEnumerable<WeatherForecast>> GenerateForecasts(
            [FromQuery()] string city,
            [FromQuery()] DateTimeOffset startDatetime,
            [FromQuery()] int numOfDays,
            [FromQuery()] int averageTemp)
        {
            return await _forecastRepo.GenerateForecasts(city,
                startDatetime, numOfDays, averageTemp);
            // return new List<WeatherForecast>();
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
