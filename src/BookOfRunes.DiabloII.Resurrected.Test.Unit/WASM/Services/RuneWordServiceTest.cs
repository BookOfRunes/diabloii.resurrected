using AutoBogus;
using Bogus;
using Bogus.Extensions;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Services;
using BookOfRunes.DiabloII.Resurrected.WASM.Models;
using BookOfRunes.DiabloII.Resurrected.WASM.Services;
using Moq;
using RuneDex.DiabloII.Resurrected.Test.Unit.WASM.Fakers;
using STrain;
using Xunit;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.WASM.Services
{
	public class RuneWordServiceTest
	{
		private Mock<IRequestSender> _requestSenderMock = null!;

		private RuneWordService CreateSUT()
		{
			_requestSenderMock = new Mock<IRequestSender>();

			return new RuneWordService(_requestSenderMock.Object);
		}

		[Fact(DisplayName = "[UNIT][RWS-001] - Load Rune Words")]
		[Trait("Feature", "RW - Rune Word")]
		public async Task RuneWordService_LoadRuneWords()
		{
			// Arrange
			var sut = CreateSUT();
			var faker = new Faker();
			var itemTypes = new ItemTypeFaker().GenerateBetween(1, 5);
			var socketFrom = faker.Random.Int();
			var socketTo = faker.Random.Int();
			var level = faker.Random.Int();

			var runeWords = new AutoFaker<GetRuneWordsQuery.Result>().GenerateBetween(1, 5);

			_requestSenderMock.Setup(rs => rs.SendAsync<GetRuneWordsQuery, IEnumerable<GetRuneWordsQuery.Result>>(It.Is<GetRuneWordsQuery>(q => q.Verify(itemTypes, socketFrom, socketTo, level)), default))
				.ReturnsAsync(runeWords);

			// Act
			await sut.LoadAsync(itemTypes.Select(it => it.Id), socketFrom, socketTo, level, default);

			// Assert
			Assert.Collection(sut.RuneWords, [.. runeWords.AsInspectors()]);
		}

		[Fact(DisplayName = "[UNIT][RWS-002] - Raise Loaded Event")]
		[Trait("Feature", "RW - Rune Word")]
		public async Task RuneWordService_RaiseLoadedEvent()
		{
			// Arrange
			var sut = CreateSUT();
			var faker = new Faker();

			var runeWords = new AutoFaker<GetRuneWordsQuery.Result>().GenerateBetween(1, 5);

			_requestSenderMock.Setup(rs => rs.SendAsync<GetRuneWordsQuery, IEnumerable<GetRuneWordsQuery.Result>>(It.IsAny<GetRuneWordsQuery>(), default))
				.ReturnsAsync(runeWords);

			// Act

			// Assert
			await Assert.RaisesAsync<EventArgs>(handler => sut.Loaded += handler, handler => sut.Loaded -= handler, async () => await sut.LoadAsync(new ItemTypeFaker().GenerateBetween(1, 5).Select(it => it.Id), faker.Random.Int(), faker.Random.Int(), faker.Random.Int(), default));
		}
	}

	file static class RuneWordServiceTestExtensions
	{
		public static bool Verify(this GetRuneWordsQuery query, IEnumerable<ItemType> itemTypes, int socketFrom, int socketTo, int level)
		{
			return query.ItemTypes.SequenceEqual(itemTypes.Select(it => it.Id)) &&
				query.SocketFrom == socketFrom &&
				query.SocketTo == socketTo &&
				query.MaxLevel == level;
		}

		public static IEnumerable<Action<GetRuneWordsQuery.Result>> AsInspectors(this IEnumerable<GetRuneWordsQuery.Result> runeWords)
		{
			foreach (var runeWord in runeWords)
			{
				yield return rw =>
				{
					Assert.Equal(runeWord.Id, rw.Id);
					Assert.Equal(runeWord.Name, rw.Name);
					Assert.Equal(runeWord.Level, rw.Level);
					Assert.Equal(runeWord.Url, rw.Url);
				};
			}
		}
	}
}
