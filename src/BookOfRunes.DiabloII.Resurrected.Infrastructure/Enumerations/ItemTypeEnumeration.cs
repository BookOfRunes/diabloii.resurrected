using STrain.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Enumerations
{
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
}
