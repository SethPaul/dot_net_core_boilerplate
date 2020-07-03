using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForecastCore.Models;
using ForecastCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IForecastSearch _forecastSearch;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IForecastSearch forecastSearch
            )
        {
            _logger = logger;
            _forecastSearch = forecastSearch;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Generate forecast
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        /// <summary>
        /// Clear from cache
        /// </summary>
        /// <param name="id">index id of forecast (url encoded page title)</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> ClearCache([FromRoute()] string id)
        {
            await _forecastSearch.ClearForecastById(id.ToLower());
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
            var doc = await _forecastSearch.GetForecastById(id.ToLower());
            if (doc is null)
            {
                return NotFound();
            }
            return doc;
        }

        /// <summary>
        /// Query, filter by key:value or text, group counts
        /// </summary>
        /// <param name="q">query</param>
        /// <param name="f">dictionary of filters - {"genre":"horror","year":1981}</param>
        /// <param name="g">comma separated lst of groups - genre,decade </param>
        /// <param name="take">number of results to return</param>
        /// <param name="cursor">scroll id to request next result set</param>
        /// <returns>search result object</returns>
        [HttpGet]
        public async Task<ActionResult<QueryResult>> Query_Get(
             [FromQuery] string q,
             [FromQuery] string f,
             [FromQuery] string g,
             [FromQuery] int take,
             [FromQuery] string cursor
             )
        {
            return await _forecastSearch.QueryGetAsync(f, g, q, take, cursor);
        }

        /// <summary>
        /// Query, filter by key:value or text, group counts
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Search result object</returns>
        [HttpPost]
        public async Task<ActionResult<QueryResult>> Query_Post([FromBody]
             ForecastQuery query )
        {
            return await _forecastSearch.QueryAsync(query);
        }
    }
}
