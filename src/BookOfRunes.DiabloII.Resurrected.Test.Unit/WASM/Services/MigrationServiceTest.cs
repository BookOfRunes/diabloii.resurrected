using AutoBogus;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using BookOfRunes.DiabloII.Resurrected.WASM.Services;
using Microsoft.Extensions.Logging;
using Moq;
using STrain;
using Xunit;
using Xunit.Abstractions;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Services
{
	public class MigrationServiceTest
	{

		private readonly ILogger<MigrationService> _logger;
		private Mock<IRequestSender> _requestSenderMock = null!;
		private Mock<IRuneService> _runeServiceMock = null!;
		private Mock<ICharacterService> _characterServiceMock = null!;

		public MigrationServiceTest(ITestOutputHelper outputHelper)
		{
			_logger = new LoggerFactory()
						  .AddXUnit(outputHelper)
						  .CreateLogger<MigrationService>();
		}

		private MigrationService CreateSUT()
		{
			_requestSenderMock = new Mock<IRequestSender>();
			_runeServiceMock = new Mock<IRuneService>();
			_characterServiceMock = new Mock<ICharacterService>();

			return new MigrationService(_requestSenderMock.Object, _runeServiceMock.Object, _characterServiceMock.Object, _logger);
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][MGS-001] - Skip Creation")]
		public async Task MigrationService_MigrateAsync_SkipCreation()
		{
			// Arrange
			var sut = CreateSUT();

			_requestSenderMock.Setup(rs => rs.SendAsync<HasUserDataQuery, bool>(It.IsAny<HasUserDataQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(true);

			// Act
			await sut.MigrateAsync(default);

			// Assert
			_requestSenderMock.Verify(rs => rs.SendAsync<CreateUserCommand, object>(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()), Times.Never);
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][MGS-002] - Migrate data")]
		public async Task MigrationService_MigrateAsync_MigrateData()
		{
			// Arrange
			var sut = CreateSUT();
			var runes = new AutoFaker<Rune>().Generate(20);
			var character = new AutoFaker<Character>().RuleFor(c => c.Class, f => f.PickRandom<Class>()).Generate();

			_requestSenderMock.Setup(rs => rs.SendAsync<HasUserDataQuery, bool>(It.IsAny<HasUserDataQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(false);

			_runeServiceMock.SetupGet(rs => rs.Runes).Returns(runes);
			_characterServiceMock.SetupGet(rs => rs.Characters).Returns([character, character]);

			// Act
			await sut.MigrateAsync(default);

			// Assert
			_requestSenderMock.Verify(rs => rs.SendAsync<CreateUserCommand, object>(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()), Times.Once);
			_requestSenderMock.Verify(rs => rs.SendAsync<SaveRunesCommand, object>(It.Is<SaveRunesCommand>(c => c.Runes.Order().SequenceEqual(runes.Where(r => r.Selected).Select(r => r.Id).Order().ToList())), It.IsAny<CancellationToken>()), Times.Once);
			_requestSenderMock.Verify(rs => rs.SendAsync<SaveCharacterCommand, object>(It.Is<SaveCharacterCommand>(c => c.Name == character.Name &&
																														c.Class == (int)character.Class &&
																														c.Level == character.Level), It.IsAny<CancellationToken>()), Times.Exactly(2));
		}
	}
}
