using Microsoft.EntityFrameworkCore.Migrations;

namespace AgiltProjektarbete.Migrations
{
    public partial class ANewOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f293941-9696-4552-ac61-2f68515869ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1695c55-8abb-4889-af9c-7d4a37264a08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ff0f3d3-e1cb-4c76-98f7-9ff51a3361b6", "66dbadb1-4a12-4206-bb8c-3e865c8c8e4d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e308e615-4133-40d4-9d75-ef937899adcb", "17b24b32-5600-4d44-b2af-bdbd75d31b13", "RestaurantOwner", "RESTAURANTOWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ff0f3d3-e1cb-4c76-98f7-9ff51a3361b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e308e615-4133-40d4-9d75-ef937899adcb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f293941-9696-4552-ac61-2f68515869ef", "d9a964ce-9bc6-4068-9dd5-56f43e5ebbae", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1695c55-8abb-4889-af9c-7d4a37264a08", "d1c5ef6c-e56b-4142-bcdb-cd94ba27fbc6", "RestaurantOwner", "RESTAURANTOWNER" });
        }
    }
}
