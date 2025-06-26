using AutoBogus;
using Bogus.Extensions;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using BookOfRunes.DiabloII.Resurrected.WASM.Services.DataService;
using Microsoft.Extensions.Logging;
using Moq;
using STrain;
using Xunit;
using Xunit.Abstractions;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Services.DataService
{
	public class CloudDataServiceTest
	{

		private readonly ILogger<CloudDataService> _logger;
		private Mock<IRequestSender> _requestSenderMock = null!;

		public CloudDataServiceTest(ITestOutputHelper outputHelper)
		{
			_logger = new LoggerFactory()
						  .AddXUnit(outputHelper)
						  .CreateLogger<CloudDataService>();
		}

		private CloudDataService CreateSUT()
		{
			_requestSenderMock = new Mock<IRequestSender>();

			return new CloudDataService(_requestSenderMock.Object, _logger);
		}

		[Trait("FeatureTitle", "CM - Character Management")]
		[Fact(DisplayName = "[UNIT][CDS-001] - Get characters")]
		public async Task CloudDataService_GetAsync_GetCharacters()
		{
			// Arrange
			var sut = CreateSUT();
			var characters = new AutoFaker<Character>().GenerateBetween(1, 3);

			_requestSenderMock.Setup(rs => rs.SendAsync<GetCharactersQuery, IEnumerable<GetCharactersQuery.Result>>(It.IsAny<GetCharactersQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(characters.AsResponse());

			// Act
			var result = await sut.GetAsync(default);

			// Assert
			Assert.Collection(result, [.. characters.Inspect()]);
		}
	}

	file static class CloudDataServiceTestExtensions
	{
		public static IEnumerable<GetCharactersQuery.Result> AsResponse(this List<Character> characters)
		{
			return characters.Select(c => new GetCharactersQuery.Result
			{
				Name = c.Name,
				Level = c.Level,
				Class = (int)c.Class
			});
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
				};
			}
		}
	}
}
