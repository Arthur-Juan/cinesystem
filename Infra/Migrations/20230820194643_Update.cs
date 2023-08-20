using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Entity_CategoriesId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Entity_MoviesId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_ChairId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_CinemaId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_MovieId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_RoomId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_SessionId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_Session_RoomId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_UserOwnId",
                table: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_ChairId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_CinemaId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_Email",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_MovieId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_RoomId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_Session_RoomId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_SessionId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_UserOwnId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Category_Name",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "ChairId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Movie_Name",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Room_Number",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Session_RoomId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "UserOwnId",
                table: "Entity");

            migrationBuilder.RenameTable(
                name: "Entity",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    Stars = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chairs_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Start = table.Column<TimeSpan>(type: "time", nullable: true),
                    End = table.Column<TimeSpan>(type: "time", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserOwnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChairId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Chairs_ChairId",
                        column: x => x.ChairId,
                        principalTable: "Chairs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserOwnId",
                        column: x => x.UserOwnId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chairs_RoomId",
                table: "Chairs",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CinemaId",
                table: "Rooms",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoomId",
                table: "Sessions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ChairId",
                table: "Tickets",
                column: "ChairId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SessionId",
                table: "Tickets",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserOwnId",
                table: "Tickets",
                column: "UserOwnId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Categories_CategoriesId",
                table: "CategoryMovie",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Movies_MoviesId",
                table: "CategoryMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Categories_CategoriesId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Movies_MoviesId",
                table: "CategoryMovie");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Chairs");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Entity");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Entity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Entity",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Entity",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Entity",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                table: "Entity",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChairId",
                table: "Entity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CinemaId",
                table: "Entity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Entity",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Entity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Entity",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "End",
                table: "Entity",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "Entity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Movie_Name",
                table: "Entity",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entity",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Entity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Entity",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Entity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Room_Number",
                table: "Entity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Entity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Session_RoomId",
                table: "Entity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Stars",
                table: "Entity",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Start",
                table: "Entity",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserOwnId",
                table: "Entity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity",
                table: "Entity",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Entity_CategoriesId",
                table: "CategoryMovie",
                column: "CategoriesId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Entity_MoviesId",
                table: "CategoryMovie",
                column: "MoviesId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_ChairId",
                table: "Entity",
                column: "ChairId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_CinemaId",
                table: "Entity",
                column: "CinemaId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_MovieId",
                table: "Entity",
                column: "MovieId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_RoomId",
                table: "Entity",
                column: "RoomId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_SessionId",
                table: "Entity",
                column: "SessionId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_Session_RoomId",
                table: "Entity",
                column: "Session_RoomId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_UserOwnId",
                table: "Entity",
                column: "UserOwnId",
                principalTable: "Entity",
                principalColumn: "Id");
        }
    }
}
