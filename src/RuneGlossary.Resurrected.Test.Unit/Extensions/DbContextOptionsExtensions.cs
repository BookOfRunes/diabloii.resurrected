using RuneGlossary.Resurrected.Infrastructure;

namespace Microsoft.EntityFrameworkCore
{
	internal static class DbContextOptionsExtensions
	{
		public static async Task InsertAsync<T>(this DbContextOptions<DatabaseContext> options, IEnumerable<T> entities)
		{
			await using var context = new DatabaseContext(options);
			foreach (var entity in entities)
			{
				await context.AddAsync(entity!);
			}
			await context.SaveChangesAsync();
		}
	}
}
