using Forecast;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ForecastCore.Services
{
    public class PgContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=forecasts;Username=dev;" +
            "Password=dev_pw",
            options => options.EnableRetryOnFailure());
        static PgContext()
            => NpgsqlConnection.GlobalTypeMapper.MapEnum<Summary>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseHiLo();
            modelBuilder.Entity<WeatherForecast>()
                // .HasIndex(b => b.Id)
                // .IncludeProperties(b => b.Name)
                // .HasMethod("gin")
                .Property(b => b.Id)
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.HasPostgresEnum<Summary>();
        }
        public DbSet<WeatherForecast> Forecasts { get; set; }
    }
}
