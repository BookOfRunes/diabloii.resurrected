using Bogus;
using Microsoft.Playwright;

namespace BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects
{
	public class IndexPageObject
	{
		private bool _firstCharacter = true;

		private readonly string[] _classes = ["Amazon", "Assassin", "Necromancer", "Barbarian", "Paladin", "Sorceress", "Druid"];

		private readonly IPage _page;

		public string? Name => _page.GetByTestId("spnName").TextContentAsync().GetAwaiter().GetResult();
		public int? Level => int.Parse(_page.GetByTestId("inpLevel").InputValueAsync().GetAwaiter().GetResult());

		public IndexPageObject(IPage page)
		{
			_page = page;
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

		public async Task<bool> IsShownCharaterCreatorAsync()
		{
			return (await _page.WaitForSelectorAsync("[data-testid=dlgAddCharacter]")) is not null;
		}

		public async Task<bool> IsRuneSelectedAsync(string rune)
		{
			return await _page.GetByTestId($"chb{rune}").IsCheckedAsync();
		}
	}
}
