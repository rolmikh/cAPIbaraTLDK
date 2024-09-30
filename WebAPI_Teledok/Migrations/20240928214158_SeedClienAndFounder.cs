using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI_Teledok.Migrations
{
    /// <inheritdoc />
    public partial class SeedClienAndFounder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ID_Client", "Date_Of_Addition_Client", "Date_Of_Update_Client", "INN_Client", "Name_Client", "Type_Of_Client_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 29, 0, 41, 57, 928, DateTimeKind.Local).AddTicks(734), null, "132808730606", "ООО Альфа", 1 },
                    { 2, new DateTime(2024, 9, 29, 0, 41, 57, 928, DateTimeKind.Local).AddTicks(740), null, "2345678901", "ИП Иванов", 2 },
                    { 3, new DateTime(2024, 9, 29, 0, 41, 57, 928, DateTimeKind.Local).AddTicks(742), null, "3456789012", "ООО Бета", 1 },
                    { 4, new DateTime(2024, 9, 29, 0, 41, 57, 928, DateTimeKind.Local).AddTicks(743), null, "4567890123", "ООО Гамма", 1 },
                    { 5, new DateTime(2024, 9, 29, 0, 41, 57, 928, DateTimeKind.Local).AddTicks(745), null, "5678901234", "ИП Смирнов", 2 }
                });

            migrationBuilder.InsertData(
                table: "Founder",
                columns: new[] { "ID_Founder", "Client_ID", "Date_Of_Addition_Founder", "Date_Of_Update_Founder", "INN_Founder", "MiddleName_Founder", "Name_Founder", "Surname_Founder" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 29, 0, 41, 57, 927, DateTimeKind.Local).AddTicks(6928), null, "8765432109", "Сергеевич", "Алексей", "Петров" },
                    { 2, 3, new DateTime(2024, 9, 29, 0, 41, 57, 927, DateTimeKind.Local).AddTicks(6943), null, "9876543210", "Андреевич", "Максим", "Иванов" },
                    { 3, 4, new DateTime(2024, 9, 29, 0, 41, 57, 927, DateTimeKind.Local).AddTicks(6945), null, "0987654321", "Александрович", "Дмитрий", "Кузнецов" },
                    { 4, 4, new DateTime(2024, 9, 29, 0, 41, 57, 927, DateTimeKind.Local).AddTicks(6946), null, "8765432190", "Петрович", "Иван", "Васильев" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ID_Client",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ID_Client",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Founder",
                keyColumn: "ID_Founder",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Founder",
                keyColumn: "ID_Founder",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Founder",
                keyColumn: "ID_Founder",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Founder",
                keyColumn: "ID_Founder",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ID_Client",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ID_Client",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ID_Client",
                keyValue: 4);
        }
    }
}
