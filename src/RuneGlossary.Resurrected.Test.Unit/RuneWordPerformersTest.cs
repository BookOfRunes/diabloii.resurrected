using AutoFixture;
using AutoFixture.Dsl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Application.Performers;
using RuneGlossary.Resurrected.Infrastructure;
using RuneGlossary.Resurrected.Infrastructure.Entities;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace RuneGlossary.Resurrected.Test.Unit
{
    public class RuneWordPerformersTest : IDisposable
    {

        private readonly ILogger<RuneWordPerformers> _logger;
        private DatabaseContext _context;

        public RuneWordPerformersTest(ITestOutputHelper outputHelper)
        {
            _logger = new LoggerFactory()
                          .AddXUnit(outputHelper)
                          .CreateLogger<RuneWordPerformers>();
        }

        private RuneWordPerformers CreateSUT()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                                .UseInMemoryDatabase(nameof(RuneWordPerformersTest))
                                .ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                .Options;

            _context = new DatabaseContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            return new RuneWordPerformers(_context, _logger);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact(DisplayName = "[UNIT][GRWQ-001] - Get rune word information")]
        public async Task RuneWordPerformers_GetRuneWordsQuery_GetInformation()
        {
            // Arrange
            var sut = CreateSUT();
            var socket = new Fixture().Create<int>();

            var runeWord = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes)
                                                                                    .With(rw => rw.Level, 1))
                            .GenerateRunes()
                            .GenerateItemTypes()
                            .GenerateStatistics();

            await _context.InsertAsnyc(runeWord, TimeSpan.FromSeconds(1));

            // Act
            var result = await sut.PerformAsync(new GetRuneWordsQuery(runeWord.ItemTypes.Select(it => it.Id), 1, 1, 99), default);

            // Assert
            Assert.Equal(runeWord.AsResult(), result.First(), new GetRuneWordsQueryResultEqualityComparer());
        }

        [Fact(DisplayName = "[UNIT][GRWQ-002] - Filter by item type")]
        public async Task RuneWordPerformers_GetRuneWordsQuery_FilterByItemType()
        {
            // Arrange
            var sut = CreateSUT();

            var runeWord = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes)
                                                                                    .With(rw => rw.Level, 1))
                            .GenerateRunes()
                            .GenerateItemTypes()
                            .GenerateStatistics();
            var runeWordFiltered = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes)
                                                                                    .With(rw => rw.Level, 1))
                            .GenerateRunes()
                            .GenerateItemTypes()
                            .GenerateStatistics();

            await _context.InsertRangeAsync(new List<RuneWordEntity> { runeWord, runeWordFiltered }, TimeSpan.FromSeconds(1));

            // Act
            var result = await sut.PerformAsync(new GetRuneWordsQuery(new List<int> { runeWord.ItemTypes.First().Id }, 1, 1, 99), default);

            // Assert
            Assert.Collection(result, rw => Assert.Equal(runeWord.Id, rw.Id));
        }

        [Fact(DisplayName = "[UNIT][GRWQ-002] - Filter by socket number")]
        public async Task RuneWordPerformers_GetRuneWordsQuery_SocketNumber()
        {
            // Arrange
            var sut = CreateSUT();

            var runeWord = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes)
                                                                                    .With(rw => rw.Level, 1))
                            .GenerateRunes()
                            .GenerateItemTypes()
                            .GenerateStatistics();
            var runeWordFiltered = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes)
                                                                                    .With(rw => rw.Level, 1))
                            .GenerateRunes(3)
                            .GenerateItemTypes()
                            .GenerateStatistics();

            await _context.InsertRangeAsync(new List<RuneWordEntity> { runeWord, runeWordFiltered }, TimeSpan.FromSeconds(1));

            // Act
            var result = await sut.PerformAsync(new GetRuneWordsQuery(runeWord.ItemTypeSwitch.Select(it => it.ItemType.Id).Concat(runeWordFiltered.ItemTypeSwitch.Select(it => it.ItemType.Id)), runeWord.RuneSwitch.Count, runeWord.RuneSwitch.Count, 99), default);

            // Assert
            Assert.Collection(result, rw => Assert.Equal(runeWord.Id, rw.Id));
        }

        [Fact(DisplayName = "[UNIT][GRWQ-003] - Filter by level")]
        public async Task RuneWordPerformers_GetRuneWordsQuery_ByLevel()
        {
            // Arrange
            var sut = CreateSUT();

            var runeWord = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes)
                                                                                    .With(rw => rw.Level, 1))
                            .GenerateRunes()
                            .GenerateItemTypes()
                            .GenerateStatistics();
            var runeWordFiltered = TestHelper.Generate<RuneWordEntity>(composer => composer
                                                                                    .Without(rw => rw.RuneSwitch)
                                                                                    .Without(rw => rw.Runes)
                                                                                    .Without(rw => rw.Statistics)
                                                                                    .Without(rw => rw.ItemTypeSwitch)
                                                                                    .Without(rw => rw.ItemTypes)
                                                                                    .With(rw => rw.Level, 2))
                            .GenerateRunes()
                            .GenerateItemTypes()
                            .GenerateStatistics();

            await _context.InsertRangeAsync(new List<RuneWordEntity> { runeWord, runeWordFiltered }, TimeSpan.FromSeconds(1));

            // Act
            var result = await sut.PerformAsync(new GetRuneWordsQuery(runeWord.ItemTypeSwitch.Select(it => it.ItemType.Id).Concat(runeWordFiltered.ItemTypeSwitch.Select(it => it.ItemType.Id)), runeWord.RuneSwitch.Count, runeWord.RuneSwitch.Count, 1), default);

            // Assert
            Assert.Collection(result, rw => Assert.Equal(runeWord.Id, rw.Id));
        }
    }

    internal static class RuneWordPerformersTestExtensions
    {
        public static async Task InsertRangeAsync<TEntity>(this DatabaseContext context, IEnumerable<TEntity> entities, TimeSpan timeout)
        {
            using var cancellationTokenSource = new CancellationTokenSource(timeout);
            foreach (var entity in entities)
            {
                await context.AddAsync(entity!, cancellationTokenSource.Token);

            }
            await context.SaveChangesAsync(cancellationTokenSource.Token);
        }

        public static async Task InsertAsnyc<TEntity>(this DatabaseContext context, TEntity entity, TimeSpan timeout)
        {
            using var cancellationTokenSource = new CancellationTokenSource(timeout);
            await context.AddAsync(entity!, cancellationTokenSource.Token);
            await context.SaveChangesAsync(cancellationTokenSource.Token);
        }

        public static GetRuneWordsQuery.Result AsResult(this RuneWordEntity entity)
        {
            return new GetRuneWordsQuery.Result(entity.Id,
                                                 entity.Name,
                                                 entity.Level,
                                                 entity.Url,
                                                 entity.RuneSwitch.Select(rs => new GetRuneWordsQuery.Result.Rune(rs.Rune.Id,
                                                                                                                    rs.Rune.Name,
                                                                                                                   rs.Order,
                                                                                                                   rs.Rune.Level,
                                                                                                                   rs.Rune.InHelmet,
                                                                                                                   rs.Rune.InBodyArmor,
                                                                                                                   rs.Rune.InShield,
                                                                                                                   rs.Rune.InWeapon)),
                                                 entity.ItemTypeSwitch.Select(it => new GetRuneWordsQuery.Result.ItemType(it.ItemType.Id, it.ItemType.Class, it.ItemType.Name)),
                                                 entity.Statistics.Select(s => new GetRuneWordsQuery.Result.Statistic(s.Id, s.Description, new GetRuneWordsQuery.Result.Skill(s.Skill!.Id, s.Skill.Name, s.Skill.Description, s.Skill.Url))));
        }

        public static RuneWordEntity GenerateRunes(this RuneWordEntity entity, int count = 1)
        {
            var runes = new List<RuneEntity>();

            for (var i = 0; i < count; i++)
            {
                runes.Add(TestHelper.Generate<RuneEntity>(composer => composer
                                                                        .With(r => r.RuneWords, new List<RuneWordEntity> { entity })
                                                                        .With(r => r.RuneWordSwitch, new List<RuneRuneWordSwitchEntity>
                                                                                                                            {
                                                                                                                                TestHelper.Generate<RuneRuneWordSwitchEntity>(composer => composer
                                                                                                                                                                                                    .With(r => r.RuneWord, entity)
                                                                                                                                                                                                    .With(r => r.Rune, TestHelper.Generate<RuneEntity>(composer => composer.Without(r => r.RuneWords).Without(r => r.RuneWordSwitch))))
                                                                                                                            })));
            }

            entity.Runes = runes;
            return entity;
        }

        public static RuneWordEntity GenerateItemTypes(this RuneWordEntity entity)
        {
            entity.ItemTypes = new List<ItemTypeEntity>
            {
                TestHelper.Generate<ItemTypeEntity>(composer => composer
                                                                            .With(it => it.RuneWords, new List<RuneWordEntity>{ entity})
                                                                            .With(it => it.ItemTypeSwitch, new List<RuneWordItemTypeSwitchEntity>
                                                                                                                                    {
                                                                                                                                        TestHelper.Generate<RuneWordItemTypeSwitchEntity>(composer => composer
                                                                                                                                                                                                                .With(r => r.RuneWord, entity)
                                                                                                                                                                                                                .With(r => r.ItemType, TestHelper.Generate<ItemTypeEntity>(composer => composer.Without(it => it.RuneWords).Without(it => it.ItemTypeSwitch))))
                                                                                                                                    }))
            };
            return entity;
        }

        public static RuneWordEntity GenerateStatistics(this RuneWordEntity entity)
        {
            entity.Statistics = TestHelper.GenerateMany<StatisticEntity>().ToList();
            return entity;
        }
    }

    internal static class TestHelper
    {
        public static IEnumerable<T> GenerateMany<T>()
        {
            return new Fixture().CreateMany<T>();
        }

        public static T Generate<T>()
        {
            return new Fixture().Create<T>();
        }

        public static T Generate<T>(Func<ICustomizationComposer<T>, IPostprocessComposer<T>> compose)
        {
            return compose(new Fixture().Build<T>()).Create();
        }
    }

    internal class GetRuneWordsQueryResultEqualityComparer : IEqualityComparer<GetRuneWordsQuery.Result>
    {
        public bool Equals(GetRuneWordsQuery.Result? x, GetRuneWordsQuery.Result? y)
        {
            return x.Id == y.Id
                && x.Name.Equals(y.Name)
                && x.Level == y.Level
                && y.Url.Equals(y.Url)
                && x.Runes.SequenceEqual(y.Runes)
                && x.ItemTypes.SequenceEqual(y.ItemTypes)
                && x.Statistics.SequenceEqual(y.Statistics);
        }

        public int GetHashCode([DisallowNull] GetRuneWordsQuery.Result obj)
        {
            return obj.GetHashCode();
        }
    }
}
