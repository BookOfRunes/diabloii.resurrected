using STrain.Core.Enumerations;

#nullable disable

namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Enumerations
{
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
}
