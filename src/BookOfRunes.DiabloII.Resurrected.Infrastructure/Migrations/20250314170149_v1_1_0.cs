using BookOfRunes.DiabloII.Resurrected.Infrastructure.Enumerations;
using Microsoft.EntityFrameworkCore.Migrations;
using STrain.Core.Enumerations;

#nullable disable

namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1_1_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Insert(RuneWordEnumeration.Mosaic);
            migrationBuilder.Insert(RuneWordEnumeration.Bulwark);
            migrationBuilder.Insert(RuneWordEnumeration.Metamorphosis);
            migrationBuilder.Insert(RuneWordEnumeration.Hustle);
            migrationBuilder.Insert(RuneWordEnumeration.Cure);
            migrationBuilder.Insert(RuneWordEnumeration.Heart);
            migrationBuilder.Insert(RuneWordEnumeration.Ground);
            migrationBuilder.Insert(RuneWordEnumeration.Temper);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_statistics_skill_id",
                schema: "diabloii.resurrected",
                table: "statistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_runes",
                schema: "diabloii.resurrected",
                table: "runes");

            migrationBuilder.DropColumn(
                name: "order",
                schema: "diabloii.resurrected",
                table: "rune_words_runes_switch");

            migrationBuilder.RenameTable(
                name: "runes",
                schema: "diabloii.resurrected",
                newName: "Runes");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Runes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Runes",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Runes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "in_weapon",
                table: "Runes",
                newName: "InWeapon");

            migrationBuilder.RenameColumn(
                name: "in_shield",
                table: "Runes",
                newName: "InShield");

            migrationBuilder.RenameColumn(
                name: "in_helmet",
                table: "Runes",
                newName: "InHelmet");

            migrationBuilder.RenameColumn(
                name: "in_body_armor",
                table: "Runes",
                newName: "InBodyArmor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Runes",
                table: "Runes",
                column: "Id");
        }
    }
}
