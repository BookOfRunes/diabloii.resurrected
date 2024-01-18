namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public record RuneEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public string InWeapon { get; set; }
        public string InHelmet { get; set; }
        public string InBodyArmor { get; set; }
        public string InShield { get; set; }

        public List<RuneWordEntity> RuneWords { get; set; }
        public List<RuneRuneWordSwitchEntity> RuneWordSwitch { get; set; }
    }
}
