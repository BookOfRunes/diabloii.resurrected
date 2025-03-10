using BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects;
using Microsoft.Playwright;

namespace BookOfRunes.DiabloII.Resurrected.Test.E2E.Support
{
	[Binding]
	public sealed class WireupHooks
	{
		private readonly ScenarioContext _context;

		public WireupHooks(ScenarioContext context)
		{
			_context = context;
		}

		[BeforeScenario(Order = 0)]
		public async Task WireupPlaywrightAsync()
		{
			var playwright = await Playwright.CreateAsync();
			var browser = await playwright.Chromium.LaunchAsync();
			var context = await browser.NewContextAsync(new BrowserNewContextOptions
			{
				BaseURL = "http://localhost:5000/"
			});

			_context.ScenarioContainer.RegisterInstanceAs(await context.NewPageAsync());

			_context.ScenarioContainer.RegisterTypeAs<IndexPageObject, IndexPageObject>();
		}

		[AfterScenario]
		public async Task TearDownAsync()
		{
			await _context.ScenarioContainer.Resolve<IPage>().CloseAsync();
		}
	}
}