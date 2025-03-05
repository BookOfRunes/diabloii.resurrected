using STrain;

namespace RuneDex.DiabloII.Resurrected.Api
{
	public enum ItemClass
	{
		Armor,
		Weapon
	}

	public record GetItemTypesQuery : Query<IEnumerable<GetItemTypesQuery.Result>>
	{
		public record Result
		{
			public required int Id { get; init; }
			public required ItemClass Class { get; init; }
			public required string Name { get; init; }
		}
	}
}
