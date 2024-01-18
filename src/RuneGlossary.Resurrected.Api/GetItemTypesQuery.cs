using STrain;

namespace RuneGlossary.Resurrected.Api
{
    public enum ItemClass
    {
        Armor,
        Weapon
    }

    public record GetItemTypesQuery : Query<IEnumerable<GetItemTypesQuery.Result>>
    {
        public record Result
        {
            public int Id { get; }
            public ItemClass Class { get; }
            public string Name { get; }

            public Result(int id, ItemClass @class, string name)
            {
                Id = id;
                Class = @class;
                Name = name;
            }
        }
    }
}
