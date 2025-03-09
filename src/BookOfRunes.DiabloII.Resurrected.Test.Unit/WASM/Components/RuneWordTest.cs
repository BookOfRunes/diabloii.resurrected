using AutoBogus;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.WASM.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Fakers;
using BookOfRunes.DiabloII.Resurrected.WASM.Components;
using Xunit;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Components
{
	public class RuneWordTest
	{
		private Mock<ICharacterService> _characterServiceMock = null!;
		private Mock<IRuneService> _runeServiceMock = null!;

		private IRenderedComponent<RuneWord> CreateCUT(GetRuneWordsQuery.Result model)
		{
			var context = new TestContext();

			_characterServiceMock = new Mock<ICharacterService>();
			_runeServiceMock = new Mock<IRuneService>();

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(new CharacterFaker().Generate());

			context.Services.AddSingleton(_characterServiceMock.Object);
			context.Services.AddSingleton(_runeServiceMock.Object);

			return context.RenderComponent<RuneWord>(p => p.Add(rw => rw.Model, model)
															.Add(rw => rw.Runes, [])
															.Add(rw => rw.ItemTypes, []));
		}

		[Fact(DisplayName = "[UNIT][RNW-001] - Get Skill")]
		[Trait("Feature", "RW - Rune Word")]
		public void RuneWord_GetSkill()
		{
			// Arrange
			var runeWord = new AutoFaker<GetRuneWordsQuery.Result>()
				.RuleFor(rw => rw.Statistics, _ =>
					[
						new AutoFaker<GetRuneWordsQuery.Result.Statistic>()
							.RuleFor(s => s.Description, "{skill}")
							.Generate()
					])
				.Generate();

			// Act
			var cut = CreateCUT(runeWord);

			// Assert
			Assert.Equal(runeWord.Statistics.First().Skill!.Name, cut.Find("[data-testid=txtDescription]").TextContent);
		}

		[Fact(DisplayName = "[UNIT][RNW-001] - Calculate Statistics Based on Character Level")]
		[Trait("Feature", "RW - Rune Word")]
		public async Task RuneWord_CalculateCharacterLevel()
		{
			// Arrange
			var runeWord = new AutoFaker<GetRuneWordsQuery.Result>()
				.RuleFor(rw => rw.Statistics, _ =>
					[
						new AutoFaker<GetRuneWordsQuery.Result.Statistic>()
							.RuleFor(s => s.Description, "(0.5*Clvl)")
							.Generate()
					])
				.Generate();
			var character = new CharacterFaker().Generate();

			var cut = CreateCUT(runeWord);

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(character);

			// Act
			await cut.InvokeAsync(() => cut.Render());

			// Assert
			Assert.Equal((0.5 * character.Level).ToString("0"), cut.Find("[data-testid=txtDescription]").TextContent);
		}
	}
}
