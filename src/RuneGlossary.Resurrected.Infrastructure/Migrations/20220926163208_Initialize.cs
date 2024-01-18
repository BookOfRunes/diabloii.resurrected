using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using STrain.Core.Enumerations;

#nullable disable

namespace RuneGlossary.Resurrected.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "resurrected");

            migrationBuilder.CreateAndFillClasses();
            migrationBuilder.CreateAndFillItemTypes();
            migrationBuilder.CreateAndFillRunes();
            migrationBuilder.CreateAndFillRuneWords();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classes",
                schema: "resurrected");
        }
    }

    public class ItemTypeEnumeration : Enumeration
    {
        public string Class { get; }

        public static ItemTypeEnumeration Helmet => new(0, "Helmet", "Armor");
        public static ItemTypeEnumeration BodyArmor => new(1, "Body Armor", "Armor");
        public static ItemTypeEnumeration Shield => new(2, "Shield", "Armor");
        public static ItemTypeEnumeration PaladinShield => new(21, "Paladin Shield", "Armor");

        public static ItemTypeEnumeration Axe => new(3, "Axe", "Weapon");
        public static ItemTypeEnumeration Claw => new(4, "Claw", "Weapon");
        public static ItemTypeEnumeration Club => new(5, "Club", "Weapon");
        public static ItemTypeEnumeration Dagger => new(6, "Dagger", "Weapon");
        public static ItemTypeEnumeration Hammer => new(7, "Hammer", "Weapon");
        public static ItemTypeEnumeration Javelin => new(8, "Javelin", "Weapon");
        public static ItemTypeEnumeration Mace => new(9, "Mace", "Weapon");
        public static ItemTypeEnumeration Orb => new(10, "Orb", "Weapon");
        public static ItemTypeEnumeration Scepter => new(11, "Scepter", "Weapon");
        public static ItemTypeEnumeration Sword => new(12, "Sword", "Weapon");
        public static ItemTypeEnumeration ThrowingAxe => new(13, "Throwing Axe", "Weapon");
        public static ItemTypeEnumeration ThrowingKnife => new(14, "Throwing Knife", "Weapon");
        public static ItemTypeEnumeration Wand => new(15, "Wand", "Weapon");
        public static ItemTypeEnumeration Bow => new(16, "Bow", "Weapon");
        public static ItemTypeEnumeration Spear => new(17, "Spear", "Weapon");
        public static ItemTypeEnumeration Crossbow => new(18, "Crossbow", "Weapon");
        public static ItemTypeEnumeration Polearm => new(19, "Polearm", "Weapon");
        public static ItemTypeEnumeration Stave => new(20, "Stave", "Weapon");

        public ItemTypeEnumeration(int id, string name, string @class)
            : base(id, name)
        {
            Class = @class;
        }

    }

    public class RuneEnumeration : Enumeration
    {
        public int? Level { get; }
        public string InWeapon { get; }
        public string InHelmet { get; }
        public string InBodyArmor { get; }
        public string InShield { get; }

        public static RuneEnumeration El => new(0, "El", 11, "+50 attack rating;+1 light radius", "+15 defense;+1 light radius", "+15 defense;+1 light radius", "+15 defense;+1 light radius");
        public static RuneEnumeration Eld => new(1, "Eld", 11, "+75% Damage vs. Undead;+50 Attack Rating vs. Undead", "Lowers Stamina drain by 15%", "Lowers Stamina drain by 15%", "+7% Blocking");
        public static RuneEnumeration Tir => new(2, "Tir", 13, "+2 Mana Per Kill", "+2 Mana Per Kill", "+2 Mana Per Kill", "+2 Mana Per Kill");
        public static RuneEnumeration Nef => new(3, "Nef", 13, "Knockback", "+30 Defense vs. Missile", "+30 Defense vs. Missile", "+30 Defense vs. Missile");
        public static RuneEnumeration Eth => new(4, "Eth", 15, "-25% Target Defense", "Regenerate Mana 15%", "Regenerate Mana 15%", "Regenerate Mana 15%");
        public static RuneEnumeration Ith => new(5, "Ith", 15, "+9 to Maximum Damage", "15% Damage Taken Goes to Mana", "15% Damage Taken Goes to Mana", "15% Damage Taken Goes to Mana");
        public static RuneEnumeration Tal => new(6, "Tal", 17, "75 Poison damage over 5 seconds", "+30% Poison Resistance", "+30% Poison Resistance", "+35% Poison Resistance");
        public static RuneEnumeration Ral => new(7, "Ral", 19, "+5-30 Fire Damage", "+30% Fire Resistance", "+30% Fire Resistance", "+35% Fire Resistance");
        public static RuneEnumeration Ort => new(8, "Ort", 21, "+1-50 Lightning Damage", "+30% Lightning Resistance", "+30% Lightning Resistance", "+35% Lightning Resistance");
        public static RuneEnumeration Thul => new(9, "Thul", 23, "+3-14 Cold Damage (Cold Length 3 seconds)", "+30% Cold Resistance", "+30% Cold Resistance", "+35% Cold Resistance");
        public static RuneEnumeration Amn => new(10, "Amn", 25, "7% Life Stolen Per Hit", "Attacker takes 14 damage", "Attacker takes 14 damage", "Attacker takes 14 damage");
        public static RuneEnumeration Sol => new(11, "Sol", 27, "+9 to Minimum Damage", "-7 Damage Taken", "-7 Damage Taken", "-7 Damage Taken");
        public static RuneEnumeration Shael => new(12, "Shael", 29, "Faster Attack Rate (+20)", "Faster Hit Recovery (+20)", "Faster Hit Recovery (+20)", "Faster Block Rate (+20)");
        public static RuneEnumeration Dol => new(13, "Dol", 31, "25% Chance that Hit Causes Monster to Flee", "+7 Replenish Life", "+7 Replenish Life", "+7 Replenish Life");
        public static RuneEnumeration Hel => new(14, "Hel", null, "-20% Requirements", "-15% Requirements", "-15% Requirements", "-15% Requirements");
        public static RuneEnumeration Io => new(15, "Io", 35, "+10 Vitality", "+10 Vitality", "+10 Vitality", "+10 Vitality");
        public static RuneEnumeration Lum => new(16, "Lum", 37, "+10 Energy", "+10 Energy", "+10 Energy", "+10 Energy");
        public static RuneEnumeration Ko => new(17, "Ko", 39, "+10 Dexterity", "+10 Dexterity", "+10 Dexterity", "+10 Dexterity");
        public static RuneEnumeration Fal => new(18, "Fal", 41, "+10 Strength", "+10 Strength", "+10 Strength", "+10 Strength");
        public static RuneEnumeration Lem => new(19, "Lem", 43, "+75% Extra Gold from Monsters", "+50% Extra Gold from Monsters", "+50% Extra Gold from Monsters", "+50% Extra Gold from Monsters");
        public static RuneEnumeration Pul => new(20, "Pul", 45, "+75% Damage to Demons;+100 AR against Demons", "+30% Defense", "+30% Defense", "+30% Defense");
        public static RuneEnumeration Um => new(21, "Um", 47, "25% Chance of Open Wounds", "+15% Resist All", "+15% Resist All", "+22% Resist All");
        public static RuneEnumeration Mal => new(22, "Mal", 49, "Prevent Monster Healing", "Reduce Magic Damage by 7", "Reduce Magic Damage by 7", "Reduce Magic Damage by 7");
        public static RuneEnumeration Ist => new(23, "Ist", 51, "+30% Better Chance of Finding Magical Items", "+25% Better Chance of Finding Magical Items", "+25% Better Chance of Finding Magical Items", "+25% Better Chance of Finding Magical Items");
        public static RuneEnumeration Gul => new(24, "Gul", 53, "+20% Attack Rating", "+5 to Max Resist Poison", "+5 to Max Resist Poison", "+5 to Max Resist Poison");
        public static RuneEnumeration Vex => new(25, "Vex", 55, "7% Mana Leech", "+5 to Max Fire Resist", "+5 to Max Fire Resist", "+5 to Max Fire Resist");
        public static RuneEnumeration Ohm => new(26, "Ohm", 57, "+50% Damage", "+5 to Max. Resist Cold", "+5 to Max. Resist Cold", "+5 to Max. Resist Cold");
        public static RuneEnumeration Lo => new(27, "Lo", 59, "20% Chance of Deadly Strike", "+5 to Max. Resist Lightning", "+5 to Max. Resist Lightning", "+5 to Max. Resist Lightning");
        public static RuneEnumeration Sur => new(28, "Sur", 61, "20% Chance of Hit Blinds Target", "+5% total Mana", "+5% total Mana", "+50 Mana");
        public static RuneEnumeration Ber => new(29, "Ber", 63, "20% Chance of Crushing Blow", "Damage Reduced by 8%", "Damage Reduced by 8%", "Damage Reduced by 8%");
        public static RuneEnumeration Jah => new(30, "Jah", 65, "Ignores Target Defense", "+5% of total Hit Points", "+5% of total Hit Points", "+50 Hit Points");
        public static RuneEnumeration Cham => new(31, "Cham", 67, "32% Chance of Hit Freezing Target for 3 seconds", "Cannot be Frozen", "Cannot be Frozen", "Cannot be Frozen");
        public static RuneEnumeration Zod => new(32, "Zod", 69, "Indestructible", "Indestructible", "Indestructible", "Indestructible");

        public RuneEnumeration(int id, string name, int? level, string inWeapon, string inHelmet, string inBodyArmor, string inShield)
            : base(id, name)
        {
            Level = level;
            InWeapon = inWeapon;
            InHelmet = inHelmet;
            InBodyArmor = inBodyArmor;
            InShield = inShield;
        }
    }

    public class SkillEnumeration : Enumeration
    {
        public string Description { get; }
        public string Url { get; }

        public static SkillEnumeration Fanaticism => new(0, "Fanaticism", "Fanaticism increases the damage, attack speed, and attack rating of the Paladin and everyone in his party.", "https://diablo2.wiki.fextralife.com/Fanaticism");
        public static SkillEnumeration Werebear => new(1, "Werebear", "This skill enables the Druid to transform into a Werebear. It includes substantial bonuses to his defense, damage, and life.", "https://diablo2.wiki.fextralife.com/Werebear");
        public static SkillEnumeration Lycanthropy => new(2, "Lycanthropy", "This skill adds a passive bonus that allows the Druid to remain in fur form much longer. There is also a substantial hit point boost.", "https://diablo2.wiki.fextralife.com/Lycanthropy");
        public static SkillEnumeration SummonGrizzly => new(3, "Summon Grizzly", "Summoned Grizzlies are fierce minions, capable of inflicting heavy damage. Grizzlies move slowly, but have strong attacks that stun and knock back their targets.", "https://diablo2.wiki.fextralife.com/Summon+Grizzly");
        public static SkillEnumeration CorpseExplosion => new(4, "Corpse Explosion", "One of the messiest and most fun skills in the game, Corpse Explosion detonates fallen monster corpses in messy sprays of bone and blood, striking all nearby enemies for substantial fire and physical damage.", "https://diablo2.wiki.fextralife.com/Corpse+Explosion");
        public static SkillEnumeration BoneArmor => new(5, "Bone Armor", "An orbiting shield that absorbs a set amount of physical damage before vanishing.", "https://diablo2.wiki.fextralife.com/Bone_Armor");
        public static SkillEnumeration BoneSpear => new(6, "Bone Spear", "Bone Spear fires a straight shot of magical damage bone that can pass through any number of targets. It does less damage to each target than Bone Spirit (until very high levels), but can hit multiple enemies, and is very effective against large mobs, or in narrow hallways, such as inside the Maggot Lair. Their damage is magical so only by raise skill levels can you increase it.", "https://diablo2.wiki.fextralife.com/Bone_Spear");
        public static SkillEnumeration Thorns => new(7, "Thorns", "Creates a spiky barrier around the Paladin and all in his party, reflecting huge damage back against melee, physical attackers. Has no effect against ranged or elemental attacks.", "https://diablo2.wiki.fextralife.com/Thorns");
        public static SkillEnumeration SpiritOfBarbs => new(8, "Spirit of Barbs", "This spirit bestows a Thorns aura on the Druid and all in his party.", "https://diablo2.wiki.fextralife.com/Spirit+of+Barbs");
        public static SkillEnumeration AmplifyDamage => new(9, "Amplify Damage", "Amplify damage greatly increases the physical damage taken by any afflicted target.", "https://diablo2.wiki.fextralife.com/Amplify+Damage");
        public static SkillEnumeration ExplodingArrow => new(10, "Exploding Arrow", "Enchants arrows by adding explosive fire damage to them. The flame splashes enough to strike several monsters in a tight cluster, and there is an accuracy bonus as well.", "https://diablo2.wiki.fextralife.com/Exploding+Arrow");
        public static SkillEnumeration PoisonNova => new(11, "Poison Nova", "Poison Nova sends out an expanding circle of toxic bolts, poisoning everything within range, and virtually everything on the screen.", "https://diablo2.wiki.fextralife.com/Poison+Nova");
        public static SkillEnumeration BattleCommand => new(12, "Battle Command", "Battle Command adds a +1 to all of the Barbarian's skills, and does the same for all characters and minions in his party.", "https://diablo2.wiki.fextralife.com/Battle+Command");
        public static SkillEnumeration BattleOrder => new(13, "Battle Orders", "Improve party members' life, mana and stamina.", "https://diablo2.wiki.fextralife.com/Battle+Orders");
        public static SkillEnumeration BattleCry => new(14, "Battle Cry", "Fearsome cry reduces enemy effectiveness.", "https://diablo2.wiki.fextralife.com/Battle+Cry");
        public static SkillEnumeration FrozenOrb => new(15, "Frozen Orb", "One of the more awesome spells in the game, Frozen Orb fires out a glowing orb of ice that spins across most of the visible screen, emitting dozens of tiny Ice Bolts in all directions.", "https://diablo2.wiki.fextralife.com/Frozen+Orb");
        public static SkillEnumeration ChargedBolt => new(16, "Charged Bolt", "Charged bolt is one of the first skills a sorceress can learn, and is one of the few level 1 skills that scales well end game.", "https://diablo2.wiki.fextralife.com/Charged+Bolt");
        public static SkillEnumeration Whirlwind => new(17, "Whirlwind", "Whirlwind is the Tasmanian Devil of Barbarian skills, turning the character into a spinning death-dealer, capable of passing through huge mobs and hitting dozens of targets with a single use of the skill.", "https://diablo2.wiki.fextralife.com/Whirlwind");
        public static SkillEnumeration ChainLightning => new(18, "Chain Lightning", "Chain Lightning jumps from target to target, and can be quite impressive when cast on a cluster of enemies.", "https://diablo2.wiki.fextralife.com/Chain+Lightning");
        public static SkillEnumeration StaticField => new(19, "Static Field", "Static Field hits every monster in range, instantly chopping 25% off of their current hit points (similar to crushing blow).", "https://diablo2.wiki.fextralife.com/Static");
        public static SkillEnumeration SummonSpiritWolf => new(20, "Summon Spirit Wolf", "This gift of Nature allows the Druid to conjure forth one or more wolf allies who, with their mystical powers, provide the Druid a potent and ferocious colleague.", "https://diablo2.wiki.fextralife.com/Summon+Spirit+Wolf");
        public static SkillEnumeration GlacialSpike => new(21, "Glacial Spike", "Shoots a large snowball that hits with substantial damage and a large splash effect, freezing the targeted monster and anything within 2.6 yards.", "https://diablo2.wiki.fextralife.com/Glacial+Spike");
        public static SkillEnumeration BloodGolem => new(22, "Blood Golem", "Blood Golems are linked to the Necromancer who casts them. As the Blood Golem damages the target it leeches life, and shares this with the Necromancer.", "https://diablo2.wiki.fextralife.com/Blood+Golem");
        public static SkillEnumeration MindBlast => new(23, "Mind Blast", "Focusing her anima, an Assassin using this potent ability can crush the will of a group of enemies. Mind Blast stuns and confuses the feeble minded into attacking their comrades.", "https://diablo2.wiki.fextralife.com/Mind+Blast");
        public static SkillEnumeration Terror => new(24, "Terror", "Cursed monsters run away at very high speed.", "https://diablo2.wiki.fextralife.com/Terror");
        public static SkillEnumeration Confuse => new(25, "Confuse", "Confused monsters attack whatever target is nearest them, including other monsters.", "https://diablo2.wiki.fextralife.com/Confuse");
        public static SkillEnumeration Volcano => new(26, "Volcano", "A more powerful version of Fissure, the Volcano erupts from one point and deals substantial fire damage to everything in the vicinity.", "https://diablo2.wiki.fextralife.com/Volcano");
        public static SkillEnumeration HolyFreeze => new(27, "Holy Freeze", "This aura chills and slows the movement and attack speed of all enemies within range. It also deals constant cold damage, and adds cold damage to the Paladin's attacks.", "https://diablo2.wiki.fextralife.com/Holy+Freeze");
        public static SkillEnumeration Venom => new(28, "Venom", "Poison use is another technique an Assassin has to help even the odds when battling demons and their ilk. An Assassin who has mastered this skill secretly coats her weapons with vile toxins.", "https://diablo2.wiki.fextralife.com/Venom");
        public static SkillEnumeration Hydra => new(29, "Hydra", "Hydras are three-headed dragons composed of pure flame. The heads each fire a constant stream of Fire Bolts, dealing damage to the target, but not splashing to the sides.", "https://diablo2.wiki.fextralife.com/Hydra");
        public static SkillEnumeration HolyFire => new(30, "Holy Fire", "Holy Fire adds fire damage to the Paladin's attacks, as well as dealing a few points of fire damage to every monster in range.", "https://diablo2.wiki.fextralife.com/Holy+Fire");
        public static SkillEnumeration HolyShock => new(31, "Holy Shock", "Holy Shock adds lightning damage to the Paladin's attacks, as well as dealing a few points of lightning damage to every monster in range.", "https://diablo2.wiki.fextralife.com/Holy+Shock");
        public static SkillEnumeration Teleport => new(32, "Teleport", "Teleport moves the Sorceress instantly to any valid location she can point her cursor at.", "https://diablo2.wiki.fextralife.com/Teleport");
        public static SkillEnumeration Blaze => new(33, "Blaze", "Blaze leaves a trail of fire behind the Sorceress as she walks or runs along, for as long as she keeps the spell active.", "https://diablo2.wiki.fextralife.com/Blaze");
        public static SkillEnumeration Fireball => new(34, "Fireball", "A substantial upgrade from Firebolt, Fireballs are larger and more damaging, and they hit with splash damage, burning the target and any nearby monsters too.", "https://diablo2.wiki.fextralife.com/Fireball");
        public static SkillEnumeration Warmth => new(35, "Warmth", "Warmth increases the Sorceress' mana regeneration rate.", "https://diablo2.wiki.fextralife.com/Warmth");
        public static SkillEnumeration Revive => new(36, "Revive", "Revives the dead monster, raising it up in its living form, but coloured dark gray.", "https://diablo2.wiki.fextralife.com/Revive");
        public static SkillEnumeration LifeTap => new(37, "Life Tap", "Life Tap causes huge life leech to flow to any physical damage attacker.", "https://diablo2.wiki.fextralife.com/Life+Tap");
        public static SkillEnumeration Defiance => new(38, "Defiance", "This aura boosts the defense of the Paladin and all characters and minions in his party.", "https://diablo2.wiki.fextralife.com/Defiance");
        public static SkillEnumeration ChillingArmor => new(39, "Chilling Armor", "Chilling Armor provides a slightly smaller defensive bonus than Shiver Armor (but larger than Frozen Armor).", "https://diablo2.wiki.fextralife.com/Chilling+Armor");
        public static SkillEnumeration Frenzy => new(40, "Frenzy", "Frenzy allows the Barbarian to strike and move much faster, with any skill.", "https://diablo2.wiki.fextralife.com/Frenzy");
        public static SkillEnumeration DimVision => new(41, "Dim Vision", "Monsters that have had their vision dimmed no longer see their enemies.", "https://diablo2.wiki.fextralife.com/Dim+Vision");
        public static SkillEnumeration Meteor => new(42, "Meteor", "A flaming ball of rock is called down from above, dealing explosive damage to the target and leaving a patch of fiery burning earth behind.", "https://diablo2.wiki.fextralife.com/Meteor");
        public static SkillEnumeration Vigor => new(43, "Vigor", "Vigor boosts the running speed, maximum stamina, and stamina regeneration rate for the Paladin and all in his party.", "https://diablo2.wiki.fextralife.com/Vigor");
        public static SkillEnumeration Valkyrie => new(44, "Valkyrie", "Valkyries are powerful magical tanks. They spawn with high defense and hit points, and can stand up to a tremendous amount of damage.", "https://diablo2.wiki.fextralife.com/Valkyrie");
        public static SkillEnumeration OakSage => new(45, "Oak Sage", "The Oak Sage spirit floats around, radiating a hit point enhancing aura that affects the Druid and all characters and minions in his party.", "https://diablo2.wiki.fextralife.com/Oak+Sage");
        public static SkillEnumeration Raven => new(46, "Raven", "Ravens swarm in a cloud and look nifty, but their damage is negligible and their AI is lacking.", "https://diablo2.wiki.fextralife.com/Raven");
        public static SkillEnumeration Blizzard => new(47, "Blizzard", "Blizzard is an area effect spell, calling down an icy storm that chills and cold damages everything over a wide area.", "https://diablo2.wiki.fextralife.com/Blizzard");
        public static SkillEnumeration FrostNova => new(48, "Frost Nova", "Creates and expanding ring of ice that damages enemies with cold damage and slows enemies.", "https://diablo2.wiki.fextralife.com/Frost+Nova");
        public static SkillEnumeration Conviction => new(49, "Conviction", "This aura lowers the defense and fire, lightning, and cold resistances of monsters, making it ideal to pair with an elemental weapon or skill, such as Vengeance.", "https://diablo2.wiki.fextralife.com/Conviction");
        public static SkillEnumeration CycloneArmor => new(50, "Cyclone Armor", "This shielding spell is essentially an elemental version of the Necromancer's Bone Shield. It absorbs a set amount of elemental damage, but has no effect against physical attacks.", "https://diablo2.wiki.fextralife.com/Cyclone+Armor");
        public static SkillEnumeration Meditation => new(51, "Meditation", "Boosts the mana regeneration rate for the Paladin and all his party members.", "https://diablo2.wiki.fextralife.com/Meditation");
        public static SkillEnumeration Twister => new(52, "Twister", "Each cast of Twister sets up a small tornado that stuns and deals physical damage to any enemies in the area.", "https://diablo2.wiki.fextralife.com/Twister");
        public static SkillEnumeration Vengeance => new(53, "Vengeance", "A powerful single-hit attack that adds fire, lightning, and cold damage.", "https://diablo2.wiki.fextralife.com/Vengeance");
        public static SkillEnumeration Fade => new(54, "Fade", "Raises all resistances and resists curses for a period of time.", "https://diablo2.wiki.fextralife.com/Fade");
        public static SkillEnumeration Might => new(55, "Might", "Might increases the output of all physical damage attacks by the Paladin or his party.", "https://diablo2.wiki.fextralife.com/Might");
        public static SkillEnumeration Decrepify => new(56, "Decrepify", "This powerful curse lowers movement, attack speed, damage and physical resistance by 50%.", "https://diablo2.wiki.fextralife.com/Decrepify");
        public static SkillEnumeration Sanctuary => new(57, "Sanctuary", "This aura only works against the Undead, but provides the Paladin with a substantial damage bonus, as well as working to push back and constantly deal holy damage to all Undead in range.", "https://diablo2.wiki.fextralife.com/Sanctuary");
        public static SkillEnumeration Inferno => new(58, "Inferno", "Inferno turns a Sorceress into a human flamethrower, capable of emitting a massive spout of flame for as long as the spell is kept active.", "https://diablo2.wiki.fextralife.com/Inferno");
        public static SkillEnumeration FireBolt => new(59, "Fire Bolt", "Shoots a small ball of fire. Fire Bolts hit only one target and have no splash damage.", "https://diablo2.wiki.fextralife.com/Fire+Bolt");
        public static SkillEnumeration SlowMissiles => new(60, "Slow Missiles", "A curse-like debuff skill that slows the missles of all monsters within the skill's range.", "https://diablo2.wiki.fextralife.com/Slow_Missiles");
        public static SkillEnumeration Dodge => new(61, "Dodge", "Allows the Amazon to dodge melee attacks while standing still or attacking.", "https://diablo2.wiki.fextralife.com/Dodge");
        public static SkillEnumeration CriticalStrike => new(62, "Critical Strike", "This extremely powerful skill gives a chance to deal a critical strike, doubling the physical damage of an attack with any sort of weapon.", "https://diablo2.wiki.fextralife.com/Critical+Strike");
        public static SkillEnumeration EnergyShield => new(63, "Energy Shield", "Energy Shield allows the Sorceress to redirect damage from life to mana.", "https://diablo2.wiki.fextralife.com/Energy+Shield");
        public static SkillEnumeration Howl => new(64, "Howl", "Howling will cause affected monsters to cease attacking and retreat as a green 'rain' drizzles down on them.", "https://diablo2.wiki.fextralife.com/Howl");
        public static SkillEnumeration Taunt => new(65, "Taunt", "Taunt is set up to get those pesky fleeing monsters to come to you.", "https://diablo2.wiki.fextralife.com/Taunt");
        public static SkillEnumeration CloackOfShadows => new(66, "Cloak of Shadows", "This spell blocks some monster effects; sand maggots cannot lay eggs, unravelers cannot use their poison breath, venom lords cannot use their Inferno attack etc.", "https://diablo2.wiki.fextralife.com/Cloak+of+Shadows");
        public static SkillEnumeration BoneSpirit => new(67, "Bone Spirit", "Bone Spirits are slow-moving, homing missiles that will track targets for quite a distance off the screen.", "https://diablo2.wiki.fextralife.com/Bone+Spirit");
        public static SkillEnumeration HeartOfWolverine => new(68, "Heart of Wolverine", "This spirit's aura provides a hearty attack rating and damage bonus to the Druid and all players and minions in his party.", "https://diablo2.wiki.fextralife.com/Heart+of+Wolverine");
        public static SkillEnumeration IronGolem => new(69, "Iron Golem", "This golem is created from the item, and takes on properties of the item.", "https://diablo2.wiki.fextralife.com/Iron+Golem");
        public static SkillEnumeration Enchant => new(70, "Enchant", "Temporarily grants bonus fire damage and boosts the Attack Rating of any friendly player or minion.", "https://diablo2.wiki.fextralife.com/Enchant");
        public static SkillEnumeration Berserk => new(71, "Berserk", "Berserk gives the Barbarian a way to deal a huge amount of magical (non-physical) damage with a melee attack, saving him from needing to use elemental damage weapons to kill Stone Skin and Physical Immune monsters.", "https://diablo2.wiki.fextralife.com/Berserk");
        public static SkillEnumeration Zeal => new(72, "Zeal", "Zeal is a rapid, multi-strike attack with substantial bonuses to attack rating, attack speed, and damage.", "https://diablo2.wiki.fextralife.com/Zeal");
        public static SkillEnumeration Firestorm => new(73, "Firestorm", "Wielding this ability, the Druid projects waves of molten earth that spread outward and burn a wide swath of destruction through his foes.", "https://diablo2.wiki.fextralife.com/Firestorm");
        public static SkillEnumeration Redemption => new(74, "Redemption", "Redemption uses up corpses, making them vanish with a lovely rising spirit graphic (also seen coming up from the skeletons after Radament is defeated in the Act Two Sewers), and transferring substantial mana and life to the Paladin.", "https://diablo2.wiki.fextralife.com/Redemption");
        public static SkillEnumeration FireWall => new(75, "Fire Wall", "A wall of flame springs up in both directions from the spot the Sorceress targets for ignition.", "https://diablo2.wiki.fextralife.com/Fire+Wall");
        public static SkillEnumeration Concentration => new(76, "Concentration", "Concentration greatly increases the physical damage of the Paladin and all in his party.", "https://diablo2.wiki.fextralife.com/Concentration");
        public static SkillEnumeration HolyBolt => new(77, "Holy Bolt", "A glowing, magical projectile is fired out at a medium rate of speed.", "https://diablo2.wiki.fextralife.com/Holy+Bolt");
        public static SkillEnumeration Tornado => new(78, "Tornado", "An upgraded version of Twister, a Tornado is much larger and more powerful, but lacks the stunning effect of the smaller Twisters.", "https://diablo2.wiki.fextralife.com/Tornado");
        public static SkillEnumeration IronMaiden => new(79, "Iron Maiden", "Causes the physical, melee damage inflicted by the target to reflect back to themselves.", "https://diablo2.wiki.fextralife.com/Iron+Maiden");
        public static SkillEnumeration Weaken => new(80, "Weaken", "Lowers the physical damage the target inflicts by 33%.", "https://diablo2.wiki.fextralife.com/Weaken");
        public static SkillEnumeration MoltenBoulder => new(81, "Molten Boulder", "A fun skill to use, this one sends forth a rolling boulder of molten stone.", "https://diablo2.wiki.fextralife.com/Molten+Boulder");
        public static SkillEnumeration ClayGolem => new(82, "Clay Golem", "Raises a Golem from the earth to fight for you.", "https://diablo2.wiki.fextralife.com/Clay+Golem");
        public static SkillEnumeration PosionExplosion => new(83, "Poison Explosion", "Like Corpse Explosion, but with poison damage.", "https://diablo2.wiki.fextralife.com/Poison+Explosion");
        public static SkillEnumeration IceBlast => new(84, "Ice Blast", "Shoots a large snowball that hits with cold damage, freezing the target.", "https://diablo2.wiki.fextralife.com/Ice+Blast");
        public static SkillEnumeration SkeletonMastery => new(85, "Skeleton Mastery", "Increases the hit points and damage dealt by Skeletons, Skeleton Mages, and Revived.", "https://diablo2.wiki.fextralife.com/Skeleton+Mastery");
        public static SkillEnumeration Attract => new(86, "Attract", "A monster with Attract cast on it becomes the target of aggression to all other monsters in the vicinity.", "https://diablo2.wiki.fextralife.com/Attract");
        public static SkillEnumeration Nova => new(87, "Nova", "Nova casts an expanding ring of lightning that strikes everything in its path, extending nearly to the edge of the screen.", "https://diablo2.wiki.fextralife.com/Nova");
        public static SkillEnumeration LowerResist => new(88, "LowerResist", "Curses an enemy to take more damage from all magical attack lowers resistances of monsters lowers maximum resistances of hostile players. ", "https://diablo2.wiki.fextralife.com/Lower+Resist");
        public static SkillEnumeration Cleansing => new(89, "Cleansing", "Reduces Poison and Curse duration for all party members.", "https://diablo2.wiki.fextralife.com/Cleansing");
        public static SkillEnumeration ResistFire => new(90, "Resist Fire", "Increases the Fire resistance of all party members.", "https://diablo2.wiki.fextralife.com/Resist+Fire");

        public SkillEnumeration(int id, string name, string description, string url)
            : base(id, name)
        {
            Description = description;
            Url = url;
        }
    }

    public class RuneWordEnumeration : Enumeration
    {
        public class Statistic
        {
            public string Description { get; }
            public SkillEnumeration Skill { get; }

            public Statistic(string description, SkillEnumeration skill)
            {
                Description = description;
                Skill = skill;
            }
        }

        private static readonly IEnumerable<ItemTypeEnumeration> _rangedWeapons = new List<ItemTypeEnumeration>()
        {
            ItemTypeEnumeration.Bow,
            ItemTypeEnumeration.Crossbow,
            ItemTypeEnumeration.ThrowingAxe,
            ItemTypeEnumeration.ThrowingKnife
        };
        private static readonly IEnumerable<ItemTypeEnumeration> _meleeWeapons = new List<ItemTypeEnumeration>()
        {
            ItemTypeEnumeration.Axe,
            ItemTypeEnumeration.Claw,
            ItemTypeEnumeration.Club,
            ItemTypeEnumeration.Mace,
            ItemTypeEnumeration.Wand,
            ItemTypeEnumeration.Dagger,
            ItemTypeEnumeration.Orb,
            ItemTypeEnumeration.Hammer,
            ItemTypeEnumeration.Javelin,
            ItemTypeEnumeration.Polearm,
            ItemTypeEnumeration.Scepter,
            ItemTypeEnumeration.Stave,
            ItemTypeEnumeration.Sword
        };

        public int Level { get; }
        public IEnumerable<RuneEnumeration> Runes { get; }
        public IEnumerable<ItemTypeEnumeration> ItemTypes { get; }
        public IEnumerable<Statistic> Statistics { get; }
        public string Url { get; }

        public static RuneWordEnumeration AncientsPledge => new(0, "Ancient's Pledge", 21, new List<RuneEnumeration>
        {
            RuneEnumeration.Ral,
            RuneEnumeration.Ort,
            RuneEnumeration.Tal
        },
        new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield },
        new List<Statistic>
        {
            new Statistic("+50% Enhanced Defense", null),
            new Statistic("Cold Resist +43%", null),
            new Statistic("Lightning Resist +48%", null),
            new Statistic("Fire Resist +48%", null),
            new Statistic("Poison Resist +48%", null),
            new Statistic("10% Damage Taken Goes to Mana", null)
        }, "https://diablo2.wiki.fextralife.com/Ancient's+Pledge");

        public static RuneWordEnumeration Beast => new(1, "Beast", 63, new List<RuneEnumeration>
        {
            RuneEnumeration.Ber,
            RuneEnumeration.Tir,
            RuneEnumeration.Um,
            RuneEnumeration.Mal,
            RuneEnumeration.Lum
        },
       new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Hammer, ItemTypeEnumeration.Scepter },
       new List<Statistic>
       {
            new Statistic("Level 9 {skill} Aura When Equipped", SkillEnumeration.Fanaticism),
            new Statistic("+40% Increased Attack Speed", null),
            new Statistic("+240-270% Enhanced Damage (varies)", null),
            new Statistic("20% Chance of Crushing Blow", null),
            new Statistic("25% Chance of Open Wounds", null),
            new Statistic("+3 To {skill}",SkillEnumeration.Werebear),
            new Statistic("+3 To {skill}",SkillEnumeration.Lycanthropy),
            new Statistic("Prevent Monster Heal", null),
            new Statistic("+25-40 To Strength (varies)", null),
            new Statistic("+10 To Energy", null),
            new Statistic("+2 To Mana After Each Kill", null),
            new Statistic("Level 13  {skill} (5 Charges)", SkillEnumeration.SummonGrizzly),
       }, "https://diablo2.wiki.fextralife.com/Beast");

        public static RuneWordEnumeration Black => new(2, "Black", 35, new List<RuneEnumeration> { RuneEnumeration.Thul, RuneEnumeration.Io, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Club, ItemTypeEnumeration.Hammer, ItemTypeEnumeration.Mace },
            new List<Statistic>
            {
                new Statistic("+15% Increased Attack Speed", null),
                new Statistic("+120% Enhanced Damage", null),
                new Statistic("+200 to Attack Rating", null),
                new Statistic("Adds 3-14 Cold Damage (3 sec)", null),
                new Statistic("40% Chance of Crushing Blow", null),
                new Statistic("Knockback", null),
                new Statistic("+10 to Vitality", null),
                new Statistic("Magic Damage Reduced By 2", null),
                new Statistic("Level 4 {skill} (12 Charges)", SkillEnumeration.CorpseExplosion)
            }, "https://diablo2.wiki.fextralife.com/Black");

        public static RuneWordEnumeration Bone => new(3, "Bone", 47, new List<RuneEnumeration> { RuneEnumeration.Sol, RuneEnumeration.Um, RuneEnumeration.Um },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("15% Chance To Cast level 10 {skill} When Struck", SkillEnumeration.BoneArmor),
                new Statistic("15% Chance To Cast level 10 {skill} On Striking", SkillEnumeration.BoneSpear),
                new Statistic("+2 To Necromancer Skill Levels", null),
                new Statistic("+100-150 To Mana (varies)", null),
                new Statistic("All Resistances +30", null),
                new Statistic("Damage Reduced By 7", null)
            }, "https://diablo2.wiki.fextralife.com/Bone");

        public static RuneWordEnumeration Bramble => new(4, "Bramble", 61, new List<RuneEnumeration> { RuneEnumeration.Ral, RuneEnumeration.Ohm, RuneEnumeration.Sur, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("Level 15-21 {skill} Aura When Equipped (varies)", SkillEnumeration.Thorns),
                new Statistic("+50% Faster Hit Recovery", null),
                new Statistic("+25-50% To Poison Skill Damage (varies)", null),
                new Statistic("+300 Defense", null),
                new Statistic("Increase Maximum Mana 5%", null),
                new Statistic("Regenerate Mana 15%", null),
                new Statistic("+5% To Maximum Cold Resist", null),
                new Statistic("Fire Resist +30%", null),
                new Statistic("Poison Resist +100%", null),
                new Statistic("+13 Life After Each Kill", null),
                new Statistic("Level 13 {skill} (33 Charges)", SkillEnumeration.SpiritOfBarbs)
            }, "https://diablo2.wiki.fextralife.com/Bramble");

        public static RuneWordEnumeration Brand => new(5, "Brand", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Lo, RuneEnumeration.Mal, RuneEnumeration.Gul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new Statistic("35% Chance To Cast Level 14 {skill} When Struck", SkillEnumeration.AmplifyDamage),
                new Statistic("100% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.BoneSpear),
                new Statistic("Fires {skill} (15)", SkillEnumeration.ExplodingArrow),
                new Statistic("+260-340% Enhanced Damage (varies)", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("20% Bonus to Attack Rating", null),
                new Statistic("+280-330% Damage To Demons (varies)", null),
                new Statistic("20% Deadly Strike", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("Knockback", null)
            }, "https://diablo2.wiki.fextralife.com/Brand");

        public static RuneWordEnumeration BreathOfTheDying => new(6, "Breath of the Dying", 69, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Hel, RuneEnumeration.El, RuneEnumeration.Eld, RuneEnumeration.Zod, RuneEnumeration.Eth },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new Statistic("50% Chance To Cast Level 20 {skill} When You Kill An Enemy", SkillEnumeration.PoisonNova),
                new Statistic("Indestructible", null),
                new Statistic("+60% Increased Attack Speed", null),
                new Statistic("+350-400% Enhanced Damage (varies)", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("+50 To Attack Rating", null),
                new Statistic("+200% Damage To Undead", null),
                new Statistic("+50 To Attack Rating Against Undead", null),
                new Statistic("7% Mana Stolen Per Hit", null),
                new Statistic("12-15% Life Stolen Per Hit (varies)", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+30 To All Attributes", null),
                new Statistic("+1 To Light Radius", null),
                new Statistic("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Breath+of+the+Dying");

        public static RuneWordEnumeration CallToArms => new(7, "Call to Arms", 57, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Ral, RuneEnumeration.Mal, RuneEnumeration.Ist, RuneEnumeration.Ohm },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new Statistic("+1 To All Skills", null),
                new Statistic("+40% Increased Attack Speed", null),
                new Statistic("+240-290% Enhanced Damage (varies)", null),
                new Statistic("Adds 5-30 Fire Damage", null),
                new Statistic("7% Life Stolen Per Hit", null),
                new Statistic("+2-6 To {skill} (varies)", SkillEnumeration.BattleCommand),
                new Statistic("+1-6 To {skill} (varies)", SkillEnumeration.BattleOrder),
                new Statistic("+1-4 To {skill} (varies)", SkillEnumeration.BattleCry),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("Replenish Life +12", null),
                new Statistic("30% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Call+to+Arms");

        public static RuneWordEnumeration ChainsOfHonor => new(8, "Chains of Honor", 63, new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Um, RuneEnumeration.Ber, RuneEnumeration.Ist },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("+2 To All Skills", null),
                new Statistic("+200% Damage To Demons", null),
                new Statistic("+100% Damage To Undead", null),
                new Statistic("8% Life Stolen Per Hit", null),
                new Statistic("+70% Enhanced Defense", null),
                new Statistic("+20 To Strength", null),
                new Statistic("Replenish Life +7", null),
                new Statistic("All Resistances +65", null),
                new Statistic("Damage Reduced By 8%", null),
                new Statistic("25% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Chains+of+Honor");

        public static RuneWordEnumeration Chaos => new(9, "Chaos", 57, new List<RuneEnumeration> { RuneEnumeration.Fal, RuneEnumeration.Ohm, RuneEnumeration.Um },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Claw },
            new List<Statistic>
            {
                new Statistic("9% Chance To Cast Level 11 {skill} On Striking", SkillEnumeration.FrozenOrb),
                new Statistic("11% Chance To Cast Level 9 {skill} On Striking", SkillEnumeration.ChargedBolt),
                new Statistic("+35% Increased Attacked Speed", null),
                new Statistic("+240-290% Enhanced Damage (varies)", null),
                new Statistic("Adds 216-471 Magic Damage", null),
                new Statistic("25% Chance of Open Wounds", null),
                new Statistic("+1 To {skill}", SkillEnumeration.Whirlwind),
                new Statistic("+10 To Strength", null),
                new Statistic("+15 Life After Each Demon Kill", null)
            }, "https://diablo2.wiki.fextralife.com/Chaos");

        public static RuneWordEnumeration CrescentMoon => new(10, "CrescentMoon", 47, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Um, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new Statistic("10% Chance To Cast Level 17 {skill} On Striking", SkillEnumeration.ChainLightning),
                new Statistic("7% Chance To Cast Level 13 {skill} On Striking", SkillEnumeration.StaticField),
                new Statistic("+20% Increased Attack Speed", null),
                new Statistic("+180-220% Enhanced Damage (varies)", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("-35% To Enemy Lightning Resistance", null),
                new Statistic("25% Chance of Open Wounds", null),
                new Statistic("+9-11 Magic Absorb (varies)", null),
                new Statistic("+2 To Mana After Each Kill", null),
                new Statistic("Level 18 Summon {{{}} (30 Charges)", SkillEnumeration.SummonSpiritWolf)
            }, "https://diablo2.wiki.fextralife.com/Crescent+Moon+(Runeword)");

        public static RuneWordEnumeration Death => new(11, "Death", 55, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.El, RuneEnumeration.Vex, RuneEnumeration.Ort, RuneEnumeration.Gul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new Statistic("Indestructible", null),
                new Statistic("100% Chance To Cast Level 44 {skill} When You Die", SkillEnumeration.ChainLightning),
                new Statistic("25% Chance To Cast Level 18 {skill} On Attack", SkillEnumeration.GlacialSpike),
                new Statistic("+300-385% Enhanced Damage (varies)", null),
                new Statistic("20% Bonus To Attack Rating", null),
                new Statistic("+50 To Attack Rating", null),
                new Statistic("Adds 1-50 Lightning Damage", null),
                new Statistic("7% Mana Stolen Per Hit", null),
                new Statistic("50% Chance of Crushing Blow", null),
                new Statistic("(0.5*Clvl)% Deadly Strike (Based on Character Level)", null),
                new Statistic("+1 To Light Radius", null),
                new Statistic("Level 22 {skill} (15 Charges)", SkillEnumeration.BloodGolem),
                new Statistic("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Death");

        public static RuneWordEnumeration Delirium => new(12, "Delirium", 51, new List<RuneEnumeration> { RuneEnumeration.Lem, RuneEnumeration.Ist, RuneEnumeration.Io },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new Statistic("1% Chance To Cast lvl 50 Delirium When Struck", null),
                new Statistic("6% Chance To Cast lvl 14 {skill} When Struck", SkillEnumeration.MindBlast),
                new Statistic("14% Chance To Cast lvl 13 {skill} When Struck", SkillEnumeration.Terror),
                new Statistic("11% Chance To Cast lvl 18 {skill} On Striking", SkillEnumeration.Confuse),
                new Statistic("+2 To All Skills", null),
                new Statistic("+261 Defense", null),
                new Statistic("+10 To Vitality", null),
                new Statistic("50% Extra Gold From Monsters", null),
                new Statistic("25% Better Chance of Getting Magic Items", null),
                new Statistic("Level 17 {skill} (60 Charges)", SkillEnumeration.Attract)
            }, "https://diablo2.wiki.fextralife.com/Delirium");

        public static RuneWordEnumeration Destruction => new(13, "Destruction", 65, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Lo, RuneEnumeration.Ber, RuneEnumeration.Jah, RuneEnumeration.Ko },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new Statistic("23% Chance To Cast Level 12 {skill} On Striking", SkillEnumeration.Volcano),
                new Statistic("5% Chance To Cast Level 23 {skill} On Striking", SkillEnumeration.MoltenBoulder),
                new Statistic("100% Chance To Cast level 45 {skill} When You Die", SkillEnumeration.Meteor),
                new Statistic("15% Chance To Cast Level 22 {skill} On Attack", SkillEnumeration.Nova),
                new Statistic("+350% Enhanced Damage", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("Adds 100-180 Magic Damage", null),
                new Statistic("7% Mana Stolen Per Hit", null),
                new Statistic("20% Chance Of Crushing Blow", null),
                new Statistic("20% Deadly Strike", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+10 To Dexterity", null),
            }, "https://diablo2.wiki.fextralife.com/Destruction");

        public static RuneWordEnumeration Doom => new(14, "Doom", 67, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Ohm, RuneEnumeration.Um, RuneEnumeration.Lo, RuneEnumeration.Cham },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Hammer, ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new Statistic("5% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.Volcano),
                new Statistic("Level 12 {skill} Aura When Equipped", SkillEnumeration.HolyFreeze),
                new Statistic("+2 To All Skills", null),
                new Statistic("+45% Increased Attack Speed", null),
                new Statistic("+330-370% Enhanced Damage (varies)", null),
                new Statistic("-40-60% To Enemy Cold Resistance (varies)", null),
                new Statistic("20% Deadly Strike", null),
                new Statistic("25% Chance of Open Wounds", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("Freezes Target +3", null),
                new Statistic("Requirements -20%", null),
            }, "https://diablo2.wiki.fextralife.com/Doom");

        public static RuneWordEnumeration Dragon => new(15, "Dragon", 61, new List<RuneEnumeration> { RuneEnumeration.Sur, RuneEnumeration.Lo, RuneEnumeration.Sol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor, ItemTypeEnumeration.Shield },
            new List<Statistic>
            {
                new Statistic("20% Chance to Cast Level 18 {skill} When Struck", SkillEnumeration.Venom),
                new Statistic("12% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Hydra),
                new Statistic("Level 14 {skill} Aura When Equipped", SkillEnumeration.HolyFire),
                new Statistic("+360 Defense", null),
                new Statistic("+230 Defense Vs. Missile", null),
                new Statistic("+3-5 To All Attributes (varies)", null),
                new Statistic("+(0.375*Clvl) To Strength (Based on Character Level)", null),
                new Statistic("+5% To Maximum Lightning Resist", null),
                new Statistic("Damage Reduced by 7", null),
                new Statistic("Increase Maximum Mana 5% (Armor)", null),
                new Statistic("+50 To Mana (Shields)", null),
            }, "https://diablo2.wiki.fextralife.com/Dragon");

        public static RuneWordEnumeration Dream => new(16, "Dream", 65, new List<RuneEnumeration> { RuneEnumeration.Io, RuneEnumeration.Jah, RuneEnumeration.Pul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new Statistic("10% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Confuse),
                new Statistic("Level 15 {skill} Aura When Equipped", SkillEnumeration.HolyShock),
                new Statistic("+20-30% Faster Hit Recovery (varies)", null),
                new Statistic("+30% Enhanced Defense", null),
                new Statistic("+150-220 Defense (varies)", null),
                new Statistic("+10 To Vitality", null),
                new Statistic("+(0.625*Clvl) To Mana (Based On Character Level)", null),
                new Statistic("All Resistances +5-20 (varies)", null),
                new Statistic("12-25% Better Chance of Getting Magic Items (varies)", null),
                new Statistic("Increase Maximum Life 5% (Helmet)", null),
                new Statistic("+50 To Life (Shields)", null),
            }, "https://diablo2.wiki.fextralife.com/Dream");

        public static RuneWordEnumeration Duress => new(17, "Duress", 47, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Um, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("40% faster hit Recovery", null),
                new Statistic("+10-20% Enhanced Damage (varies)", null),
                new Statistic("Adds 37-133 Cold Damage", null),
                new Statistic("15% Crushing Blow", null),
                new Statistic("33% Open Wounds", null),
                new Statistic("+150-200% Enhanced Defense (varies)", null),
                new Statistic("-20% Slower Stamina Drain", null),
                new Statistic("Cold Resist +45%", null),
                new Statistic("Lightning Resist +15%", null),
                new Statistic("Fire Resist +15%", null),
                new Statistic("Poison Resist +15%", null),
            }, "https://diablo2.wiki.fextralife.com/Duress");

        public static RuneWordEnumeration Edge => new(18, "Edge", 25, new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.Tal, RuneEnumeration.Amn },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new Statistic("Level 15 {skill} Aura When Equipped", SkillEnumeration.Thorns),
                new Statistic("+35% Increased Attack Speed", null),
                new Statistic("+320-380% Damage To Demons (varies)", null),
                new Statistic("+280% Damage To Undead", null),
                new Statistic("+75 Poison Damage Over 5 Seconds", null),
                new Statistic("7% Life Stolen Per Hit", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+5-10 To All Attributes (varies)", null),
                new Statistic("+2 To Mana After Each Kill", null),
                new Statistic("Reduces All Vendor Prices 15%", null),
            }, "https://diablo2.wiki.fextralife.com/Edge");

        public static RuneWordEnumeration Enigma => new(19, "Enigma", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Ith, RuneEnumeration.Ber },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("+2 To All Skills", null),
                new Statistic("+45% Faster Run/Walk", null),
                new Statistic("+1 To {skill}", SkillEnumeration.Teleport),
                new Statistic("+750-775 Defense (Varies)", null),
                new Statistic("+(0.75*Clvl) To Strength (Based On Character Level)", null),
                new Statistic("Increase Maximum Life 5%", null),
                new Statistic("Damage Reduced By 8%", null),
                new Statistic("+14 Life After Each Kill", null),
                new Statistic("15% Damage Taken Goes To Mana", null),
                new Statistic("(1*Clvl)% Better Chance of Getting Magic Items (Based On Character Level)", null),
            }, "https://diablo2.wiki.fextralife.com/Enigma");

        public static RuneWordEnumeration Enlightenment => new(20, "Enlightenment", 45, new List<RuneEnumeration> { RuneEnumeration.Pul, RuneEnumeration.Ral, RuneEnumeration.Sol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("5% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Blaze),
                new Statistic("5% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Fireball),
                new Statistic("+2 To Sorceress Skill Levels", null),
                new Statistic("+1 To Warmth", null),
                new Statistic("+30% Enhanced Defense", null),
                new Statistic("Fire Resist +30%", null),
                new Statistic("Damage Reduced By 7", null),
            }, "https://diablo2.wiki.fextralife.com/Enlightenment");

        public static RuneWordEnumeration Eternity => new(21, "Eternity", 63, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Ber, RuneEnumeration.Ist, RuneEnumeration.Sol, RuneEnumeration.Sur },
            _meleeWeapons,
            new List<Statistic>
            {
                new Statistic("Indestructible", null),
                new Statistic("+260-310% Enhanced Damage (varies)", null),
                new Statistic("+9 To Minimum Damage", null),
                new Statistic("7% Life Stolen Per Hit", null),
                new Statistic("20% Chance of Crushing Blow", null),
                new Statistic("Hit Blinds Target", null),
                new Statistic("Slows Target By 33%", null),
                new Statistic("Replenish Mana 16%", null),
                new Statistic("Cannot Be Frozen", null),
                new Statistic("30% Better Chance Of Getting Magic Items", null),
                new Statistic("Level 8 {skill} (88 Charges)", SkillEnumeration.Revive),
            }, "https://diablo2.wiki.fextralife.com/Eternity");

        public static RuneWordEnumeration Exile => new(22, "Exile", 57, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Ohm, RuneEnumeration.Ist, RuneEnumeration.Dol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.PaladinShield },
            new List<Statistic>
            {
                new Statistic("15% Chance To Cast Level 5 {skill} On Striking", SkillEnumeration.LifeTap),
                new Statistic("Level 13-16 {skill} Aura When Equipped (varies)", SkillEnumeration.Defiance),
                new Statistic("+2 To Offensive Auras (Paladin Only)", null),
                new Statistic("+30% Faster Block Rate", null),
                new Statistic("Freezes Target", null),
                new Statistic("+220-260% Enhanced Defense (varies)", null),
                new Statistic("Replenish Life +7", null),
                new Statistic("+5% To Maximum Cold Resist", null),
                new Statistic("+5% To Maximum Fire Resist", null),
                new Statistic("25% Better Chance Of Getting Magic Items", null),
                new Statistic("Repairs 1 Durability every 4 seconds", null)
            }, "https://diablo2.wiki.fextralife.com/Exile");

        public static RuneWordEnumeration Faith => new(23, "Faith", 65, new List<RuneEnumeration> { RuneEnumeration.Ohm, RuneEnumeration.Jah, RuneEnumeration.Lem, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new Statistic("Level 12-15 {skill} Aura When Equipped (varies)", SkillEnumeration.Fanaticism),
                new Statistic("+1-2 To All Skills (varies)", null),
                new Statistic("+330% Enhanced Damage", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("300% Bonus To Attack Rating", null),
                new Statistic("+75% Damage To Undead", null),
                new Statistic("+50 To Attack Rating Against Undead", null),
                new Statistic("+120 Fire Damage", null),
                new Statistic("All Resistances +15", null),
                new Statistic("10% Reanimate As: Returned", null),
                new Statistic("75% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Faith");

        public static RuneWordEnumeration Famine => new(24, "Famine", 65, new List<RuneEnumeration> { RuneEnumeration.Fal, RuneEnumeration.Ohm, RuneEnumeration.Ort, RuneEnumeration.Jah },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Hammer },
            new List<Statistic>
            {
                new Statistic("+30% Increased Attack Speed", null),
                new Statistic("+320-370% Enhanced Damage (varies)", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("Adds 180-200 Magic Damage", null),
                new Statistic("Adds 50-200 Fire Damage", null),
                new Statistic("Adds 51-250 Lightning Damage", null),
                new Statistic("Adds 50-200 Cold Damage", null),
                new Statistic("12% Life Stolen Per Hit", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+10 To Strength", null)
            }, "https://diablo2.wiki.fextralife.com/Famine");

        public static RuneWordEnumeration Fortitude => new(25, "Fortitude", 59, new List<RuneEnumeration> { RuneEnumeration.El, RuneEnumeration.Sol, RuneEnumeration.Dol, RuneEnumeration.Lo },
            _rangedWeapons.Concat(_meleeWeapons).Concat(new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor }),
            new List<Statistic>
            {
                new Statistic("20% Chance To Cast Level 15 {skill} when Struck", SkillEnumeration.ChillingArmor),
                new Statistic("+25% Faster Cast Rate", null),
                new Statistic("+300% Enhanced Damage", null),
                new Statistic("+200% Enhanced Defense", null),
                new Statistic("+((8-12)*0.125*Clvl) To Life (Based on Character Level) (varies)", null),
                new Statistic("All Resistances +25-30 (varies)", null),
                new Statistic("12% Damage Taken Goes To Mana", null),
                new Statistic("+1 To Light Radius", null),
                new Statistic("+9 To Minimum Damage (Weapons)", null),
                new Statistic("+50 To Attack Rating (Weapons)", null),
                new Statistic("20% Deadly Strike (Weapons)", null),
                new Statistic("Hit Causes Monster To Flee 25% (Weapons)", null),
                new Statistic("+15 Defense (Armor)", null),
                new Statistic("Replenish Life +7 (Armor)", null),
                new Statistic("+5% To Maximum Lightning Resist (Armor)", null),
                new Statistic("Damage Reduced By 7 (Armor)", null)
            }, "https://diablo2.wiki.fextralife.com/Fortitude");

        public static RuneWordEnumeration Fury => new(26, "Fury", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Gul, RuneEnumeration.Eth },
            _meleeWeapons,
            new List<Statistic>
            {
                new Statistic("40% Increased Attack Speed", null),
                new Statistic("+209% Enhanced Damage", null),
                new Statistic("Ignores Target Defense", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("20% Bonus to Attack Rating", null),
                new Statistic("6% Life Stolen Per Hit", null),
                new Statistic("33% Chance Of Deadly Strike", null),
                new Statistic("66% Chance Of Open Wounds", null),
                new Statistic("+5 To {skill} (Barbarian Only)", SkillEnumeration.Frenzy),
                new Statistic("Prevent Monster Heal", null)
            }, "https://diablo2.wiki.fextralife.com/Fury");

        public static RuneWordEnumeration Gloom => new(27, "Gloom", 47, new List<RuneEnumeration> { RuneEnumeration.Fal, RuneEnumeration.Um, RuneEnumeration.Pul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("15% Chance To Cast Level 3 {skill} When Struck", SkillEnumeration.DimVision),
                new Statistic("+10% Faster Hit Recovery", null),
                new Statistic("+200-260% Enhanced Defense (varies)", null),
                new Statistic("+10 To Strength", null),
                new Statistic("All Resistances +45", null),
                new Statistic("Half Freeze Duration", null),
                new Statistic("5% Damage Taken Goes To Mana", null),
                new Statistic("-3 To Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Gloom");

        public static RuneWordEnumeration Grief => new(28, "Grief", 59, new List<RuneEnumeration> { RuneEnumeration.Eth, RuneEnumeration.Tir, RuneEnumeration.Lo, RuneEnumeration.Mal, RuneEnumeration.Ral },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe },
            new List<Statistic>
            {
                new Statistic("35% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Venom),
                new Statistic("+30-40% Increased Attack Speed (varies)", null),
                new Statistic("Damage +340-400 (varies)", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("+(1.875*Clvl)% Damage To Demons (Based on Character Level)", null),
                new Statistic("Adds 5-30 Fire Damage", null),
                new Statistic("-20-25% To Enemy Poison Resistance (varies)", null),
                new Statistic("20% Deadly Strike", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+2 To Mana After Each Kill", null),
                new Statistic("+10-15 Life After Each Kill (varies)", null)
            }, "https://diablo2.wiki.fextralife.com/Grief");

        public static RuneWordEnumeration HandOfJustice => new(29, "HandOfJustice", 67, new List<RuneEnumeration> { RuneEnumeration.Sur, RuneEnumeration.Cham, RuneEnumeration.Lo, RuneEnumeration.Amn, RuneEnumeration.Lo },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new Statistic("100% Chance To Cast Level 36 {skill} When You Level-Up", SkillEnumeration.Blaze),
                new Statistic("100% Chance To Cast Level 48 {skill} When You Die", SkillEnumeration.Meteor),
                new Statistic("Level 16 {skill} Aura When Equipped", SkillEnumeration.HolyFire),
                new Statistic("+33% Increased Attack Speed", null),
                new Statistic("+280-330% Enhanced Damage (varies)", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("-20% To Enemy Fire Resistance", null),
                new Statistic("7% Life Stolen Per Hit", null),
                new Statistic("20% Deadly Strike", null),
                new Statistic("Hit Blinds Target", null),
                new Statistic("Freezes Target +3", null)
            }, "https://diablo2.wiki.fextralife.com/Hand+of+Justice");

        public static RuneWordEnumeration Harmony => new(30, "Harmony", 39, new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.Ith, RuneEnumeration.Sol, RuneEnumeration.Ko },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new Statistic("Level 10 {skill} Aura When Equipped", SkillEnumeration.Vigor),
                new Statistic("+200-275% Enhanced Damage (varies)", null),
                new Statistic("+9 To Minimum Damage", null),
                new Statistic("+9 To Maximum Damage", null),
                new Statistic("Adds 55-160 Fire Damage", null),
                new Statistic("Adds 55-160 Lightning Damage", null),
                new Statistic("Adds 55-160 Cold Damage", null),
                new Statistic("+2-6 To {skill} (varies)", SkillEnumeration.Valkyrie),
                new Statistic("+10 To Dexterity", null),
                new Statistic("Regenerate Mana 20%", null),
                new Statistic("+2 To Mana After Each Kill", null),
                new Statistic("+2 To Light Radius", null),
                new Statistic("Level 20 {skill} (25 Charges)", SkillEnumeration.Revive)
            }, "https://diablo2.wiki.fextralife.com/Harmony");

        public static RuneWordEnumeration HeartOfTheOak => new(31, "Heart of the Oak", 55, new List<RuneEnumeration> { RuneEnumeration.Ko, RuneEnumeration.Vex, RuneEnumeration.Pul, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave, ItemTypeEnumeration.Mace },
            new List<Statistic>
            {
                new Statistic("+3 To All Skills", null),
                new Statistic("+40% Faster Cast Rate", null),
                new Statistic("+75% Damage To Demons", null),
                new Statistic("+100 To Attack Rating Against Demons", null),
                new Statistic("Adds 3-14 Cold Damage", null),
                new Statistic("7% Mana Stolen Per Hit", null),
                new Statistic("+10 To Dexterity", null),
                new Statistic("Replenish Life +20", null),
                new Statistic("Increase Maximum Mana 15%", null),
                new Statistic("All Resistances +30-40 (varies)", null),
                new Statistic("Level 4 {skill} (25 Charges)", SkillEnumeration.OakSage),
                new Statistic("Level 14 {skill} (60 Charges)", SkillEnumeration.Raven)
            }, "https://diablo2.wiki.fextralife.com/Heart+of+the+Oak");

        public static RuneWordEnumeration HolyThunder => new(32, "Holy Thunder", 23, new List<RuneEnumeration> { RuneEnumeration.Eth, RuneEnumeration.Ral, RuneEnumeration.Ort, RuneEnumeration.Tal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Scepter },
            new List<Statistic>
            {
                new Statistic("+60% Enhanced Damage", null),
                new Statistic("+10 to Maximum Damage", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("Adds 5-30 Fire Damage", null),
                new Statistic("Adds 21-110 Lightning Damage", null),
                new Statistic("+75 Poison Damage over 5 secs", null),
                new Statistic("+3 to {{{SkillEnumeration.HolyShock}}} (Paladin Only)", null),
                new Statistic("+5% to Maximum Lightning Resist", null),
                new Statistic("Lightning Resist +60%", null),
                new Statistic("Level 7 {{{SkillEnumeration.ChainLightning}}} (60 charges)", null)
            }, "https://diablo2.wiki.fextralife.com/Holy+Thunder");

        public static RuneWordEnumeration Honor => new(33, "Honor", 27, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.El, RuneEnumeration.Ith, RuneEnumeration.Tir, RuneEnumeration.Sol },
            _meleeWeapons,
            new List<Statistic>
            {
                new Statistic("+1 to all skills", null),
                new Statistic("+160% Enhanced Damage", null),
                new Statistic("+9 to Minimum Damage", null),
                new Statistic("+9 to Maximum Damage", null),
                new Statistic("+250 Attack Rating", null),
                new Statistic("7% Life Stolen per Hit", null),
                new Statistic("25% Deadly Strike", null),
                new Statistic("+10 to Strength", null),
                new Statistic("Replenish life +10", null),
                new Statistic("+2 to Mana after each Kill", null),
                new Statistic("+1 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Honor");

        public static RuneWordEnumeration Ice => new(34, "Ice", 65, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Shael, RuneEnumeration.Jah, RuneEnumeration.Tir, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new Statistic("100% Chance To Cast Level 40 {skill} When You Level-up", SkillEnumeration.Blizzard),
                new Statistic("25% Chance To Cast Level 22 {skill} On Striking", SkillEnumeration.FrostNova),
                new Statistic("Level 18 {skill} Aura When Equipped", SkillEnumeration.HolyFreeze),
                new Statistic("+20% Increased Attack Speed", null),
                new Statistic("+140-210% Enhanced Damage (varies)", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("+25-30% To Cold Skill Damage (varies)", null),
                new Statistic("7% Life Stolen Per Hit", null),
                new Statistic("-20% To Enemy Cold Resistance", null),
                new Statistic("20% Deadly Strike", null),
                new Statistic("(3.125*Clvl)% Extra Gold From Monsters (Based on Character Level)", null)
            }, "https://diablo2.wiki.fextralife.com/Ice");

        public static RuneWordEnumeration Infinity => new(35, "Infinity", 63, new List<RuneEnumeration> { RuneEnumeration.Ber, RuneEnumeration.Mal, RuneEnumeration.Ber, RuneEnumeration.Ist, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new Statistic("Level 12-17 {skill} Aura When Equipped (varies)", SkillEnumeration.Meditation),
                new Statistic("+35% Faster Cast Rate", null),
                new Statistic("+200-260% Enhanced Damage (varies)", null),
                new Statistic("+9 To Minimum Damage", null),
                new Statistic("180-250% Bonus to Attack Rating (varies)", null),
                new Statistic("Adds 5-30 Fire Damage", null),
                new Statistic("+75 Poison Damage Over 5 Seconds", null),
                new Statistic("+1-6 To Critical Strike (varies)", null),
                new Statistic("+5 To All Attributes", null),
                new Statistic("+2 To Mana After Each Kill", null),
                new Statistic("23% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Infinity");

        public static RuneWordEnumeration Insight => new(36, "Insight", 63, new List<RuneEnumeration> { RuneEnumeration.Ral, RuneEnumeration.Tir, RuneEnumeration.Tal, RuneEnumeration.Sol, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Stave },
            new List<Statistic>
            {
                new Statistic("50% Chance To Cast Level 20 {skill} When You Kill An Enemy", SkillEnumeration.ChainLightning),
                new Statistic("Level 12 {skill} Aura When Equipped", SkillEnumeration.Conviction),
                new Statistic("+35% Faster Run/Walk", null),
                new Statistic("+255-325% Enhanced Damage (varies)", null),
                new Statistic("-(45-55)% To Enemy Lightning Resistance (varies)", null),
                new Statistic("40% Chance of Crushing Blow", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+(0.5*Clvl) To Vitality (Based on Character Level)", null),
                new Statistic("30% Better Chance of Getting Magic Items", null),
                new Statistic("Level 21 {skill} (30 Charges)", SkillEnumeration.CycloneArmor)
            }, "https://diablo2.wiki.fextralife.com/Infinity");

        public static RuneWordEnumeration KingsGrace => new(37, "King's Grace", 25, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Ral, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Scepter },
            new List<Statistic>
            {
                new Statistic("+100% Enhanced Damage", null),
                new Statistic("+150 to Attack Rating", null),
                new Statistic("+100% Damage to Demons", null),
                new Statistic("+100 to Attack Rating against Demons", null),
                new Statistic("+50% Damage to Undead", null),
                new Statistic("+100 to Attack Rating against Undead", null),
                new Statistic("Adds 5-30 Fire Damage", null),
                new Statistic("Adds 3-14 Cold damage", null),
                new Statistic("7% Life stolen per hit", null)
            }, "https://diablo2.wiki.fextralife.com/King%27s+Grace");

        public static RuneWordEnumeration Kingslayer => new(38, "Kingslayer", 53, new List<RuneEnumeration> { RuneEnumeration.Mal, RuneEnumeration.Um, RuneEnumeration.Gul, RuneEnumeration.Fal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe },
            new List<Statistic>
            {
                new Statistic("+30% Increased Attack Speed", null),
                new Statistic("+230-270% Enhanced Damage (varies)", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("20% Bonus To Attack Rating", null),
                new Statistic("33% Chance of Crushing Blow", null),
                new Statistic("50% Chance of Open Wounds", null),
                new Statistic("+1 To {skill}", SkillEnumeration.Vengeance),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+10 To Strength", null),
                new Statistic("40% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Kingslayer");

        public static RuneWordEnumeration LastWish => new(39, "Last Wish", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Mal, RuneEnumeration.Jah, RuneEnumeration.Sur, RuneEnumeration.Jah, RuneEnumeration.Ber },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe, ItemTypeEnumeration.Hammer },
            new List<Statistic>
            {
                new Statistic("6% Chance To Cast Level 11 {skill} When Struck", SkillEnumeration.Fade),
                new Statistic("10% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.LifeTap),
                new Statistic("20% Chance To Cast Level 20 {skill} On Attack", SkillEnumeration.ChargedBolt),
                new Statistic("Level 17 {skill} Aura When Equipped", SkillEnumeration.Might),
                new Statistic("+330-375% Enhanced Damage (varies)", null),
                new Statistic("Ignore Target's Defense", null),
                new Statistic("60-70% Chance of Crushing Blow (varies)", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("Hit Blinds Target", null),
                new Statistic("(0.5*Clvl)% Chance of Getting Magic Items (Based on Character Level)", null)
            }, "https://diablo2.wiki.fextralife.com/Last+Wish");

        public static RuneWordEnumeration Lawbringer => new(40, "Lawbringer", 43, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Lem, RuneEnumeration.Ko },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Scepter, ItemTypeEnumeration.Hammer },
            new List<Statistic>
            {
                new Statistic("20% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Decrepify),
                new Statistic("Level 16-18 {skill} Aura When Equipped (varies)", SkillEnumeration.Sanctuary),
                new Statistic("-50% Target Defense", null),
                new Statistic("Adds 150-210 Fire Damage", null),
                new Statistic("Adds 130-180 Cold Damage", null),
                new Statistic("7% Life Stolen Per Hit", null),
                new Statistic("Slain Monsters Rest In Peace", null),
                new Statistic("+200-250 Defense Vs. Missile (varies)", null),
                new Statistic("+10 To Dexterity", null),
                new Statistic("75% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Lawbringer");

        public static RuneWordEnumeration Leaf => new(41, "Leaf", 19, new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.Ral },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave },
            new List<Statistic>
            {
                new Statistic("+3 to Fire Skills", null),
                new Statistic("Adds 5-30 Fire Damage", null),
                new Statistic("+3 to {{{SkillEnumeration.Inferno}}} (Sorceress Only)", null),
                new Statistic("+3 to {{{SkillEnumeration.Warmth}}} (Sorceress Only)", null),
                new Statistic("+3 to {{{SkillEnumeration.FireBolt}}} (Sorceress Only)", null),
                new Statistic("+(2*Clvl) Defence (Based on Character Level)", null),
                new Statistic("Cold Resist +33%", null),
                new Statistic("+2 to Mana after each Kill", null)
            }, "https://diablo2.wiki.fextralife.com/Leaf");

        public static RuneWordEnumeration Lionheart => new(42, "Lionheart", 41, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Lum, RuneEnumeration.Fal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("+20% Enhanced Damage", null),
                new Statistic("+25 To Strength", null),
                new Statistic("+15 To Dexterity", null),
                new Statistic("+20 To Vitality", null),
                new Statistic("+10 To Energy", null),
                new Statistic("+50 To Life", null),
                new Statistic("All Resistances +30", null),
                new Statistic("Requirements -15%", null)
            }, "https://diablo2.wiki.fextralife.com/Lionheart");

        public static RuneWordEnumeration Lore => new(43, "Lore", 27, new List<RuneEnumeration> { RuneEnumeration.Ort, RuneEnumeration.Sol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new Statistic("+1 to All Skills", null),
                new Statistic("+10 to Energy", null),
                new Statistic("Lightning Resist +30%", null),
                new Statistic("Damage Reduced by 7", null),
                new Statistic("+2 to Mana after each Kill", null),
                new Statistic("+2 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Lore");

        public static RuneWordEnumeration Malice => new(44, "Malice", 15, new List<RuneEnumeration> { RuneEnumeration.Ith, RuneEnumeration.El, RuneEnumeration.Eth },
            _meleeWeapons,
            new List<Statistic>
            {
                new Statistic("+33% Enhanced Damage", null),
                new Statistic("+9 to Maximum Damage", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("+50 to Attack Rating", null),
                new Statistic("100% Chance of Open wounds", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("-100 to Monster Defense Per Hit", null),
                new Statistic("Drain Life -5", null)
            }, "https://diablo2.wiki.fextralife.com/Malice");

        public static RuneWordEnumeration Melody => new(45, "Melody", 39, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Ko, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new Statistic("+3 To Bow and Crossbow Skills (Amazon Only)", null),
                new Statistic("+20% Increased Attack Speed", null),
                new Statistic("+50% Enhanced Damage", null),
                new Statistic("+300% Damage To Undead", null),
                new Statistic("+3 To {skill} (Amazon Only)", SkillEnumeration.SlowMissiles),
                new Statistic("+3 To {skill} (Amazon Only)", SkillEnumeration.Dodge),
                new Statistic("+3 To {skill} (Amazon Only)", SkillEnumeration.CriticalStrike),
                new Statistic("Knockback", null),
                new Statistic("+10 To Dexterity", null)
            }, "https://diablo2.wiki.fextralife.com/Melody");

        public static RuneWordEnumeration Memory => new(46, "Memory", 37, new List<RuneEnumeration> { RuneEnumeration.Lum, RuneEnumeration.Io, RuneEnumeration.Sol, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave },
            new List<Statistic>
            {
                new Statistic("+3 To Sorceress Skill Levels", null),
                new Statistic("+33% Faster Cast Rate", null),
                new Statistic("+9 To Minimum Damage", null),
                new Statistic("-25% Target Defence", null),
                new Statistic("+3 To {skill} (Sorceress Only)", SkillEnumeration.EnergyShield),
                new Statistic("+2 To {skill} (Sorceress Only)", SkillEnumeration.StaticField),
                new Statistic("+50% Enhanced Defense", null),
                new Statistic("+10 Vitality", null),
                new Statistic("+10 Energy", null),
                new Statistic("Increase Maximum Mana 20%", null),
                new Statistic("Magic Damage Reduced By 7", null)
            }, "https://diablo2.wiki.fextralife.com/Memory");

        public static RuneWordEnumeration Myth => new(47, "Myth", 25, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Amn, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("3% Chance To Cast Level 1 {skill} When Struck", SkillEnumeration.Howl),
                new Statistic("10% Chance To Cast Level 1 {skill} On Striking", SkillEnumeration.Taunt),
                new Statistic("+2 To Barbarian Skill Levels", null),
                new Statistic("+30 Defense Vs. Missile", null),
                new Statistic("Replenish Life +10", null),
                new Statistic("Attacker Takes Damage of 14", null),
                new Statistic("Requirements -15%", null)
            }, "https://diablo2.wiki.fextralife.com/Myth");

        public static RuneWordEnumeration Nadir => new(48, "Nadir", 13, new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new Statistic("+50% Enhanced Defense", null),
                new Statistic("+10 Defense", null),
                new Statistic("+30 Defense vs. Missile", null),
                new Statistic("+5 to Strength", null),
                new Statistic("+2 to Mana after each Kill", null),
                new Statistic("-33% Extra Gold from Monsters", null),
                new Statistic("-3 to Light Radius", null),
                new Statistic("Level 13 {skill} (9 charges)", SkillEnumeration.CloackOfShadows)
            }, "https://diablo2.wiki.fextralife.com/Nadir");

        public static RuneWordEnumeration Oath => new(49, "Oath", 59, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Pul, RuneEnumeration.Mal, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Mace, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new Statistic("Indestructible", null),
                new Statistic("30% Chance To Cast Level 20 {skill} On Striking", SkillEnumeration.BoneSpirit),
                new Statistic("+50% Increased Attack Speed", null),
                new Statistic("+210-340% Enhanced Damage (varies)", null),
                new Statistic("+75% Damage To Demons", null),
                new Statistic("+100 To Attack Rating Against Demons", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+10 To Energy", null),
                new Statistic("+10-15 Magic Absorb (varies)", null),
                new Statistic("Level 16 {skill} (20 Charges)", SkillEnumeration.HeartOfWolverine),
                new Statistic("Level 17 {skill} (14 Charges)", SkillEnumeration.IronGolem)
            }, "https://diablo2.wiki.fextralife.com/Oath");

        public static RuneWordEnumeration Obedience => new(50, "Obedience", 41, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Ko, RuneEnumeration.Thul, RuneEnumeration.Eth, RuneEnumeration.Fal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new Statistic("30% Chance To Cast Level 21 {skill} When You Kill An Enemy", SkillEnumeration.Enchant),
                new Statistic("+40% Faster Hit Recovery", null),
                new Statistic("+370% Enhanced Damage", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("Adds 3-14 Cold Damage (3 Seconds Duration,Normal)", null),
                new Statistic("-25% To Enemy Fire Resistance", null),
                new Statistic("40% Chance of Crushing Blow", null),
                new Statistic("+200-300 Defense (varies)", null),
                new Statistic("+10 To Strength", null),
                new Statistic("+10 To Dexterity", null),
                new Statistic("All Resistances +20-30 (varies)", null),
                new Statistic("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Obedience");

        public static RuneWordEnumeration Passion => new(51, "Passion", 43, new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Ort, RuneEnumeration.Eld, RuneEnumeration.Lem },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new Statistic("+25% Increased Attack Speed", null),
                new Statistic("+160-210% Enhanced Damage (varies)", null),
                new Statistic("50-80% Bonus To Attack Rating (varies)", null),
                new Statistic("+75% Damage To Undead", null),
                new Statistic("+50 To Attack Rating Against Undead", null),
                new Statistic("Adds 1-50 Lightning Damage", null),
                new Statistic("+1 To {skill}", SkillEnumeration.Berserk),
                new Statistic("+1 To {skill}", SkillEnumeration.Zeal),
                new Statistic("Hit Blinds Target +10", null),
                new Statistic("Hit Causes Monster To Flee 25%", null),
                new Statistic("75% Extra Gold From Monsters", null),
                new Statistic("Level 3 {skill} (12 Charges)", SkillEnumeration.HeartOfWolverine)
            }, "https://diablo2.wiki.fextralife.com/Passion");

        public static RuneWordEnumeration Peace => new(52, "Peace", 29, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Thul, RuneEnumeration.Amn },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("4% Chance To Cast Level 5 {skill} When Struck", SkillEnumeration.SlowMissiles),
                new Statistic("2% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Valkyrie),
                new Statistic("+2 To Amazon Skill Levels", null),
                new Statistic("+20% Faster Hit Recovery", null),
                new Statistic("+2 To Critical Strike", null),
                new Statistic("Cold Resist +30%", null),
                new Statistic("Attacker Takes Damage of 14", null)
            }, "https://diablo2.wiki.fextralife.com/Peace");

        public static RuneWordEnumeration Phoenix => new(53, "Phoenix", 65, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Vex, RuneEnumeration.Lo, RuneEnumeration.Jah },
            _rangedWeapons.Concat(_meleeWeapons).Concat(new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.PaladinShield }),
            new List<Statistic>
            {
                new Statistic("100% Chance To Cast level 40 {skill} When You Level-up", SkillEnumeration.Blaze),
                new Statistic("40% Chance To Cast Level 22 {skill} On Striking", SkillEnumeration.Firestorm),
                new Statistic("Level 10-15 {skill} Aura When Equipped (varies)", SkillEnumeration.Redemption),
                new Statistic("+350-400% Enhanced Damage (varies)", null),
                new Statistic("-28% To Enemy Fire Resistance", null),
                new Statistic("+350-400 Defense Vs. Missile (varies)", null),
                new Statistic("+15-21 Fire Absorb (varies)", null),
                new Statistic("Ignores Target's Defense (Weapons)", null),
                new Statistic("14% Mana Stolen Per Hit (Weapons)", null),
                new Statistic("20% Deadly Strike (Weapons)", null),
                new Statistic("+50 To Life (Shields)", null),
                new Statistic("+5% To Maximum Lightning Resist (Shields)", null),
                new Statistic("+10% To Maximum Fire Resist (Shields)", null)
            }, "https://diablo2.wiki.fextralife.com/Phoenix");

        public static RuneWordEnumeration Pride => new(54, "Pride", 67, new List<RuneEnumeration> { RuneEnumeration.Cham, RuneEnumeration.Sur, RuneEnumeration.Io, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new Statistic("25% Chance To Cast Level 17 {skill} When Struck", SkillEnumeration.FireWall),
                new Statistic("Level 16-20 {skill} Aura When Equipped (varies)", SkillEnumeration.Concentration),
                new Statistic("260-300% Bonus To Attack Rating (varies)", null),
                new Statistic("+(1*Clvl)% Damage To Demons (Based on Character Level)", null),
                new Statistic("Adds 50-280 Lightning Damage", null),
                new Statistic("20% Deadly Strike", null),
                new Statistic("Hit Blinds Target", null),
                new Statistic("Freezes Target +3", null),
                new Statistic("+10 To Vitality", null),
                new Statistic("Replenish Life +8", null),
                new Statistic("(1.875*Clvl)% Extra Gold From Monsters (Based on Character Level)", null)
            }, "https://diablo2.wiki.fextralife.com/Pride");

        public static RuneWordEnumeration Principle => new(55, "Principle", 55, runes: new List<RuneEnumeration> { RuneEnumeration.Ral, RuneEnumeration.Gul, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("100% Chance To Cast Level 5 {skill} On Striking", SkillEnumeration.HolyBolt),
                new Statistic("+2 To Paladin Skill Levels", null),
                new Statistic("+50% Damage to Undead", null),
                new Statistic("+100-150 to Life (varies)", null),
                new Statistic("15% Slower Stamina Drain", null),
                new Statistic("+5% To Maximum Poison Resist", null),
                new Statistic("Fire Resist +30%", null)
            }, "https://diablo2.wiki.fextralife.com/Principle");

        public static RuneWordEnumeration Prudence => new(56, "Prudence", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Mal, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("+25% Faster Hit Recovery", null),
                new Statistic("+140-170% Enhanced Defense (varies)", null),
                new Statistic("All Resistances +25-35 (varies)", null),
                new Statistic("Damage Reduced by 3", null),
                new Statistic("Magic Damage Reduced by 17", null),
                new Statistic("+2 To Mana After Each Kill", null),
                new Statistic("+1 To Light Radius", null),
                new Statistic("Repairs Durability 1 In 4 Seconds", null)
            }, "https://diablo2.wiki.fextralife.com/Prudence");

        public static RuneWordEnumeration Radiance => new(57, "Radiance", 27, runes: new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Sol, RuneEnumeration.Ith },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new Statistic("+75% Enhanced Defense", null),
                new Statistic("+30 Defense vs. Missiles", null),
                new Statistic("+10 to Vitality", null),
                new Statistic("+10 to Energy", null),
                new Statistic("+33 to Mana", null),
                new Statistic("Damage Reduced by 7", null),
                new Statistic("Magic Damage Reduced by 3", null),
                new Statistic("15% Damage Taken Goes to Mana", null),
                new Statistic("+5 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Radiance");

        public static RuneWordEnumeration Rain => new(58, "Rain", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Ort, RuneEnumeration.Mal, RuneEnumeration.Ith },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("5% Chance To Cast Level 15 {skill} Armor When Struck", SkillEnumeration.CycloneArmor),
                new Statistic("5% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Twister),
                new Statistic("+2 To Druid Skills", null),
                new Statistic("+100-150 To Mana (varies)", null),
                new Statistic("Lightning Resist +30%", null),
                new Statistic("Magic Damage Reduced By 7", null),
                new Statistic("15% Damage Taken Goes to Mana", null)
            }, "https://diablo2.wiki.fextralife.com/Rain");

        public static RuneWordEnumeration Rhyme => new(59, "Rhyme", 29, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.PaladinShield },
            new List<Statistic>
            {
                new Statistic("+40% Faster Block Rate", null),
                new Statistic("20% Increased Chance of Blocking", null),
                new Statistic("Regenerate Mana 15%", null),
                new Statistic("All Resistances +25", null),
                new Statistic("Cannot be Frozen", null),
                new Statistic("50% Extra Gold from Monsters", null),
                new Statistic("25% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Rhyme");

        public static RuneWordEnumeration Rift => new(60, "Rite", 53, runes: new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Ko, RuneEnumeration.Lem, RuneEnumeration.Gul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Scepter },
            new List<Statistic>
            {
                new Statistic("20% Chance To Cast Level 16 {skill} On Striking", SkillEnumeration.Tornado),
                new Statistic("16% Chance To Cast Level 21 {skill} On Attack", SkillEnumeration.FrozenOrb),
                new Statistic("20% Bonus To Attack Rating", null),
                new Statistic("Adds 160-250 Magic Damage", null),
                new Statistic("Adds 60-180 Fire Damage", null),
                new Statistic("+5-10 To All Attributes (varies)", null),
                new Statistic("+10 To Dexterity", null),
                new Statistic("38% Damage Taken Goes To Mana", null),
                new Statistic("75% Extra Gold From Monsters", null),
                new Statistic("Level 15 {skill} (40 Charges)", SkillEnumeration.IronMaiden),
                new Statistic("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Rift");

        public static RuneWordEnumeration Sanctuary => new(61, "Sanctuary", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Ko, RuneEnumeration.Ko, RuneEnumeration.Mal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.PaladinShield, ItemTypeEnumeration.Shield },
            new List<Statistic>
            {
                new Statistic("+20% Faster Hit Recovery", null),
                new Statistic("+20% Faster Block Rate", null),
                new Statistic("20% Increased Chance of Blocking", null),
                new Statistic("+130-160% Enhanced Defense (varies)", null),
                new Statistic("+250 Defense vs. Missile", null),
                new Statistic("+20 To Dexterity", null),
                new Statistic("All Resistances +50-70 (varies)", null),
                new Statistic("Magic Damage Reduced By 7", null),
                new Statistic("Level 12 {skill} (60 Charges)", SkillEnumeration.SlowMissiles)
            }, "https://diablo2.wiki.fextralife.com/Sanctuary");

        public static RuneWordEnumeration Silence => new(62, "Silence", 55, runes: new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Eld, RuneEnumeration.Hel, RuneEnumeration.Ist, RuneEnumeration.Tir, RuneEnumeration.Vex },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new Statistic("+2 to All Skills", null),
                new Statistic("+20% Increased Attack Speed", null),
                new Statistic("+20% Faster Hit Recovery", null),
                new Statistic("+200% Enhanced Damage", null),
                new Statistic("+75% Damage To Undead", null),
                new Statistic("+50 to Attack Rating Against Undead", null),
                new Statistic("11% Mana Stolen Per Hit", null),
                new Statistic("Hit Blinds Target +33", null),
                new Statistic("Hit Causes Monster to Flee 25%", null),
                new Statistic("All Resistances +75", null),
                new Statistic("+2 to Mana After Each Kill", null),
                new Statistic("30% Better Chance of Getting Magic Items", null),
                new Statistic("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Silence");

        public static RuneWordEnumeration Smoke => new(63, "Smoke", 37, runes: new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("+20% Faster Hit Recovery", null),
                new Statistic("+75% Enhanced Defense", null),
                new Statistic("+280 Defense vs. Missiles", null),
                new Statistic("+10 to Energy", null),
                new Statistic("All Resistances +50", null),
                new Statistic("-1 to Light Radius", null),
                new Statistic("Level 6 {skill} (18 charges)", SkillEnumeration.Weaken)
            }, "https://diablo2.wiki.fextralife.com/Smoke");

        public static RuneWordEnumeration Spirit => new(64, "Spirit", 25, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Thul, RuneEnumeration.Ort, RuneEnumeration.Amn },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new Statistic("+2 To All Skills", null),
                new Statistic("+25-35% Faster Cast Rate (varies)", null),
                new Statistic("+55% Faster Hit Recovery", null),
                new Statistic("+250 Defense Vs. Missile", null),
                new Statistic("+22 To Vitality", null),
                new Statistic("+89-112 To Mana (varies)", null),
                new Statistic("+3-8 Magic Absorb (varies)", null),
                new Statistic("Cold Resist +35% (Shields)", null),
                new Statistic("Lightning Resist +35% (Shields)", null),
                new Statistic("Poison Resist +35% (Shields)", null),
                new Statistic("Attacker Takes Damage of 14 (Shields)", null),
                new Statistic("Adds 1-50 Lightning Damage (Swords)", null),
                new Statistic("Adds 3-14 Cold Damage (3 Sec,Normal) (Swords)", null),
                new Statistic("+75 Poison Damage Over 5 Seconds (Swords)", null),
                new Statistic("7% Life Stolen Per Hit (Swords)", null)
            }, "https://diablo2.wiki.fextralife.com/Spirit");

        public static RuneWordEnumeration Splendor => new(65, "Splendor", 37, runes: new List<RuneEnumeration> { RuneEnumeration.Eth, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.PaladinShield },
            new List<Statistic>
            {
                new Statistic("+1 To All Skills", null),
                new Statistic("+10% Faster Cast Rate", null),
                new Statistic("+20% Faster Block Rate", null),
                new Statistic("+60-100% Enhanced Defense (varies)", null),
                new Statistic("+10 To Energy", null),
                new Statistic("Regenerate Mana 15%", null),
                new Statistic("50% Extra Gold From Monsters", null),
                new Statistic("20% Better Chance of Getting Magic Items", null),
                new Statistic("+3 To Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Splendor");

        public static RuneWordEnumeration Stealth => new(66, "Stealth", 17, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("+25% Faster Run/Walk", null),
                new Statistic("+25% Faster Casting Rate", null),
                new Statistic("+25% Faster Hit Recovery", null),
                new Statistic("+6 to Dexterity", null),
                new Statistic("Regenerate Mana 15%", null),
                new Statistic("+15 Maximum Stamina", null),
                new Statistic("Poison Resist +30%", null),
                new Statistic("Magic Damage Reduced by 3", null)
            }, "https://diablo2.wiki.fextralife.com/Stealth");

        public static RuneWordEnumeration Steel => new(67, "Steel", 13, runes: new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.El },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe, ItemTypeEnumeration.Mace },
            new List<Statistic>
            {
                new Statistic("+25% Increased Attack Speed", null),
                new Statistic("+20% Enhanced Damage", null),
                new Statistic("+3 to Minimum Damage", null),
                new Statistic("+3 to Maximum Damage", null),
                new Statistic("+50 to Attack Rating", null),
                new Statistic("50% Chance of Open Wounds", null),
                new Statistic("+2 to Mana after each Kill", null),
                new Statistic("+1 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Steel");

        public static RuneWordEnumeration Stone => new(68, "Stone", 47, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Um, RuneEnumeration.Pul, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new Statistic("+60% Faster Hit Recovery", null),
                new Statistic("+250-290% Enhanced Defense (varies)", null),
                new Statistic("+300 Defense Vs. Missile", null),
                new Statistic("+16 To Strength", null),
                new Statistic("+16 To Vitality", null),
                new Statistic("+10 To Energy", null),
                new Statistic("All Resistances +15", null),
                new Statistic("Level 16 {skill} (80 Charges)", SkillEnumeration.MoltenBoulder),
                new Statistic("Level 16 {skill} (16 Charges)", SkillEnumeration.ClayGolem)
            }, "https://diablo2.wiki.fextralife.com/Stone");

        public static RuneWordEnumeration Strength => new(69, "Strength", 25, runes: new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Tir },
            _meleeWeapons,
            new List<Statistic>
            {
                new Statistic("+35% Enhanced Damage", null),
                new Statistic("7% Life stolen per hit", null),
                new Statistic("25% Chance of Crushing Blow", null),
                new Statistic("+20 to Strength", null),
                new Statistic("+10 to Vitality", null),
                new Statistic("+2 to Mana after each Kill", null)
            }, "https://diablo2.wiki.fextralife.com/Strength");

        public static RuneWordEnumeration Treachery => new(70, "Treachery", 43, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Thul, RuneEnumeration.Lem },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
           new List<Statistic>
            {
                new Statistic("5% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Fade),
                new Statistic("25% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Venom),
                new Statistic("+2 To Assassin Skills", null),
                new Statistic("+45% Increased Attack Speed", null),
                new Statistic("+20% Faster Hit Recovery", null),
                new Statistic("Cold Resist +30%", null),
                new Statistic("50% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Treachery");

        public static RuneWordEnumeration Venom => new(71, "Venom", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Dol, RuneEnumeration.Mal },
            _rangedWeapons.Concat(_meleeWeapons),
           new List<Statistic>
            {
                new Statistic("Ignore Target's Defense", null),
                new Statistic("+273 Poison Damage Over 6 Seconds", null),
                new Statistic("7% Mana Stolen Per Hit", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("Hit Causes Monster To Flee 25%", null),
                new Statistic("Level 13 {skill} (11 Charges)", SkillEnumeration.PoisonNova),
                new Statistic("Level 15 {skill} (27 Charges)", SkillEnumeration.PosionExplosion)
            }, "https://diablo2.wiki.fextralife.com/Venom");

        public static RuneWordEnumeration VoiceOfReason => new(72, "Voice of Reason", 43, runes: new List<RuneEnumeration> { RuneEnumeration.Lem, RuneEnumeration.Ko, RuneEnumeration.El, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Mace, ItemTypeEnumeration.Sword },
           new List<Statistic>
            {
                new Statistic("15% Chance To Cast Level 13 {skill} On Striking", SkillEnumeration.FrozenOrb),
                new Statistic("18% Chance To Cast Level 20 {skill} On Striking", SkillEnumeration.IceBlast),
                new Statistic("+50 To Attack Rating", null),
                new Statistic("+220-350% Damage To Demons (varies)", null),
                new Statistic("+355-375% Damage To Undead (varies)", null),
                new Statistic("+50 To Attack Rating Against Undead", null),
                new Statistic("Adds 100-220 Cold Damage", null),
                new Statistic("-24% To Enemy Cold Resistance", null),
                new Statistic("+10 To Dexterity", null),
                new Statistic("Cannot Be Frozen", null),
                new Statistic("75% Extra Gold From Monsters", null),
                new Statistic("+1 To Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Voice+of+Reason");

        public static RuneWordEnumeration Wealth => new(73, "Wealth", 43, runes: new List<RuneEnumeration> { RuneEnumeration.Lem, RuneEnumeration.Ko, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
           new List<Statistic>
            {
                new Statistic("+10 to Dexterity", null),
                new Statistic("+2 to Mana After Each Kill", null),
                new Statistic("300% Extra Gold From Monsters", null),
                new Statistic("100% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Wealth");

        public static RuneWordEnumeration White => new(74, "White", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Io },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Wand },
           new List<Statistic>
            {
                new Statistic("+3 to Poison and Bone Skills (Necromancer Only)", null),
                new Statistic("+20% Faster Cast Rate", null),
                new Statistic("+2 to {skill} (Necromancer Only)", SkillEnumeration.BoneSpear),
                new Statistic("+4 to {skill} (Necromancer Only)", SkillEnumeration.SkeletonMastery),
                new Statistic("+3 to {skill} (Necromancer Only)", SkillEnumeration.BoneArmor),
                new Statistic("Hit causes monster to flee 25%", null),
                new Statistic("+10 to vitality", null),
                new Statistic("+13 to mana", null),
                new Statistic("Magic Damage Reduced by 4", null)
            }, "https://diablo2.wiki.fextralife.com/White");

        public static RuneWordEnumeration Wind => new(75, "Wind", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Sur, RuneEnumeration.El },
            _meleeWeapons,
           new List<Statistic>
            {
                new Statistic("10% Chance To Cast Level 9 {skill} On Striking", SkillEnumeration.Tornado),
                new Statistic("+20% Faster Run/Walk", null),
                new Statistic("+40% Increased Attack Speed", null),
                new Statistic("+15% Faster Hit Recovery", null),
                new Statistic("+120-160% Enhanced Damage (varies)", null),
                new Statistic("-50% Target Defense", null),
                new Statistic("+50 To Attack Rating", null),
                new Statistic("Hit Blinds Target", null),
                new Statistic("+1 To Light Radius", null),
                new Statistic("Level 13 {skill} (127 Charges)", SkillEnumeration.Twister)
            }, "https://diablo2.wiki.fextralife.com/Wind");

        public static RuneWordEnumeration Wrath => new(76, "Wrath", 63, runes: new List<RuneEnumeration> { RuneEnumeration.Pul, RuneEnumeration.Lum, RuneEnumeration.Ber, RuneEnumeration.Mal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
           new List<Statistic>
            {
                new Statistic("30% Chance To Cast Level 1 {skill} On Striking", SkillEnumeration.Decrepify),
                new Statistic("5% Chance To Cast Level 10 {skill} On Striking", SkillEnumeration.LifeTap),
                new Statistic("+375% Damage To Demons", null),
                new Statistic("+100 To Attack Rating Against Demons", null),
                new Statistic("+250-300% Damage To Undead (varies)", null),
                new Statistic("Adds 85-120 Magic Damage", null),
                new Statistic("Adds 41-240 Lightning Damage", null),
                new Statistic("20% Chance of Crushing Blow", null),
                new Statistic("Prevent Monster Heal", null),
                new Statistic("+10 To Energy", null),
                new Statistic("Cannot Be Frozen", null)
            }, "https://diablo2.wiki.fextralife.com/Wrath");

        public static RuneWordEnumeration Zephyr => new(77, "Zephyr", 21, runes: new List<RuneEnumeration> { RuneEnumeration.Ort, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
           new List<Statistic>
            {
                new Statistic("7% Chance to Cast Level 1 {skill} When Struck", SkillEnumeration.Twister),
                new Statistic("+25% Faster Run/Walk", null),
                new Statistic("+25% Increased Attack Speed", null),
                new Statistic("+33% Enhanced Damage", null),
                new Statistic("-25% Target Defense", null),
                new Statistic("+66 to Attack Rating", null),
                new Statistic("Adds 1-50 lightning damage", null),
                new Statistic("+25 Defense", null)
            }, "https://diablo2.wiki.fextralife.com/Unbending+Will");

        public static RuneWordEnumeration Mist => new(79, "Mist", 67, runes: new List<RuneEnumeration> { RuneEnumeration.Cham, RuneEnumeration.Shael, RuneEnumeration.Gul, RuneEnumeration.Eld, RuneEnumeration.Thul, RuneEnumeration.Ith },
            _rangedWeapons,
           new List<Statistic>
            {
                new Statistic("Level 8-12 {skill} Aura When Equipped (varies)", SkillEnumeration.Concentration),
                new Statistic("+3 To All Skills", null),
                new Statistic("20% Increased Attack Speed", null),
                new Statistic("+100% Piercing Attack", null),
                new Statistic("+325-375% Enhanced Damage (varies)", null),
                new Statistic("+9 To Maximum Damage", null),
                new Statistic("20% Bonus to Attack Rating", null),
                new Statistic("Adds 3-14 Cold Damage", null),
                new Statistic("Freeze Target +3", null),
                new Statistic("+24 to Vitality", null),
                new Statistic("All Resistances +40", null)
            }, "https://diablo2.wiki.fextralife.com/Mist");

        public static RuneWordEnumeration Wisdom => new(80, "Wisdom", 45, runes: new List<RuneEnumeration> { RuneEnumeration.Pul, RuneEnumeration.Ith, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new Statistic("+33% Piercing Attack", null),
                new Statistic("+15-25% Bonus to Attack Rating (varies)", null),
                new Statistic("4-8% Mana Stolen Per Hit (varies)", null),
                new Statistic("+30% Enhanced Defense", null),
                new Statistic("+10 to Energy", null),
                new Statistic("15% Slower Stamina Drain", null),
                new Statistic("Cannot Be Frozen", null),
                new Statistic("+5 Mana After Each Kill", null),
                new Statistic("15% Damage Taken Goes to Mana", null)
            }, "https://diablo2.wiki.fextralife.com/Wisdom");

        public static RuneWordEnumeration Pattern => new(81, "Pattern", 23, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Ort, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Claw },
           new List<Statistic>
            {
                new Statistic("+30% Faster Block Rate", null),
                new Statistic("+40-80% Enhanced Damage (varies)", null),
                new Statistic("10% Bonus to Attack Rating", null),
                new Statistic("Adds 12-32 Fire Damage", null),
                new Statistic("Adds 1-50 Lightning Damage", null),
                new Statistic("Adds 3-14 Cold Damage", null),
                new Statistic("+75 Poison Damage Over 5 Seconds", null),
                new Statistic("+6 to Strength", null),
                new Statistic("+6 to Dexterity", null),
                new Statistic("All Resistances +15", null)
            }, "https://diablo2.wiki.fextralife.com/Pattern");

        public static RuneWordEnumeration Plague => new(82, "Plague", 67, runes: new List<RuneEnumeration> { RuneEnumeration.Cham, RuneEnumeration.Shael, RuneEnumeration.Um },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Claw, ItemTypeEnumeration.Dagger },
           new List<Statistic>
            {
                new Statistic("20% Chance to cast level 12 {skill} when struck", SkillEnumeration.LowerResist),
                new Statistic("25% Chance to cast level 15 {skill} on striking", SkillEnumeration.PoisonNova),
                new Statistic("Level 13-17 {skill} Aura When Equipped (varies)", SkillEnumeration.Cleansing),
                new Statistic("+1-2 All Skills", null),
                new Statistic("+20% Increased Attack Speed", null),
                new Statistic("+220-320% Enhanced Damage (varies)", null),
                new Statistic("-23% To Enemy Poison Resistance", null),
                new Statistic("+(0.375*Clvl) Deadly Strike (Based on Character Level)", null),
                new Statistic("+25% Chance of Open Wounds", null),
                new Statistic("Freezes Target +3", null)
            }, "https://diablo2.wiki.fextralife.com/Plague");

        public static RuneWordEnumeration Obsession => new(83, "Obsession", 69, runes: new List<RuneEnumeration> { RuneEnumeration.Zod, RuneEnumeration.Ist, RuneEnumeration.Lem, RuneEnumeration.Lum, RuneEnumeration.Io, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave },
           new List<Statistic>
            {
                new Statistic("Indestructible", null),
                new Statistic("24% Chance to cast level 10 {skill} when struck", SkillEnumeration.Weaken),
                new Statistic("+4 To All Skills", null),
                new Statistic("+65% Faster Cast Rate", null),
                new Statistic("+60% Faster Hit Recovery", null),
                new Statistic("Knockback", null),
                new Statistic("+10 To Vitality", null),
                new Statistic("+10 To Energy", null),
                new Statistic("Increase Maximum Life 15-25% (varies)", null),
                new Statistic("Regenerate Mana 15-30% (varies)", null),
                new Statistic("All Resistances +60-70 (varies)", null),
                new Statistic("75% Extra Gold from Monsters", null),
                new Statistic("30% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Obsession");

        public static RuneWordEnumeration FlickeringFlame => new(84, "Flickering Flame", 55, runes: new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Pul, RuneEnumeration.Vex },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new Statistic("Level 4-8 {skill} Aura When Equipped (varies)", SkillEnumeration.ResistFire),
                new Statistic("+3 To Fire Skills", null),
                new Statistic("-10-15% to Enemy Fire Resistance (varies)", null),
                new Statistic("+30% Enhanced Defense", null),
                new Statistic("+30 Defense Vs. Missile", null),
                new Statistic("+50-75 To Mana (varies)", null),
                new Statistic("Half Freeze Duration", null),
                new Statistic("+5% To Maximum Fire Resist", null),
                new Statistic("Poison Length Reduced by 50%", null)
            }, "https://diablo2.wiki.fextralife.com/Obsession");

        public RuneWordEnumeration(int id, string name, int level, IEnumerable<RuneEnumeration> runes, IEnumerable<ItemTypeEnumeration> itemTypes, IEnumerable<Statistic> statistics, string url)
            : base(id, name)
        {
            Level = level;
            Runes = runes;
            ItemTypes = itemTypes;
            Statistics = statistics;
            Url = url;
        }
    }

    internal static class InitializeMigration
    {
        public static void Insert<TEnumeration>(this MigrationBuilder migrationBuilder, string table, string[] columns, Func<TEnumeration, object[]> values)
            where TEnumeration : Enumeration
        {
            foreach (var value in Enumeration.GetAll<TEnumeration>())
            {
                migrationBuilder.InsertData(table, columns, values(value), schema: "resurrected");
            }
        }

        public static void Insert(this MigrationBuilder migrationBuilder, RuneWordEnumeration runeWord)
        {
            migrationBuilder.InsertData("rune_words", new string[] { "id", "name", "level", "url" },
                    new object[] { runeWord.Id, runeWord.Name, runeWord.Level, runeWord.Url }, schema: "resurrected");

            foreach (var itemType in runeWord.ItemTypes)
            {
                migrationBuilder.InsertData("rune_words_item_types_switch", new string[] { "item_type_id", "rune_word_id" },
                        new object[] { itemType.Id, runeWord.Id }, schema: "resurrected");
            }

            var order = 1;
            foreach (var rune in runeWord.Runes)
            {
                migrationBuilder.InsertData("rune_words_runes_switch", new string[] { "rune_id", "rune_word_id", "order" },
                        new object[] { rune.Id, runeWord.Id, order++ }, schema: "resurrected");
            }

            foreach (var statistic in runeWord.Statistics)
            {
                migrationBuilder.InsertData("statistics", new string[] { "description", "rune_word_id", "skill_id" },
                        new object[] { statistic.Description, runeWord.Id, statistic.Skill?.Id }, schema: "resurrected");
            }
        }

        public static void CreateAndFillClasses(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                schema: "resurrected",
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

            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 0, "Amazon" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 1, "Assassin" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 2, "Barbarian" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 3, "Druid" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 4, "Necromancer" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 5, "Paladin" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 6, "Sorceress" }, schema: "resurrected");
        }

        public static void CreateAndFillItemTypes(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "item_types",
                 schema: "resurrected",
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

            migrationBuilder.Insert<ItemTypeEnumeration>("item_types", new string[] { "id", "name", "class" }, it => new object[] { it.Id, it.Name, it.Class });
        }

        public static void CreateAndFillRunes(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "runes",
                schema: "resurrected",
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

            migrationBuilder.Insert<RuneEnumeration>("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" }, r => new object[] { r.Id, r.Name, r.Level, r.InWeapon, r.InHelmet, r.InBodyArmor, r.InShield });
        }

        public static void CreateAndFillRuneWords(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rune_words",
                schema: "resurrected",
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
                schema: "resurrected",
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
                        principalSchema: "resurrected",
                        principalTable: "item_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rune_words_item_types",
                        column: x => x.rune_word_id,
                        principalSchema: "resurrected",
                        principalTable: "rune_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rune_words_runes_switch",
                schema: "resurrected",
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
                        principalSchema: "resurrected",
                        principalTable: "rune_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_runes_rune_words",
                        column: x => x.rune_id,
                        principalSchema: "resurrected",
                        principalTable: "runes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
               name: "skills",
               schema: "resurrected",
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
                schema: "resurrected",
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
                        principalSchema: "resurrected",
                        principalTable: "rune_words",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_statistics_skills",
                        column: x => x.skill_id,
                        principalSchema: "resurrected",
                        principalTable: "skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.Insert<SkillEnumeration>("skills", new string[] { "id", "name", "description", "url" }, s => new object[] { s.Id, s.Name, s.Description, s.Url });

            migrationBuilder.CreateIndex(
                name: "IX_rune_words_id",
                table: "rune_words",
                schema: "resurrected",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_rune_words_item_types_switch_rune_word_id",
                table: "rune_words_item_types_switch",
                schema: "resurrected",
                column: "rune_word_id");

            migrationBuilder.CreateIndex(
                name: "IX_rune_words_runes_switch_rune_word_id",
                table: "rune_words_runes_switch",
                schema: "resurrected",
                column: "rune_word_id");

            migrationBuilder.CreateIndex(
                name: "IX_statistic_skill_id",
                table: "statistics",
                schema: "resurrected",
                column: "skill_id");

            foreach (var runeWord in Enumeration.GetAll<RuneWordEnumeration>())
            {
                migrationBuilder.Insert(runeWord);
            }
        }
    }
}
