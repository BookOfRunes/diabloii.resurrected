namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public record RuneRuneWordSwitchEntity
    {
        public RuneEntity Rune { get; set; }
        public RuneWordEntity RuneWord { get; set; }
        public int Order { get; set; }
    }
}
