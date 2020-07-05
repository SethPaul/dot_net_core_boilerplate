using System.Collections.Generic;
using ForecastCore.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Nest;
using NUnit.Framework;
using StackExchange.Redis;

namespace Web.Test
{
    public class Tests
    {
        private IForecastSearch _forecastSearch;
        private IElasticClient _client;
        private Mock<ILogger<EsForecastSearch>> _logger;
        private IConnectionMultiplexer _redis;

        [SetUp]
        public void Setup()
        {
            _client = ForecastSearchConfiguration.GetClient();
            _logger = new Mock<ILogger<EsForecastSearch>>();
            _redis = ConnectionMultiplexer.Connect("localhost");

            _forecastSearch = new EsForecastSearch(
                client: _client,
                logger:_logger.Object,
                redis:_redis
                );
        }

        [Test]
        public void AbleToQueryEs()
        {
        _forecastSearch.ClearForecastById("chicago");
        var forecast =  _forecastSearch.GetForecastById("chicago").Result;
        Assert.AreEqual("chicago",forecast.City);
        }
    }
}
