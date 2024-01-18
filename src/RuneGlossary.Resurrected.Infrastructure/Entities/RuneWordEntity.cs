namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public record RuneWordEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<RuneEntity> Runes { get; set; }
        public ICollection<ItemTypeEntity> ItemTypes { get; set; }
        public ICollection<StatisticEntity> Statistics { get; set; }
        public string Url { get; set; }

        public ICollection<RuneRuneWordSwitchEntity> RuneSwitch { get; set; }
        public ICollection<RuneWordItemTypeSwitchEntity> ItemTypeSwitch { get; set; }
    }
}
