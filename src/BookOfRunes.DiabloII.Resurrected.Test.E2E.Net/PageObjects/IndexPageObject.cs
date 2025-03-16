using Bogus;
using BookOfRunes.DiabloII.Resurrected.Test.E2E.Support;
using Microsoft.Playwright;

namespace BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects
{
    public class IndexPageObject
    {
        private bool _firstCharacter = true;

        private readonly string[] _classes = ["Amazon", "Assassin", "Necromancer", "Barbarian", "Paladin", "Sorceress", "Druid"];

        private readonly IPage _page;
        private readonly TestContext _context;

        public string? Name => _page.GetByTestId("spnName").TextContentAsync().GetAwaiter().GetResult();
        public int? Level => int.Parse(_page.GetByTestId("inpLevel").InputValueAsync().GetAwaiter().GetResult());

        public int SocketFrom
        {
            get => int.Parse(_page.GetByTestId("inpSocketFrom").InputValueAsync().GetAwaiter().GetResult()); set => _page.GetByTestId("inpSocketFrom").FillAsync(value.ToString()).GetAwaiter().GetResult();
        }
        public int SocketTo
        {
            get => int.Parse(_page.GetByTestId("inpSocketTo").InputValueAsync().GetAwaiter().GetResult()); set => _page.GetByTestId("inpSocketTo").FillAsync(value.ToString()).GetAwaiter().GetResult();
        }

        public int LevelFilter
        {
            get => int.Parse(_page.GetByTestId("inpLevelFilter").InputValueAsync().GetAwaiter().GetResult());
            set => _page.GetByTestId("inpLevelFilter").FillAsync(value.ToString()).GetAwaiter().GetResult();
        }

        public IEnumerable<string> RuneWords => _page.QuerySelectorAllAsync("[data-testid=spnRuneWord]").GetAwaiter().GetResult().Select(rw => rw.TextContentAsync().GetAwaiter().GetResult()!).ToList();

        public IndexPageObject(IPage page, TestContext context)
        {
            _page = page;
            _context = context;
        }

        public async Task OpenAsync()
        {
            await _page.GotoAsync("/", new PageGotoOptions());
        }

        public async Task OpenCharacterSelectorAsync()
        {
            await _page.GetByTestId("btnAdd").ClickAsync();
            await _page.GetByTestId("dlgAddCharacter").WaitForAsync();
        }

        public async Task AddCharacterAsync(string name, int level)
        {
            if (!_firstCharacter) await OpenCharacterSelectorAsync();

            var @class = new Faker().PickRandom(_classes);
            await _page.GetByTestId($"cls{@class}").ClickAsync();

            await _page.GetByTestId("inpName").FillAsync(name);
            await _page.GetByTestId("inpAddCharacterLevel").FillAsync(level.ToString());
            await _page.GetByTestId("btnSaveCharacter").ClickAsync();

            await _page.GetByTestId("dlgAddCharacter").WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Detached
            });

            _firstCharacter = false;
        }

        public async Task DeleteCharacterAsync(string name)
        {
            await _page.ReloadAsync();

            await _page.GetByTestId("btnDelete").ClickAsync();

            await _page.ReloadAsync();
        }

        public async Task LevelUpAsync()
        {
            await _page.GetByTestId("btnIncreaseLevel").ClickAsync();
            await _page.GetByTestId("btnSave").ClickAsync();

            await _page.ReloadAsync();
        }

        public async Task SelectAsync(string name)
        {
            await _page.ReloadAsync();

            while (Name != name)
            {
                await SelectNextAsync();
            }
        }

        public async Task FilterAsync()
        {
            await _page.RunAndWaitForRequestFinishedAsync(async () => await _page.GetByTestId("btnFilter").ClickAsync(), new PageRunAndWaitForRequestFinishedOptions
            {
                Predicate = request => request.Headers["run-id"] == _context.RunId.ToString()
            });
            await _page.GetByTestId("ovlLoading").WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Detached });

        }

        public async Task ShowAllRuneWordsAsync()
        {
            await _page.RunAndWaitForRequestFinishedAsync(async () => await _page.GetByTestId("btnAll").ClickAsync(), new PageRunAndWaitForRequestFinishedOptions
            {
                Predicate = request => request.Headers["run-id"] == _context.RunId.ToString()
            });
            await _page.GetByTestId("ovlLoading").WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Detached });
        }

        public async Task FilterForUsableAsync()
        {
            await _page.RunAndWaitForRequestFinishedAsync(async () => await _page.GetByTestId("btnUseable").ClickAsync(), new PageRunAndWaitForRequestFinishedOptions
            {
                Predicate = request => request.Headers["run-id"] == _context.RunId.ToString()
            });
            await _page.GetByTestId("ovlLoading").WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Detached });
        }

        public async Task SelectNextAsync()
        {
            await _page.GetByTestId("btnNext").ClickAsync();
        }

        public async Task SelectPreviousAsync()
        {
            await _page.GetByTestId("btnPrevious").ClickAsync();
        }

        public async Task SelectRuneAsync(string rune)
        {
            await _page.GetByTestId($"chb{rune}").ClickAsync();
        }

        public async Task SaveAsync()
        {
            await _page.GetByTestId("btnSave").ClickAsync();
        }

        public async Task SelectItemTypeAsync(string itemType)
        {
            await _page.GetByTestId($"chb{itemType}").ClickAsync();
        }

        public async Task ClearItemTypesFilterAsync()
        {
            await _page.GetByTestId("btnArmors").ClickAsync();
            await _page.GetByTestId("btnWeapons").ClickAsync();
        }

        public async Task<bool> IsShownCharaterCreatorAsync()
        {
            return (await _page.WaitForSelectorAsync("[data-testid=dlgAddCharacter]")) is not null;
        }

        public async Task<bool> IsRuneSelectedAsync(string rune)
        {
            await _page.ReloadAsync();
            return await _page.GetByTestId($"chb{rune}").IsCheckedAsync();
        }

        public async Task<bool> IsItemTypeSelectedAsync(string itemType)
        {
            await _page.ReloadAsync();
            return await _page.GetByTestId($"chb{itemType}").IsCheckedAsync();
        }
    }
}
