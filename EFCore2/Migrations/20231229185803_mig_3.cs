using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore2.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CratedDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 29, 21, 58, 3, 604, DateTimeKind.Local).AddTicks(525), "Bilgisayar", null },
                    { 2, new DateTime(2023, 12, 29, 21, 58, 3, 604, DateTimeKind.Local).AddTicks(538), "Telefon", null },
                    { 3, new DateTime(2023, 12, 29, 21, 58, 3, 604, DateTimeKind.Local).AddTicks(539), "Tablet", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CratedDate", "Name", "Price", "Stock", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 29, 21, 58, 3, 604, DateTimeKind.Local).AddTicks(542), "Asus Bilgisayar", 15000.0, 30, null },
                    { 2, 1, new DateTime(2023, 12, 29, 21, 58, 3, 604, DateTimeKind.Local).AddTicks(545), "Dell Bilgisayar", 19000.0, 40, null },
                    { 3, 2, new DateTime(2023, 12, 29, 21, 58, 3, 604, DateTimeKind.Local).AddTicks(546), "Iphone 15", 17000.0, 50, null },
                    { 4, 2, new DateTime(2023, 12, 29, 21, 58, 3, 604, DateTimeKind.Local).AddTicks(547), "Galaxy S20", 23000.0, 10, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
