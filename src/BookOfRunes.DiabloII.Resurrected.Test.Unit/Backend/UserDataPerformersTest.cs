using BookOfRunes.DiabloII.Resurrected.Application.Contexts;
using BookOfRunes.DiabloII.Resurrected.Application.Performers;
using BookOfRunes.DiabloII.Resurrected.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.Backend
{
	public partial class UserDataPerformersTest
	{
		private DbContextOptions<DatabaseContext> _context = null!;
		private Mock<IUserContext> _userContextMock = null;
		private readonly ILogger<UserDataPerformers> _logger;

		public UserDataPerformersTest(ITestOutputHelper outputHelper)
		{
			_logger = new LoggerFactory()
						  .AddXUnit(outputHelper)
						  .CreateLogger<UserDataPerformers>();
		}

		private UserDataPerformers CreateSUT()
		{
			_context = new DbContextOptionsBuilder<DatabaseContext>()
								.UseInMemoryDatabase(nameof(UserDataPerformers))
								.ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning))
								.Options;

			_userContextMock = new Mock<IUserContext>();

			return new UserDataPerformers(new DatabaseContext(_context), _userContextMock.Object, _logger);
		}
	}
}
