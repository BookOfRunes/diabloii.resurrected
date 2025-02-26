using Blazored.LocalStorage;
using RuneGlossary.Resurrected.Api;
using STrain;

namespace RuneGlossary.Resurrected.WASM.Services
{
	public interface IRuneService
	{
		IEnumerable<Models.Rune> Runes { get; }

		event EventHandler<EventArgs>? Loaded;
		event EventHandler<EventArgs>? Changed;

		Task LoadAsync(CancellationToken cancellationToken);
		Task SaveAsync(CancellationToken cancellationToken);
	}

	public class RuneService(IRequestSender Sender, ILocalStorageService storage) : IRuneService
	{
		private readonly IRequestSender _sender = Sender;
		private readonly ILocalStorageService _storage = storage;

		public event EventHandler<EventArgs>? Loaded;
		public event EventHandler<EventArgs>? Changed;

		private IEnumerable<Models.Rune> _runes = Enumerable.Empty<Models.Rune>().ToList();
		public IEnumerable<Models.Rune> Runes => _runes;

		public async Task LoadAsync(CancellationToken cancellationToken)
		{
			var response = await _sender.SendAsync<GetRunesQuery, IEnumerable<GetRunesQuery.Rune>>(new GetRunesQuery(), cancellationToken);
			var selected = await _storage.GetItemAsync<IEnumerable<int>>("runes", cancellationToken);

			_runes = response!.Select(r => new Models.Rune { Id = r.Id, Selected = selected?.Any(id => r.Id == id) ?? false, Name = r.Name, Level = r.Level, InHelmet = r.InHelmet, InBodyArmor = r.InBodyArmor, InShield = r.InShield, InWeapon = r.InWeapon }).ToList();

			foreach (var rune in _runes)
			{
				rune.PropertyChanged += (_, __) => Changed?.Invoke(this, EventArgs.Empty);
			}

			Loaded?.Invoke(this, EventArgs.Empty);
		}

		public async Task SaveAsync(CancellationToken cancellationToken)
		{
			var selected = _runes.Where(r => r.Selected);

			await _storage.SetItemAsync("runes", _runes.Where(r => r.Selected).Select(r => r.Id).ToList(), cancellationToken); ;
		}
	}
}
