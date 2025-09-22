using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesBoxd_api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "backlog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_backlog", x => x.id);
                    table.ForeignKey(
                        name: "fk_backlog_user_id",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "backlog_game",
                columns: table => new
                {
                    BacklogId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_backlog_game", x => new { x.BacklogId, x.GameId });
                    table.ForeignKey(
                        name: "fk_backloggame_backlog_id",
                        column: x => x.BacklogId,
                        principalTable: "backlog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_backloggame_game_id",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_backlog_UserId",
                table: "backlog",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_backlog_game_GameId",
                table: "backlog_game",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "backlog_game");

            migrationBuilder.DropTable(
                name: "backlog");
        }
    }
}
