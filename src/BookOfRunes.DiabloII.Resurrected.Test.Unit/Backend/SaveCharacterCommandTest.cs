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
		[Theory(DisplayName = "[UNIT][SCC-001] - Name is empty")]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("   ")]
		public async Task SaveCharacterCommand_ValidateAsync_NameIsEmpty(string? name)
		{
			// Arrange
			var sut = new SaveCharacterCommandValidator();

			// Act
			var result = await sut.ValidateAsync(new AutoFaker<SaveCharacterCommand>().RuleFor(c => c.Name, name).Generate(), default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Theory(DisplayName = "[UNIT][SCC-002] - Level is invalid")]
		[InlineData(0)]
		[InlineData(-1)]
		[InlineData(100)]
		[InlineData(1000)]
		public async Task SaveCharacterCommand_ValidateAsync_LevelIsInvalid(int level)
		{
			// Arrange
			var sut = new SaveCharacterCommandValidator();

			// Act
			var result = await sut.ValidateAsync(new AutoFaker<SaveCharacterCommand>().RuleFor(c => c.Level, level).Generate(), default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Theory(DisplayName = "[UNIT][SCC-003] - Valid Command")]
		[InlineData(1)]
		[InlineData(99)]
		[InlineData(52)]
		public async Task SaveCharacterCommand_ValidateAsync_ValidCommand(int level)
		{
			// Arrange
			var sut = new SaveCharacterCommandValidator();

			// Act
			var result = await sut.ValidateAsync(new AutoFaker<SaveCharacterCommand>().RuleFor(c => c.Level, level).Generate(), default);

			// Assert
			Assert.True(result.IsValid);
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][SCC-004] - Save Character")]
		public async Task SaveCharacterCommand_PerformAsync_SaveCharacter()
		{
			// Arrange
			var sut = CreateSUT();
			var user = new AutoFaker<UserEntity>().Generate();
			var classes = new AutoFaker<ClassEntity>().Generate(3);
			var command = new AutoFaker<SaveCharacterCommand>().RuleFor(c => c.Class, f => f.PickRandom(classes).Id).Generate();

			await _context.InsertAsync([user]);
			await _context.InsertAsync(classes);

			_userContextMock.SetupGet(uc => uc.Id).Returns(user.Id);

			// Act
			await sut.PerformAsync(command, default);

			// Assert
			await using var context = new DatabaseContext(_context);
			Assert.NotNull(await context.Characters.SingleOrDefaultAsync(c => c.User.Id == user.Id &&
																			c.Name == command.Name &&
																			c.Class.Id == command.Class &&
																			c.Level == command.Level));
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][SCC-005] - User does not Found")]
		public async Task SaveCharacterCommand_PerformAsync_UserDoesNotFound()
		{
			// Arrange
			var sut = CreateSUT();

			_userContextMock.SetupGet(uc => uc.Id).Returns(new Faker().Internet.Email());

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () => await sut.PerformAsync(new AutoFaker<SaveCharacterCommand>().Generate(), default));
		}

		[Trait("FeatureTitle", "UD - User Data")]
		[Fact(DisplayName = "[UNIT][SCC-006] - Class does not Found")]
		public async Task SaveCharacterCommand_PerformAsync_ClassDoesNotFound()
		{
			// Arrange
			var sut = CreateSUT();
			var user = new AutoFaker<UserEntity>().Generate();

			await _context.InsertAsync([user]);

			_userContextMock.SetupGet(uc => uc.Id).Returns(user.Id);

			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(async () => await sut.PerformAsync(new AutoFaker<SaveCharacterCommand>().Generate(), default));
		}
	}
}
