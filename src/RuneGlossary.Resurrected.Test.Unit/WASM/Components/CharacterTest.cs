using Bogus;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using RuneGlossary.Resurrected.Test.Unit.WASM.Fakers;
using RuneGlossary.Resurrected.WASM.Components;
using RuneGlossary.Resurrected.WASM.Controls;
using RuneGlossary.Resurrected.WASM.Services;
using Xunit;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Components
{
    public class CharacterTest
    {
        private Mock<IRuneService> _runeServiceMock;
        private Mock<ICharacterService> _characterServiceMock;
        private Mock<IDialogService> _dialogServiceMock;

        private IRenderedComponent<Character> CreateCUT()
        {
            var context = new TestContext();

            _runeServiceMock = new Mock<IRuneService>();
            _characterServiceMock = new Mock<ICharacterService>();
            _dialogServiceMock = new Mock<IDialogService>();

            var runtimeMock = new Mock<IJSRuntime>();
            runtimeMock.Setup(r => r.InvokeAsync<string>("getFontSize", It.IsAny<object[]>())).ReturnsAsync(10.ToString());
            runtimeMock.Setup(r => r.InvokeAsync<int>("getWindowHeight", It.IsAny<object[]>())).ReturnsAsync(100);
            runtimeMock.Setup(r => r.InvokeAsync<int>("getHeight", It.IsAny<object[]>())).ReturnsAsync(50);

            context.Services.AddSingleton(runtimeMock.Object);
            context.Services.AddSingleton(_runeServiceMock.Object);
            context.Services.AddSingleton(_characterServiceMock.Object);
            context.Services.AddSingleton(_dialogServiceMock.Object);
            context.Services.AddSingleton(new Mock<DialogService>().Object);

            _characterServiceMock.SetupGet(cs => cs.Current).Returns(new CharacterFaker().Generate());

            return context.RenderComponent<Character>();
        }

        [Fact(DisplayName = "[UNIT][CHR-001] - Add New Character")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_AddNewCharacter()
        {
            // Arrange
            var cut = CreateCUT();

            // Act
            await cut.AddAsync();

            // Assert
            _dialogServiceMock.Verify(ds => ds.Show(), Times.Once());
        }

        [Fact(DisplayName = "[UNIT][CHR-002] - Add First Character")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_AddFirstCharacter()
        {
            // Arrange
            var cut = CreateCUT();

            _characterServiceMock.SetupGet(cs => cs.Current).Returns(value: null);

            // Act
            await cut.InvokeAsync(() => _characterServiceMock.Raise(cs => cs.Loaded += null, EventArgs.Empty));

            // Assert
            _dialogServiceMock.Verify(ds => ds.Show(), Times.Once());
        }

        [Fact(DisplayName = "[UNIT][CHR-003] - Increase Characer Level")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_IncreaseCharacterLevel()
        {
            // Arrange
            var cut = CreateCUT();
            var level = new Faker().Random.Int(1, 98);
            var character = new CharacterFaker().RuleFor(c => c.Level, level).Generate();

            _characterServiceMock.SetupGet(cs => cs.Current).Returns(character);

            // Act
            await cut.IncreaseLevelAsync();

            // Assert
            Assert.Equal(level + 1, character.Level);
        }

        [Fact(DisplayName = "[UNIT][CHR-004] - Decrease Characer Level")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_DecreaseCharacterLevel()
        {
            // Arrange
            var cut = CreateCUT();
            var level = new Faker().Random.Int(2, 99);
            var character = new CharacterFaker().RuleFor(c => c.Level, level).Generate();

            _characterServiceMock.SetupGet(cs => cs.Current).Returns(character);

            // Act
            await cut.DecreaseLevelAsync();

            // Assert
            Assert.Equal(level - 1, character.Level);
        }

        [Fact(DisplayName = "[UNIT][CHR-005] - Save Character")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_SaveCharacter()
        {
            // Arrange
            var cut = CreateCUT();

            // Act
            await cut.SaveAsync();

            // Assert
            _characterServiceMock.Verify(cs => cs.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "[UNIT][CHR-006] - Save Runes")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_SaveRunes()
        {
            // Arrange
            var cut = CreateCUT();

            // Act
            await cut.SaveAsync();

            // Assert
            _runeServiceMock.Verify(cs => cs.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "[UNIT][CHR-007] - Delete Character")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_DeleteCharacter()
        {
            // Arrange
            var cut = CreateCUT();
            var character = new CharacterFaker().Generate();

            _characterServiceMock.SetupGet(cs => cs.Current).Returns(character);

            // Act
            await cut.DeleteAsync();

            // Assert
            _characterServiceMock.Verify(cs => cs.DeleteAsync(It.Is<Resurrected.WASM.Models.Character>(c => c.Name == character.Name), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "[UNIT][CHR-008] - Delete Character if nothing Selected")]
        [Trait("Feature", "CM - Character Management")]
        public async Task Character_DeleteCharacterIfNothingSelected()
        {
            // Arrange
            var cut = CreateCUT();

            _characterServiceMock.SetupGet(cs => cs.Current).Returns(value: null);

            // Act
            await cut.DeleteAsync();

            // Assert
            _characterServiceMock.Verify(cs => cs.DeleteAsync(It.IsAny<Resurrected.WASM.Models.Character>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }

    file static class CharacterTestExtensions
    {
        public static async Task AddAsync(this IRenderedComponent<Character> component)
        {
            await component.ClickAsync("btnAdd");
        }

        public static async Task IncreaseLevelAsync(this IRenderedComponent<Character> component)
        {
            await component.ClickAsync("btnIncreaseLevel");
        }

        public static async Task DecreaseLevelAsync(this IRenderedComponent<Character> component)
        {
            await component.ClickAsync("btnDecreaseLevel");
        }

        public static async Task SaveAsync(this IRenderedComponent<Character> component)
        {
            await component.ClickAsync("btnSave");
        }

        public static async Task DeleteAsync(this IRenderedComponent<Character> component)
        {
            await component.ClickAsync("btnDelete");
        }
    }
}
