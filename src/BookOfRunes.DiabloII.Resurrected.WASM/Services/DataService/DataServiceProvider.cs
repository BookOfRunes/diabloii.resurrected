using BookOfRunes.DiabloII.Resurrected.WASM.Contexts;

namespace BookOfRunes.DiabloII.Resurrected.WASM.Services.DataService
{
	public interface IDataServiceProvider
	{
		IDataService Get();
	}

	public class DataServiceProvider : IDataServiceProvider
	{
		private readonly IServiceProvider _services;
		private readonly UserContext _userContext;

		public DataServiceProvider(IServiceProvider services, UserContext userContext)
		{
			_services = services;
			_userContext = userContext;
		}

		public IDataService Get()
		{
			Console.WriteLine(_userContext.IsAuthenticated);
			if (_userContext.IsAuthenticated) return _services.GetRequiredService<CloudDataService>();
			return _services.GetRequiredService<LocalStorageDataService>();
		}
	}
}
