using RuneDex.DiabloII.Resurrected.Api;

namespace RuneDex.DiabloII.Resurrected.Infrastructure.Entities
{
	public record ItemTypeEntity
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public ItemClass Class { get; set; }

		public required ICollection<RuneWordEntity> RuneWords { get; set; }
		public required ICollection<RuneWordItemTypeSwitchEntity> ItemTypeSwitch { get; set; }
	}
}
