using AutoBogus;
using Blazored.LocalStorage;
using Bogus;
using Moq;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.WASM.Models;
using STrain;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Services
{
	public class RuneServiceTest
	{
		private Mock<IRequestSender> _senderMock = null!;
		private Mock<ILocalStorageService> _storageMock = null!;

		private Resurrected.WASM.Services.RuneService CreateSUT()
		{
			_senderMock = new Mock<IRequestSender>();
			_storageMock = new Mock<ILocalStorageService>();

			return new Resurrected.WASM.Services.RuneService(_senderMock.Object, _storageMock.Object);
		}

		[Fact(DisplayName = "[UNIT][RSV-001] - Query Runes")]
		[Trait("Feature", "RN - Runes")]
		public async Task RuneService_LoadAsync_QueryRunes()
		{
			// Arrange
			var sut = CreateSUT();

			// Act
			await sut.LoadAsync(default);

			// Assert
			_senderMock.Verify(s => s.SendAsync<GetRunesQuery, IEnumerable<GetRunesQuery.Rune>>(It.IsAny<GetRunesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[Fact(DisplayName = "[UNIT][RSV-002] - Load Runes")]
		[Trait("Feature", "RN - Runes")]
		public async Task RuneService_LoadAsync_LoadRunes()
		{
			// Arrange
			var sut = CreateSUT();
			var runes = new AutoFaker<Rune>().Generate(33);
			var selected = new Faker().PickRandom(runes, 5).Select(s => s.Id).ToList();

			_senderMock.Setup(s => s.SendAsync<GetRunesQuery, IEnumerable<GetRunesQuery.Rune>>(It.IsAny<GetRunesQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(runes.AsResponse());

			_storageMock.Setup(s => s.GetItemAsync<IEnumerable<int>>("runes", It.IsAny<CancellationToken>()))
				.ReturnsAsync(selected);

			// Act
			await sut.LoadAsync(default);

			// Assert
			Assert.Equal(runes.Apply(selected), sut.Runes, new RuneEqualityComparer());
		}

		[Fact(DisplayName = "[UNIT][RSV-003] - Raise Loaded Event")]
		[Trait("Feature", "RN - Runes")]
		public async Task RuneService_LoadAsync_RaiseLoadedEvent()
		{
			// Arrange
			var sut = CreateSUT();

			_senderMock.Setup(s => s.SendAsync<GetRunesQuery, IEnumerable<GetRunesQuery.Rune>>(It.IsAny<GetRunesQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(new AutoFaker<GetRunesQuery.Rune>().Generate(33));

			// Act
			// Assert
			await Assert.RaisesAsync<EventArgs>((handler) => sut.Loaded += handler, (handler) => sut.Loaded -= handler, async () => await sut.LoadAsync(default));
		}

		[Fact(DisplayName = "[UNIT][RSV-004] - Query Selected Runes")]
		[Trait("Feature", "RN - Runes")]
		public async Task RuneService_LoadAsync_QuerySelectedRunes()
		{
			// Arrange
			var sut = CreateSUT();

			_senderMock.Setup(s => s.SendAsync<GetRunesQuery, IEnumerable<GetRunesQuery.Rune>>(It.IsAny<GetRunesQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(new AutoFaker<GetRunesQuery.Rune>().Generate(33));

			// Act
			await sut.LoadAsync(default);

			// Assert
			_storageMock.Verify(s => s.GetItemAsync<IEnumerable<int>>("runes", It.IsAny<CancellationToken>()), Times.Once());
		}
	}

	file static class RuneServiceTestExtensions
	{
		public static IEnumerable<GetRunesQuery.Rune> AsResponse(this IEnumerable<Resurrected.WASM.Models.Rune> runes)
		{
			return runes.Select(r => new GetRunesQuery.Rune
			{
				Id = r.Id,
				Name = r.Name,
				Level = r.Level,
				InWeapon = r.InWeapon,
				InBodyArmor = r.InBodyArmor,
				InHelmet = r.InHelmet,
				InShield = r.InShield
			});
		}

		public static IEnumerable<Rune> Apply(this IEnumerable<Rune> runes, IEnumerable<int> selected)
		{
			var result = new List<Rune>();

			foreach (var rune in runes.ToList())
			{
				result.Add(new Rune { Id = rune.Id, Selected = false, Name = rune.Name, Level = rune.Level, InWeapon = rune.InWeapon, InBodyArmor = rune.InBodyArmor, InHelmet = rune.InHelmet, InShield = rune.InShield });
			}
			foreach (var id in selected)
			{
				result.Single(r => r.Id == id).Selected = true;
			}

			return result;
		}
	}

	file class RuneEqualityComparer : IEqualityComparer<Rune>
	{
		public bool Equals(Rune? x, Rune? y)
		{
			return (x is null && y is null) ||
				x is not null && y is not null &&
				x.Id == y.Id &&
				x.Name == y.Name &&
				x.Level == y.Level &&
				x.Selected == y.Selected &&
				x.InWeapon == y.InWeapon &&
				x.InShield == y.InShield &&
				x.InBodyArmor == y.InBodyArmor &&
				x.InHelmet == y.InHelmet;

		}

		public int GetHashCode([DisallowNull] Rune obj)
		{
			return obj.GetHashCode();
		}
	}
}
