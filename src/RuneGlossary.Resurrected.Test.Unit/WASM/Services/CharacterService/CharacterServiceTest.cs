using AutoBogus;
using Blazored.LocalStorage;
using Bogus;
using Bogus.Extensions;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Test.Unit.WASM.Fakers;
using RuneGlossary.Resurrected.WASM.Models;
using RuneGlossary.Resurrected.WASM.Services;
using STrain;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Services
{
	public partial class CharacterServiceTest
	{
		private Mock<ILocalStorageService> _storageMock = null!;
		private Mock<IRequestSender> _senderMock = null!;

		private CharacterService CreateSUT()
		{
			_storageMock = new Mock<ILocalStorageService>();
			_senderMock = new Mock<IRequestSender>();

			return new CharacterService(_storageMock.Object, _senderMock.Object);
		}

		[Fact(DisplayName = "[UNIT][CSV-004] - Get Current Character")]
		public async Task CharacterService_LoadAsync_GetCurrentCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var itemTypes = new List<ItemType> { new ItemTypeFaker().Generate(), new ItemTypeFaker().Selected().Generate() };
			var characters = new CharacterFaker().Filter(itemTypes).GenerateBetween(1, 5);

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(characters.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			_senderMock.Setup(s => s.SendAsync<GetItemTypesQuery, IEnumerable<GetItemTypesQuery.Result>>(It.IsAny<GetItemTypesQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(itemTypes.AsResponse());

			await sut.LoadAsync(default);

			// Act
			var result = sut.Current;

			// Assert
			Assert.Equal(characters[0], result, new TestCharacterEqualityComparer());
		}

		[Fact(DisplayName = "[UNIT][CSV-005] - Get Current Character on Empty Character List")]
		public async Task CharacterService_LoadAsync_GetCurrentCharacterOnEmptyCharacterList()
		{
			// Arrange
			var sut = CreateSUT();

			await sut.LoadAsync(default);

			// Act
			var result = sut.Current;

			// Assert
			Assert.Null(result);
		}

		[Fact(DisplayName = "[UNIT][CSV-006] - Select Next Character")]
		public async Task CharacterService_Next_SelectNextCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new List<Character> { new AutoFaker<Character>().Generate(), character }.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);

			// Act
			sut.Next();

			// Assert
			Assert.Equal(character, sut.Current, new TestCharacterEqualityComparer());
		}

		[Fact(DisplayName = "[UNIT][CSV-006] - Select Next After the Last")]
		public async Task CharacterService_Next_SelectNextCharacterAfterTheLast()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new List<Character> { character }.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } })); ;

			await sut.LoadAsync(default);

			// Act
			sut.Next();

			// Assert
			Assert.Equal(character, sut.Current, new TestCharacterEqualityComparer());
		}

		[Fact(DisplayName = "[UNIT][CSV-007] - Select Previous")]
		public async Task CharacterService_Previous_SelectPrevious()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new List<Character> { character, new AutoFaker<Character>().Generate() }.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);
			sut.Next();

			// Act
			sut.Previous();

			// Assert
			Assert.Equal(character, sut.Current, new TestCharacterEqualityComparer());
		}

		[Fact(DisplayName = "[UNIT][CSV-007] - Select Previous Before the First")]
		public async Task CharacterService_Previous_SelectPreviousBeforeTheFirst()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new List<Character> { character }.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);

			// Act
			sut.Previous();

			// Assert
			Assert.Equal(character, sut.Current, new TestCharacterEqualityComparer());
		}

		[Fact(DisplayName = "[UNIT][CSV-008] - Select Next Raises Changed Event")]
		public async Task CharacterService_Previous_SelectNextRaisesChangedEvent()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new AutoFaker<Character>().Generate(2).AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);

			// Act
			// Assert
			Assert.Raises<EventArgs>((handler) => sut.Changed += handler, (handler) => sut.Changed -= handler, sut.Next);
		}

		[Fact(DisplayName = "[UNIT][CSV-009] - Select Previous Raises Changed Event")]
		public async Task CharacterService_Previous_SelectPreviousRaisesChangedEvent()
		{
			// Arrange
			var sut = CreateSUT();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new AutoFaker<Character>().Generate(2).AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);
			sut.Next();

			// Act
			// Assert
			Assert.Raises<EventArgs>((handler) => sut.Changed += handler, (handler) => sut.Changed -= handler, sut.Previous);
		}

		[Fact(DisplayName = "[UNIT][CSV-011] - Set Current Character after Add")]
		public async Task CharacterService_SaveAsync_SetCurrentCharacterAfterAdd()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new AutoFaker<Character>().Generate(2).AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);

			// Act
			await sut.AddAsync(character, default);

			// Assert
			Assert.Equal(character, sut.Current);
		}

		[Fact(DisplayName = "[UNIT][CSV-012] - Store Added Character")]
		public async Task CharacterService_SaveAsync_StoreAddedCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			await sut.LoadAsync(default);

			// Act
			await sut.AddAsync(character, default);

			// Assert
			_storageMock.Verify(s => s.SetItemAsync("characters", It.Is<IEnumerable<Character>>(v => v.Contains(character)), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact(DisplayName = "[UNIT][CSV-013] - Delete Character")]
		public async Task CharacterService_SaveAsync_DeleteCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new List<Character> { character, new AutoFaker<Character>().Generate() }.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);

			// Act
			await sut.DeleteAsync(character, default);

			// Assert
			Assert.DoesNotContain(sut.Characters, c => c.Equals(character));
		}

		[Fact(DisplayName = "[UNIT][CSV-014] - Store Delete Character")]
		public async Task CharacterService_SaveAsync_StoreDeletedCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new List<Character> { character, new AutoFaker<Character>().Generate() }.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);

			// Act
			await sut.DeleteAsync(character, default);

			// Assert
			_storageMock.Verify(s => s.SetItemAsync("characters", It.Is<IEnumerable<Character>>(cl => cl.All(c => !c.Equals(character))), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact(DisplayName = "[UNIT][CSV-015] - Save Characters")]
		public async Task CharacterService_SaveAsync_SaveCharacters()
		{
			// Arrange
			var sut = CreateSUT();
			var character = new AutoFaker<Character>().Generate();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new List<Character> { character, new AutoFaker<Character>().Generate() }.AsResponse(), new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() } }));

			await sut.LoadAsync(default);

			sut.Current!.Level = new Faker().Random.Int();

			// Act
			await sut.SaveAsync(default);

			// Assert
			_storageMock.Verify(s => s.SetItemAsync("characters", It.Is<IEnumerable<Character>>(cl => cl.All(c => !c.Equals(character))), It.IsAny<CancellationToken>()), Times.Once());
		}
	}

	internal static class CharacterServiceTestExtensions
	{
		public static IEnumerable<Data> AsResponse(this IEnumerable<Character> characters)
		{
			return characters.Select(c => new Data
			{
				Name = c.Name,
				Class = c.Class,
				Level = c.Level,
				Filters = c.Filters.Where(f => f.Selected).Select(f => f.Id).ToList()
			}).ToList();
		}

		public static IEnumerable<GetItemTypesQuery.Result> AsResponse(this IEnumerable<ItemType> itemTypes)
		{
			return itemTypes.Select(c => new GetItemTypesQuery.Result
			{
				Id = c.Id,
				Class = c.Class,
				Name = c.Name
			}).ToList();
		}

		public static IEnumerable<Action<Character>> AsInspectors(this IEnumerable<Character> characters)
		{
			foreach (var character in characters)
			{
				yield return (c) =>
				{
					Assert.Equal(character.Name, c.Name);
					Assert.Equal(character.Class, c.Class);
					Assert.Equal(character.Level, c.Level);
					Assert.Collection(c.Filters, character.Filters.AsInspectors().ToArray());
				};
			}
		}

		public static IEnumerable<Action<ItemType>> AsInspectors(this IEnumerable<ItemType> filters)
		{
			foreach (var filter in filters)
			{
				yield return (f) =>
				{
					Assert.Equal(filter, f);
				};
			}
		}
	}

	internal record Data
	{
		public required string Name { get; init; }
		public required Class Class { get; init; }
		public required int Level { get; init; }
		public required IEnumerable<int> Filters { get; init; }
	}

	internal class TestCharacterEqualityComparer : IEqualityComparer<Character?>
	{
		public bool Equals(Character? x, Character? y)
		{
			return x!.Name == y!.Name
				&& x.Level == y.Level
				&& x.Class == y.Class;
		}

		public int GetHashCode([DisallowNull] Character obj)
		{
			return obj.GetHashCode();
		}
	}
}
