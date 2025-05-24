using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Contexts
{

	public class UserContext
	{
		private ClaimsPrincipal? _user;
		private readonly IJSRuntime _jsRuntime;

		public bool IsAuthenticated => _user?.Identity?.IsAuthenticated ?? false;
		public string? Name => _user?.Claims.Single(c => c.Type == "given_name").Value ?? null;

		public UserContext(IJSRuntime jsRuntime)
		{
			_jsRuntime = jsRuntime;
		}

		public async Task InitializeAsync(Task<AuthenticationState> authenticationState)
		{
			_user = (await authenticationState).User;
		}

		public async Task<string?> GetIdTokenAsync()
		{
			return await _jsRuntime.InvokeAsync<string>("idToken");
		}
	}
}
