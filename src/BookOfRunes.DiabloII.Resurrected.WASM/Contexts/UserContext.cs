using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Contexts
{
	public class UserContext
	{
		private ClaimsPrincipal _user;

		public string Name => _user.Claims.Single(c => c.Type == "given_name").Value;

		public async Task InitializeAsync(Task<AuthenticationState> authenticationState)
		{
			_user = (await authenticationState).User;
		}
	}
}
