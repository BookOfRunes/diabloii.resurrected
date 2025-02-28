using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RuneGlossary.Resurrected.WASM.Components;
using RuneGlossary.Resurrected.WASM.Controls;
using RuneGlossary.Resurrected.WASM.Pages;
using RuneGlossary.Resurrected.WASM.Services;
using Xunit;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Pages
{
    public class IndexPageTest
    {
        private Mock<IRuneService> _runeServiceMock = null!;
        private Mock<ICharacterService> _characterServiceMock = null!;
        private Mock<ILoading> _loadingMock = null!;
        private Mock<IRuneWordService> _runeWordServiceMock = null!;

        private IRenderedComponent<IndexPage> CreateCUT()
        {
            _runeServiceMock = new Mock<IRuneService>();
            _characterServiceMock = new Mock<ICharacterService>();
            _loadingMock = new Mock<ILoading>();
            _runeWordServiceMock = new Mock<IRuneWordService>();

            var context = new TestContext();
            context.Services.AddSingleton(_runeServiceMock.Object);
            context.Services.AddSingleton(_characterServiceMock.Object);
            context.Services.AddSingleton(_loadingMock.Object);
            context.Services.AddSingleton(_runeWordServiceMock.Object);
            context.ComponentFactories.AddStub<Character>();

            return context.RenderComponent<IndexPage>();
        }

        [Fact(DisplayName = "[UNIT][INP-001] - Load Runes")]
        public void IndexPage_InitializedAsync_LoadRunes()
        {
            // Act
            CreateCUT();

            // Assert
            _runeServiceMock.Verify(rs => rs.LoadAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "[UNIT][INP-002] - Load Characters")]
        public void IndexPage_InitializedAsync_LoadCharacters()
        {
            // Act
            CreateCUT();

            // Assert
            _characterServiceMock.Verify(rs => rs.LoadAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
