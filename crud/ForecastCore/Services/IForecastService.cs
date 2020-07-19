using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forecast;

namespace ForecastCore.Services
{
    public interface IForecastService
    {
        public Task<List<WeatherForecast>> GenerateForecasts(string city,
            DateTimeOffset startDate,
            int numOfDays, int averageTemp);
    }
}
