using STrain;
using static BookOfRunes.DiabloII.Resurrected.Api.GetClassesQuery;

namespace BookOfRunes.DiabloII.Resurrected.Api
{
	public record GetClassesQuery : Query<IEnumerable<@Class>>
	{
		public record @Class
		{
			public int Id { get; }
			public string Name { get; }

			public Class(int id, string name)
			{
				Id = id;
				Name = name;
			}
		}
	}
}
