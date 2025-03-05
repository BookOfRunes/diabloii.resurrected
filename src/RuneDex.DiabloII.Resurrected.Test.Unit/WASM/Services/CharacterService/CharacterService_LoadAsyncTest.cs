using Bogus.Extensions;
using Moq;
using Newtonsoft.Json;
using RuneDex.DiabloII.Resurrected.Api;
using RuneDex.DiabloII.Resurrected.Test.Unit.WASM.Fakers;
using RuneDex.DiabloII.Resurrected.WASM.Models;
using Xunit;

namespace RuneDex.DiabloII.Resurrected.Test.Unit.WASM.Services
{
	public partial class CharacterServiceTest
	{
		[Fact(DisplayName = "[UNIT][CSV/LOAD-001] - Query Characters")]
		[Trait("Feature", "CM - Character Management")]
		public async Task CharacterService_LoadAsync_QueryCharacter()
		{
			// Arrange
			var sut = CreateSUT();

			// Act
			await sut.LoadAsync(default);

			// Assert
			_storageMock.Verify(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact(DisplayName = "[UNIT][CSV/LOAD-002] - Load Characters")]
		[Trait("Feature", "CM - Character Management")]
		public async Task CharacterService_LoadAsync_LoadCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var itemTypes = new List<ItemType> { new ItemTypeFaker().Generate(), new ItemTypeFaker().Selected().Generate() };
			var characters = new CharacterFaker().Filter(itemTypes).Generate(3);

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(characters.AsResponse()));

			_senderMock.Setup(s => s.SendAsync<GetItemTypesQuery, IEnumerable<GetItemTypesQuery.Result>>(It.IsAny<GetItemTypesQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(itemTypes.AsResponse());

			// Act
			await sut.LoadAsync(default);

			// Assert
			Assert.Collection(sut.Characters, characters.AsInspectors().ToArray());
		}

		[Fact(DisplayName = "[UNIT][CSV/LOAD-003] - Raise Loaded Event")]
		[Trait("Feature", "CM - Character Management")]
		public async Task CharacterService_LoadAsync_RaiseLoadedEvent()
		{
			// Arrange
			var sut = CreateSUT();

			_storageMock.Setup(s => s.GetItemAsStringAsync("characters", It.IsAny<CancellationToken>()))
				.ReturnsAsync(JsonConvert.SerializeObject(new CharacterFaker().GenerateBetween(1, 5).AsResponse()));

			// Act
			// Assert
			await Assert.RaisesAsync<EventArgs>((handler) => sut.Loaded += handler, (handler) => sut.Loaded -= handler, async () => await sut.LoadAsync(default));
		}

		[Fact(DisplayName = "[UNIT][CSV/LOAD-016] - Querying Item Types")]
		[Trait("Feature", "CM - Character Management")]
		public async Task CharacterService_LoadAsync_QueryingItemTypes()
		{
			// Arrange
			var sut = CreateSUT();

			// Act
			await sut.LoadAsync(default);

			// Assert
			_senderMock.Verify(s => s.SendAsync<GetItemTypesQuery, IEnumerable<GetItemTypesQuery.Result>>(It.IsAny<GetItemTypesQuery>(), It.IsAny<CancellationToken>()));
		}
	}
}
