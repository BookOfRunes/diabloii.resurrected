using RuneGlossary.Resurrected.Api;
using Xunit;

namespace RuneGlossary.Resurrected.Test.Unit
{
	public class GetRuneWordsQueryValidatorTest
	{
		private GetRuneWordsQueryValidator CreateSUT()
		{
			return new GetRuneWordsQueryValidator();
		}

		[Fact(DisplayName = "[UNIT][GRWQV-001] - Empty item types")]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_EmptyItemTypes()
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(Enumerable.Empty<int>(), 1, 1, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-002] - Max level is 0 or above")]
		[InlineData(0)]
		[InlineData(-100)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_MaxLevelIsZeroOrAbove(int level)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, 1, 1, level);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-003] - Max level is more than 99")]
		[InlineData(100)]
		[InlineData(100000)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_MaxLevelIsMoreThan(int level)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, 1, 1, level);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-004] - Max level is between 1 and 99")]
		[InlineData(1)]
		[InlineData(99)]
		[InlineData(50)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_MaxLevelIsInRange(int level)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, 1, 1, level);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.True(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-005] - SocketFrom is 0 or above")]
		[InlineData(0)]
		[InlineData(-100)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_SocketFromIsZeroOrAbove(int socketFrom)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, socketFrom, 1, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-006] - SocketFrom is more than 6")]
		[InlineData(7)]
		[InlineData(100)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_SocketFromIsMoreThanSix(int socketFrom)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, socketFrom, 1, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Fact(DisplayName = "[UNIT][GRWQV-007] - SocketFrom is less than SocketTo")]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_SocketFromIsLessThanSocketTo()
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, 2, 1, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-008] - SocketFrom is in range")]
		[InlineData(1)]
		[InlineData(6)]
		[InlineData(3)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_SocketFromIsInRange(int socketFrom)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, socketFrom, 6, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.True(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-009] - SocketTo is 0 or above")]
		[InlineData(0)]
		[InlineData(-100)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_SocketToIsZeroOrAbove(int socketTo)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, 1, socketTo, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-010] - SocketTo is more than 6")]
		[InlineData(7)]
		[InlineData(100)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_SocketToIsMoreThanSix(int socketTo)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, 1, socketTo, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.False(result.IsValid);
		}

		[Theory(DisplayName = "[UNIT][GRWQV-011] - SocketTo is in range")]
		[InlineData(1)]
		[InlineData(6)]
		[InlineData(3)]
		public async Task GetRuneWordsQueryValidator_ValidateAsync_SocketToIsInRange(int socketTo)
		{
			// Arrange
			var sut = CreateSUT();
			var query = new GetRuneWordsQuery(new List<int> { 1 }, 1, socketTo, 1);

			// Act
			var result = await sut.ValidateAsync(query, default);

			// Assert
			Assert.True(result.IsValid);
		}
	}
}
