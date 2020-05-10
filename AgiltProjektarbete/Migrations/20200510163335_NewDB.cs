using Microsoft.EntityFrameworkCore.Migrations;



namespace AgiltProjektarbete.Migrations
{
    public partial class NewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "d2de18c1-bf13-4d69-971e-d537696186b9", "b0df3a4f-2b5d-41ed-bf6c-56d66e8913dd", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04b35110-61c5-459f-9cd4-c1c932fc2010", "843fa8e4-0afe-4c60-a8a6-40c5d0b10b74", "RestaurantOwner", "RESTAURANTOWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04b35110-61c5-459f-9cd4-c1c932fc2010");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2de18c1-bf13-4d69-971e-d537696186b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ff0f3d3-e1cb-4c76-98f7-9ff51a3361b6", "66dbadb1-4a12-4206-bb8c-3e865c8c8e4d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e308e615-4133-40d4-9d75-ef937899adcb", "17b24b32-5600-4d44-b2af-bdbd75d31b13", "RestaurantOwner", "RESTAURANTOWNER" });
        }
    }
}
