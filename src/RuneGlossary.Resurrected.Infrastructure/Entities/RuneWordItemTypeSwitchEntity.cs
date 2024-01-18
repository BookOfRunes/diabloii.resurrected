namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public record RuneWordItemTypeSwitchEntity
    {
        public RuneWordEntity RuneWord { get; set; }
        public ItemTypeEntity ItemType { get; set; }
    }
}
