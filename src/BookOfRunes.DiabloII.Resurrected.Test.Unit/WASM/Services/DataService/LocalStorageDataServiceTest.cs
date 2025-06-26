using AutoBogus;
using Blazored.LocalStorage;
using Bogus.Extensions;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using BookOfRunes.DiabloII.Resurrected.WASM.Services.DataService;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;
using Xunit.Abstractions;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Services.DataService
{
	public class LocalStorageDataServiceTest
	{

		private readonly ILogger<LocalStorageDataService> _logger;
		private Mock<ILocalStorageService> _localStorageMock = null!;

		public LocalStorageDataServiceTest(ITestOutputHelper outputHelper)
		{
			_logger = new LoggerFactory()
						  .AddXUnit(outputHelper)
						  .CreateLogger<LocalStorageDataService>();
		}

		private LocalStorageDataService CreateSUT()
		{
			_localStorageMock = new Mock<ILocalStorageService>();

			return new LocalStorageDataService(_localStorageMock.Object, _logger);
		}

		[Trait("FeatureTitle", "CM - Character Management")]
		[Fact(DisplayName = "[UNIT][LSD-001]: Get Characters")]
		public async Task LocalStorageDataService_GetAsync_GetCharacters()
		{
			// Arrange
			var sut = CreateSUT();
			var characters = new AutoFaker<Character>().GenerateBetween(1, 3);

			_localStorageMock.Setup(ls => ls.GetItemAsStringAsync(It.Is<string>(k => k == "characters"), It.IsAny<CancellationToken>()))
				.ReturnsAsync(await characters.SerializeAsync());

			// Act
			var result = await sut.GetAsync(default);

			// Assert
			Assert.Collection(result, [.. characters.Inspect()]);
		}

		[Trait("FeatureTitle", "CM - Character Management")]
		[Fact(DisplayName = "[UNIT][LSD-002]: Characters are not set")]
		public async Task LocalStorageDataService_GetAsync_CharactersAreNotSet()
		{
			// Arrange
			var sut = CreateSUT();

			// Act
			var result = await sut.GetAsync(default);

			// Assert
			Assert.Empty(result);
		}
	}

	file static class LocalStorageDataServiceTestExtensions
	{
		public static async Task<string> SerializeAsync(this IEnumerable<Character> characters)
		{
			await using var stream = new MemoryStream();
			var options = new JsonSerializerOptions();
			options.Converters.Add(new JsonStringEnumConverter());
			await JsonSerializer.SerializeAsync(stream, characters, options);
			stream.Position = 0;
			using var reader = new StreamReader(stream);
			return await reader.ReadToEndAsync();
		}

		public static IEnumerable<Action<Character>> Inspect(this IEnumerable<Character> characters)
		{
			foreach (var character in characters)
			{
				yield return (c) =>
				{
					Assert.Equal(character.Name, c.Name);
					Assert.Equal(character.Class, c.Class);
					Assert.Equal(character.Level, c.Level);
					Assert.Collection(c.Filters.ItemTypes, [.. character.Filters.ItemTypes.Inspect()]);
				};
			}
		}

		public static IEnumerable<Action<ItemType>> Inspect(this IEnumerable<ItemType> filters)
		{
			foreach (var filter in filters)
			{
				yield return (f) =>
				{
					Assert.Equal(filter.Id, f.Id);
					Assert.Equal(filter.Name, f.Name);
					Assert.Equal(filter.Selected, f.Selected);
					Assert.Equal(filter.Class, f.Class);
				};
			}
		}
	}
}
