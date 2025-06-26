using Microsoft.AspNetCore.Authorization;
using STrain;

namespace BookOfRunes.DiabloII.Resurrected.Api
{
	[Authorize]
	public record GetCharactersQuery : Query<IEnumerable<GetCharactersQuery.Result>>
	{
		public record Result
		{
			public required string Name { get; init; }
			public required int Level { get; init; }
			public required int Class { get; init; }
		}
	}
}
