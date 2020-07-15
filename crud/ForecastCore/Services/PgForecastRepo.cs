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
        public Task<List<WeatherForecast>> SaveForecasts(
            List<WeatherForecast> forecasts)
        {
            return null;
        }
        public async Task<List<WeatherForecast>> GenerateForecasts(string city, DateTime startDate)
        {
            var rng = new Random();
            // var sampleTopic = new CreateTopicSample();
            var maxEnum = Enum.GetValues(typeof(Summary))
                .Cast<Int32>().Max();

            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    // Date = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(index)),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = ((Summary) rng.Next(maxEnum))
                }).ToList()
                ;
            // sampleTopic.PublishMessage("project", "topic");
            _pgContext.Add(forecasts.FirstOrDefault());
            _pgContext.SaveChanges();

            return forecasts;
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
