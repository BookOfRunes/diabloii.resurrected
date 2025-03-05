using STrain;

namespace RuneDex.DiabloII.Resurrected.Api
{
	public record GetRunesQuery : Query<IEnumerable<GetRunesQuery.Rune>>
	{
		public record Rune
		{
			public required int Id { get; init; }
			public required string Name { get; init; }
			public required int? Level { get; init; }
			public required string InHelmet { get; init; }
			public required string InBodyArmor { get; init; }
			public required string InShield { get; init; }
			public required string InWeapon { get; init; }
		}
	}
}
