using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGamesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "GenreId", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "The Witcher 3: Wild Hunt is a story-driven open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.", 1, "The Witcher 3", 29.99m, new DateOnly(2015, 5, 19) },
                    { 2, "Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.", 1, "Cyberpunk 2077", 59.99m, new DateOnly(2020, 12, 10) },
                    { 3, "The Elder Scrolls V: Skyrim is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks.", 1, "The Elder Scrolls V: Skyrim", 19.99m, new DateOnly(2011, 11, 11) },
                    { 4, "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.", 3, "Grand Theft Auto V", 29.99m, new DateOnly(2013, 9, 17) },
                    { 5, "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.", 3, "Red Dead Redemption 2", 39.99m, new DateOnly(2018, 10, 26) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
