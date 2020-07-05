using System;
using Nest;

namespace WebApplication
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public string City { get; set; }

        [PropertyName("temperature_c")]
        public int TemperatureC { get; set; }

        [PropertyName("temperature_f")]
        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
