using AutoBogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using RuneDex.DiabloII.Resurrected.Api;
using RuneDex.DiabloII.Resurrected.Application.Performers;
using RuneDex.DiabloII.Resurrected.Infrastructure;
using RuneDex.DiabloII.Resurrected.Infrastructure.Entities;
using RuneDex.DiabloII.Resurrected.Test.Unit.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace RuneDex.DiabloII.Resurrected.Test.Unit.Backend
{
	public class RunePerformersTest
	{
		private readonly ILogger<RunePerformers> _logger;
		private DbContextOptions<DatabaseContext> _context = null!;

		public RunePerformersTest(ITestOutputHelper outputHelper)
		{
			_logger = new LoggerFactory()
						  .AddXUnit(outputHelper)
			.CreateLogger<RunePerformers>();
		}

		private RunePerformers CreateSUT()
		{
			_context = new DbContextOptionsBuilder<DatabaseContext>()
								.UseInMemoryDatabase(nameof(RunePerformers))
								.ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning))
								.Options;

			return new RunePerformers(new DatabaseContext(_context), _logger);
		}

		[Fact(DisplayName = "[UNIT][RNP-001] - Get Runes")]
		[Trait("Feature", "RN - Runes")]
		public async Task RunePerformers_PerformerAsync_GetRunes()
		{
			// Arrange
			var sut = CreateSUT();
			var runes = new AutoFaker<GetRunesQuery.Rune>().GenerateBetween(1, 5);

			await _context.InsertAsync(runes.AsEntity());

			// Act
			var result = await sut.PerformAsync(new GetRunesQuery(), default);

			// Assert
			Assert.Collection(result, [.. runes.AsInspectors()]);
		}
	}

	file static class RunePerformersTestExtensions
	{
		public static IEnumerable<RuneEntity> AsEntity(this IEnumerable<GetRunesQuery.Rune> runes)
		{
			return runes.Select(r => new RuneEntity
			{
				Id = r.Id,
				Name = r.Name,
				Level = r.Level,
				InBodyArmor = r.InBodyArmor,
				InHelmet = r.InHelmet,
				InShield = r.InShield,
				InWeapon = r.InWeapon
			});
		}

		public static IEnumerable<Action<GetRunesQuery.Rune>> AsInspectors(this IEnumerable<GetRunesQuery.Rune> runes)
		{
			foreach (var rune in runes)
			{
				yield return (r) =>
				{
					Assert.Equal(rune.Id, r.Id);
					Assert.Equal(rune.Name, r.Name);
					Assert.Equal(rune.Level, r.Level);
					Assert.Equal(rune.InHelmet, r.InHelmet);
					Assert.Equal(rune.InWeapon, r.InWeapon);
					Assert.Equal(rune.InBodyArmor, r.InBodyArmor);
					Assert.Equal(rune.InShield, r.InShield);
				};
			}
		}
	}
}
