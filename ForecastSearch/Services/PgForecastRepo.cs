using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForecastCore.Models;
using WebApplication;

namespace ForecastCore.Services
{
    public class PgForecastRepo : IForecastRepo
    {
        public Task<List<WeatherForecast>> SaveForecasts(
            List<WeatherForecast> forecasts)
        {
            return null;
        }
        public async Task<List<WeatherForecast>> GenerateForecasts(string city, DateTime startDate)
        {

            var rng = new Random();
            var sampleTopic = new CreateTopicSample();
            var maxEnum = Enum.GetValues(typeof(WeatherSummaries))
                .Cast<Int32>().Max();
            sampleTopic.CreateTopic("lilihi", "lilihiTest");

            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = ((WeatherSummaries) rng.Next(maxEnum)).ToString()
                }).ToList()
                ;
            sampleTopic.PublishMessage("lilihi", "lilihiTest");
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
