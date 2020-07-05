using System.Threading.Tasks;
using Forecast;
using ForecastCore.Models;
using Microsoft.Extensions.Logging;
using Nest;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ForecastCore.Services
{
    public class EsForecastSearch : IForecastSearch
    {

        private readonly IElasticClient _client;
        private readonly ILogger<EsForecastSearch> _logger;
        private readonly IConnectionMultiplexer _redis;

        public EsForecastSearch(
            ILogger<EsForecastSearch> logger,
            IElasticClient client,
            IConnectionMultiplexer redis
        )
        {
            _logger = logger;
            _client = client;
            _redis = redis;
        }

        public async Task<QueryResult>QueryAsync(ForecastQuery query)
        {
            SearchDescriptor<WeatherForecast> esQuery;
            if (query.Groups?.Count > 0)
            {
                esQuery = ConstructAggQuery(query);
            }
            else
            {
                esQuery = ConstructAllQuery(query);
            }


            var s = new SearchDescriptor<WeatherForecast>()
                .Query(q => q
                    .Bool(b => b
                    .Must(m => m
                        .Term(t => t
                            .Field( f=> f.City)
                            .Value("album")
                    )))).Size(10);

            var result = await _client.SearchAsync<WeatherForecast>(s);

            return new QueryResult();
        }

        public async Task<QueryResult>QueryGetAsync(
            string f,
            string g,
            string q,
            int take,
            string cursor)
        {
            // var filters =  JsonConvert
            //     .DeserializeObject<Dictionary<string, List<string>>>(f);
            // var groups = g?.Split(",") ?? new string[0];
            // var query = new ForecastQuery()
            // {
            //     Filters = filters,
            //     Groups = groups.ToList(),
            //     QueryText = q,
            //     Take = take,
            //     Cursor = cursor
            // };
            var query = new ForecastQuery();
            return await QueryAsync(query);
        }

        private SearchDescriptor<WeatherForecast> ConstructAggQuery(ForecastQuery query)
        {
            var s = new SearchDescriptor<WeatherForecast>();
            return s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.City)
                        .Query(query.QueryText)
                    )).Size(10);
        }

        private SearchDescriptor<WeatherForecast> ConstructAllQuery(ForecastQuery query)
        {
            var s = new SearchDescriptor<WeatherForecast>();
            return s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.City)
                        .Query(query.QueryText)
                    )).Size(10);
        }

        public async Task ClearForecastById(string id)
        {
            var db = _redis.GetDatabase();
            var kabob =db.StringGet(id);
            await db.KeyDeleteAsync(id);
        }

        public async Task<WeatherForecast>GetForecastById(string id)
        {
            var db = _redis.GetDatabase();
            var kabob =db.StringGet(id);
            if (kabob.HasValue)
            {
                return JsonConvert.DeserializeObject<WeatherForecast>(kabob);
            }
            var result = await _client.GetAsync<WeatherForecast>(id);
            db.StringSet(id, JsonConvert.SerializeObject(result.Source) );
            return result.Source;
        }
    }
}
