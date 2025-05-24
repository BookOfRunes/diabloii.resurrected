using BookOfRunes.DiabloII.Resurrected.WASM.Contexts;
using STrain.CQS;
using STrain.CQS.Http.RequestSending.Binders;
using System.Net.Http.Headers;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Binders
{
	public class AuthorizedGenericHeaderBinder : IHeaderParameterBinder
	{
		private readonly IHeaderParameterBinder _next;
		private readonly UserContext _userContext;
		private readonly ILogger<AuthorizedGenericHeaderBinder> _logger;

		public AuthorizedGenericHeaderBinder(IHeaderParameterBinder next, UserContext userContext, ILogger<AuthorizedGenericHeaderBinder> logger)
		{
			_next = next;
			_userContext = userContext;
			_logger = logger;
		}

		public async Task BindAsync<TRequest>(TRequest request, HttpRequestHeaders headers, CancellationToken cancellationToken) where TRequest : IRequest
		{
			_logger.LogInformation("Adding authorization header");
			var token = await _userContext.GetIdTokenAsync();
			if (token is not null) headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

			await _next.BindAsync(request, headers, cancellationToken).ConfigureAwait(false);
		}
	}
}
