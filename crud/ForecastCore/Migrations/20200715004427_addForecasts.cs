using Forecast;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForecastCore.Migrations
{
    public partial class addForecasts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Context = table.Column<int>(nullable: false),
                    TemperatureC = table.Column<int>(nullable: false),
                    Summary = table.Column<Summary>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
