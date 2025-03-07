using BookOfRunes.DiabloII.Resurrected.Api;
using BookOfRunes.DiabloII.Resurrected.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using STrain;

namespace BookOfRunes.DiabloII.Resurrected.Application.Performers
{
	public class ClassPerformers : IQueryPerformer<GetClassesQuery, IEnumerable<GetClassesQuery.Class>>
	{
		private readonly DatabaseContext _context;
		private readonly ILogger<ClassPerformers> _logger;

		public ClassPerformers(DatabaseContext context, ILogger<ClassPerformers> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IEnumerable<GetClassesQuery.Class>> PerformAsync(GetClassesQuery query, CancellationToken cancellationToken)
		{
			_logger.LogDebug("Querying classes");
			return (await _context.Classes.ToListAsync(cancellationToken))
						.Select(c => new GetClassesQuery.Class(c.Id, c.Name));
		}
	}
}
