using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilProjektarbete.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cdb28e2-534e-48a4-94c2-0769859c067f", "6d516a75-d7bd-4050-96b9-8bd40bbaa1b0", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7352401e-8266-4d59-a557-3408284b9092", "113760e5-710f-4bca-b142-b2b9a1f6a268", "Restaurant", "RESTAURANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cdb28e2-534e-48a4-94c2-0769859c067f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7352401e-8266-4d59-a557-3408284b9092");
        }
    }
}
