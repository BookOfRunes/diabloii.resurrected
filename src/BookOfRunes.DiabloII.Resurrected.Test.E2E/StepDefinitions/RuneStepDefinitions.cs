using BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects;

namespace BookOfRunes.DiabloII.Resurrected.Test.E2E.StepDefinitions
{
	[Binding]
	public class RuneStepDefinitions
	{
		private readonly IndexPageObject _pageObject;

		public RuneStepDefinitions(IndexPageObject pageObject)
		{
			_pageObject = pageObject;
		}


		[Given("Rune {string} is selected")]
		public async Task SelectRuneAsync(string name)
		{
			await _pageObject.SelectRuneAsync(name);
		}


		[When("Saving character")]
		public async Task SaveAsync()
		{
			await _pageObject.SaveAsync();
		}


		[Then("Rune {string} should be selected")]
		public async Task ShouldBeSelectAsync(string rune)
		{
			Assert.True(await _pageObject.IsRuneSelectedAsync(rune));
		}
	}
}
