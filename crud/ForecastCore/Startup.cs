using System;
using System.IO;
using System.Reflection;
using ForecastCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using StackExchange.Redis;

namespace ForecastCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<pgContext>(opt =>
                    opt.UseNpgsql(Configuration.GetConnectionString("pgContext"))
                .UseSnakeCaseNamingConvention());

            services.AddControllers()
                .AddNewtonsoftJson(o => o.SerializerSettings.ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                });
            services.AddResponseCaching();
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
            // register the client as a singleton
            // services.AddSingleton<IElasticClient>(ForecastSearchConfiguration.GetClient());
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
            // services.AddTransient<IForecastSearch, EsForecastSearch>();
            services.AddTransient<IForecastRepo, PgForecastRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Core API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Configuration["DOT_NET_ENV"]=="dev")
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    c.RoutePrefix = string.Empty;
                });

            }

            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                };
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseResponseCompression();
            app.Use(async (context, next) =>
                {
                    context.Response.GetTypedHeaders().CacheControl =
                        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromSeconds(30)
                        };
                    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                        new[] { "Accept-Encoding" };

                    await next();
                });
            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseHsts();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
