using Microsoft.AspNetCore.Authorization;
using STrain;

namespace BookOfRunes.DiabloII.Resurrected.Api
{
	[Authorize]
	public record SaveRunesCommand : Command
	{
		public required IEnumerable<int> Runes { get; init; } = [];
	}
}
