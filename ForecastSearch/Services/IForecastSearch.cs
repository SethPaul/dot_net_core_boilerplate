using System.Collections.Generic;
using System.Threading.Tasks;
using ForecastCore.Models;
using WebApplication;

namespace ForecastCore.Services
{
    public interface IForecastSearch
    {
        public Task<QueryResult> QueryAsync(ForecastQuery query);
        public Task<QueryResult> QueryGetAsync(
            string f,
            string g,
            string q,
            int take,
            string cursor);
        public Task<WeatherForecast> GetForecastById(string id);
        public Task ClearForecastById(string id);
    }
}
