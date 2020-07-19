using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forecast;
using Google.Protobuf.WellKnownTypes;
using Enum = System.Enum;

namespace ForecastCore.Services
{
    public class ForecastService : IForecastService
    {
        private IForecastRepo _forecastRepo;

        public ForecastService(
            IForecastRepo forecastRepo
        )
        {
            _forecastRepo=forecastRepo;
        }
        public async Task<List<WeatherForecast>> GenerateForecasts(string city,
            DateTimeOffset startDate,
            int numOfDays, int averageTemp)
        {
            var rng = new Random();
            var maxEnum = Enum.GetValues(typeof(Summary))
                .Cast<Int32>().Max();

            var forecasts = Enumerable.Range(0, numOfDays-1).Select(index => new WeatherForecast
                {
                    Id = Guid.NewGuid().ToString(),
                    City = city,
                    CreationTime =Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                    Date = Timestamp.FromDateTimeOffset(startDate.AddDays(index)),
                    TemperatureC = averageTemp + rng.Next(-20, 55),
                    Summary = ((Summary) rng.Next(maxEnum)),
                    Context = Context.InShade
                }).ToList();
            
            await _forecastRepo.SaveForecasts(forecasts);

            return forecasts;
            // var sampleTopic = new CreateTopicSample();
            // sampleTopic.PublishMessage("project", "topic");
        }
    }
}
