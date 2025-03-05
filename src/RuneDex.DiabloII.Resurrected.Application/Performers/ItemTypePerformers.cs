using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RuneDex.DiabloII.Resurrected.Api;
using RuneDex.DiabloII.Resurrected.Infrastructure;
using STrain;

namespace RuneDex.DiabloII.Resurrected.Application.Performers
{
	public class ItemTypePerformers : IQueryPerformer<GetItemTypesQuery, IEnumerable<GetItemTypesQuery.Result>>
	{
		private readonly DatabaseContext _context;
		private readonly ILogger<ItemTypePerformers> _logger;

		public ItemTypePerformers(DatabaseContext context, ILogger<ItemTypePerformers> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IEnumerable<GetItemTypesQuery.Result>> PerformAsync(GetItemTypesQuery query, CancellationToken cancellationToken)
		{
			_logger.LogDebug("Querying item types");
			return (await _context.ItemTypes.ToListAsync(cancellationToken))
				.Select(it => new GetItemTypesQuery.Result { Id = it.Id, Class = it.Class, Name = it.Name });
		}
	}
}
