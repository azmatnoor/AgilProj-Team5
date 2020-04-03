using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilProjektarbete.Migrations
{
    public partial class AddIndentityScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cdb28e2-534e-48a4-94c2-0769859c067f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7352401e-8266-4d59-a557-3408284b9092");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3791b4a1-44f5-4fba-a1a9-7fa433994008", "16aa316a-16d9-4f7a-8c83-de27df946fbe", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f092d8c-2fbd-46d1-885f-f8a224ac64b9", "eae5861e-302c-4ecd-b582-17ced4554161", "Restaurant", "RESTAURANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3791b4a1-44f5-4fba-a1a9-7fa433994008");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f092d8c-2fbd-46d1-885f-f8a224ac64b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cdb28e2-534e-48a4-94c2-0769859c067f", "6d516a75-d7bd-4050-96b9-8bd40bbaa1b0", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7352401e-8266-4d59-a557-3408284b9092", "113760e5-710f-4bca-b142-b2b9a1f6a268", "Restaurant", "RESTAURANT" });
        }
    }
}
