using System;
using System.Diagnostics;
using System.Linq;
using ForecastCore.Models;
using Nest;
using WebApplication;

namespace ForecastCore.Services
{
    public static class ForecastSearchConfiguration
    {

        public static ElasticClient GetClient() => new ElasticClient(ConnectionSettings);

        static ForecastSearchConfiguration()
        {
            ConnectionSettings = new ConnectionSettings(CreateUri(9200))
                .DefaultIndex("forecasts")
                .DefaultMappingFor<WeatherForecast>(i => i
                        .IndexName("forecasts")
                        )
                .DisableDirectStreaming()
                ;

        }
        private static readonly ConnectionSettings ConnectionSettings;

        public static string LiveIndexAlias => "forecasts";

        public static Uri CreateUri(int port)
        {
            var host = Process.GetProcessesByName("fiddler").Any()
                ? "ipv4.fiddler"
                : "localhost";

            return new Uri($"http://{host}:{port}");
        }

        public static string CreateIndexName() => $"{LiveIndexAlias}-{DateTime.UtcNow:dd-MM-yyyy-HH-mm-ss}";
    }
}
