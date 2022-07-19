using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalsClassLibrary.Migrations
{
    public partial class AddLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedingByBreast",
                table: "Dogs",
                newName: "BreastFeed");

            migrationBuilder.RenameColumn(
                name: "FeedingByBreast",
                table: "Cats",
                newName: "BreastFeed");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.RenameColumn(
                name: "BreastFeed",
                table: "Dogs",
                newName: "FeedingByBreast");

            migrationBuilder.RenameColumn(
                name: "BreastFeed",
                table: "Cats",
                newName: "FeedingByBreast");
        }
    }
}
