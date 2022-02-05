using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmstudion.DataAccess.Migrations
{
    public partial class UpdateFilmStudioUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "FilmStudioUser");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Film",
                newName: "FilmCopies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmStudioUser",
                table: "FilmStudioUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CreateFilm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmCopies = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateFilm", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateFilm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmStudioUser",
                table: "FilmStudioUser");

            migrationBuilder.RenameTable(
                name: "FilmStudioUser",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "FilmCopies",
                table: "Film",
                newName: "Amount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
