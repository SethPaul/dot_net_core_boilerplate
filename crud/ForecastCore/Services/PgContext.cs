using Forecast;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using NodaTime.Serialization.Protobuf;
using Npgsql;

namespace ForecastCore.Services
{
    public class PgContext: DbContext
    {
        public PgContext(DbContextOptions options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Summary>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseHiLo();
            modelBuilder.HasPostgresEnum<Summary>();
            modelBuilder.HasPostgresEnum<Context>();
            modelBuilder.Entity<WeatherForecast>()
                .Property(t => t.CreationTime)
                .HasConversion(
                    c => c.ToDateTimeOffset(),
                    c => Timestamp.FromDateTimeOffset(c)
                    )
                ;

            modelBuilder.Entity<WeatherForecast>()
                .Property(t => t.Date)
                .HasConversion(
                    c => c.ToInstant().ToUnixTimeSeconds(),
                    c => Instant.FromUnixTimeSeconds(c).ToTimestamp()
                    )
                ;
        }
        public DbSet<WeatherForecast> Forecasts { get; set; }
    }
}
