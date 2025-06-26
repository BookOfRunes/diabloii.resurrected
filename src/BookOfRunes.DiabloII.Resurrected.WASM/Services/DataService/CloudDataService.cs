using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using STrain;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Services.DataService
{
	public class CloudDataService : IDataService
	{
		private readonly IRequestSender _requestSender;
		private readonly ILogger<CloudDataService> _logger;

		public CloudDataService(IRequestSender requestSender, ILogger<CloudDataService> logger)
		{
			_requestSender = requestSender;
			_logger = logger;
		}

		public async Task<IEnumerable<Character>> GetAsync(CancellationToken cancellationToken)
		{
			var result = await _requestSender.GetAsync<GetCharactersQuery, IEnumerable<GetCharactersQuery.Result>>(new GetCharactersQuery(), cancellationToken);

			return [.. result!.Select(r => new Character { Name = r.Name, Level = r.Level, Class = (Class)r.Class })];
		}
	}
}
