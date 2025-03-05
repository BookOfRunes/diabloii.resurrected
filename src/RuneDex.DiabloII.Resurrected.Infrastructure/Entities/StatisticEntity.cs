namespace RuneDex.DiabloII.Resurrected.Infrastructure.Entities
{
	public record StatisticEntity
	{
		public int Id { get; set; }
		public required string Description { get; set; }
		public SkillEntity? Skill { get; set; }
	}
}
