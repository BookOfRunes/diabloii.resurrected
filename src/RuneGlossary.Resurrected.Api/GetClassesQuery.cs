using STrain;
using static RuneGlossary.Resurrected.Api.GetClassesQuery;

namespace RuneGlossary.Resurrected.Api
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
