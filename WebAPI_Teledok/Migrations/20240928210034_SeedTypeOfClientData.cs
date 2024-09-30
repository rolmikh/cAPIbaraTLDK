using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI_Teledok.Migrations
{
    /// <inheritdoc />
    public partial class SeedTypeOfClientData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Type_Of_Client",
                columns: new[] { "ID_Type_Of_Client", "Name_Type_Of_Client" },
                values: new object[,]
                {
                    { 1, "Юридическое лицо" },
                    { 2, "Индивидуальный предприниматель" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Type_Of_Client",
                keyColumn: "ID_Type_Of_Client",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Type_Of_Client",
                keyColumn: "ID_Type_Of_Client",
                keyValue: 2);
        }
    }
}
