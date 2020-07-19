using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forecast;
using Google.Protobuf.WellKnownTypes;
using Enum = System.Enum;

namespace ForecastCore.Services
{
    public class PgForecastRepo : IForecastRepo
    {
        private PgContext _pgContext;

        public PgForecastRepo(
            PgContext pgContext
        )
        {
            _pgContext = pgContext;
        }
        public async Task SaveForecasts(
            List<WeatherForecast> forecasts)
        {
            await _pgContext.AddRangeAsync(forecasts);
            await _pgContext.SaveChangesAsync();
        }
        public Task<List<WeatherForecast>> GetForecastsByCity(string city)
        {
            return null;
        }

        public Task<List<WeatherForecast>> GetForecastsByDate(DateTime forecastDate)
        {
            return null;
        }

        public Task<WeatherForecast> GetForecastById(string id)
        {
            return null;
        }

        public Task DeleteForecastById(string id)
        {
            return null;
        }
    }
}
