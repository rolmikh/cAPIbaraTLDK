using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Teledok.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type_Of_Client",
                columns: table => new
                {
                    ID_Type_Of_Client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Type_Of_Client = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Client", x => x.ID_Type_Of_Client);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID_Client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INN_Client = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Name_Client = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date_Of_Addition_Client = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Date_Of_Update_Client = table.Column<DateTime>(type: "datetime", nullable: true),
                    Type_Of_Client_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID_Client);
                    table.ForeignKey(
                        name: "FK_Type_Of_Client",
                        column: x => x.Type_Of_Client_ID,
                        principalTable: "Type_Of_Client",
                        principalColumn: "ID_Type_Of_Client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Founder",
                columns: table => new
                {
                    ID_Founder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INN_Founder = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Surname_Founder = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name_Founder = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MiddleName_Founder = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Date_Of_Addition_Founder = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Date_Of_Update_Founder = table.Column<DateTime>(type: "datetime", nullable: true),
                    Client_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founder", x => x.ID_Founder);
                    table.ForeignKey(
                        name: "FK_Client",
                        column: x => x.Client_ID,
                        principalTable: "Client",
                        principalColumn: "ID_Client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Type_Of_Client_ID",
                table: "Client",
                column: "Type_Of_Client_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_INN_Client",
                table: "Client",
                column: "INN_Client",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Founder_Client_ID",
                table: "Founder",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_INN_Founder",
                table: "Founder",
                column: "INN_Founder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Name_Type_Of_Client",
                table: "Type_Of_Client",
                column: "Name_Type_Of_Client",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Founder");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Type_Of_Client");
        }
    }
}
