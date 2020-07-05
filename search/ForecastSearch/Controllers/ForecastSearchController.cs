using System.Threading.Tasks;
using ForecastCore.Models;
using ForecastCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ForecastCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastSearchController : ControllerBase
    {

        private readonly IForecastSearch _forecastSearch;
        private readonly ILogger<ForecastSearchController> _logger;

        public ForecastSearchController(
            ILogger<ForecastSearchController> logger,
            IForecastSearch forecastSearch
            )
        {
            _logger = logger;
            _forecastSearch = forecastSearch;
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
        [HttpGet("/search")]
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
