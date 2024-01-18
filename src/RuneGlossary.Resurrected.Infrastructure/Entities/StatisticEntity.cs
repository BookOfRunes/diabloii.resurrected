namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public record StatisticEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public SkillEntity? Skill { get; set; }
    }
}
