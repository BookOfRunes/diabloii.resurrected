using RuneDex.DiabloII.Resurrected.Api;
using STrain;

namespace RuneDex.DiabloII.Resurrected.WASM.Services
{
	public interface IRuneWordService
	{
		IEnumerable<GetRuneWordsQuery.Result> RuneWords { get; }

		event EventHandler<EventArgs> Loaded;

		Task LoadAsync(IEnumerable<int> itemTypes, int socketFrom, int socketTo, int maxLevel, CancellationToken cancellationToken);
	}

	public class RuneWordService(IRequestSender sender) : IRuneWordService
	{
		private IEnumerable<GetRuneWordsQuery.Result> _runeWords = [];
		private readonly IRequestSender _sender = sender;

		public IEnumerable<GetRuneWordsQuery.Result> RuneWords => _runeWords;

		public event EventHandler<EventArgs>? Loaded;

		public async Task LoadAsync(IEnumerable<int> itemTypes, int socketFrom, int socketTo, int maxLevel, CancellationToken cancellationToken)
		{
			var query = new GetRuneWordsQuery(itemTypes, socketFrom, socketTo, maxLevel);
			_runeWords = await _sender.GetAsync<GetRuneWordsQuery, IEnumerable<GetRuneWordsQuery.Result>>(query, cancellationToken) ?? [];
			Loaded?.Invoke(this, EventArgs.Empty);
		}
	}
}
