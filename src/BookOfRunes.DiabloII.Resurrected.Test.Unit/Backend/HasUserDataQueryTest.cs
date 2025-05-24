using AutoBogus;
using Bogus;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Infrastructure.Entities;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.Extensions;
using Xunit;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.Backend
{
	public partial class UserDataPerformersTest
	{
		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][HUD-001]: User has Data")]
		public async Task HasUserDataQuery_PerformAsync_UserHasData()
		{
			// Arrange
			var sut = CreateSUT();
			var user = new Faker().Internet.Email();

			await _context.InsertAsync([new UserEntity { Id = user }]);

			_userContextMock.SetupGet(uc => uc.Id).Returns(user);

			// Act
			var result = await sut.PerformAsync(new AutoFaker<HasUserDataQuery>().Generate(), default);

			// Assert
			Assert.True(result);
		}
		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][HUD-002]: User does not have Data")]
		public async Task HasUserDataQuery_PerformAsync_UserDoesNotHaveData()
		{
			// Arrange
			var sut = CreateSUT();
			var user = new Faker().Internet.Email();

			_userContextMock.SetupGet(uc => uc.Id).Returns(user);

			// Act
			var result = await sut.PerformAsync(new AutoFaker<HasUserDataQuery>().Generate(), default);

			// Assert
			Assert.False(result);
		}
	}
}
