using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v120 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "characters",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_user = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    id_class = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.id);
                    table.ForeignKey(
                        name: "FK_characters_classes",
                        column: x => x.id_class,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_characters",
                        column: x => x.id_user,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_runes",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_user = table.Column<string>(type: "text", nullable: false),
                    id_rune = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_runes", x => x.id);
                    table.ForeignKey(
                        name: "FK_runes_user_runes",
                        column: x => x.id_rune,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "runes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_user_runes",
                        column: x => x.id_user,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_characters_id_class",
                schema: "diabloii.resurrected",
                table: "characters",
                column: "id_class");

            migrationBuilder.CreateIndex(
                name: "IX_characters_id_user",
                schema: "diabloii.resurrected",
                table: "characters",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_user_runes_id_rune",
                schema: "diabloii.resurrected",
                table: "user_runes",
                column: "id_rune");

            migrationBuilder.CreateIndex(
                name: "IX_user_runes_id_user",
                schema: "diabloii.resurrected",
                table: "user_runes",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characters",
                schema: "diabloii.resurrected");

            migrationBuilder.DropTable(
                name: "user_runes",
                schema: "diabloii.resurrected");

            migrationBuilder.DropTable(
                name: "users",
                schema: "diabloii.resurrected");
        }
    }
}
