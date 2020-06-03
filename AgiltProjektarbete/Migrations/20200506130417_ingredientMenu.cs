using Microsoft.EntityFrameworkCore.Migrations;

namespace AgiltProjektarbete.Migrations
{
    public partial class ingredientMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3953b63c-f03b-43c4-8411-40b4c8a686c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51771dfd-6ec0-46c5-b765-dc18cae3793a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0eec3a9b-39a4-41e0-84e3-a97589c07e84", "aa68792e-73c4-4368-82d2-468fc467249b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff3d7db7-1768-4687-9498-97545d984a7a", "225681aa-bae6-48e3-9479-adea13e7e211", "RestaurantOwner", "RESTAURANTOWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eec3a9b-39a4-41e0-84e3-a97589c07e84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3d7db7-1768-4687-9498-97545d984a7a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51771dfd-6ec0-46c5-b765-dc18cae3793a", "f7578b33-3a57-4193-aae7-4b161e182827", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3953b63c-f03b-43c4-8411-40b4c8a686c3", "0250977b-c0fb-49f5-b160-68179c27c667", "RestaurantOwner", "RESTAURANTOWNER" });
        }
    }
}
