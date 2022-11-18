using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment_api.Migrations
{
    public partial class addingtablesforVG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Errands");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Errands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    ErrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Errands_ErrandId",
                        column: x => x.ErrandId,
                        principalTable: "Errands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Errands_UserId",
                table: "Errands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ErrandId",
                table: "Comments",
                column: "ErrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Errands_Users_UserId",
                table: "Errands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Errands_Users_UserId",
                table: "Errands");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Errands_UserId",
                table: "Errands");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Errands");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Errands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
