using RuneGlossary.Resurrected.Api;

namespace RuneGlossary.Resurrected.Infrastructure.Entities
{
    public record ItemTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemClass Class { get; set; }


        public ICollection<RuneWordEntity> RuneWords { get; set; }
        public ICollection<RuneWordItemTypeSwitchEntity> ItemTypeSwitch { get; set; }
    }
}
