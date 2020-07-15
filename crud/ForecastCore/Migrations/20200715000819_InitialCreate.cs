using Microsoft.EntityFrameworkCore.Migrations;

namespace ForecastCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:summary", "freezing,bracing,chilly,cool,mild,warm,balmy,hot,sweltering,scorching");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
