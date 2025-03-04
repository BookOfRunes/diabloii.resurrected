using AutoBogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Application.Performers;
using RuneGlossary.Resurrected.Infrastructure;
using RuneGlossary.Resurrected.Infrastructure.Entities;
using Xunit;
using Xunit.Abstractions;

namespace RuneGlossary.Resurrected.Test.Unit.Backend
{
    public class ItemTypePerformersTest
    {
        private DbContextOptions<DatabaseContext> _context = null!;
        private readonly ILogger<ItemTypePerformers> _logger;

        public ItemTypePerformersTest(ITestOutputHelper outputHelper)
        {
            _logger = new LoggerFactory()
                          .AddXUnit(outputHelper)
                          .CreateLogger<ItemTypePerformers>();
        }

        private ItemTypePerformers CreateSUT()
        {
            _context = new DbContextOptionsBuilder<DatabaseContext>()
                                .UseInMemoryDatabase(nameof(ItemTypePerformersTest))
                                .ConfigureWarnings(builder => builder.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                .Options;

            return new ItemTypePerformers(new DatabaseContext(_context), _logger);
        }

        [Fact(DisplayName = "[UNIT][ITP-001] - Get Item Types")]
        [Trait("Feature", "IT - Item Types")]
        public async Task ItemTypePerformers_PerformAsync_GetItemTypes()
        {
            // Arrange
            var sut = CreateSUT();
            var itemTypes = new AutoFaker<GetItemTypesQuery.Result>().GenerateBetween(1, 5);

            await _context.InsertAsync(itemTypes.AsEntity());

            // Act
            var result = await sut.PerformAsync(new GetItemTypesQuery(), default);

            // Assert
            Assert.Collection(result, [.. itemTypes.AsInspectors()]);
        }
    }

    public static class ItemTypePerformersTestExtensions
    {
        public static IEnumerable<ItemTypeEntity> AsEntity(this IEnumerable<GetItemTypesQuery.Result> itemTypes)
        {
            return itemTypes.Select(it => new ItemTypeEntity
            {
                Id = it.Id,
                Class = it.Class,
                Name = it.Name,
                RuneWords = [],
                ItemTypeSwitch = []
            });
        }

        public static IEnumerable<Action<GetItemTypesQuery.Result>> AsInspectors(this IEnumerable<GetItemTypesQuery.Result> itemTypes)
        {
            foreach (var itemType in itemTypes)
            {
                yield return it =>
                {
                    Assert.Equal(itemType.Id, it.Id);
                    Assert.Equal(itemType.Name, it.Name);
                    Assert.Equal(itemType.Class, it.Class);
                };
            }
        }
    }
}
