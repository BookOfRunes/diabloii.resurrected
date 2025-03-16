using BookOfRunes.DiabloII.Resurrected.Test.E2E.PageObjects;

namespace BookOfRunes.DiabloII.Resurrected.Test.E2E.StepDefinitions
{
    [Binding]
    public class RuneWordStepDefinitions
    {
        private readonly IndexPageObject _pageObject;

        public RuneWordStepDefinitions(IndexPageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given("{string} item type filter is selected")]
        public async Task SelectItemTypeAsync(string itemType)
        {
            await _pageObject.ClearItemTypesFilterAsync();
            await _pageObject.SelectItemTypeAsync(itemType);
        }

        [Given("Socket from is set to {int}")]
        public void SetSocketFrom(int socketFrom)
        {
            _pageObject.SocketFrom = socketFrom;
        }

        [Given("Socket to is set to {int}")]
        public void SetSocketTo(int socketTo)
        {
            _pageObject.SocketTo = socketTo;
        }

        [Given("Level filter is set to {int}")]
        public void LevelFilterIsSetTo(int level)
        {
            _pageObject.LevelFilter = level;
        }

        [When("Filtering rune words")]
        public async Task FilterAsync()
        {
            await _pageObject.FilterAsync();
        }

        [When("Showing all rune words")]
        public async Task ShowAllRuneWordsAsync()
        {
            await _pageObject.ShowAllRuneWordsAsync();
        }

        [When("Filtering for usable rune words")]
        public async Task FilterForUsableAsync()
        {
            await _pageObject.FilterForUsableAsync();
        }

        [Then("{string} item type filter should be saved")]
        public async Task ItemTypeShouldBeSelectedAsync(string itemType)
        {
            Assert.True(await _pageObject.IsItemTypeSelectedAsync(itemType));
        }

        [Then("Socket from should be {int}")]
        public void SocketFromShouldBe(int socketFrom)
        {
            Assert.Equal(socketFrom, _pageObject.SocketFrom);
        }

        [Then("Socket to should be {int}")]
        public void SocketToShouldBe(int socketTo)
        {
            Assert.Equal(socketTo, _pageObject.SocketTo);
        }

        [Then("Level filter should be {int}")]
        public void LevelFilterShouldBe(int level)
        {
            Assert.Equal(level, _pageObject.LevelFilter);
        }

        [Then("Following rune words are shown:")]
        public void ShowRuneWords(DataTable table)
        {
            Assert.Collection(_pageObject.RuneWords, [.. table.AsInspectors()]);
        }

        [Then("Should be shown {int} rune words")]
        public void ShouldBeShown(int count)
        {
            Assert.Equal(count, _pageObject.RuneWords.Count());
        }
    }

    file static class RuneWordStepDefinitionsExtensions
    {
        public static IEnumerable<Action<string>> AsInspectors(this DataTable table)
        {
            foreach (var row in table.Rows)
            {
                yield return rw => Assert.Equal(row["name"], rw);
            }
        }
    }
}
