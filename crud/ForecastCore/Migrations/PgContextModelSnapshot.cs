﻿// <auto-generated />
using System;
using Forecast;
using ForecastCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ForecastCore.Migrations
{
    [DbContext(typeof(PgContext))]
    partial class PgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:Enum:context", "in_sun,in_shade")
                .HasAnnotation("Npgsql:Enum:summary", "freezing,bracing,chilly,cool,mild,warm,balmy,hot,sweltering,scorching")
                .HasAnnotation("Npgsql:HiLoSequenceName", "EntityFrameworkHiLoSequence")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.EntityFrameworkHiLoSequence", "'EntityFrameworkHiLoSequence', '', '1', '10', '', '', 'Int64', 'False'");

            modelBuilder.Entity("Forecast.WeatherForecast", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("text");

                    b.Property<int>("Context")
                        .HasColumnName("context")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Summary>("Summary")
                        .HasColumnName("summary")
                        .HasColumnType("summary");

                    b.Property<int>("TemperatureC")
                        .HasColumnName("temperature_c")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_forecasts");

                    b.ToTable("forecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
