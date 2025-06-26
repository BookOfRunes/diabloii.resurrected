using Blazored.LocalStorage;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Services.DataService
{
	public class LocalStorageDataService : IDataService
	{
		private const string KEY = "characters";

		private readonly ILocalStorageService _localStorage;
		private readonly ILogger<LocalStorageDataService> _logger;

		private readonly JsonSerializerOptions _jsonSerializerOptions = new();

		public LocalStorageDataService(ILocalStorageService localStorage, ILogger<LocalStorageDataService> logger)
		{
			_localStorage = localStorage;
			_logger = logger;

			_jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		}

		public async Task<IEnumerable<Character>> GetAsync(CancellationToken cancellationToken)
		{
			_logger.LogDebug("Querying characters");
			var raw = await _localStorage.GetItemAsStringAsync(KEY, cancellationToken);
			if (string.IsNullOrWhiteSpace(raw)) return Enumerable.Empty<Character>();

			await using var stream = new MemoryStream();
			await using var writer = new StreamWriter(stream);

			await writer.WriteAsync(raw);
			await writer.FlushAsync(cancellationToken);
			stream.Position = 0;

			return (await JsonSerializer.DeserializeAsync<IEnumerable<Character>>(stream, _jsonSerializerOptions, cancellationToken: cancellationToken))!;
		}
	}
}
