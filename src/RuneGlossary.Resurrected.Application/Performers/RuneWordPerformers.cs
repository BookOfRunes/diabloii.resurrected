using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Infrastructure;
using RuneGlossary.Resurrected.Infrastructure.Entities;
using STrain;

namespace RuneGlossary.Resurrected.Application.Performers
{
    public class RuneWordPerformers : IQueryPerformer<GetRuneWordsQuery, IEnumerable<GetRuneWordsQuery.Result>>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<RuneWordPerformers> _logger;

        public RuneWordPerformers(DatabaseContext context, ILogger<RuneWordPerformers> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<GetRuneWordsQuery.Result>> PerformAsync(GetRuneWordsQuery query, CancellationToken cancellationToken)
        {
            var runeWords = await _context.RuneWords
                                                .Include(rw => rw.RuneSwitch)
                                                .ThenInclude(s => s.Rune)
                                                .Include(rw => rw.ItemTypeSwitch)
                                                .ThenInclude(s => s.ItemType)
                                                .Include(rw => rw.Statistics)
                                                .ThenInclude(s => s.Skill)
                                                .Where(rw => rw.ItemTypes.Any(it => query.ItemTypes.Contains(it.Id))
                                                            && (rw.RuneSwitch.Count >= query.SocketFrom && rw.RuneSwitch.Count <= query.SocketTo)
                                                            && rw.Level <= query.MaxLevel)
                                            .ToListAsync(cancellationToken);

            return runeWords.AsResult();
        }
    }

    internal static class RuneWordPerformersExtensions
    {
        public static IEnumerable<GetRuneWordsQuery.Result> AsResult(this IEnumerable<RuneWordEntity> entities)
        {
            return entities.Select(e => e.AsResult());
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
                                                 entity.Statistics.Select(s => new GetRuneWordsQuery.Result.Statistic(s.Id, s.Description, s.Skill is not null ? new GetRuneWordsQuery.Result.Skill(s.Skill.Id, s.Skill.Name, s.Skill.Description, s.Skill.Url) : null)));
        }
    }
}
