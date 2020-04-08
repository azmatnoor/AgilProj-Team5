using Microsoft.EntityFrameworkCore.Migrations;

namespace AgiltProjektarbete.Migrations
{
    public partial class updateRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ce35fa1-08e0-4eff-b8e5-cf66f8540f93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f55fc2b-ed9e-452c-a30d-d974473e3bd1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d352f9d7-43fc-4d7d-8e8b-1b9cfdd2563a", "a565aaf6-a231-47e9-b8a3-5a52e025c708", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a27a31ce-b2cf-447d-8bcb-8e6d8d6ea3a6", "d5bf9fea-f49a-4ad3-8eff-128ec1fc7908", "RestaurantOwner", "RESTAURANTOWNER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a27a31ce-b2cf-447d-8bcb-8e6d8d6ea3a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d352f9d7-43fc-4d7d-8e8b-1b9cfdd2563a");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Restaurants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ce35fa1-08e0-4eff-b8e5-cf66f8540f93", "17a9f161-9d90-4016-9da2-4148ce2791ee", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f55fc2b-ed9e-452c-a30d-d974473e3bd1", "02633cb5-f734-471d-8c33-cd8c7e3367ac", "RestaurantOwner", "RESTAURANTOWNER" });
        }
    }
}
