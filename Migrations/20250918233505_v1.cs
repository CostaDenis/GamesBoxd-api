using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesBoxd_api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "developer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "platform",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platform", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "varchar", maxLength: 256, nullable: false),
                    username = table.Column<string>(type: "varchar", maxLength: 25, nullable: false),
                    bio = table.Column<string>(type: "varchar", maxLength: 300, nullable: true),
                    image = table.Column<string>(type: "varchar", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 80, nullable: false),
                    image = table.Column<string>(type: "varchar", maxLength: 2048, nullable: false),
                    bio = table.Column<string>(type: "varchar", maxLength: 1024, nullable: false),
                    developer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    publisher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    release_date = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    average_rating = table.Column<float>(type: "numeric(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.id);
                    table.ForeignKey(
                        name: "fk_games_developer_id",
                        column: x => x.developer_id,
                        principalTable: "developer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_games_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publisher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "game_list",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    likes = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_list", x => x.id);
                    table.ForeignKey(
                        name: "fk_gamelist_user_id",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users_follows",
                columns: table => new
                {
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FolloweeId = table.Column<Guid>(type: "uuid", nullable: false),
                    is_blocked = table.Column<bool>(type: "boolean", nullable: false),
                    date = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_follows", x => new { x.FollowerId, x.FolloweeId });
                    table.ForeignKey(
                        name: "fk_userfollows_followee_id",
                        column: x => x.FolloweeId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_userfollows_follower_id",
                        column: x => x.FollowerId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_genre",
                columns: table => new
                {
                    game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    genre_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_genre", x => new { x.game_id, x.genre_id });
                    table.ForeignKey(
                        name: "fk_game_genre_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_platform",
                columns: table => new
                {
                    game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    platform_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_platform", x => new { x.game_id, x.platform_id });
                    table.ForeignKey(
                        name: "fk_game_platform_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_platform_platform_id",
                        column: x => x.platform_id,
                        principalTable: "platform",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_games",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_games", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "fk_usergames_game_id",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usergames_user_id",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gamelist_game",
                columns: table => new
                {
                    gamelist_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gamelist_game", x => new { x.gamelist_id, x.game_id });
                    table.ForeignKey(
                        name: "fk_gamelist_game_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_gamelist_game_gamelist_id",
                        column: x => x.gamelist_id,
                        principalTable: "game_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameListId = table.Column<Guid>(type: "uuid", nullable: true),
                    title = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    text = table.Column<string>(type: "varchar", maxLength: 1024, nullable: false),
                    likes = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    has_spoiler = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_comments_gamelist_id",
                        column: x => x.GameListId,
                        principalTable: "game_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    MainCommentId = table.Column<Guid>(type: "uuid", nullable: true),
                    rating = table.Column<float>(type: "numeric(3,2)", nullable: false),
                    likes = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_game_id",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_main_comment_id",
                        column: x => x.MainCommentId,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_reviews_user_id",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_GameListId",
                table: "comments",
                column: "GameListId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ReviewId",
                table: "comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "idx_developer_name",
                table: "developer",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_game_genre_game_id",
                table: "game_genre",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_genre_genre_id",
                table: "game_genre",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_list_UserId",
                table: "game_list",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_game_platform_game_id",
                table: "game_platform",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_platform_platform_id",
                table: "game_platform",
                column: "platform_id");

            migrationBuilder.CreateIndex(
                name: "IX_gamelist_game_game_id",
                table: "gamelist_game",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_gamelist_game_gamelist_id",
                table: "gamelist_game",
                column: "gamelist_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_developer_id",
                table: "games",
                column: "developer_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_publisher_id",
                table: "games",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "idx_genre_name",
                table: "genre",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_platform_name",
                table: "platform",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_publisher_name",
                table: "publisher",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_GameId",
                table: "reviews",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_MainCommentId",
                table: "reviews",
                column: "MainCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_games_GameId",
                table: "user_games",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_user_games_UserId",
                table: "user_games",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "ux_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_users_username",
                table: "users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_follows_FolloweeId",
                table: "users_follows",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_users_follows_FollowerId_FolloweeId",
                table: "users_follows",
                columns: new[] { "FollowerId", "FolloweeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_comment_review_id",
                table: "comments",
                column: "ReviewId",
                principalTable: "reviews",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comment_review_id",
                table: "comments");

            migrationBuilder.DropTable(
                name: "game_genre");

            migrationBuilder.DropTable(
                name: "game_platform");

            migrationBuilder.DropTable(
                name: "gamelist_game");

            migrationBuilder.DropTable(
                name: "user_games");

            migrationBuilder.DropTable(
                name: "users_follows");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "platform");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "developer");

            migrationBuilder.DropTable(
                name: "publisher");

            migrationBuilder.DropTable(
                name: "game_list");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
