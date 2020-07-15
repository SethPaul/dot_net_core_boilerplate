using Forecast;
using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<WeatherForecast>()
                // .HasIndex(b => b.Id)
                // .IncludeProperties(b => b.Name)
                // .HasMethod("gin")
                .HasKey(b => b.Id);
                // .Property(b => b.Id)dd
                // .IsRequired()
                // .HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.HasPostgresEnum<Summary>();
        }
        public DbSet<WeatherForecast> Forecasts { get; set; }
    }
}
