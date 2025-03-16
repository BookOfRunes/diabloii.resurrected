using BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects;

namespace BookOfRunes.DiabloII.Resurrected.Test.E2E.Support
{
	[Binding]
	public sealed class GenericHooks
	{
		private readonly IndexPageObject _pageObject;

		public GenericHooks(IndexPageObject pageObject)
		{
			_pageObject = pageObject;
		}

		[BeforeScenario(Order = 1)]
		public async Task OpenAsync()
		{
			await _pageObject.OpenAsync();
		}
	}
}