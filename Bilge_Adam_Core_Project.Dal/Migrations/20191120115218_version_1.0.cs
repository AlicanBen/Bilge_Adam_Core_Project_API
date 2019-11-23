using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bilge_Adam_Core_Project.Dal.Migrations
{
    public partial class version_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DateOfAdd = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DateOfAdd = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    ImdbRating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DateOfAdd = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<short>(nullable: false),
                    Mail = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DateOfAdd = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<short>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    DirectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectorMovies_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovies_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DateOfAdd = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<short>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    ListType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                    table.ForeignKey(
                        name: "FK_List_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovies_DirectorId",
                table: "DirectorMovies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovies_MovieId",
                table: "DirectorMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_List_MovieId",
                table: "List",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_List_UserId",
                table: "List",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorMovies");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
