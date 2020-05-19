using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgiltProjektarbete.Migrations
{
    public partial class testXD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae353364-2451-4310-8585-cac859cb5606");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caaf630a-f4fe-43f1-8bb8-679abaffcd8e");

            migrationBuilder.AddColumn<bool>(
                name: "InMenu",
                table: "Pizzas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51771dfd-6ec0-46c5-b765-dc18cae3793a", "f7578b33-3a57-4193-aae7-4b161e182827", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3953b63c-f03b-43c4-8411-40b4c8a686c3", "0250977b-c0fb-49f5-b160-68179c27c667", "RestaurantOwner", "RESTAURANTOWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3953b63c-f03b-43c4-8411-40b4c8a686c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51771dfd-6ec0-46c5-b765-dc18cae3793a");

            migrationBuilder.DropColumn(
                name: "InMenu",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae353364-2451-4310-8585-cac859cb5606", "2e18b641-20ba-47e5-b056-660b81a63477", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "caaf630a-f4fe-43f1-8bb8-679abaffcd8e", "a42fc0e5-4d87-4e3f-9f48-14713fc003f1", "RestaurantOwner", "RESTAURANTOWNER" });
        }
    }
}
