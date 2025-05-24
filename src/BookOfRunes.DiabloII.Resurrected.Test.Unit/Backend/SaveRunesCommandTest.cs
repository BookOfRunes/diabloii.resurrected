using AutoBogus;
using Bogus;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Infrastructure;
using BookOfRunes.DiabloII.Resurrected.Infrastructure.Entities;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.Extensions;
using Microsoft.EntityFrameworkCore;
using STrain.Core.Exceptions;
using Xunit;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.Backend
{
	public partial class UserDataPerformersTest
	{
		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][SRC-001] - Save Runes")]
		public async Task SaveRunesCommand_PerformAsync_SaveRunes()
		{
			// Arrange
			var sut = CreateSUT();
			var user = new AutoFaker<UserEntity>().Generate();
			var runes = new AutoFaker<RuneEntity>().Ignore(e => e.RuneWords).Ignore(e => e.RuneWordSwitch).Generate(10);
			IEnumerable<int> userRunes = [new Faker().PickRandom(runes).Id, new Faker().PickRandom(runes).Id];

			await _context.InsertAsync([user]);
			await _context.InsertAsync(runes);

			_userContextMock.SetupGet(uc => uc.Id).Returns(user.Id);

			// Act
			await sut.PerformAsync(new AutoFaker<SaveRunesCommand>().RuleFor(c => c.Runes, f => userRunes).Generate(), default);

			// Assert
			await using var context = new DatabaseContext(_context);
			await Assert.CollectionAsync(await context.UserRunes.Include(ur => ur.Rune).Where(e => e.User.Id == user.Id).ToListAsync(), [.. userRunes.Inspect()]);
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][SRC-002] - User does not Found")]
		public async Task SaveRunesCommand_PerformAsync_UserDoesNotFound()
		{
			// Arrange
			var sut = CreateSUT();

			_userContextMock.SetupGet(uc => uc.Id).Returns(new Faker().Internet.Email());

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () => await sut.PerformAsync(new AutoFaker<SaveRunesCommand>().Generate(), default));
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][SRC-003] - Rune does not Found")]
		public async Task SaveRunesCommand_PerformAsync_RuneDoesNotFound()
		{
			// Arrange
			var sut = CreateSUT();
			var user = new AutoFaker<UserEntity>().Generate();

			_userContextMock.SetupGet(uc => uc.Id).Returns(user.Id);

			await _context.InsertAsync([user]);

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () => await sut.PerformAsync(new AutoFaker<SaveRunesCommand>().Generate(), default));
		}
	}

	file static class SaveRunesCommandExtensions
	{
		public static IEnumerable<Func<UserRuneEntity, Task>> Inspect(this IEnumerable<int> expected)
		{
			foreach (var item in expected)
			{
				yield return data =>
				{
					Assert.Equal(data.Rune.Id, item);
					return Task.CompletedTask;
				};
			}
		}
	}
}
