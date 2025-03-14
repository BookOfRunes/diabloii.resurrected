using Bogus.Extensions;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.Extensions;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Fakers;
using BookOfRunes.DiabloII.Resurrected.WASM.Components;
using BookOfRunes.DiabloII.Resurrected.WASM.Controls.LoadingScreen;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using BookOfRunes.DiabloII.Resurrected.WASM.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Components
{
	public class FilterTest
	{
		private Mock<ICharacterService> _characterServiceMock = null!;
		private Mock<IRuneWordService> _runeWordServiceMock = null!;
		private Mock<ILoading> _loadingMock = null!;

		private IRenderedComponent<Filters> CreateCUT()
		{
			var context = new TestContext();

			_characterServiceMock = new Mock<ICharacterService>();
			_runeWordServiceMock = new Mock<IRuneWordService>();
			_loadingMock = new Mock<ILoading>();

			context.Services.AddSingleton(_characterServiceMock.Object);
			context.Services.AddSingleton(_runeWordServiceMock.Object);
			context.Services.AddSingleton(_loadingMock.Object);

			return context.RenderComponent<Filters>();
		}

		[Fact(DisplayName = "[UNIT][FLT-001] - Select All Armors")]
		[Trait("FeatureTitle", "RW - Rune Word")]
		public async Task Filters_SelectArmors()
		{
			// Arrange
			var cut = CreateCUT();
			var armors = new ItemTypeFaker().GenerateBetween(1, 5);

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(new CharacterFaker().RuleFor(c => c.Filters, _ => new FilterData { ItemTypes = armors }));

			cut.Render();

			// Act
			await cut.SelectArmorsAsync();

			// Assert
			Assert.Collection(armors, [.. armors.ArmorsSelected()]);
		}

		[Fact(DisplayName = "[UNIT][FLT-002] - Unselect All Armors")]
		[Trait("FeatureTitle", "RW - Rune Word")]
		public async Task Filters_UnselectArmors()
		{
			// Arrange
			var cut = CreateCUT();
			var armors = new ItemTypeFaker().Selected().GenerateBetween(1, 5);

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(new CharacterFaker().RuleFor(c => c.Filters, _ => new FilterData { ItemTypes = armors }));

			cut.Render();

			// Act
			await cut.SelectArmorsAsync();

			// Assert
			Assert.Collection(armors, [.. armors.ArmorsNotselected()]);
		}

		[Fact(DisplayName = "[UNIT][FLT-003] - Select All Weapons")]
		[Trait("FeatureTitle", "RW - Rune Word")]
		public async Task Filters_SelectWeapons()
		{
			// Arrange
			var cut = CreateCUT();
			var armors = new ItemTypeFaker().GenerateBetween(1, 5);

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(new CharacterFaker().RuleFor(c => c.Filters, _ => new FilterData { ItemTypes = armors }));

			cut.Render();

			// Act
			await cut.SelectWeaponsAsync();

			// Assert
			Assert.Collection(armors, [.. armors.WeaponsSelected()]);
		}

		[Fact(DisplayName = "[UNIT][FLT-004] - Unselect All Weapons")]
		[Trait("FeatureTitle", "RW - Rune Word")]
		public async Task Filters_UnselectWeapons()
		{
			// Arrange
			var cut = CreateCUT();
			var armors = new ItemTypeFaker().Selected().GenerateBetween(1, 5);

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(new CharacterFaker().RuleFor(c => c.Filters, _ => new FilterData { ItemTypes = armors }));

			cut.Render();

			// Act
			await cut.SelectWeaponsAsync();

			// Assert
			Assert.Collection(armors, [.. armors.WeaponsNotselected()]);
		}

		[Fact(DisplayName = "[UNIT][FLT-005] - Filter for Useable Rune Words")]
		[Trait("FeatureTitle", "RW - Rune Word")]
		public async Task Filters_FilterForUseableRuneWords()
		{
			// Arrange
			var cut = CreateCUT();
			var itemTypes = new ItemTypeFaker().Selected().GenerateBetween(1, 5);
			var character = new CharacterFaker().RuleFor(c => c.Filters, new FilterData
			{
				ItemTypes = [.. itemTypes, .. new ItemTypeFaker().GenerateBetween(1, 5)]
			}).Generate();

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(character);

			cut.Render();

			// Act
			await cut.FilterForUsableAsync();

			// Assert
			_runeWordServiceMock.Verify(rws => rws.LoadAsync(It.Is<IEnumerable<int>>(id => itemTypes.Select(it => it.Id).SequenceEqual(id)), It.Is<int>(sf => sf == 2), It.Is<int>(st => st == 6), It.Is<int>(l => l == character.Level), It.IsAny<CancellationToken>()));
		}

		[Fact(DisplayName = "[UNIT][FLT-006] - Show All Rune Words")]
		[Trait("FeatureTitle", "RW - Rune Word")]
		public async Task Filters_ShowAllRuneWords()
		{
			// Arrange
			var cut = CreateCUT();
			var itemTypes = new ItemTypeFaker().GenerateBetween(1, 5);

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(new CharacterFaker().RuleFor(c => c.Filters, new FilterData
			{
				ItemTypes = itemTypes
			}).Generate());

			cut.Render();

			// Act
			await cut.ShowAllAsync();

			// Assert
			_runeWordServiceMock.Verify(rws => rws.LoadAsync(It.Is<IEnumerable<int>>(id => itemTypes.Select(it => it.Id).SequenceEqual(id)), It.Is<int>(sf => sf == 2), It.Is<int>(st => st == 6), It.Is<int>(l => l == 99), It.IsAny<CancellationToken>()));
		}

		[Fact(DisplayName = "[UNIT][FLT-007] - Filter Rune Words")]
		[Trait("FeatureTitle", "RW - Rune Word")]
		public async Task Filters_FilterRuneWords()
		{
			// Arrange
			var cut = CreateCUT();
			var character = new CharacterFaker().Generate();

			_characterServiceMock.SetupGet(cs => cs.Current).Returns(character);

			cut.Render();

			// Act
			await cut.FilterAsync();

			// Assert
			_runeWordServiceMock.Verify(rws => rws.LoadAsync(It.Is<IEnumerable<int>>(id => character.Filters.ItemTypes.Where(it => it.Selected).Select(it => it.Id).SequenceEqual(id)), It.Is<int>(sf => sf == character.Filters.SocketFrom), It.Is<int>(st => st == character.Filters.SocketTo), It.Is<int>(l => l == character.Filters.Level), It.IsAny<CancellationToken>()));
		}
	}

	file static class FilterTestExtensions
	{
		public static IEnumerable<Action<ItemType>> ArmorsSelected(this IEnumerable<ItemType> itemTypes)
		{
			foreach (var itemType in itemTypes)
			{
				yield return it => Assert.Equal(itemType.Class == ItemClass.Armor, it.Selected);
			}
		}

		public static IEnumerable<Action<ItemType>> ArmorsNotselected(this IEnumerable<ItemType> itemTypes)
		{
			foreach (var itemType in itemTypes)
			{
				yield return it => Assert.Equal(itemType.Class != ItemClass.Armor, it.Selected);
			}
		}
		public static IEnumerable<Action<ItemType>> WeaponsSelected(this IEnumerable<ItemType> itemTypes)
		{
			foreach (var itemType in itemTypes)
			{
				yield return it => Assert.Equal(itemType.Class == ItemClass.Weapon, it.Selected);
			}
		}

		public static IEnumerable<Action<ItemType>> WeaponsNotselected(this IEnumerable<ItemType> itemTypes)
		{
			foreach (var itemType in itemTypes)
			{
				yield return it => Assert.Equal(itemType.Class != ItemClass.Weapon, it.Selected);
			}
		}

		public static async Task SelectArmorsAsync(this IRenderedComponent<Filters> component)
		{
			await component.ClickAsync("btnArmors");
		}

		public static async Task SelectWeaponsAsync(this IRenderedComponent<Filters> component)
		{
			await component.ClickAsync("btnWeapons");
		}

		public static async Task FilterForUsableAsync(this IRenderedComponent<Filters> component)
		{
			await component.ClickAsync("btnUseable");
		}

		public static async Task ShowAllAsync(this IRenderedComponent<Filters> component)
		{
			await component.ClickAsync("btnAll");
		}

		public static async Task FilterAsync(this IRenderedComponent<Filters> component)
		{
			await component.ClickAsync("btnFilter");
		}
	}
}
