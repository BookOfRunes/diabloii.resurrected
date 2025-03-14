using STrain.Core.Enumerations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Enumerations
{
    [ExcludeFromCodeCoverage]
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
            new("+50% Enhanced Defense", null),
            new("Cold Resist +43%", null),
            new("Lightning Resist +48%", null),
            new("Fire Resist +48%", null),
            new("Poison Resist +48%", null),
            new("10% Damage Taken Goes to Mana", null)
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
            new("Level 9 {skill} Aura When Equipped", SkillEnumeration.Fanaticism),
            new("+40% Increased Attack Speed", null),
            new("+240-270% Enhanced Damage (varies)", null),
            new("20% Chance of Crushing Blow", null),
            new("25% Chance of Open Wounds", null),
            new("+3 To {skill}",SkillEnumeration.Werebear),
            new("+3 To {skill}",SkillEnumeration.Lycanthropy),
            new("Prevent Monster Heal", null),
            new("+25-40 To Strength (varies)", null),
            new("+10 To Energy", null),
            new("+2 To Mana After Each Kill", null),
            new("Level 13  {skill} (5 Charges)", SkillEnumeration.SummonGrizzly),
       }, "https://diablo2.wiki.fextralife.com/Beast");

        public static RuneWordEnumeration Black => new(2, "Black", 35, new List<RuneEnumeration> { RuneEnumeration.Thul, RuneEnumeration.Io, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Club, ItemTypeEnumeration.Hammer, ItemTypeEnumeration.Mace },
            new List<Statistic>
            {
                new("+15% Increased Attack Speed", null),
                new("+120% Enhanced Damage", null),
                new("+200 to Attack Rating", null),
                new("Adds 3-14 Cold Damage (3 sec)", null),
                new("40% Chance of Crushing Blow", null),
                new("Knockback", null),
                new("+10 to Vitality", null),
                new("Magic Damage Reduced By 2", null),
                new("Level 4 {skill} (12 Charges)", SkillEnumeration.CorpseExplosion)
            }, "https://diablo2.wiki.fextralife.com/Black");

        public static RuneWordEnumeration Bone => new(3, "Bone", 47, new List<RuneEnumeration> { RuneEnumeration.Sol, RuneEnumeration.Um, RuneEnumeration.Um },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("15% Chance To Cast level 10 {skill} When Struck", SkillEnumeration.BoneArmor),
                new("15% Chance To Cast level 10 {skill} On Striking", SkillEnumeration.BoneSpear),
                new("+2 To Necromancer Skill Levels", null),
                new("+100-150 To Mana (varies)", null),
                new("All Resistances +30", null),
                new("Damage Reduced By 7", null)
            }, "https://diablo2.wiki.fextralife.com/Bone");

        public static RuneWordEnumeration Bramble => new(4, "Bramble", 61, new List<RuneEnumeration> { RuneEnumeration.Ral, RuneEnumeration.Ohm, RuneEnumeration.Sur, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("Level 15-21 {skill} Aura When Equipped (varies)", SkillEnumeration.Thorns),
                new("+50% Faster Hit Recovery", null),
                new("+25-50% To Poison Skill Damage (varies)", null),
                new("+300 Defense", null),
                new("Increase Maximum Mana 5%", null),
                new("Regenerate Mana 15%", null),
                new("+5% To Maximum Cold Resist", null),
                new("Fire Resist +30%", null),
                new("Poison Resist +100%", null),
                new("+13 Life After Each Kill", null),
                new("Level 13 {skill} (33 Charges)", SkillEnumeration.SpiritOfBarbs)
            }, "https://diablo2.wiki.fextralife.com/Bramble");

        public static RuneWordEnumeration Brand => new(5, "Brand", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Lo, RuneEnumeration.Mal, RuneEnumeration.Gul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new("35% Chance To Cast Level 14 {skill} When Struck", SkillEnumeration.AmplifyDamage),
                new("100% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.BoneSpear),
                new("Fires {skill} (15)", SkillEnumeration.ExplodingArrow),
                new("+260-340% Enhanced Damage (varies)", null),
                new("Ignore Target's Defense", null),
                new("20% Bonus to Attack Rating", null),
                new("+280-330% Damage To Demons (varies)", null),
                new("20% Deadly Strike", null),
                new("Prevent Monster Heal", null),
                new("Knockback", null)
            }, "https://diablo2.wiki.fextralife.com/Brand");

        public static RuneWordEnumeration BreathOfTheDying => new(6, "Breath of the Dying", 69, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Hel, RuneEnumeration.El, RuneEnumeration.Eld, RuneEnumeration.Zod, RuneEnumeration.Eth },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new("50% Chance To Cast Level 20 {skill} When You Kill An Enemy", SkillEnumeration.PoisonNova),
                new("Indestructible", null),
                new("+60% Increased Attack Speed", null),
                new("+350-400% Enhanced Damage (varies)", null),
                new("-25% Target Defense", null),
                new("+50 To Attack Rating", null),
                new("+200% Damage To Undead", null),
                new("+50 To Attack Rating Against Undead", null),
                new("7% Mana Stolen Per Hit", null),
                new("12-15% Life Stolen Per Hit (varies)", null),
                new("Prevent Monster Heal", null),
                new("+30 To All Attributes", null),
                new("+1 To Light Radius", null),
                new("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Breath+of+the+Dying");

        public static RuneWordEnumeration CallToArms => new(7, "Call to Arms", 57, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Ral, RuneEnumeration.Mal, RuneEnumeration.Ist, RuneEnumeration.Ohm },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new("+1 To All Skills", null),
                new("+40% Increased Attack Speed", null),
                new("+240-290% Enhanced Damage (varies)", null),
                new("Adds 5-30 Fire Damage", null),
                new("7% Life Stolen Per Hit", null),
                new("+2-6 To {skill} (varies)", SkillEnumeration.BattleCommand),
                new("+1-6 To {skill} (varies)", SkillEnumeration.BattleOrder),
                new("+1-4 To {skill} (varies)", SkillEnumeration.BattleCry),
                new("Prevent Monster Heal", null),
                new("Replenish Life +12", null),
                new("30% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Call+to+Arms");

        public static RuneWordEnumeration ChainsOfHonor => new(8, "Chains of Honor", 63, new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Um, RuneEnumeration.Ber, RuneEnumeration.Ist },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("+2 To All Skills", null),
                new("+200% Damage To Demons", null),
                new("+100% Damage To Undead", null),
                new("8% Life Stolen Per Hit", null),
                new("+70% Enhanced Defense", null),
                new("+20 To Strength", null),
                new("Replenish Life +7", null),
                new("All Resistances +65", null),
                new("Damage Reduced By 8%", null),
                new("25% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Chains+of+Honor");

        public static RuneWordEnumeration Chaos => new(9, "Chaos", 57, new List<RuneEnumeration> { RuneEnumeration.Fal, RuneEnumeration.Ohm, RuneEnumeration.Um },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Claw },
            new List<Statistic>
            {
                new("9% Chance To Cast Level 11 {skill} On Striking", SkillEnumeration.FrozenOrb),
                new("11% Chance To Cast Level 9 {skill} On Striking", SkillEnumeration.ChargedBolt),
                new("+35% Increased Attacked Speed", null),
                new("+240-290% Enhanced Damage (varies)", null),
                new("Adds 216-471 Magic Damage", null),
                new("25% Chance of Open Wounds", null),
                new("+1 To {skill}", SkillEnumeration.Whirlwind),
                new("+10 To Strength", null),
                new("+15 Life After Each Demon Kill", null)
            }, "https://diablo2.wiki.fextralife.com/Chaos");

        public static RuneWordEnumeration CrescentMoon => new(10, "Crescent Moon", 47, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Um, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new("10% Chance To Cast Level 17 {skill} On Striking", SkillEnumeration.ChainLightning),
                new("7% Chance To Cast Level 13 {skill} On Striking", SkillEnumeration.StaticField),
                new("+20% Increased Attack Speed", null),
                new("+180-220% Enhanced Damage (varies)", null),
                new("Ignore Target's Defense", null),
                new("-35% To Enemy Lightning Resistance", null),
                new("25% Chance of Open Wounds", null),
                new("+9-11 Magic Absorb (varies)", null),
                new("+2 To Mana After Each Kill", null),
                new("Level 18 Summon {skill} (30 Charges)", SkillEnumeration.SummonSpiritWolf)
            }, "https://diablo2.wiki.fextralife.com/Crescent+Moon+(Runeword)");

        public static RuneWordEnumeration Death => new(11, "Death", 55, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.El, RuneEnumeration.Vex, RuneEnumeration.Ort, RuneEnumeration.Gul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new("Indestructible", null),
                new("100% Chance To Cast Level 44 {skill} When You Die", SkillEnumeration.ChainLightning),
                new("25% Chance To Cast Level 18 {skill} On Attack", SkillEnumeration.GlacialSpike),
                new("+300-385% Enhanced Damage (varies)", null),
                new("20% Bonus To Attack Rating", null),
                new("+50 To Attack Rating", null),
                new("Adds 1-50 Lightning Damage", null),
                new("7% Mana Stolen Per Hit", null),
                new("50% Chance of Crushing Blow", null),
                new("(0.5*Clvl)% Deadly Strike (Based on Character Level)", null),
                new("+1 To Light Radius", null),
                new("Level 22 {skill} (15 Charges)", SkillEnumeration.BloodGolem),
                new("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Death");

        public static RuneWordEnumeration Delirium => new(12, "Delirium", 51, new List<RuneEnumeration> { RuneEnumeration.Lem, RuneEnumeration.Ist, RuneEnumeration.Io },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new("1% Chance To Cast lvl 50 Delirium When Struck", null),
                new("6% Chance To Cast lvl 14 {skill} When Struck", SkillEnumeration.MindBlast),
                new("14% Chance To Cast lvl 13 {skill} When Struck", SkillEnumeration.Terror),
                new("11% Chance To Cast lvl 18 {skill} On Striking", SkillEnumeration.Confuse),
                new("+2 To All Skills", null),
                new("+261 Defense", null),
                new("+10 To Vitality", null),
                new("50% Extra Gold From Monsters", null),
                new("25% Better Chance of Getting Magic Items", null),
                new("Level 17 {skill} (60 Charges)", SkillEnumeration.Attract)
            }, "https://diablo2.wiki.fextralife.com/Delirium");

        public static RuneWordEnumeration Destruction => new(13, "Destruction", 65, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Lo, RuneEnumeration.Ber, RuneEnumeration.Jah, RuneEnumeration.Ko },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new("23% Chance To Cast Level 12 {skill} On Striking", SkillEnumeration.Volcano),
                new("5% Chance To Cast Level 23 {skill} On Striking", SkillEnumeration.MoltenBoulder),
                new("100% Chance To Cast level 45 {skill} When You Die", SkillEnumeration.Meteor),
                new("15% Chance To Cast Level 22 {skill} On Attack", SkillEnumeration.Nova),
                new("+350% Enhanced Damage", null),
                new("Ignore Target's Defense", null),
                new("Adds 100-180 Magic Damage", null),
                new("7% Mana Stolen Per Hit", null),
                new("20% Chance Of Crushing Blow", null),
                new("20% Deadly Strike", null),
                new("Prevent Monster Heal", null),
                new("+10 To Dexterity", null),
            }, "https://diablo2.wiki.fextralife.com/Destruction");

        public static RuneWordEnumeration Doom => new(14, "Doom", 67, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Ohm, RuneEnumeration.Um, RuneEnumeration.Lo, RuneEnumeration.Cham },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Hammer, ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new("5% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.Volcano),
                new("Level 12 {skill} Aura When Equipped", SkillEnumeration.HolyFreeze),
                new("+2 To All Skills", null),
                new("+45% Increased Attack Speed", null),
                new("+330-370% Enhanced Damage (varies)", null),
                new("-40-60% To Enemy Cold Resistance (varies)", null),
                new("20% Deadly Strike", null),
                new("25% Chance of Open Wounds", null),
                new("Prevent Monster Heal", null),
                new("Freezes Target +3", null),
                new("Requirements -20%", null),
            }, "https://diablo2.wiki.fextralife.com/Doom");

        public static RuneWordEnumeration Dragon => new(15, "Dragon", 61, new List<RuneEnumeration> { RuneEnumeration.Sur, RuneEnumeration.Lo, RuneEnumeration.Sol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor, ItemTypeEnumeration.Shield },
            new List<Statistic>
            {
                new("20% Chance to Cast Level 18 {skill} When Struck", SkillEnumeration.Venom),
                new("12% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Hydra),
                new("Level 14 {skill} Aura When Equipped", SkillEnumeration.HolyFire),
                new("+360 Defense", null),
                new("+230 Defense Vs. Missile", null),
                new("+3-5 To All Attributes (varies)", null),
                new("+(0.375*Clvl) To Strength (Based on Character Level)", null),
                new("+5% To Maximum Lightning Resist", null),
                new("Damage Reduced by 7", null),
                new("Increase Maximum Mana 5% (Armor)", null),
                new("+50 To Mana (Shields)", null),
            }, "https://diablo2.wiki.fextralife.com/Dragon");

        public static RuneWordEnumeration Dream => new(16, "Dream", 65, new List<RuneEnumeration> { RuneEnumeration.Io, RuneEnumeration.Jah, RuneEnumeration.Pul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new("10% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Confuse),
                new("Level 15 {skill} Aura When Equipped", SkillEnumeration.HolyShock),
                new("+20-30% Faster Hit Recovery (varies)", null),
                new("+30% Enhanced Defense", null),
                new("+150-220 Defense (varies)", null),
                new("+10 To Vitality", null),
                new("+(0.625*Clvl) To Mana (Based On Character Level)", null),
                new("All Resistances +5-20 (varies)", null),
                new("12-25% Better Chance of Getting Magic Items (varies)", null),
                new("Increase Maximum Life 5% (Helmet)", null),
                new("+50 To Life (Shields)", null),
            }, "https://diablo2.wiki.fextralife.com/Dream");

        public static RuneWordEnumeration Duress => new(17, "Duress", 47, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Um, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("40% faster hit Recovery", null),
                new("+10-20% Enhanced Damage (varies)", null),
                new("Adds 37-133 Cold Damage", null),
                new("15% Crushing Blow", null),
                new("33% Open Wounds", null),
                new("+150-200% Enhanced Defense (varies)", null),
                new("-20% Slower Stamina Drain", null),
                new("Cold Resist +45%", null),
                new("Lightning Resist +15%", null),
                new("Fire Resist +15%", null),
                new("Poison Resist +15%", null),
            }, "https://diablo2.wiki.fextralife.com/Duress");

        public static RuneWordEnumeration Edge => new(18, "Edge", 25, new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.Tal, RuneEnumeration.Amn },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new("Level 15 {skill} Aura When Equipped", SkillEnumeration.Thorns),
                new("+35% Increased Attack Speed", null),
                new("+320-380% Damage To Demons (varies)", null),
                new("+280% Damage To Undead", null),
                new("+75 Poison Damage Over 5 Seconds", null),
                new("7% Life Stolen Per Hit", null),
                new("Prevent Monster Heal", null),
                new("+5-10 To All Attributes (varies)", null),
                new("+2 To Mana After Each Kill", null),
                new("Reduces All Vendor Prices 15%", null),
            }, "https://diablo2.wiki.fextralife.com/Edge");

        public static RuneWordEnumeration Enigma => new(19, "Enigma", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Ith, RuneEnumeration.Ber },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("+2 To All Skills", null),
                new("+45% Faster Run/Walk", null),
                new("+1 To {skill}", SkillEnumeration.Teleport),
                new("+750-775 Defense (Varies)", null),
                new("+(0.75*Clvl) To Strength (Based On Character Level)", null),
                new("Increase Maximum Life 5%", null),
                new("Damage Reduced By 8%", null),
                new("+14 Life After Each Kill", null),
                new("15% Damage Taken Goes To Mana", null),
                new("(1*Clvl)% Better Chance of Getting Magic Items (Based On Character Level)", null),
            }, "https://diablo2.wiki.fextralife.com/Enigma");

        public static RuneWordEnumeration Enlightenment => new(20, "Enlightenment", 45, new List<RuneEnumeration> { RuneEnumeration.Pul, RuneEnumeration.Ral, RuneEnumeration.Sol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("5% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Blaze),
                new("5% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Fireball),
                new("+2 To Sorceress Skill Levels", null),
                new("+1 To Warmth", null),
                new("+30% Enhanced Defense", null),
                new("Fire Resist +30%", null),
                new("Damage Reduced By 7", null),
            }, "https://diablo2.wiki.fextralife.com/Enlightenment");

        public static RuneWordEnumeration Eternity => new(21, "Eternity", 63, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Ber, RuneEnumeration.Ist, RuneEnumeration.Sol, RuneEnumeration.Sur },
            _meleeWeapons,
            new List<Statistic>
            {
                new("Indestructible", null),
                new("+260-310% Enhanced Damage (varies)", null),
                new("+9 To Minimum Damage", null),
                new("7% Life Stolen Per Hit", null),
                new("20% Chance of Crushing Blow", null),
                new("Hit Blinds Target", null),
                new("Slows Target By 33%", null),
                new("Replenish Mana 16%", null),
                new("Cannot Be Frozen", null),
                new("30% Better Chance Of Getting Magic Items", null),
                new("Level 8 {skill} (88 Charges)", SkillEnumeration.Revive),
            }, "https://diablo2.wiki.fextralife.com/Eternity");

        public static RuneWordEnumeration Exile => new(22, "Exile", 57, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Ohm, RuneEnumeration.Ist, RuneEnumeration.Dol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.PaladinShield },
            new List<Statistic>
            {
                new("15% Chance To Cast Level 5 {skill} On Striking", SkillEnumeration.LifeTap),
                new("Level 13-16 {skill} Aura When Equipped (varies)", SkillEnumeration.Defiance),
                new("+2 To Offensive Auras (Paladin Only)", null),
                new("+30% Faster Block Rate", null),
                new("Freezes Target", null),
                new("+220-260% Enhanced Defense (varies)", null),
                new("Replenish Life +7", null),
                new("+5% To Maximum Cold Resist", null),
                new("+5% To Maximum Fire Resist", null),
                new("25% Better Chance Of Getting Magic Items", null),
                new("Repairs 1 Durability every 4 seconds", null)
            }, "https://diablo2.wiki.fextralife.com/Exile");

        public static RuneWordEnumeration Faith => new(23, "Faith", 65, new List<RuneEnumeration> { RuneEnumeration.Ohm, RuneEnumeration.Jah, RuneEnumeration.Lem, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new("Level 12-15 {skill} Aura When Equipped (varies)", SkillEnumeration.Fanaticism),
                new("+1-2 To All Skills (varies)", null),
                new("+330% Enhanced Damage", null),
                new("Ignore Target's Defense", null),
                new("300% Bonus To Attack Rating", null),
                new("+75% Damage To Undead", null),
                new("+50 To Attack Rating Against Undead", null),
                new("+120 Fire Damage", null),
                new("All Resistances +15", null),
                new("10% Reanimate As: Returned", null),
                new("75% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Faith");

        public static RuneWordEnumeration Famine => new(24, "Famine", 65, new List<RuneEnumeration> { RuneEnumeration.Fal, RuneEnumeration.Ohm, RuneEnumeration.Ort, RuneEnumeration.Jah },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Hammer },
            new List<Statistic>
            {
                new("+30% Increased Attack Speed", null),
                new("+320-370% Enhanced Damage (varies)", null),
                new("Ignore Target's Defense", null),
                new("Adds 180-200 Magic Damage", null),
                new("Adds 50-200 Fire Damage", null),
                new("Adds 51-250 Lightning Damage", null),
                new("Adds 50-200 Cold Damage", null),
                new("12% Life Stolen Per Hit", null),
                new("Prevent Monster Heal", null),
                new("+10 To Strength", null)
            }, "https://diablo2.wiki.fextralife.com/Famine");

        public static RuneWordEnumeration Fortitude => new(25, "Fortitude", 59, new List<RuneEnumeration> { RuneEnumeration.El, RuneEnumeration.Sol, RuneEnumeration.Dol, RuneEnumeration.Lo },
            _rangedWeapons.Concat(_meleeWeapons).Concat(new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor }),
            new List<Statistic>
            {
                new("20% Chance To Cast Level 15 {skill} when Struck", SkillEnumeration.ChillingArmor),
                new("+25% Faster Cast Rate", null),
                new("+300% Enhanced Damage", null),
                new("+200% Enhanced Defense", null),
                new("+(8*0.125*Clvl)-(12*0.125*Clvl) To Life (Based on Character Level) (varies)", null),
                new("All Resistances +25-30 (varies)", null),
                new("12% Damage Taken Goes To Mana", null),
                new("+1 To Light Radius", null),
                new("+9 To Minimum Damage (Weapons)", null),
                new("+50 To Attack Rating (Weapons)", null),
                new("20% Deadly Strike (Weapons)", null),
                new("Hit Causes Monster To Flee 25% (Weapons)", null),
                new("+15 Defense (Armor)", null),
                new("Replenish Life +7 (Armor)", null),
                new("+5% To Maximum Lightning Resist (Armor)", null),
                new("Damage Reduced By 7 (Armor)", null)
            }, "https://diablo2.wiki.fextralife.com/Fortitude");

        public static RuneWordEnumeration Fury => new(26, "Fury", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Gul, RuneEnumeration.Eth },
            _meleeWeapons,
            new List<Statistic>
            {
                new("40% Increased Attack Speed", null),
                new("+209% Enhanced Damage", null),
                new("Ignores Target Defense", null),
                new("-25% Target Defense", null),
                new("20% Bonus to Attack Rating", null),
                new("6% Life Stolen Per Hit", null),
                new("33% Chance Of Deadly Strike", null),
                new("66% Chance Of Open Wounds", null),
                new("+5 To {skill} (Barbarian Only)", SkillEnumeration.Frenzy),
                new("Prevent Monster Heal", null)
            }, "https://diablo2.wiki.fextralife.com/Fury");

        public static RuneWordEnumeration Gloom => new(27, "Gloom", 47, new List<RuneEnumeration> { RuneEnumeration.Fal, RuneEnumeration.Um, RuneEnumeration.Pul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("15% Chance To Cast Level 3 {skill} When Struck", SkillEnumeration.DimVision),
                new("+10% Faster Hit Recovery", null),
                new("+200-260% Enhanced Defense (varies)", null),
                new("+10 To Strength", null),
                new("All Resistances +45", null),
                new("Half Freeze Duration", null),
                new("5% Damage Taken Goes To Mana", null),
                new("-3 To Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Gloom");

        public static RuneWordEnumeration Grief => new(28, "Grief", 59, new List<RuneEnumeration> { RuneEnumeration.Eth, RuneEnumeration.Tir, RuneEnumeration.Lo, RuneEnumeration.Mal, RuneEnumeration.Ral },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe },
            new List<Statistic>
            {
                new("35% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Venom),
                new("+30-40% Increased Attack Speed (varies)", null),
                new("Damage +340-400 (varies)", null),
                new("Ignore Target's Defense", null),
                new("-25% Target Defense", null),
                new("+(1.875*Clvl)% Damage To Demons (Based on Character Level)", null),
                new("Adds 5-30 Fire Damage", null),
                new("-20-25% To Enemy Poison Resistance (varies)", null),
                new("20% Deadly Strike", null),
                new("Prevent Monster Heal", null),
                new("+2 To Mana After Each Kill", null),
                new("+10-15 Life After Each Kill (varies)", null)
            }, "https://diablo2.wiki.fextralife.com/Grief");

        public static RuneWordEnumeration HandOfJustice => new(29, "Hand of Justice", 67, new List<RuneEnumeration> { RuneEnumeration.Sur, RuneEnumeration.Cham, RuneEnumeration.Lo, RuneEnumeration.Amn, RuneEnumeration.Lo },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new("100% Chance To Cast Level 36 {skill} When You Level-Up", SkillEnumeration.Blaze),
                new("100% Chance To Cast Level 48 {skill} When You Die", SkillEnumeration.Meteor),
                new("Level 16 {skill} Aura When Equipped", SkillEnumeration.HolyFire),
                new("+33% Increased Attack Speed", null),
                new("+280-330% Enhanced Damage (varies)", null),
                new("Ignore Target's Defense", null),
                new("-20% To Enemy Fire Resistance", null),
                new("7% Life Stolen Per Hit", null),
                new("20% Deadly Strike", null),
                new("Hit Blinds Target", null),
                new("Freezes Target +3", null)
            }, "https://diablo2.wiki.fextralife.com/Hand+of+Justice");

        public static RuneWordEnumeration Harmony => new(30, "Harmony", 39, new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.Ith, RuneEnumeration.Sol, RuneEnumeration.Ko },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new("Level 10 {skill} Aura When Equipped", SkillEnumeration.Vigor),
                new("+200-275% Enhanced Damage (varies)", null),
                new("+9 To Minimum Damage", null),
                new("+9 To Maximum Damage", null),
                new("Adds 55-160 Fire Damage", null),
                new("Adds 55-160 Lightning Damage", null),
                new("Adds 55-160 Cold Damage", null),
                new("+2-6 To {skill} (varies)", SkillEnumeration.Valkyrie),
                new("+10 To Dexterity", null),
                new("Regenerate Mana 20%", null),
                new("+2 To Mana After Each Kill", null),
                new("+2 To Light Radius", null),
                new("Level 20 {skill} (25 Charges)", SkillEnumeration.Revive)
            }, "https://diablo2.wiki.fextralife.com/Harmony");

        public static RuneWordEnumeration HeartOfTheOak => new(31, "Heart of the Oak", 55, new List<RuneEnumeration> { RuneEnumeration.Ko, RuneEnumeration.Vex, RuneEnumeration.Pul, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave, ItemTypeEnumeration.Mace },
            new List<Statistic>
            {
                new("+3 To All Skills", null),
                new("+40% Faster Cast Rate", null),
                new("+75% Damage To Demons", null),
                new("+100 To Attack Rating Against Demons", null),
                new("Adds 3-14 Cold Damage", null),
                new("7% Mana Stolen Per Hit", null),
                new("+10 To Dexterity", null),
                new("Replenish Life +20", null),
                new("Increase Maximum Mana 15%", null),
                new("All Resistances +30-40 (varies)", null),
                new("Level 4 {skill} (25 Charges)", SkillEnumeration.OakSage),
                new("Level 14 {skill} (60 Charges)", SkillEnumeration.Raven)
            }, "https://diablo2.wiki.fextralife.com/Heart+of+the+Oak");

        public static RuneWordEnumeration HolyThunder => new(32, "Holy Thunder", 23, new List<RuneEnumeration> { RuneEnumeration.Eth, RuneEnumeration.Ral, RuneEnumeration.Ort, RuneEnumeration.Tal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Scepter },
            new List<Statistic>
            {
                new("+60% Enhanced Damage", null),
                new("+10 to Maximum Damage", null),
                new("-25% Target Defense", null),
                new("Adds 5-30 Fire Damage", null),
                new("Adds 21-110 Lightning Damage", null),
                new("+75 Poison Damage over 5 secs", null),
                new("+3 to {skill} (Paladin Only)", SkillEnumeration.HolyShock),
                new("+5% to Maximum Lightning Resist", null),
                new("Lightning Resist +60%", null),
                new("Level 7 {skill} (60 charges)", SkillEnumeration.ChainLightning)
            }, "https://diablo2.wiki.fextralife.com/Holy+Thunder");

        public static RuneWordEnumeration Honor => new(33, "Honor", 27, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.El, RuneEnumeration.Ith, RuneEnumeration.Tir, RuneEnumeration.Sol },
            _meleeWeapons,
            new List<Statistic>
            {
                new("+1 to all skills", null),
                new("+160% Enhanced Damage", null),
                new("+9 to Minimum Damage", null),
                new("+9 to Maximum Damage", null),
                new("+250 Attack Rating", null),
                new("7% Life Stolen per Hit", null),
                new("25% Deadly Strike", null),
                new("+10 to Strength", null),
                new("Replenish life +10", null),
                new("+2 to Mana after each Kill", null),
                new("+1 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Honor");

        public static RuneWordEnumeration Ice => new(34, "Ice", 65, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Shael, RuneEnumeration.Jah, RuneEnumeration.Tir, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new("100% Chance To Cast Level 40 {skill} When You Level-up", SkillEnumeration.Blizzard),
                new("25% Chance To Cast Level 22 {skill} On Striking", SkillEnumeration.FrostNova),
                new("Level 18 {skill} Aura When Equipped", SkillEnumeration.HolyFreeze),
                new("+20% Increased Attack Speed", null),
                new("+140-210% Enhanced Damage (varies)", null),
                new("Ignore Target's Defense", null),
                new("+25-30% To Cold Skill Damage (varies)", null),
                new("7% Life Stolen Per Hit", null),
                new("-20% To Enemy Cold Resistance", null),
                new("20% Deadly Strike", null),
                new("(3.125*Clvl)% Extra Gold From Monsters (Based on Character Level)", null)
            }, "https://diablo2.wiki.fextralife.com/Ice");

        public static RuneWordEnumeration Infinity => new(35, "Infinity", 63, new List<RuneEnumeration> { RuneEnumeration.Ber, RuneEnumeration.Mal, RuneEnumeration.Ber, RuneEnumeration.Ist, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new("Level 12-17 {skill} Aura When Equipped (varies)", SkillEnumeration.Meditation),
                new("+35% Faster Cast Rate", null),
                new("+200-260% Enhanced Damage (varies)", null),
                new("+9 To Minimum Damage", null),
                new("180-250% Bonus to Attack Rating (varies)", null),
                new("Adds 5-30 Fire Damage", null),
                new("+75 Poison Damage Over 5 Seconds", null),
                new("+1-6 To Critical Strike (varies)", null),
                new("+5 To All Attributes", null),
                new("+2 To Mana After Each Kill", null),
                new("23% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Infinity");

        public static RuneWordEnumeration Insight => new(36, "Insight", 63, new List<RuneEnumeration> { RuneEnumeration.Ral, RuneEnumeration.Tir, RuneEnumeration.Tal, RuneEnumeration.Sol, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Stave },
            new List<Statistic>
            {
                new("50% Chance To Cast Level 20 {skill} When You Kill An Enemy", SkillEnumeration.ChainLightning),
                new("Level 12 {skill} Aura When Equipped", SkillEnumeration.Conviction),
                new("+35% Faster Run/Walk", null),
                new("+255-325% Enhanced Damage (varies)", null),
                new("-(45-55)% To Enemy Lightning Resistance (varies)", null),
                new("40% Chance of Crushing Blow", null),
                new("Prevent Monster Heal", null),
                new("+(0.5*Clvl) To Vitality (Based on Character Level)", null),
                new("30% Better Chance of Getting Magic Items", null),
                new("Level 21 {skill} (30 Charges)", SkillEnumeration.CycloneArmor)
            }, "https://diablo2.wiki.fextralife.com/Infinity");

        public static RuneWordEnumeration KingsGrace => new(37, "King's Grace", 25, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Ral, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Scepter },
            new List<Statistic>
            {
                new("+100% Enhanced Damage", null),
                new("+150 to Attack Rating", null),
                new("+100% Damage to Demons", null),
                new("+100 to Attack Rating against Demons", null),
                new("+50% Damage to Undead", null),
                new("+100 to Attack Rating against Undead", null),
                new("Adds 5-30 Fire Damage", null),
                new("Adds 3-14 Cold damage", null),
                new("7% Life stolen per hit", null)
            }, "https://diablo2.wiki.fextralife.com/King%27s+Grace");

        public static RuneWordEnumeration Kingslayer => new(38, "Kingslayer", 53, new List<RuneEnumeration> { RuneEnumeration.Mal, RuneEnumeration.Um, RuneEnumeration.Gul, RuneEnumeration.Fal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe },
            new List<Statistic>
            {
                new("+30% Increased Attack Speed", null),
                new("+230-270% Enhanced Damage (varies)", null),
                new("-25% Target Defense", null),
                new("20% Bonus To Attack Rating", null),
                new("33% Chance of Crushing Blow", null),
                new("50% Chance of Open Wounds", null),
                new("+1 To {skill}", SkillEnumeration.Vengeance),
                new("Prevent Monster Heal", null),
                new("+10 To Strength", null),
                new("40% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Kingslayer");

        public static RuneWordEnumeration LastWish => new(39, "Last Wish", 65, new List<RuneEnumeration> { RuneEnumeration.Jah, RuneEnumeration.Mal, RuneEnumeration.Jah, RuneEnumeration.Sur, RuneEnumeration.Jah, RuneEnumeration.Ber },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe, ItemTypeEnumeration.Hammer },
            new List<Statistic>
            {
                new("6% Chance To Cast Level 11 {skill} When Struck", SkillEnumeration.Fade),
                new("10% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.LifeTap),
                new("20% Chance To Cast Level 20 {skill} On Attack", SkillEnumeration.ChargedBolt),
                new("Level 17 {skill} Aura When Equipped", SkillEnumeration.Might),
                new("+330-375% Enhanced Damage (varies)", null),
                new("Ignore Target's Defense", null),
                new("60-70% Chance of Crushing Blow (varies)", null),
                new("Prevent Monster Heal", null),
                new("Hit Blinds Target", null),
                new("(0.5*Clvl)% Chance of Getting Magic Items (Based on Character Level)", null)
            }, "https://diablo2.wiki.fextralife.com/Last+Wish");

        public static RuneWordEnumeration Lawbringer => new(40, "Lawbringer", 43, new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Lem, RuneEnumeration.Ko },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Scepter, ItemTypeEnumeration.Hammer },
            new List<Statistic>
            {
                new("20% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Decrepify),
                new("Level 16-18 {skill} Aura When Equipped (varies)", SkillEnumeration.Sanctuary),
                new("-50% Target Defense", null),
                new("Adds 150-210 Fire Damage", null),
                new("Adds 130-180 Cold Damage", null),
                new("7% Life Stolen Per Hit", null),
                new("Slain Monsters Rest In Peace", null),
                new("+200-250 Defense Vs. Missile (varies)", null),
                new("+10 To Dexterity", null),
                new("75% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Lawbringer");

        public static RuneWordEnumeration Leaf => new(41, "Leaf", 19, new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.Ral },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave },
            new List<Statistic>
            {
                new("+3 to Fire Skills", null),
                new("Adds 5-30 Fire Damage", null),
                new("+3 to {skill} (Sorceress Only)", SkillEnumeration.Inferno),
                new("+3 to {skill} (Sorceress Only)", SkillEnumeration.Warmth),
                new("+3 to {skill} (Sorceress Only)", SkillEnumeration.Fireball),
                new("+(2*Clvl) Defence (Based on Character Level)", null),
                new("Cold Resist +33%", null),
                new("+2 to Mana after each Kill", null)
            }, "https://diablo2.wiki.fextralife.com/Leaf");

        public static RuneWordEnumeration Lionheart => new(42, "Lionheart", 41, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Lum, RuneEnumeration.Fal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("+20% Enhanced Damage", null),
                new("+25 To Strength", null),
                new("+15 To Dexterity", null),
                new("+20 To Vitality", null),
                new("+10 To Energy", null),
                new("+50 To Life", null),
                new("All Resistances +30", null),
                new("Requirements -15%", null)
            }, "https://diablo2.wiki.fextralife.com/Lionheart");

        public static RuneWordEnumeration Lore => new(43, "Lore", 27, new List<RuneEnumeration> { RuneEnumeration.Ort, RuneEnumeration.Sol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new("+1 to All Skills", null),
                new("+10 to Energy", null),
                new("Lightning Resist +30%", null),
                new("Damage Reduced by 7", null),
                new("+2 to Mana after each Kill", null),
                new("+2 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Lore");

        public static RuneWordEnumeration Malice => new(44, "Malice", 15, new List<RuneEnumeration> { RuneEnumeration.Ith, RuneEnumeration.El, RuneEnumeration.Eth },
            _meleeWeapons,
            new List<Statistic>
            {
                new("+33% Enhanced Damage", null),
                new("+9 to Maximum Damage", null),
                new("-25% Target Defense", null),
                new("+50 to Attack Rating", null),
                new("100% Chance of Open wounds", null),
                new("Prevent Monster Heal", null),
                new("-100 to Monster Defense Per Hit", null),
                new("Drain Life -5", null)
            }, "https://diablo2.wiki.fextralife.com/Malice");

        public static RuneWordEnumeration Melody => new(45, "Melody", 39, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Ko, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
            new List<Statistic>
            {
                new("+3 To Bow and Crossbow Skills (Amazon Only)", null),
                new("+20% Increased Attack Speed", null),
                new("+50% Enhanced Damage", null),
                new("+300% Damage To Undead", null),
                new("+3 To {skill} (Amazon Only)", SkillEnumeration.SlowMissiles),
                new("+3 To {skill} (Amazon Only)", SkillEnumeration.Dodge),
                new("+3 To {skill} (Amazon Only)", SkillEnumeration.CriticalStrike),
                new("Knockback", null),
                new("+10 To Dexterity", null)
            }, "https://diablo2.wiki.fextralife.com/Melody");

        public static RuneWordEnumeration Memory => new(46, "Memory", 37, new List<RuneEnumeration> { RuneEnumeration.Lum, RuneEnumeration.Io, RuneEnumeration.Sol, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave },
            new List<Statistic>
            {
                new("+3 To Sorceress Skill Levels", null),
                new("+33% Faster Cast Rate", null),
                new("+9 To Minimum Damage", null),
                new("-25% Target Defence", null),
                new("+3 To {skill} (Sorceress Only)", SkillEnumeration.EnergyShield),
                new("+2 To {skill} (Sorceress Only)", SkillEnumeration.StaticField),
                new("+50% Enhanced Defense", null),
                new("+10 Vitality", null),
                new("+10 Energy", null),
                new("Increase Maximum Mana 20%", null),
                new("Magic Damage Reduced By 7", null)
            }, "https://diablo2.wiki.fextralife.com/Memory");

        public static RuneWordEnumeration Myth => new(47, "Myth", 25, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Amn, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("3% Chance To Cast Level 1 {skill} When Struck", SkillEnumeration.Howl),
                new("10% Chance To Cast Level 1 {skill} On Striking", SkillEnumeration.Taunt),
                new("+2 To Barbarian Skill Levels", null),
                new("+30 Defense Vs. Missile", null),
                new("Replenish Life +10", null),
                new("Attacker Takes Damage of 14", null),
                new("Requirements -15%", null)
            }, "https://diablo2.wiki.fextralife.com/Myth");

        public static RuneWordEnumeration Nadir => new(48, "Nadir", 13, new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new("+50% Enhanced Defense", null),
                new("+10 Defense", null),
                new("+30 Defense vs. Missile", null),
                new("+5 to Strength", null),
                new("+2 to Mana after each Kill", null),
                new("-33% Extra Gold from Monsters", null),
                new("-3 to Light Radius", null),
                new("Level 13 {skill} (9 charges)", SkillEnumeration.CloackOfShadows)
            }, "https://diablo2.wiki.fextralife.com/Nadir");

        public static RuneWordEnumeration Oath => new(49, "Oath", 59, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Pul, RuneEnumeration.Mal, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Axe, ItemTypeEnumeration.Mace, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new("Indestructible", null),
                new("30% Chance To Cast Level 20 {skill} On Striking", SkillEnumeration.BoneSpirit),
                new("+50% Increased Attack Speed", null),
                new("+210-340% Enhanced Damage (varies)", null),
                new("+75% Damage To Demons", null),
                new("+100 To Attack Rating Against Demons", null),
                new("Prevent Monster Heal", null),
                new("+10 To Energy", null),
                new("+10-15 Magic Absorb (varies)", null),
                new("Level 16 {skill} (20 Charges)", SkillEnumeration.HeartOfWolverine),
                new("Level 17 {skill} (14 Charges)", SkillEnumeration.IronGolem)
            }, "https://diablo2.wiki.fextralife.com/Oath");

        public static RuneWordEnumeration Obedience => new(50, "Obedience", 41, new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Ko, RuneEnumeration.Thul, RuneEnumeration.Eth, RuneEnumeration.Fal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new("30% Chance To Cast Level 21 {skill} When You Kill An Enemy", SkillEnumeration.Enchant),
                new("+40% Faster Hit Recovery", null),
                new("+370% Enhanced Damage", null),
                new("-25% Target Defense", null),
                new("Adds 3-14 Cold Damage (3 Seconds Duration,Normal)", null),
                new("-25% To Enemy Fire Resistance", null),
                new("40% Chance of Crushing Blow", null),
                new("+200-300 Defense (varies)", null),
                new("+10 To Strength", null),
                new("+10 To Dexterity", null),
                new("All Resistances +20-30 (varies)", null),
                new("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Obedience");

        public static RuneWordEnumeration Passion => new(51, "Passion", 43, new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Ort, RuneEnumeration.Eld, RuneEnumeration.Lem },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new("+25% Increased Attack Speed", null),
                new("+160-210% Enhanced Damage (varies)", null),
                new("50-80% Bonus To Attack Rating (varies)", null),
                new("+75% Damage To Undead", null),
                new("+50 To Attack Rating Against Undead", null),
                new("Adds 1-50 Lightning Damage", null),
                new("+1 To {skill}", SkillEnumeration.Berserk),
                new("+1 To {skill}", SkillEnumeration.Zeal),
                new("Hit Blinds Target +10", null),
                new("Hit Causes Monster To Flee 25%", null),
                new("75% Extra Gold From Monsters", null),
                new("Level 3 {skill} (12 Charges)", SkillEnumeration.HeartOfWolverine)
            }, "https://diablo2.wiki.fextralife.com/Passion");

        public static RuneWordEnumeration Peace => new(52, "Peace", 29, new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Thul, RuneEnumeration.Amn },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("4% Chance To Cast Level 5 {skill} When Struck", SkillEnumeration.SlowMissiles),
                new("2% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Valkyrie),
                new("+2 To Amazon Skill Levels", null),
                new("+20% Faster Hit Recovery", null),
                new("+2 To Critical Strike", null),
                new("Cold Resist +30%", null),
                new("Attacker Takes Damage of 14", null)
            }, "https://diablo2.wiki.fextralife.com/Peace");

        public static RuneWordEnumeration Phoenix => new(53, "Phoenix", 65, new List<RuneEnumeration> { RuneEnumeration.Vex, RuneEnumeration.Vex, RuneEnumeration.Lo, RuneEnumeration.Jah },
            _rangedWeapons.Concat(_meleeWeapons).Concat(new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.PaladinShield }),
            new List<Statistic>
            {
                new("100% Chance To Cast level 40 {skill} When You Level-up", SkillEnumeration.Blaze),
                new("40% Chance To Cast Level 22 {skill} On Striking", SkillEnumeration.Firestorm),
                new("Level 10-15 {skill} Aura When Equipped (varies)", SkillEnumeration.Redemption),
                new("+350-400% Enhanced Damage (varies)", null),
                new("-28% To Enemy Fire Resistance", null),
                new("+350-400 Defense Vs. Missile (varies)", null),
                new("+15-21 Fire Absorb (varies)", null),
                new("Ignores Target's Defense (Weapons)", null),
                new("14% Mana Stolen Per Hit (Weapons)", null),
                new("20% Deadly Strike (Weapons)", null),
                new("+50 To Life (Shields)", null),
                new("+5% To Maximum Lightning Resist (Shields)", null),
                new("+10% To Maximum Fire Resist (Shields)", null)
            }, "https://diablo2.wiki.fextralife.com/Phoenix");

        public static RuneWordEnumeration Pride => new(54, "Pride", 67, new List<RuneEnumeration> { RuneEnumeration.Cham, RuneEnumeration.Sur, RuneEnumeration.Io, RuneEnumeration.Lo },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm },
            new List<Statistic>
            {
                new("25% Chance To Cast Level 17 {skill} When Struck", SkillEnumeration.FireWall),
                new("Level 16-20 {skill} Aura When Equipped (varies)", SkillEnumeration.Concentration),
                new("260-300% Bonus To Attack Rating (varies)", null),
                new("+(1*Clvl)% Damage To Demons (Based on Character Level)", null),
                new("Adds 50-280 Lightning Damage", null),
                new("20% Deadly Strike", null),
                new("Hit Blinds Target", null),
                new("Freezes Target +3", null),
                new("+10 To Vitality", null),
                new("Replenish Life +8", null),
                new("(1.875*Clvl)% Extra Gold From Monsters (Based on Character Level)", null)
            }, "https://diablo2.wiki.fextralife.com/Pride");

        public static RuneWordEnumeration Principle => new(55, "Principle", 55, runes: new List<RuneEnumeration> { RuneEnumeration.Ral, RuneEnumeration.Gul, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("100% Chance To Cast Level 5 {skill} On Striking", SkillEnumeration.HolyBolt),
                new("+2 To Paladin Skill Levels", null),
                new("+50% Damage to Undead", null),
                new("+100-150 to Life (varies)", null),
                new("15% Slower Stamina Drain", null),
                new("+5% To Maximum Poison Resist", null),
                new("Fire Resist +30%", null)
            }, "https://diablo2.wiki.fextralife.com/Principle");

        public static RuneWordEnumeration Prudence => new(56, "Prudence", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Mal, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("+25% Faster Hit Recovery", null),
                new("+140-170% Enhanced Defense (varies)", null),
                new("All Resistances +25-35 (varies)", null),
                new("Damage Reduced by 3", null),
                new("Magic Damage Reduced by 17", null),
                new("+2 To Mana After Each Kill", null),
                new("+1 To Light Radius", null),
                new("Repairs Durability 1 In 4 Seconds", null)
            }, "https://diablo2.wiki.fextralife.com/Prudence");

        public static RuneWordEnumeration Radiance => new(57, "Radiance", 27, runes: new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Sol, RuneEnumeration.Ith },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
            new List<Statistic>
            {
                new("+75% Enhanced Defense", null),
                new("+30 Defense vs. Missiles", null),
                new("+10 to Vitality", null),
                new("+10 to Energy", null),
                new("+33 to Mana", null),
                new("Damage Reduced by 7", null),
                new("Magic Damage Reduced by 3", null),
                new("15% Damage Taken Goes to Mana", null),
                new("+5 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Radiance");

        public static RuneWordEnumeration Rain => new(58, "Rain", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Ort, RuneEnumeration.Mal, RuneEnumeration.Ith },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("5% Chance To Cast Level 15 {skill} Armor When Struck", SkillEnumeration.CycloneArmor),
                new("5% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Twister),
                new("+2 To Druid Skills", null),
                new("+100-150 To Mana (varies)", null),
                new("Lightning Resist +30%", null),
                new("Magic Damage Reduced By 7", null),
                new("15% Damage Taken Goes to Mana", null)
            }, "https://diablo2.wiki.fextralife.com/Rain");

        public static RuneWordEnumeration Rhyme => new(59, "Rhyme", 29, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.PaladinShield },
            new List<Statistic>
            {
                new("+40% Faster Block Rate", null),
                new("20% Increased Chance of Blocking", null),
                new("Regenerate Mana 15%", null),
                new("All Resistances +25", null),
                new("Cannot be Frozen", null),
                new("50% Extra Gold from Monsters", null),
                new("25% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Rhyme");

        public static RuneWordEnumeration Rift => new(60, "Rift", 53, runes: new List<RuneEnumeration> { RuneEnumeration.Hel, RuneEnumeration.Ko, RuneEnumeration.Lem, RuneEnumeration.Gul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Polearm, ItemTypeEnumeration.Scepter },
            new List<Statistic>
            {
                new("20% Chance To Cast Level 16 {skill} On Striking", SkillEnumeration.Tornado),
                new("16% Chance To Cast Level 21 {skill} On Attack", SkillEnumeration.FrozenOrb),
                new("20% Bonus To Attack Rating", null),
                new("Adds 160-250 Magic Damage", null),
                new("Adds 60-180 Fire Damage", null),
                new("+5-10 To All Attributes (varies)", null),
                new("+10 To Dexterity", null),
                new("38% Damage Taken Goes To Mana", null),
                new("75% Extra Gold From Monsters", null),
                new("Level 15 {skill} (40 Charges)", SkillEnumeration.IronMaiden),
                new("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Rift");

        public static RuneWordEnumeration Sanctuary => new(61, "Sanctuary", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Ko, RuneEnumeration.Ko, RuneEnumeration.Mal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.PaladinShield, ItemTypeEnumeration.Shield },
            new List<Statistic>
            {
                new("+20% Faster Hit Recovery", null),
                new("+20% Faster Block Rate", null),
                new("20% Increased Chance of Blocking", null),
                new("+130-160% Enhanced Defense (varies)", null),
                new("+250 Defense vs. Missile", null),
                new("+20 To Dexterity", null),
                new("All Resistances +50-70 (varies)", null),
                new("Magic Damage Reduced By 7", null),
                new("Level 12 {skill} (60 Charges)", SkillEnumeration.SlowMissiles)
            }, "https://diablo2.wiki.fextralife.com/Sanctuary");

        public static RuneWordEnumeration Silence => new(62, "Silence", 55, runes: new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Eld, RuneEnumeration.Hel, RuneEnumeration.Ist, RuneEnumeration.Tir, RuneEnumeration.Vex },
            _rangedWeapons.Concat(_meleeWeapons),
            new List<Statistic>
            {
                new("+2 to All Skills", null),
                new("+20% Increased Attack Speed", null),
                new("+20% Faster Hit Recovery", null),
                new("+200% Enhanced Damage", null),
                new("+75% Damage To Undead", null),
                new("+50 to Attack Rating Against Undead", null),
                new("11% Mana Stolen Per Hit", null),
                new("Hit Blinds Target +33", null),
                new("Hit Causes Monster to Flee 25%", null),
                new("All Resistances +75", null),
                new("+2 to Mana After Each Kill", null),
                new("30% Better Chance of Getting Magic Items", null),
                new("Requirements -20%", null)
            }, "https://diablo2.wiki.fextralife.com/Silence");

        public static RuneWordEnumeration Smoke => new(63, "Smoke", 37, runes: new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("+20% Faster Hit Recovery", null),
                new("+75% Enhanced Defense", null),
                new("+280 Defense vs. Missiles", null),
                new("+10 to Energy", null),
                new("All Resistances +50", null),
                new("-1 to Light Radius", null),
                new("Level 6 {skill} (18 charges)", SkillEnumeration.Weaken)
            }, "https://diablo2.wiki.fextralife.com/Smoke");

        public static RuneWordEnumeration Spirit => new(64, "Spirit", 25, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Thul, RuneEnumeration.Ort, RuneEnumeration.Amn },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.Sword },
            new List<Statistic>
            {
                new("+2 To All Skills", null),
                new("+25-35% Faster Cast Rate (varies)", null),
                new("+55% Faster Hit Recovery", null),
                new("+250 Defense Vs. Missile", null),
                new("+22 To Vitality", null),
                new("+89-112 To Mana (varies)", null),
                new("+3-8 Magic Absorb (varies)", null),
                new("Cold Resist +35% (Shields)", null),
                new("Lightning Resist +35% (Shields)", null),
                new("Poison Resist +35% (Shields)", null),
                new("Attacker Takes Damage of 14 (Shields)", null),
                new("Adds 1-50 Lightning Damage (Swords)", null),
                new("Adds 3-14 Cold Damage (3 Sec,Normal) (Swords)", null),
                new("+75 Poison Damage Over 5 Seconds (Swords)", null),
                new("7% Life Stolen Per Hit (Swords)", null)
            }, "https://diablo2.wiki.fextralife.com/Spirit");

        public static RuneWordEnumeration Splendor => new(65, "Splendor", 37, runes: new List<RuneEnumeration> { RuneEnumeration.Eth, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Shield, ItemTypeEnumeration.PaladinShield },
            new List<Statistic>
            {
                new("+1 To All Skills", null),
                new("+10% Faster Cast Rate", null),
                new("+20% Faster Block Rate", null),
                new("+60-100% Enhanced Defense (varies)", null),
                new("+10 To Energy", null),
                new("Regenerate Mana 15%", null),
                new("50% Extra Gold From Monsters", null),
                new("20% Better Chance of Getting Magic Items", null),
                new("+3 To Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Splendor");

        public static RuneWordEnumeration Stealth => new(66, "Stealth", 17, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("+25% Faster Run/Walk", null),
                new("+25% Faster Casting Rate", null),
                new("+25% Faster Hit Recovery", null),
                new("+6 to Dexterity", null),
                new("Regenerate Mana 15%", null),
                new("+15 Maximum Stamina", null),
                new("Poison Resist +30%", null),
                new("Magic Damage Reduced by 3", null)
            }, "https://diablo2.wiki.fextralife.com/Stealth");

        public static RuneWordEnumeration Steel => new(67, "Steel", 13, runes: new List<RuneEnumeration> { RuneEnumeration.Tir, RuneEnumeration.El },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Axe, ItemTypeEnumeration.Mace },
            new List<Statistic>
            {
                new("+25% Increased Attack Speed", null),
                new("+20% Enhanced Damage", null),
                new("+3 to Minimum Damage", null),
                new("+3 to Maximum Damage", null),
                new("+50 to Attack Rating", null),
                new("50% Chance of Open Wounds", null),
                new("+2 to Mana after each Kill", null),
                new("+1 to Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Steel");

        public static RuneWordEnumeration Stone => new(68, "Stone", 47, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Um, RuneEnumeration.Pul, RuneEnumeration.Lum },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
            new List<Statistic>
            {
                new("+60% Faster Hit Recovery", null),
                new("+250-290% Enhanced Defense (varies)", null),
                new("+300 Defense Vs. Missile", null),
                new("+16 To Strength", null),
                new("+16 To Vitality", null),
                new("+10 To Energy", null),
                new("All Resistances +15", null),
                new("Level 16 {skill} (80 Charges)", SkillEnumeration.MoltenBoulder),
                new("Level 16 {skill} (16 Charges)", SkillEnumeration.ClayGolem)
            }, "https://diablo2.wiki.fextralife.com/Stone");

        public static RuneWordEnumeration Strength => new(69, "Strength", 25, runes: new List<RuneEnumeration> { RuneEnumeration.Amn, RuneEnumeration.Tir },
            _meleeWeapons,
            new List<Statistic>
            {
                new("+35% Enhanced Damage", null),
                new("7% Life stolen per hit", null),
                new("25% Chance of Crushing Blow", null),
                new("+20 to Strength", null),
                new("+10 to Vitality", null),
                new("+2 to Mana after each Kill", null)
            }, "https://diablo2.wiki.fextralife.com/Strength");

        public static RuneWordEnumeration Treachery => new(70, "Treachery", 43, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Thul, RuneEnumeration.Lem },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
           new List<Statistic>
            {
                new("5% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Fade),
                new("25% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Venom),
                new("+2 To Assassin Skills", null),
                new("+45% Increased Attack Speed", null),
                new("+20% Faster Hit Recovery", null),
                new("Cold Resist +30%", null),
                new("50% Extra Gold From Monsters", null)
            }, "https://diablo2.wiki.fextralife.com/Treachery");

        public static RuneWordEnumeration Venom => new(71, "Venom", 49, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Dol, RuneEnumeration.Mal },
            _rangedWeapons.Concat(_meleeWeapons),
           new List<Statistic>
            {
                new("Ignore Target's Defense", null),
                new("+273 Poison Damage Over 6 Seconds", null),
                new("7% Mana Stolen Per Hit", null),
                new("Prevent Monster Heal", null),
                new("Hit Causes Monster To Flee 25%", null),
                new("Level 13 {skill} (11 Charges)", SkillEnumeration.PoisonNova),
                new("Level 15 {skill} (27 Charges)", SkillEnumeration.PosionExplosion)
            }, "https://diablo2.wiki.fextralife.com/Venom");

        public static RuneWordEnumeration VoiceOfReason => new(72, "Voice of Reason", 43, runes: new List<RuneEnumeration> { RuneEnumeration.Lem, RuneEnumeration.Ko, RuneEnumeration.El, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Mace, ItemTypeEnumeration.Sword },
           new List<Statistic>
            {
                new("15% Chance To Cast Level 13 {skill} On Striking", SkillEnumeration.FrozenOrb),
                new("18% Chance To Cast Level 20 {skill} On Striking", SkillEnumeration.IceBlast),
                new("+50 To Attack Rating", null),
                new("+220-350% Damage To Demons (varies)", null),
                new("+355-375% Damage To Undead (varies)", null),
                new("+50 To Attack Rating Against Undead", null),
                new("Adds 100-220 Cold Damage", null),
                new("-24% To Enemy Cold Resistance", null),
                new("+10 To Dexterity", null),
                new("Cannot Be Frozen", null),
                new("75% Extra Gold From Monsters", null),
                new("+1 To Light Radius", null)
            }, "https://diablo2.wiki.fextralife.com/Voice+of+Reason");

        public static RuneWordEnumeration Wealth => new(73, "Wealth", 43, runes: new List<RuneEnumeration> { RuneEnumeration.Lem, RuneEnumeration.Ko, RuneEnumeration.Tir },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.BodyArmor },
           new List<Statistic>
            {
                new("+10 to Dexterity", null),
                new("+2 to Mana After Each Kill", null),
                new("300% Extra Gold From Monsters", null),
                new("100% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Wealth");

        public static RuneWordEnumeration White => new(74, "White", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Dol, RuneEnumeration.Io },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Wand },
           new List<Statistic>
            {
                new("+3 to Poison and Bone Skills (Necromancer Only)", null),
                new("+20% Faster Cast Rate", null),
                new("+2 to {skill} (Necromancer Only)", SkillEnumeration.BoneSpear),
                new("+4 to {skill} (Necromancer Only)", SkillEnumeration.SkeletonMastery),
                new("+3 to {skill} (Necromancer Only)", SkillEnumeration.BoneArmor),
                new("Hit causes monster to flee 25%", null),
                new("+10 to vitality", null),
                new("+13 to mana", null),
                new("Magic Damage Reduced by 4", null)
            }, "https://diablo2.wiki.fextralife.com/White");

        public static RuneWordEnumeration Wind => new(75, "Wind", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Sur, RuneEnumeration.El },
            _meleeWeapons,
           new List<Statistic>
            {
                new("10% Chance To Cast Level 9 {skill} On Striking", SkillEnumeration.Tornado),
                new("+20% Faster Run/Walk", null),
                new("+40% Increased Attack Speed", null),
                new("+15% Faster Hit Recovery", null),
                new("+120-160% Enhanced Damage (varies)", null),
                new("-50% Target Defense", null),
                new("+50 To Attack Rating", null),
                new("Hit Blinds Target", null),
                new("+1 To Light Radius", null),
                new("Level 13 {skill} (127 Charges)", SkillEnumeration.Twister)
            }, "https://diablo2.wiki.fextralife.com/Wind");

        public static RuneWordEnumeration Wrath => new(76, "Wrath", 63, runes: new List<RuneEnumeration> { RuneEnumeration.Pul, RuneEnumeration.Lum, RuneEnumeration.Ber, RuneEnumeration.Mal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
           new List<Statistic>
            {
                new("30% Chance To Cast Level 1 {skill} On Striking", SkillEnumeration.Decrepify),
                new("5% Chance To Cast Level 10 {skill} On Striking", SkillEnumeration.LifeTap),
                new("+375% Damage To Demons", null),
                new("+100 To Attack Rating Against Demons", null),
                new("+250-300% Damage To Undead (varies)", null),
                new("Adds 85-120 Magic Damage", null),
                new("Adds 41-240 Lightning Damage", null),
                new("20% Chance of Crushing Blow", null),
                new("Prevent Monster Heal", null),
                new("+10 To Energy", null),
                new("Cannot Be Frozen", null)
            }, "https://diablo2.wiki.fextralife.com/Wrath");

        public static RuneWordEnumeration Zephyr => new(77, "Zephyr", 21, runes: new List<RuneEnumeration> { RuneEnumeration.Ort, RuneEnumeration.Eth },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Bow, ItemTypeEnumeration.Crossbow },
           new List<Statistic>
            {
                new("7% Chance to Cast Level 1 {skill} When Struck", SkillEnumeration.Twister),
                new("+25% Faster Run/Walk", null),
                new("+25% Increased Attack Speed", null),
                new("+33% Enhanced Damage", null),
                new("-25% Target Defense", null),
                new("+66 to Attack Rating", null),
                new("Adds 1-50 lightning damage", null),
                new("+25 Defense", null)
            }, "https://diablo2.wiki.fextralife.com/Unbending+Will");

        public static RuneWordEnumeration Mist => new(79, "Mist", 67, runes: new List<RuneEnumeration> { RuneEnumeration.Cham, RuneEnumeration.Shael, RuneEnumeration.Gul, RuneEnumeration.Eld, RuneEnumeration.Thul, RuneEnumeration.Ith },
            _rangedWeapons,
           new List<Statistic>
            {
                new("Level 8-12 {skill} Aura When Equipped (varies)", SkillEnumeration.Concentration),
                new("+3 To All Skills", null),
                new("20% Increased Attack Speed", null),
                new("+100% Piercing Attack", null),
                new("+325-375% Enhanced Damage (varies)", null),
                new("+9 To Maximum Damage", null),
                new("20% Bonus to Attack Rating", null),
                new("Adds 3-14 Cold Damage", null),
                new("Freeze Target +3", null),
                new("+24 to Vitality", null),
                new("All Resistances +40", null)
            }, "https://diablo2.wiki.fextralife.com/Mist");

        public static RuneWordEnumeration Wisdom => new(80, "Wisdom", 45, runes: new List<RuneEnumeration> { RuneEnumeration.Pul, RuneEnumeration.Ith, RuneEnumeration.Eld },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("+33% Piercing Attack", null),
                new("+15-25% Bonus to Attack Rating (varies)", null),
                new("4-8% Mana Stolen Per Hit (varies)", null),
                new("+30% Enhanced Defense", null),
                new("+10 to Energy", null),
                new("15% Slower Stamina Drain", null),
                new("Cannot Be Frozen", null),
                new("+5 Mana After Each Kill", null),
                new("15% Damage Taken Goes to Mana", null)
            }, "https://diablo2.wiki.fextralife.com/Wisdom");

        public static RuneWordEnumeration Pattern => new(81, "Pattern", 23, runes: new List<RuneEnumeration> { RuneEnumeration.Tal, RuneEnumeration.Ort, RuneEnumeration.Thul },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Claw },
           new List<Statistic>
            {
                new("+30% Faster Block Rate", null),
                new("+40-80% Enhanced Damage (varies)", null),
                new("10% Bonus to Attack Rating", null),
                new("Adds 12-32 Fire Damage", null),
                new("Adds 1-50 Lightning Damage", null),
                new("Adds 3-14 Cold Damage", null),
                new("+75 Poison Damage Over 5 Seconds", null),
                new("+6 to Strength", null),
                new("+6 to Dexterity", null),
                new("All Resistances +15", null)
            }, "https://diablo2.wiki.fextralife.com/Pattern");

        public static RuneWordEnumeration Plague => new(82, "Plague", 67, runes: new List<RuneEnumeration> { RuneEnumeration.Cham, RuneEnumeration.Shael, RuneEnumeration.Um },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Sword, ItemTypeEnumeration.Claw, ItemTypeEnumeration.Dagger },
           new List<Statistic>
            {
                new("20% Chance to cast level 12 {skill} when struck", SkillEnumeration.LowerResist),
                new("25% Chance to cast level 15 {skill} on striking", SkillEnumeration.PoisonNova),
                new("Level 13-17 {skill} Aura When Equipped (varies)", SkillEnumeration.Cleansing),
                new("+1-2 All Skills", null),
                new("+20% Increased Attack Speed", null),
                new("+220-320% Enhanced Damage (varies)", null),
                new("-23% To Enemy Poison Resistance", null),
                new("+(0.375*Clvl) Deadly Strike (Based on Character Level)", null),
                new("+25% Chance of Open Wounds", null),
                new("Freezes Target +3", null)
            }, "https://diablo2.wiki.fextralife.com/Plague");

        public static RuneWordEnumeration Obsession => new(83, "Obsession", 69, runes: new List<RuneEnumeration> { RuneEnumeration.Zod, RuneEnumeration.Ist, RuneEnumeration.Lem, RuneEnumeration.Lum, RuneEnumeration.Io, RuneEnumeration.Nef },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Stave },
           new List<Statistic>
            {
                new("Indestructible", null),
                new("24% Chance to cast level 10 {skill} when struck", SkillEnumeration.Weaken),
                new("+4 To All Skills", null),
                new("+65% Faster Cast Rate", null),
                new("+60% Faster Hit Recovery", null),
                new("Knockback", null),
                new("+10 To Vitality", null),
                new("+10 To Energy", null),
                new("Increase Maximum Life 15-25% (varies)", null),
                new("Regenerate Mana 15-30% (varies)", null),
                new("All Resistances +60-70 (varies)", null),
                new("75% Extra Gold from Monsters", null),
                new("30% Better Chance of Getting Magic Items", null)
            }, "https://diablo2.wiki.fextralife.com/Obsession");

        public static RuneWordEnumeration FlickeringFlame => new(84, "Flickering Flame", 55, runes: new List<RuneEnumeration> { RuneEnumeration.Nef, RuneEnumeration.Pul, RuneEnumeration.Vex },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("Level 4-8 {skill} Aura When Equipped (varies)", SkillEnumeration.ResistFire),
                new("+3 To Fire Skills", null),
                new("-10-15% to Enemy Fire Resistance (varies)", null),
                new("+30% Enhanced Defense", null),
                new("+30 Defense Vs. Missile", null),
                new("+50-75 To Mana (varies)", null),
                new("Half Freeze Duration", null),
                new("+5% To Maximum Fire Resist", null),
                new("Poison Length Reduced by 50%", null)
            }, "https://diablo2.wiki.fextralife.com/Obsession");

        // NEW!!
        public static RuneWordEnumeration Mosaic => new(85, "Mosaic", 53, runes: new List<RuneEnumeration> { RuneEnumeration.Mal, RuneEnumeration.Gul, RuneEnumeration.Amn },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Claw },
           new List<Statistic>
            {
                new("+50% chance for finishing moves to not consume charges", null),
                new("When a finisher is executed this way, it now refreshes the expiration timer of the stack", null),
                new("+2 to Martial Arts (Assassin only)", null),
                new("+200-250% Enhanced Damage", null),
                new("+20% Bonus to Attack Rating", null),
                new("7% Life Steal", null),
                new("+8-15% to Cold Skill Damage", null),
                new("+8-15% to Lightning Skill Damage", null),
                new("+8-15% to Fire Skill Damage", null),
                new("Prevent Monster Heal", null)
            }, "https://diablo2.wiki.fextralife.com/Mosaic");

        public static RuneWordEnumeration Bulwark => new(86, "Bulwark", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Io, RuneEnumeration.Sol },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("+20% Faster Hit Recovery", null),
                new("+4-6% Life stolen per hit", null),
                new("+75-100% Enhanced Defense", null),
                new("+10 to Vitality", null),
                new("Increase Maximum Life 5%", null),
                new("Replenish Life +30", null),
                new("Damage Reduced by 7", null),
                new("Physical Damage Received Reduced by 10-15%", null)
            }, "https://diablo2.wiki.fextralife.com/Bulwark");

        public static RuneWordEnumeration Metamorphosis => new(87, "Metamorphosis", 67, runes: new List<RuneEnumeration> { RuneEnumeration.Io, RuneEnumeration.Cham, RuneEnumeration.Fal },
            new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("Werewolf strikes grant Mark for 180 seconds", null),
                new("Mark of the Wolf:", null),
                new("+30% Bonus to Attack Rating", null),
                new("Increase Maximum Life 40%", null),
                new("Werebear strikes grant Mark for 180 seconds", null),
                new("Mark of the Bear:", null),
                new("+25% Attack Speed", null),
                new("Physical Damage Received Reduced by 20%", null),
                new("+5 to Shape Shifting Skills (Druid only)", null),
                new("+25% Chance of Crushing Blow", null),
                new("+50-80% Enhanced Defense", null),
                new("+10 to Strength", null),
                new("+10 to Vitality", null),
                new("All Resistances +10", null),
                new("Cannot be Frozen", null)
            }, "https://diablo2.wiki.fextralife.com/Metamorphosis");

        public static RuneWordEnumeration Hustle => new(88, "Hustle", 39, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Ko, RuneEnumeration.Eld },
            GetAll<ItemTypeEnumeration>(),
           new List<Statistic>
            {
                new("5% Chance to cast level 1 Burst of Speed on striking (In Weapons)", null),
                new("Level 1 Fanaticism Aura When Equipped (In Weapons)", null),
                new("+30% Increased Attack Speed (In Weapons)", null),
                new("+180-200% Enhanced Damage (In Weapons)", null),
                new("+75% Damage to Undead (In Weapons)", null),
                new("+50 to Attack Rating against Undead (In Weapons)", null),
                new("+10 to Dexterity (In Weapons)", null),

                new("+65% Faster Run/Walk (In Armors)", null),
                new("+40% Increased Attack Speed (In Armors)", null),
                new("+20% Faster Hit Recovery (In Armors)", null),
                new("+6 to Evade (In Armors)", null),
                new("+10 to Dexterity (In Armors)", null),
                new("50% Slower Stamina Drain (In Armors)", null),
                new("+All Resistances +10 (In Armors)", null)
            }, "https://diablo2.wiki.fextralife.com/Hustle");

        public static RuneWordEnumeration Cure => new(89, "Cure", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Ko, RuneEnumeration.Eld },
                new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("Level 1 Cleansing Aura when Equipped", null),
                new("+20% Faster Hit Recovery", null),
                new("+75-100% Enhanced Defense", null),
                new("+10 to Vitality", null),
                new("Increase Maximum Life 5%", null),
                new("Poison Resist +40-60%", null),
                new("Poison Length Reduced by 50%", null)
            }, "https://diablo2.wiki.fextralife.com/Cure");

        public static RuneWordEnumeration Heart => new(90, "Heart", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Io, RuneEnumeration.Thul },
                new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("+20% Faster Hit Recovery", null),
                new("+75-100% Enhanced Defense", null),
                new("+10 to Vitality", null),
                new("Increase Maximum Life 5%", null),
                new("Cold Resist +40-60%", null),
                new("Cold Absorb +10-15%", null),
                new("Cannot be Frozen", null)
            }, "https://diablo2.wiki.fextralife.com/Heart");

        public static RuneWordEnumeration Ground => new(91, "Ground", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Io, RuneEnumeration.Ort },
                new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("+20% Faster Hit Recovery", null),
                new("+75-100% Enhanced Defense", null),
                new("+10 to Vitality", null),
                new("Increase Maximum Life 5%", null),
                new("Lighting Resist +40-60%", null),
                new("Lighting Absorb +10-15%", null),
            }, "https://diablo2.wiki.fextralife.com/Ground");

        public static RuneWordEnumeration Temper => new(92, "Temper", 35, runes: new List<RuneEnumeration> { RuneEnumeration.Shael, RuneEnumeration.Io, RuneEnumeration.Ral },
                new List<ItemTypeEnumeration> { ItemTypeEnumeration.Helmet },
           new List<Statistic>
            {
                new("+20% Faster Hit Recovery", null),
                new("+75-100% Enhanced Defense", null),
                new("+10 to Vitality", null),
                new("Increase Maximum Life 5%", null),
                new("Fire Resist +40-60%", null),
                new("Fire Absorb +10-15%", null),
            }, "https://diablo2.wiki.fextralife.com/Temper");

        // Ground

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
}
