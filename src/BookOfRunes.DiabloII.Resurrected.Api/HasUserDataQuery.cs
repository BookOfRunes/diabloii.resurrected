using Microsoft.AspNetCore.Authorization;
using STrain;

namespace BookOfRunes.DiabloII.Resurrected.Api
{
	[Authorize]
	public record HasUserDataQuery : Query<bool>
	{

	}
}
