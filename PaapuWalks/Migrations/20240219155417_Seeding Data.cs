using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaapuWalks.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6a55170e-ac65-48f4-9c1f-48af7dd6411b"), "Easy" },
                    { new Guid("816b9f81-2dd7-4347-8b28-6935b7932da7"), "Medium" },
                    { new Guid("8300acfc-fd4d-4d4c-80c2-9daf6ceae8f9"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("139333e8-cd54-4f89-d92e-08dc2d5648a8"), "BLR", "Banglore" },
                    { new Guid("43232ee6-8f59-451a-20d7-08dc2d53ce90"), "KLR", "Kerala" },
                    { new Guid("a0914c07-d365-4d95-20d6-08dc2d53ce90"), "HYD", "Hyderabad" },
                    { new Guid("bdcf18b1-8958-43de-8ef4-0274004930c3"), "CHN", "Chennai" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6a55170e-ac65-48f4-9c1f-48af7dd6411b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("816b9f81-2dd7-4347-8b28-6935b7932da7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8300acfc-fd4d-4d4c-80c2-9daf6ceae8f9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("139333e8-cd54-4f89-d92e-08dc2d5648a8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("43232ee6-8f59-451a-20d7-08dc2d53ce90"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a0914c07-d365-4d95-20d6-08dc2d53ce90"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bdcf18b1-8958-43de-8ef4-0274004930c3"));
        }
    }
}
