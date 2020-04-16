using Microsoft.EntityFrameworkCore.Migrations;

namespace AgiltProjektarbete.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Restaurants_RestaurantId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_RestaurantId",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a27a31ce-b2cf-447d-8bcb-8e6d8d6ea3a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d352f9d7-43fc-4d7d-8e8b-1b9cfdd2563a");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Pizzas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuId",
                table: "Pizzas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurants_id",
                        column: x => x.id,
                        principalTable: "Restaurants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30dc014c-0100-4cf1-8385-bc111fc91439", "d5ba21f1-e4c5-42dd-9a64-71a37ef5993a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d890a5fe-bf6e-4a45-84c5-bcb53bf795db", "584a5b30-ab99-4ada-81c3-aac4e710e037", "RestaurantOwner", "RESTAURANTOWNER" });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_MenuId",
                table: "Pizzas",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Menus_MenuId",
                table: "Pizzas",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Menus_MenuId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_MenuId",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30dc014c-0100-4cf1-8385-bc111fc91439");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d890a5fe-bf6e-4a45-84c5-bcb53bf795db");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Pizzas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d352f9d7-43fc-4d7d-8e8b-1b9cfdd2563a", "a565aaf6-a231-47e9-b8a3-5a52e025c708", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a27a31ce-b2cf-447d-8bcb-8e6d8d6ea3a6", "d5bf9fea-f49a-4ad3-8eff-128ec1fc7908", "RestaurantOwner", "RESTAURANTOWNER" });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_RestaurantId",
                table: "Pizzas",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Restaurants_RestaurantId",
                table: "Pizzas",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
