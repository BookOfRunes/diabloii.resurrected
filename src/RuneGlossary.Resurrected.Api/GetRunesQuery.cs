using STrain;

namespace RuneGlossary.Resurrected.Api
{
    public record GetRunesQuery : Query<IEnumerable<GetRunesQuery.Rune>>
    {
        public record Rune
        {
            public int Id { get; }
            public string Name { get; }
            public int? Level { get; }
            public string InHelmet { get; }
            public string InBodyArmor { get; }
            public string InShield { get; }
            public string InWeapon { get; }

            public Rune(int id, string name, int? level, string inHelmet, string inBodyArmor, string inShield, string inWeapon)
            {
                Id = id;
                Name = name;
                Level = level;
                InHelmet = inHelmet;
                InBodyArmor = inBodyArmor;
                InShield = inShield;
                InWeapon = inWeapon;
            }
        }
    }
}
