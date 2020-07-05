using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace ForecastCore
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            var logSwitch = new LoggingLevelSwitch(
                Configuration["DOT_NET_ENV"] =="dev" ?
                LogEventLevel.Debug:
                LogEventLevel.Information);
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(new CompactJsonFormatter())
                .MinimumLevel.ControlledBy(logSwitch)
                .MinimumLevel.Override(
                    "System",
                    LogEventLevel.Information)
                .MinimumLevel.Override(
                    "Microsoft.AspNetCore",
                    LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("AppName", "forecast_core")
                .CreateLogger();
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>()
                            .UseSerilog()
                            .UseKestrel()
                            ;
                    });
    }
}
