using BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects;
using Microsoft.Playwright;
using System.Diagnostics.CodeAnalysis;

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
            var testContext = new TestContext();
            var playwright = await Playwright.CreateAsync();

            var targetBrowser = Environment.GetEnvironmentVariable("TEST_RUN_TARGET_BROWSER");
            var browser = targetBrowser switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(),
                "firefox" => await playwright.Firefox.LaunchAsync(),
                "webkit" => await playwright.Webkit.LaunchAsync(),
                _ => await playwright.Chromium.LaunchAsync()
            };
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                BaseURL = Environment.GetEnvironmentVariable("TEST_RUN_URL") ?? "http://localhost:5000/",
                ExtraHTTPHeaders = new Dictionary<string, string>
                {
                    ["run-id"] = testContext.RunId.ToString()
                }
            });

            _context.ScenarioContainer.RegisterInstanceAs(await context.NewPageAsync());

            _context.ScenarioContainer.RegisterTypeAs<IndexPageObject, IndexPageObject>();

            _context.ScenarioContainer.RegisterInstanceAs(testContext);
        }

        [AfterScenario]
        public async Task TearDownAsync()
        {
            await _context.ScenarioContainer.Resolve<IPage>().CloseAsync();
        }
    }
}