using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RuneDex.DiabloII.Resurrected.Test.Unit.Extensions;
using RuneDex.DiabloII.Resurrected.WASM.Components;
using RuneDex.DiabloII.Resurrected.WASM.Controls.Dialog;
using RuneDex.DiabloII.Resurrected.WASM.Controls.LoadingScreen;
using RuneDex.DiabloII.Resurrected.WASM.Pages;
using RuneDex.DiabloII.Resurrected.WASM.Services;
using Xunit;

namespace RuneDex.DiabloII.Resurrected.Test.Unit.WASM.Pages
{
	public class IndexPageTest
	{
		private Mock<IRuneService> _runeServiceMock = null!;
		private Mock<ICharacterService> _characterServiceMock = null!;
		private Mock<ILoading> _loadingMock = null!;
		private Mock<IRuneWordService> _runeWordServiceMock = null!;
		private Mock<IDialogService> _dialogServiceMock = null!;

		private IRenderedComponent<IndexPage> CreateCUT()
		{
			_runeServiceMock = new Mock<IRuneService>();
			_characterServiceMock = new Mock<ICharacterService>();
			_loadingMock = new Mock<ILoading>();
			_runeWordServiceMock = new Mock<IRuneWordService>();
			_dialogServiceMock = new Mock<IDialogService>();

			var context = new TestContext();
			context.Services.AddSingleton(_runeServiceMock.Object);
			context.Services.AddSingleton(_characterServiceMock.Object);
			context.Services.AddSingleton(_loadingMock.Object);
			context.Services.AddSingleton(_runeWordServiceMock.Object);
			context.Services.AddSingleton(_dialogServiceMock.Object);
			context.Services.AddSingleton(new Mock<DialogService>().Object);

			context.ComponentFactories.AddStub<Character>();

			return context.RenderComponent<IndexPage>();
		}

		[Fact(DisplayName = "[UNIT][INP-001] - Load Runes")]
		[Trait("Feature", "RN - Runes")]
		public void IndexPage_InitializedAsync_LoadRunes()
		{
			// Act
			CreateCUT();

			// Assert
			_runeServiceMock.Verify(rs => rs.LoadAsync(It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact(DisplayName = "[UNIT][INP-002] - Load Characters")]
		[Trait("Feature", "CM - Character Management")]
		public void IndexPage_InitializedAsync_LoadCharacters()
		{
			// Act
			CreateCUT();

			// Assert
			_characterServiceMock.Verify(rs => rs.LoadAsync(It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact(DisplayName = "[UNIT][INP-003] - Show About Dialob")]
		[Trait("Feature", "SP - Support")]
		public async Task IndexPage_ShowAbout_ShowAboutDialog()
		{
			// Arrange
			var cut = CreateCUT();

			// Act
			await cut.ClickAsync("mniAbout");

			// Assert
			_dialogServiceMock.Verify(ds => ds.Show("dlgAbout"));
		}
	}
}
