using BookOfRunes.DiabloII.Resurrected.WASM.Models;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Services.DataService
{
	public interface IDataService
	{
		Task<IEnumerable<Character>> GetAsync(CancellationToken cancellationToken);
	}
}
