using Bogus;
using BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects;

namespace BookOfRunes.DiabloII.Resurrected.Test.E2E.StepDefinitions
{
	[Binding]
	public class CharacterManagementStepDefinitions
	{
		private readonly IndexPageObject _pageObject;

		public CharacterManagementStepDefinitions(IndexPageObject pageObject)
		{
			_pageObject = pageObject;
		}


		[Given("{string} character is added")]
		[When("Adding {string} character")]
		public async Task AddCharacterAsync(string name)
		{
			await _pageObject.AddCharacterAsync(name, new Faker().Random.Int(1, 99));
		}

		[Given("{string} character is added with level {int}")]
		public async Task AddCharacterAsync(string name, int level)
		{
			await _pageObject.AddCharacterAsync(name, level);
		}


		[Given("{string} is selected")]
		public async Task SelectAsync(string name)
		{
			await _pageObject.SelectAsync(name);
		}

		[When("Opening the application")]
		public async Task Open()
		{
			await _pageObject.OpenAsync();
		}

		[When("Leveling up {string}")]
		public async Task LevelingUp(string name)
		{
			await _pageObject.LevelUpAsync();
		}


		[When("Deleting {string}")]
		public async Task DeleteCharacterAsync(string name)
		{
			await _pageObject.DeleteCharacterAsync(name);
		}

		[When("Selecting next character")]
		public async Task SelectNextAsync()
		{
			await _pageObject.SelectNextAsync();
		}

		[When("Selecting previous character")]
		public async Task SelectPreviousAsync()
		{
			await _pageObject.SelectPreviousAsync();
		}

		[Then("Character creator should be shown")]
		public async Task AddCharacterShouldBeShownAsync()
		{
			Assert.True(await _pageObject.IsShownCharaterCreatorAsync());
		}

		[Then("{string} should be added")]
		public void CharacterShouldBeAdded(string name)
		{
			Assert.Equal(name, _pageObject.Name);
		}


		[Then("Level should be {int}")]
		public void LevelShouldBe(int level)
		{
			Assert.Equal(level, _pageObject.Level);
		}

		[Then("{string} should be selected")]
		public void ShouldBeSelected(string name)
		{
			Assert.Equal(name, _pageObject.Name);
		}
	}
}
