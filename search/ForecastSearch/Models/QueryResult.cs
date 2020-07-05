using System.Collections.Generic;
using Forecast;

namespace ForecastCore.Models
{
    public class QueryResult
    {
        public string PageTitle;
        public Dictionary<string, List<string>> Filters;
        public string GroupBy;
        public List<ResultGroup> ResultGroups;
    }

    public class ResultGroup
    {
        public string ResultTitle;
        public Dictionary<string, List<string>> Filters;
        public List<string> Facets;
        public List<WeatherForecast> Results;
    }
}
