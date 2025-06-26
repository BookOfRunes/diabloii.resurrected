using AutoBogus;
using Bogus.Extensions;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Infrastructure.Entities;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.Extensions;
using Xunit;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.Backend
{
	public partial class UserDataPerformersTest
	{
		[Trait("FeatureTitle", "CM - Character Management")]
		[Fact(DisplayName = "[UNIT][GCQ-001] - Get Characters")]
		public async Task GetCharactersQuery_PerformAsync_GetCharacters()
		{
			// Arrange
			var sut = CreateSUT();
			var characters = new AutoFaker<CharacterEntity>().GenerateBetween(1, 3);

			await _context.InsertAsync(characters);

			// Act
			var result = await sut.PerformAsync(new GetCharactersQuery(), default);

			// Assert
			Assert.Collection(result, [.. characters.Inspect()]);
		}
	}

	file static class UserDataPerformersTestExtensions
	{
		public static IEnumerable<Action<GetCharactersQuery.Result>> Inspect(this List<CharacterEntity> characters)
		{
			foreach (var character in characters)
			{
				yield return r =>
				{
					Assert.Equal(character.Name, r.Name);
					Assert.Equal(character.Level, r.Level);
					Assert.Equal(character.Class.Id, r.Class);
				};
			}
		}
	}
}
