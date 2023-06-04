using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeatherApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp_C = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Temp_F = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "Country", "Info", "LastUpdate", "Temp_C", "Temp_F" },
                values: new object[,]
                {
                    { 1, "Warsaw", "Poland", "Clear", new DateTime(2023, 6, 3, 21, 41, 49, 923, DateTimeKind.Local).AddTicks(6260), 16.00m, 60.80m },
                    { 2, "London", "United Kingdom", "Sunny", new DateTime(2023, 6, 3, 21, 41, 49, 923, DateTimeKind.Local).AddTicks(6365), 19.0m, 66.20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
