using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Movie_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    Stars = table.Column<float>(type: "real", nullable: true),
                    Room_Number = table.Column<int>(type: "int", nullable: true),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Start = table.Column<TimeSpan>(type: "time", nullable: true),
                    End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Session_RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserOwnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChairId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_ChairId",
                        column: x => x.ChairId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entity_Entity_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entity_Entity_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entity_Entity_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entity_Entity_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entity_Entity_Session_RoomId",
                        column: x => x.Session_RoomId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entity_Entity_UserOwnId",
                        column: x => x.UserOwnId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryMovie",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMovie", x => new { x.CategoriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Entity_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Entity_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovie_MoviesId",
                table: "CategoryMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ChairId",
                table: "Entity",
                column: "ChairId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_CinemaId",
                table: "Entity",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_Email",
                table: "Entity",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_MovieId",
                table: "Entity",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_RoomId",
                table: "Entity",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_Session_RoomId",
                table: "Entity",
                column: "Session_RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SessionId",
                table: "Entity",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_UserOwnId",
                table: "Entity",
                column: "UserOwnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMovie");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
