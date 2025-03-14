using BookOfRunes.DiabloII.Resurrected.Infrastructure.Enumerations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Migrations
{
    public static class MigrationBuilderExtensions
    {
        public static void Insert(this MigrationBuilder migrationBuilder, RuneWordEnumeration runeWord)
        {
            migrationBuilder.InsertData("rune_words", new string[] { "id", "name", "level", "url" },
                    new object[] { runeWord.Id, runeWord.Name, runeWord.Level, runeWord.Url }, schema: "diabloii.resurrected");

            foreach (var itemType in runeWord.ItemTypes)
            {
                migrationBuilder.InsertData("rune_words_item_types_switch", new string[] { "item_type_id", "rune_word_id" },
                        new object[] { itemType.Id, runeWord.Id }, schema: "diabloii.resurrected");
            }

            var order = 1;
            foreach (var rune in runeWord.Runes)
            {
                migrationBuilder.InsertData("rune_words_runes_switch", new string[] { "rune_id", "rune_word_id", "order" },
                        new object[] { rune.Id, runeWord.Id, order++ }, schema: "diabloii.resurrected");
            }

            foreach (var statistic in runeWord.Statistics)
            {
                migrationBuilder.InsertData("statistics", new string[] { "description", "rune_word_id", "skill_id" },
                        new object[] { statistic.Description, runeWord.Id, statistic.Skill?.Id }, schema: "diabloii.resurrected");
            }
        }
    }
}
