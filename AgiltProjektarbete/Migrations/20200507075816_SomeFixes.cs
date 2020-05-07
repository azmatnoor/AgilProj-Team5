using Microsoft.EntityFrameworkCore.Migrations;


namespace AgiltProjektarbete.Migrations
{
    public partial class SomeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eec3a9b-39a4-41e0-84e3-a97589c07e84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff3d7db7-1768-4687-9498-97545d984a7a");

            migrationBuilder.AddColumn<bool>(
                name: "InMenu",
                table: "Ingredients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f293941-9696-4552-ac61-2f68515869ef", "d9a964ce-9bc6-4068-9dd5-56f43e5ebbae", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1695c55-8abb-4889-af9c-7d4a37264a08", "d1c5ef6c-e56b-4142-bcdb-cd94ba27fbc6", "RestaurantOwner", "RESTAURANTOWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f293941-9696-4552-ac61-2f68515869ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1695c55-8abb-4889-af9c-7d4a37264a08");

            migrationBuilder.DropColumn(
                name: "InMenu",
                table: "Ingredients");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0eec3a9b-39a4-41e0-84e3-a97589c07e84", "aa68792e-73c4-4368-82d2-468fc467249b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff3d7db7-1768-4687-9498-97545d984a7a", "225681aa-bae6-48e3-9479-adea13e7e211", "RestaurantOwner", "RESTAURANTOWNER" });
        }
    }
}
