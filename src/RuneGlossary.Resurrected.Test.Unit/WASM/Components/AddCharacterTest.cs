using Bogus;
using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RuneGlossary.Resurrected.WASM.Components;
using RuneGlossary.Resurrected.WASM.Controls;
using RuneGlossary.Resurrected.WASM.Models;
using Xunit;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Components
{
	public class AddCharacterTest
	{
		private Mock<IDialogService> _dialogServiceMock = null!;

		private IRenderedComponent<AddCharacter> CreateCUT()
		{
			_dialogServiceMock = new Mock<IDialogService>();

			var context = new TestContext();
			context.Services.AddSingleton(_dialogServiceMock.Object);

			return context.RenderComponent<AddCharacter>();
		}

		[Theory(DisplayName = "[UNIT][ADC-001] - Select Class")]
		[Trait("Feature", "CM - Character Management")]
		[InlineData(Class.Amazon)]
		[InlineData(Class.Assassin)]
		[InlineData(Class.Barbarian)]
		[InlineData(Class.Druid)]
		[InlineData(Class.Necromancer)]
		[InlineData(Class.Paladin)]
		[InlineData(Class.Sorceress)]
		public async Task AddCharacter_SelectClass(Class @class)
		{
			// Arrange
			var cut = CreateCUT();

			// Act
			await cut.Find($"[data-testid=cls{@class}]").ClickAsync(new MouseEventArgs());

			// Assert
			Assert.Equal(@class, cut.Instance.Class);
		}

		[Fact(DisplayName = "[UNIT][ADC-003] - Save Character")]
		[Trait("Feature", "CM - Character Management")]
		public async Task AddCharacter_Save_SaveCharacter()
		{
			// Arrange
			var cut = CreateCUT();
			var faker = new Faker();
			var @class = faker.PickRandom<Class>();
			var name = faker.Random.String2(10);
			var level = faker.Random.Int(1, 99);

			cut.Instance.Class = @class;
			cut.Instance.Name = name;
			cut.Instance.Level = level;

			// Act
			await cut.Find("[data-testid=btnSave]").ClickAsync(new MouseEventArgs());

			// Assert
			_dialogServiceMock.Verify(ds => ds.AcceptAsync(It.Is<Resurrected.WASM.Models.Character>(c => c.Class.Equals(@class)
																										&& c.Name.Equals(name)
																										&& c.Level.Equals(level))), Times.Once());
		}

		[Fact(DisplayName = "[UNIT][ADC-004] - Cancel")]
		[Trait("Feature", "CM - Character Management")]
		public async Task AddCharacter_Cancel()
		{
			// Arrange
			var cut = CreateCUT();

			// Act
			await cut.Find("[data-testid=btnCancel]").ClickAsync(new MouseEventArgs());

			// Assert
			_dialogServiceMock.Verify(ds => ds.Dismiss(), Times.Once());
		}
	}
}
