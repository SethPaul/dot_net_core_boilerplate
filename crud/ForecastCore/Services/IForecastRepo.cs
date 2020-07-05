using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forecast;

namespace ForecastCore.Services
{
    public interface IForecastRepo
    {
        public Task<List<WeatherForecast>> SaveForecasts(List<WeatherForecast> forecasts);
        public Task<List<WeatherForecast>> GenerateForecasts(string city, DateTime startDate);
        public Task<List<WeatherForecast>> GetForecastsByCity(string city);
        public Task<List<WeatherForecast>> GetForecastsByDate(DateTime forecastDate);
        public Task<WeatherForecast> GetForecastById(string id);
        public Task DeleteForecastById(string id);
    }
}
