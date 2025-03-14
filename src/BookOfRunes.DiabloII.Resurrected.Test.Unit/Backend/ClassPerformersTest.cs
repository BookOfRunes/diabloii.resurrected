using AutoBogus;
using Bogus.Extensions;
using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Application.Performers;
using BookOfRunes.DiabloII.Resurrected.Infrastructure;
using BookOfRunes.DiabloII.Resurrected.Infrastructure.Entities;
using BookOfRunes.DiabloII.Resurrected.Test.Unit.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace BookOfRunes.DiabloII.Resurrected.Test.Unit.Backend
{
	public class ClassPerformersTest
	{
		private DbContextOptions<DatabaseContext> _context = null!;
		private readonly ILogger<ClassPerformers> _logger;

		public ClassPerformersTest(ITestOutputHelper outputHelper)
		{
			_logger = new LoggerFactory()
						  .AddXUnit(outputHelper)
						  .CreateLogger<ClassPerformers>();
		}

		private ClassPerformers CreateSUT()
		{
			_context = new DbContextOptionsBuilder<DatabaseContext>()
								.UseInMemoryDatabase(nameof(ClassPerformersTest))
								.ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning))
								.Options;

			return new ClassPerformers(new DatabaseContext(_context), _logger);
		}

		[Fact(DisplayName = "[UNIT][CLP-001] - Get Classes")]
		[Trait("FeatureTitle", "CL - Classes")]
		public async Task ClassPerformers_PerformAsync_GetClasses()
		{
			// Arrange
			var sut = CreateSUT();
			var classes = new AutoFaker<GetClassesQuery.Class>().GenerateBetween(2, 5);

			await _context.InsertAsync(classes.AsEntity());

			// Act
			var result = await sut.PerformAsync(new GetClassesQuery(), default);

			// Assert
			Assert.Collection(result, [.. classes.AsInspectors()]);
		}
	}

	file static class ClassPerformersTestExtensions
	{
		public static IEnumerable<ClassEntity> AsEntity(this IEnumerable<GetClassesQuery.Class> classes)
		{
			return [.. classes.Select(c => new ClassEntity { Id = c.Id, Name = c.Name })];
		}

		public static IEnumerable<Action<GetClassesQuery.Class>> AsInspectors(this IEnumerable<GetClassesQuery.Class> classes)
		{
			foreach (var @class in classes)
			{
				yield return (c) => Assert.Equal(@class, c);
			}
		}
	}
}
