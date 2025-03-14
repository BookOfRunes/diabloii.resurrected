using BookOfRunes.DiabloII.Resurrected.Infrastructure.Enumerations;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using STrain.Core.Enumerations;

#nullable disable

namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "diabloii.resurrected");

            migrationBuilder.CreateAndFillClasses();
            migrationBuilder.CreateAndFillItemTypes();
            migrationBuilder.CreateAndFillRunes();
            migrationBuilder.CreateAndFillRuneWords();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classes",
                schema: "diabloii.resurrected");
        }
    }

    file static class InitializeMigration
    {
        public static void Insert(this MigrationBuilder migrationBuilder, ItemTypeEnumeration itemType)
        {
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { itemType.Id, itemType.Name, itemType.Class });
        }

        public static void Insert(this MigrationBuilder migrationBuilder, RuneEnumeration rune)
        {
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                new object[] { rune.Id, rune.Name, rune.Level, rune.InWeapon, rune.InHelmet, rune.InBodyArmor, rune.InShield });
        }

        public static void Insert(this MigrationBuilder migrationBuilder, SkillEnumeration skill)
        {
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                new object[] { skill.Id, skill.Name, skill.Description, skill.Url });
        }

        public static void CreateAndFillClasses(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.id);
                });

            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 0, "Amazon" }, schema: "diabloii.resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 1, "Assassin" }, schema: "diabloii.resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 2, "Barbarian" }, schema: "diabloii.resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 3, "Druid" }, schema: "diabloii.resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 4, "Necromancer" }, schema: "diabloii.resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 5, "Paladin" }, schema: "diabloii.resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 6, "Sorceress" }, schema: "diabloii.resurrected");
        }

        public static void CreateAndFillItemTypes(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "item_types",
                 schema: "diabloii.resurrected",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     name = table.Column<string>(type: "text", nullable: false),
                     @class = table.Column<string>(name: "class", type: "text", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_item_types", x => x.id);
                 });

            migrationBuilder.Insert(ItemTypeEnumeration.Helmet);
            migrationBuilder.Insert(ItemTypeEnumeration.BodyArmor);
            migrationBuilder.Insert(ItemTypeEnumeration.Shield);
            migrationBuilder.Insert(ItemTypeEnumeration.PaladinShield);

            migrationBuilder.Insert(ItemTypeEnumeration.Axe);
            migrationBuilder.Insert(ItemTypeEnumeration.Claw);
            migrationBuilder.Insert(ItemTypeEnumeration.Club);
            migrationBuilder.Insert(ItemTypeEnumeration.Dagger);
            migrationBuilder.Insert(ItemTypeEnumeration.Hammer);

            migrationBuilder.Insert(ItemTypeEnumeration.Javelin);
            migrationBuilder.Insert(ItemTypeEnumeration.Mace);
            migrationBuilder.Insert(ItemTypeEnumeration.Orb);
            migrationBuilder.Insert(ItemTypeEnumeration.Scepter);
            migrationBuilder.Insert(ItemTypeEnumeration.Sword);

            migrationBuilder.Insert(ItemTypeEnumeration.ThrowingAxe);
            migrationBuilder.Insert(ItemTypeEnumeration.ThrowingKnife);
            migrationBuilder.Insert(ItemTypeEnumeration.Wand);
            migrationBuilder.Insert(ItemTypeEnumeration.Bow);
            migrationBuilder.Insert(ItemTypeEnumeration.Spear);

            migrationBuilder.Insert(ItemTypeEnumeration.Crossbow);
            migrationBuilder.Insert(ItemTypeEnumeration.Polearm);
            migrationBuilder.Insert(ItemTypeEnumeration.Stave);
        }

        public static void CreateAndFillRunes(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "runes",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    Id = table.Column<int>(name: "id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "name", type: "text", nullable: false),
                    Level = table.Column<int>(name: "level", type: "integer", nullable: true),
                    InWeapon = table.Column<string>(name: "in_weapon", type: "text", nullable: false),
                    InHelmet = table.Column<string>(name: "in_helmet", type: "text", nullable: false),
                    InBodyArmor = table.Column<string>(name: "in_body_armor", type: "text", nullable: false),
                    InShield = table.Column<string>(name: "in_shield", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_runes", x => x.Id);
                });

            migrationBuilder.Insert(RuneEnumeration.El);
            migrationBuilder.Insert(RuneEnumeration.Eld);
            migrationBuilder.Insert(RuneEnumeration.Tir);
            migrationBuilder.Insert(RuneEnumeration.Nef);
            migrationBuilder.Insert(RuneEnumeration.Eth);
            migrationBuilder.Insert(RuneEnumeration.Ith);
            migrationBuilder.Insert(RuneEnumeration.Tal);
            migrationBuilder.Insert(RuneEnumeration.Ral);
            migrationBuilder.Insert(RuneEnumeration.Ort);
            migrationBuilder.Insert(RuneEnumeration.Thul);
            migrationBuilder.Insert(RuneEnumeration.Amn);

            migrationBuilder.Insert(RuneEnumeration.Sol);
            migrationBuilder.Insert(RuneEnumeration.Shael);
            migrationBuilder.Insert(RuneEnumeration.Dol);
            migrationBuilder.Insert(RuneEnumeration.Hel);
            migrationBuilder.Insert(RuneEnumeration.Io);
            migrationBuilder.Insert(RuneEnumeration.Lum);
            migrationBuilder.Insert(RuneEnumeration.Ko);
            migrationBuilder.Insert(RuneEnumeration.Fal);
            migrationBuilder.Insert(RuneEnumeration.Lem);
            migrationBuilder.Insert(RuneEnumeration.Pul);
            migrationBuilder.Insert(RuneEnumeration.Um);

            migrationBuilder.Insert(RuneEnumeration.Mal);
            migrationBuilder.Insert(RuneEnumeration.Ist);
            migrationBuilder.Insert(RuneEnumeration.Gul);
            migrationBuilder.Insert(RuneEnumeration.Vex);
            migrationBuilder.Insert(RuneEnumeration.Ohm);
            migrationBuilder.Insert(RuneEnumeration.Lo);
            migrationBuilder.Insert(RuneEnumeration.Sur);
            migrationBuilder.Insert(RuneEnumeration.Ber);
            migrationBuilder.Insert(RuneEnumeration.Jah);
            migrationBuilder.Insert(RuneEnumeration.Cham);
            migrationBuilder.Insert(RuneEnumeration.Zod);
        }

        public static void CreateAndFillRuneWords(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rune_words",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rune_words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rune_words_item_types_switch",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    item_type_id = table.Column<int>(type: "integer", nullable: false),
                    rune_word_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rune_words_item_types_switch", x => new { x.item_type_id, x.rune_word_id });
                    table.ForeignKey(
                        name: "FK_item_types_rune_words",
                        column: x => x.item_type_id,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "item_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rune_words_item_types",
                        column: x => x.rune_word_id,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "rune_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rune_words_runes_switch",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    rune_id = table.Column<int>(type: "integer", nullable: false),
                    rune_word_id = table.Column<int>(type: "integer", nullable: false),
                    order = table.Column<byte>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rune_words_runes_switch", x => new { x.rune_id, x.rune_word_id, x.order });
                    table.ForeignKey(
                        name: "FK_rune_words_runes",
                        column: x => x.rune_word_id,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "rune_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_runes_rune_words",
                        column: x => x.rune_id,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "runes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
               name: "skills",
               schema: "diabloii.resurrected",
               columns: table => new
               {
                   id = table.Column<int>(type: "integer", nullable: false)
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   name = table.Column<string>(type: "text", nullable: false),
                   description = table.Column<string>(type: "text", nullable: false),
                   url = table.Column<string>(type: "text", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_skills", x => x.id);
               });

            migrationBuilder.CreateTable(
                name: "statistics",
                schema: "diabloii.resurrected",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    rune_word_id = table.Column<int>(type: "integer", nullable: false),
                    skill_id = table.Column<int?>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statistics", x => x.id);
                    table.ForeignKey(
                        name: "FK_rune_word_statistics",
                        column: x => x.rune_word_id,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "rune_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_statistics_skills",
                        column: x => x.skill_id,
                        principalSchema: "diabloii.resurrected",
                        principalTable: "skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Insert(SkillEnumeration.Fanaticism);
            migrationBuilder.Insert(SkillEnumeration.Werebear);
            migrationBuilder.Insert(SkillEnumeration.Lycanthropy);
            migrationBuilder.Insert(SkillEnumeration.SummonGrizzly);
            migrationBuilder.Insert(SkillEnumeration.CorpseExplosion);
            migrationBuilder.Insert(SkillEnumeration.BoneArmor);
            migrationBuilder.Insert(SkillEnumeration.BoneSpear);
            migrationBuilder.Insert(SkillEnumeration.Thorns);
            migrationBuilder.Insert(SkillEnumeration.SpiritOfBarbs);
            migrationBuilder.Insert(SkillEnumeration.AmplifyDamage);
            migrationBuilder.Insert(SkillEnumeration.ExplodingArrow);
            migrationBuilder.Insert(SkillEnumeration.PoisonNova);
            migrationBuilder.Insert(SkillEnumeration.BattleCommand);
            migrationBuilder.Insert(SkillEnumeration.BattleOrder);
            migrationBuilder.Insert(SkillEnumeration.BattleCry);
            migrationBuilder.Insert(SkillEnumeration.FrozenOrb);
            migrationBuilder.Insert(SkillEnumeration.ChargedBolt);
            migrationBuilder.Insert(SkillEnumeration.Whirlwind);
            migrationBuilder.Insert(SkillEnumeration.ChainLightning);
            migrationBuilder.Insert(SkillEnumeration.StaticField);
            migrationBuilder.Insert(SkillEnumeration.SummonSpiritWolf);
            migrationBuilder.Insert(SkillEnumeration.GlacialSpike);
            migrationBuilder.Insert(SkillEnumeration.BloodGolem);
            migrationBuilder.Insert(SkillEnumeration.MindBlast);
            migrationBuilder.Insert(SkillEnumeration.Terror);
            migrationBuilder.Insert(SkillEnumeration.Confuse);
            migrationBuilder.Insert(SkillEnumeration.Volcano);
            migrationBuilder.Insert(SkillEnumeration.HolyFreeze);
            migrationBuilder.Insert(SkillEnumeration.Venom);
            migrationBuilder.Insert(SkillEnumeration.Hydra);
            migrationBuilder.Insert(SkillEnumeration.HolyFire);
            migrationBuilder.Insert(SkillEnumeration.HolyShock);
            migrationBuilder.Insert(SkillEnumeration.Teleport);
            migrationBuilder.Insert(SkillEnumeration.Blaze);
            migrationBuilder.Insert(SkillEnumeration.Fireball);
            migrationBuilder.Insert(SkillEnumeration.Warmth);
            migrationBuilder.Insert(SkillEnumeration.Revive);
            migrationBuilder.Insert(SkillEnumeration.LifeTap);
            migrationBuilder.Insert(SkillEnumeration.Defiance);
            migrationBuilder.Insert(SkillEnumeration.ChillingArmor);
            migrationBuilder.Insert(SkillEnumeration.Frenzy);
            migrationBuilder.Insert(SkillEnumeration.DimVision);
            migrationBuilder.Insert(SkillEnumeration.Meteor);
            migrationBuilder.Insert(SkillEnumeration.Vigor);
            migrationBuilder.Insert(SkillEnumeration.Valkyrie);
            migrationBuilder.Insert(SkillEnumeration.OakSage);
            migrationBuilder.Insert(SkillEnumeration.Raven);
            migrationBuilder.Insert(SkillEnumeration.Blizzard);
            migrationBuilder.Insert(SkillEnumeration.FrostNova);
            migrationBuilder.Insert(SkillEnumeration.Conviction);
            migrationBuilder.Insert(SkillEnumeration.CycloneArmor);
            migrationBuilder.Insert(SkillEnumeration.Meditation);
            migrationBuilder.Insert(SkillEnumeration.Twister);
            migrationBuilder.Insert(SkillEnumeration.Vengeance);
            migrationBuilder.Insert(SkillEnumeration.Fade);
            migrationBuilder.Insert(SkillEnumeration.Might);
            migrationBuilder.Insert(SkillEnumeration.Decrepify);
            migrationBuilder.Insert(SkillEnumeration.Sanctuary);
            migrationBuilder.Insert(SkillEnumeration.Inferno);
            migrationBuilder.Insert(SkillEnumeration.FireBolt);
            migrationBuilder.Insert(SkillEnumeration.SlowMissiles);
            migrationBuilder.Insert(SkillEnumeration.Dodge);
            migrationBuilder.Insert(SkillEnumeration.CriticalStrike);
            migrationBuilder.Insert(SkillEnumeration.EnergyShield);
            migrationBuilder.Insert(SkillEnumeration.Howl);
            migrationBuilder.Insert(SkillEnumeration.Taunt);
            migrationBuilder.Insert(SkillEnumeration.CloackOfShadows);
            migrationBuilder.Insert(SkillEnumeration.BoneSpirit);
            migrationBuilder.Insert(SkillEnumeration.HeartOfWolverine);
            migrationBuilder.Insert(SkillEnumeration.IronGolem);
            migrationBuilder.Insert(SkillEnumeration.Enchant);
            migrationBuilder.Insert(SkillEnumeration.Berserk);
            migrationBuilder.Insert(SkillEnumeration.Zeal);
            migrationBuilder.Insert(SkillEnumeration.Firestorm);
            migrationBuilder.Insert(SkillEnumeration.Redemption);
            migrationBuilder.Insert(SkillEnumeration.FireWall);
            migrationBuilder.Insert(SkillEnumeration.Concentration);
            migrationBuilder.Insert(SkillEnumeration.HolyBolt);
            migrationBuilder.Insert(SkillEnumeration.Tornado);
            migrationBuilder.Insert(SkillEnumeration.IronMaiden);
            migrationBuilder.Insert(SkillEnumeration.Weaken);
            migrationBuilder.Insert(SkillEnumeration.MoltenBoulder);
            migrationBuilder.Insert(SkillEnumeration.ClayGolem);
            migrationBuilder.Insert(SkillEnumeration.PosionExplosion);
            migrationBuilder.Insert(SkillEnumeration.IceBlast);
            migrationBuilder.Insert(SkillEnumeration.SkeletonMastery);
            migrationBuilder.Insert(SkillEnumeration.Attract);
            migrationBuilder.Insert(SkillEnumeration.Nova);
            migrationBuilder.Insert(SkillEnumeration.LowerResist);
            migrationBuilder.Insert(SkillEnumeration.Cleansing);
            migrationBuilder.Insert(SkillEnumeration.ResistFire);

            migrationBuilder.CreateIndex(
                name: "IX_rune_words_id",
                table: "rune_words",
                schema: "diabloii.resurrected",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_rune_words_item_types_switch_rune_word_id",
                table: "rune_words_item_types_switch",
                schema: "diabloii.resurrected",
                column: "rune_word_id");

            migrationBuilder.CreateIndex(
                name: "IX_rune_words_runes_switch_rune_word_id",
                table: "rune_words_runes_switch",
                schema: "diabloii.resurrected",
                column: "rune_word_id");

            migrationBuilder.CreateIndex(
                name: "IX_statistic_skill_id",
                table: "statistics",
                schema: "diabloii.resurrected",
                column: "skill_id");

            migrationBuilder.Insert(RuneWordEnumeration.AncientsPledge);
            migrationBuilder.Insert(RuneWordEnumeration.Beast);
            migrationBuilder.Insert(RuneWordEnumeration.Black);
            migrationBuilder.Insert(RuneWordEnumeration.Bone);
            migrationBuilder.Insert(RuneWordEnumeration.Bramble);
            migrationBuilder.Insert(RuneWordEnumeration.Brand);
            migrationBuilder.Insert(RuneWordEnumeration.BreathOfTheDying);
            migrationBuilder.Insert(RuneWordEnumeration.CallToArms);
            migrationBuilder.Insert(RuneWordEnumeration.ChainsOfHonor);
            migrationBuilder.Insert(RuneWordEnumeration.Chaos);
            migrationBuilder.Insert(RuneWordEnumeration.CrescentMoon);
            migrationBuilder.Insert(RuneWordEnumeration.Death);
            migrationBuilder.Insert(RuneWordEnumeration.Delirium);
            migrationBuilder.Insert(RuneWordEnumeration.Destruction);
            migrationBuilder.Insert(RuneWordEnumeration.Doom);
            migrationBuilder.Insert(RuneWordEnumeration.Dragon);
            migrationBuilder.Insert(RuneWordEnumeration.Dream);
            migrationBuilder.Insert(RuneWordEnumeration.Duress);
            migrationBuilder.Insert(RuneWordEnumeration.Edge);
            migrationBuilder.Insert(RuneWordEnumeration.Enigma);
            migrationBuilder.Insert(RuneWordEnumeration.Enlightenment);
            migrationBuilder.Insert(RuneWordEnumeration.Eternity);
            migrationBuilder.Insert(RuneWordEnumeration.Exile);
            migrationBuilder.Insert(RuneWordEnumeration.Faith);
            migrationBuilder.Insert(RuneWordEnumeration.Famine);
            migrationBuilder.Insert(RuneWordEnumeration.Fortitude);
            migrationBuilder.Insert(RuneWordEnumeration.Fury);
            migrationBuilder.Insert(RuneWordEnumeration.Gloom);
            migrationBuilder.Insert(RuneWordEnumeration.Grief);
            migrationBuilder.Insert(RuneWordEnumeration.HandOfJustice);
            migrationBuilder.Insert(RuneWordEnumeration.Harmony);
            migrationBuilder.Insert(RuneWordEnumeration.HeartOfTheOak);
            migrationBuilder.Insert(RuneWordEnumeration.HolyThunder);
            migrationBuilder.Insert(RuneWordEnumeration.Honor);
            migrationBuilder.Insert(RuneWordEnumeration.Ice);
            migrationBuilder.Insert(RuneWordEnumeration.Infinity);
            migrationBuilder.Insert(RuneWordEnumeration.Insight);
            migrationBuilder.Insert(RuneWordEnumeration.KingsGrace);
            migrationBuilder.Insert(RuneWordEnumeration.Kingslayer);
            migrationBuilder.Insert(RuneWordEnumeration.LastWish);
            migrationBuilder.Insert(RuneWordEnumeration.Lionheart);
            migrationBuilder.Insert(RuneWordEnumeration.Lore);
            migrationBuilder.Insert(RuneWordEnumeration.Malice);
            migrationBuilder.Insert(RuneWordEnumeration.Melody);
            migrationBuilder.Insert(RuneWordEnumeration.Memory);
            migrationBuilder.Insert(RuneWordEnumeration.Myth);
            migrationBuilder.Insert(RuneWordEnumeration.Nadir);
            migrationBuilder.Insert(RuneWordEnumeration.Oath);
            migrationBuilder.Insert(RuneWordEnumeration.Obedience);
            migrationBuilder.Insert(RuneWordEnumeration.Passion);
            migrationBuilder.Insert(RuneWordEnumeration.Peace);
            migrationBuilder.Insert(RuneWordEnumeration.Phoenix);
            migrationBuilder.Insert(RuneWordEnumeration.Pride);
            migrationBuilder.Insert(RuneWordEnumeration.Principle);
            migrationBuilder.Insert(RuneWordEnumeration.Prudence);
            migrationBuilder.Insert(RuneWordEnumeration.Radiance);
            migrationBuilder.Insert(RuneWordEnumeration.Rain);
            migrationBuilder.Insert(RuneWordEnumeration.Rhyme);
            migrationBuilder.Insert(RuneWordEnumeration.Rift);
            migrationBuilder.Insert(RuneWordEnumeration.Sanctuary);
            migrationBuilder.Insert(RuneWordEnumeration.Silence);
            migrationBuilder.Insert(RuneWordEnumeration.Smoke);
            migrationBuilder.Insert(RuneWordEnumeration.Spirit);
            migrationBuilder.Insert(RuneWordEnumeration.Splendor);
            migrationBuilder.Insert(RuneWordEnumeration.Stealth);
            migrationBuilder.Insert(RuneWordEnumeration.Steel);
            migrationBuilder.Insert(RuneWordEnumeration.Stone);
            migrationBuilder.Insert(RuneWordEnumeration.Strength);
            migrationBuilder.Insert(RuneWordEnumeration.Treachery);
            migrationBuilder.Insert(RuneWordEnumeration.Venom);
            migrationBuilder.Insert(RuneWordEnumeration.VoiceOfReason);
            migrationBuilder.Insert(RuneWordEnumeration.Wealth);
            migrationBuilder.Insert(RuneWordEnumeration.White);
            migrationBuilder.Insert(RuneWordEnumeration.Wind);
            migrationBuilder.Insert(RuneWordEnumeration.Wrath);
            migrationBuilder.Insert(RuneWordEnumeration.Zephyr);
            migrationBuilder.Insert(RuneWordEnumeration.Mist);
            migrationBuilder.Insert(RuneWordEnumeration.Wisdom);
            migrationBuilder.Insert(RuneWordEnumeration.Pattern);
            migrationBuilder.Insert(RuneWordEnumeration.Obsession);
            migrationBuilder.Insert(RuneWordEnumeration.FlickeringFlame);
        }
    }
}
